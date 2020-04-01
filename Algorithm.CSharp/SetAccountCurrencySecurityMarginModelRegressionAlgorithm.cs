/*
 * QUANTCONNECT.COM - Democratizing Finance, Empowering Individuals.
 * Lean Algorithmic Trading Engine v2.0. Copyright 2014 QuantConnect Corporation.
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
*/

using System;
using System.Collections.Generic;
using System.Linq;
using QuantConnect.Data;
using QuantConnect.Interfaces;
using QuantConnect.Orders;
using QuantConnect.Securities;
using QuantConnect.Statistics;

namespace QuantConnect.Algorithm.CSharp
{
    /// <summary>
    /// Regression test used for testing setting an account currency different than USD
    /// and trading a Security in quote currency different than account currency.
    /// Uses SecurityMarginModel as BuyingPowerModel.
    /// </summary>
    public class SetAccountCurrencySecurityMarginModelRegressionAlgorithm : QCAlgorithm, IRegressionAlgorithmDefinition
    {
        private Security _spy;
        private int _step;
        private decimal _expectedOrderQuantity;
        private decimal _previousHoldingsFees;
        private int _previousClosedTradesCount;
        private decimal _initialCapital;

        /// <summary>
        /// Initialise the data and resolution required, as well as the cash and start-end dates for your algorithm. All algorithms must initialized.
        /// </summary>
        public override void Initialize()
        {
            SetStartDate(2013, 10, 07);  //Set Start Date
            SetEndDate(2013, 10, 15);    //Set End Date
            SetAccountCurrency("EUR");   // Change account currency
            _initialCapital = Portfolio.CashBook["EUR"].Amount;

            _spy = AddEquity("SPY", Resolution.Daily);
            if (!(_spy.BuyingPowerModel is SecurityMarginModel))
            {
                throw new Exception("This regression algorithm is expected to test the SecurityMarginModel");
            }
        }

        /// <summary>
        /// OnData event is the primary entry point for your algorithm. Each new data point will be pumped in here.
        /// </summary>
        /// <param name="data">Slice object keyed by symbol containing the stock data</param>
        public override void OnData(Slice data)
        {
            Log($"OnData(): Current execution step: {_step}");
            switch (_step)
            {
                case 0:
                    _step++;
                    UpdateExpectedOrderQuantity(0.5m);
                    SetHoldings(_spy.Symbol, 0.5);
                    break;
                case 1:
                    _step++;
                    UpdateExpectedOrderQuantity(1);
                    SetHoldings(_spy.Symbol, 1);
                    break;
                case 2:
                    _step++;
                    UpdateExpectedOrderQuantity(0);
                    SetHoldings(_spy.Symbol, 0);
                    break;
                case 3:
                    _step++;
                    UpdateExpectedOrderQuantity(-0.5m);
                    SetHoldings(_spy.Symbol, -0.5);
                    break;
                case 4:
                    _step++;
                    UpdateExpectedOrderQuantity(-1);
                    SetHoldings(_spy.Symbol, -1);
                    break;
                case 5:
                    _step++;
                    UpdateExpectedOrderQuantity(0);
                    SetHoldings(_spy.Symbol, 0);
                    break;
            }
        }

        private void UpdateExpectedOrderQuantity(decimal target)
        {
            _expectedOrderQuantity = ((Portfolio.TotalPortfolioValue - Settings.FreePortfolioValue) * target - _spy.Holdings.HoldingsValue)
                / (_spy.Price * _spy.QuoteCurrency.ConversionRate);
            _expectedOrderQuantity--; // minus 1 per fees
            _expectedOrderQuantity -= _expectedOrderQuantity % _spy.SymbolProperties.LotSize;
            _expectedOrderQuantity = _expectedOrderQuantity.Normalize();
        }

        public override void OnEndOfAlgorithm()
        {
            if (Portfolio.CashBook["EUR"].Amount != _initialCapital)
            {
                throw new Exception($"Unexpected EUR ending cash amount: {Portfolio.CashBook["EUR"].Amount}.");
            }
            var expectedAmount = Portfolio.CashBook.Convert(Portfolio.TotalProfit, "EUR", "USD")
                - Portfolio.CashBook.Convert(Portfolio.TotalFees, "EUR", "USD");
            var amount = Portfolio.CashBook["USD"].Amount;
            // there could be a small difference due to conversion rates
            // leave 1% for error
            if (Math.Abs(expectedAmount - amount) > Math.Abs(expectedAmount) * 0.01m)
            {
                throw new Exception($"Unexpected USD ending cash amount: {amount}. Expected {expectedAmount}");
            }
        }

        public override void OnOrderEvent(OrderEvent orderEvent)
        {
            if (orderEvent.Status == OrderStatus.Filled)
            {
                Log($"OnOrderEvent(): New filled order event: {orderEvent}");
                // leave 1 unit as error in expected value
                if (Math.Abs(orderEvent.FillQuantity - _expectedOrderQuantity) > 1)
                {
                    throw new Exception($"Unexpected order event fill quantity: {orderEvent.FillQuantity}. " +
                        $"Expected {_expectedOrderQuantity}");
                }

                var orderFeeInAccountCurrency = Portfolio.CashBook.ConvertToAccountCurrency(orderEvent.OrderFee.Value).Amount;
                var expectedOrderFee = _spy.Holdings.TotalFees - _previousHoldingsFees;
                if (orderEvent.OrderFee.Value.Currency == AccountCurrency
                    // leave 0.00001m as error in expected fee value
                    || Math.Abs(expectedOrderFee - orderFeeInAccountCurrency) > 0.00001m)
                {
                    throw new Exception($"Unexpected order fee: {orderFeeInAccountCurrency}. " +
                        $"Expected {expectedOrderFee}");
                }

                if (!TradeBuilder.HasOpenPosition(_spy.Symbol))
                {
                    var lastTrade = TradeBuilder.ClosedTrades.Last();

                    var expectedProfitLoss = (lastTrade.ExitPrice - lastTrade.EntryPrice)
                        * lastTrade.Quantity
                        * _spy.QuoteCurrency.ConversionRate
                        * (lastTrade.Direction == TradeDirection.Long ? 1 : -1);

                    if (Math.Abs(expectedProfitLoss - lastTrade.ProfitLoss) > 1)
                    {
                        throw new Exception($"Unexpected last trade ProfitLoss: {lastTrade.ProfitLoss}. " +
                            $"Expected {expectedProfitLoss}");
                    }

                    // There is a difference in what does Holdings and TradeBuilder consider LastTrade
                    if (TradeBuilder.ClosedTrades.Count - _previousClosedTradesCount > 1)
                    {
                        var trade = TradeBuilder.ClosedTrades[_previousClosedTradesCount];
                        expectedProfitLoss += trade.ProfitLoss;
                    }

                    if (Math.Abs(_spy.Holdings.LastTradeProfit - expectedProfitLoss) > 1)
                    {
                        throw new Exception($"Unexpected Holdings.NetProfit: {_spy.Holdings.LastTradeProfit}. " +
                            $"Expected {expectedProfitLoss}");
                    }
                }

                _previousHoldingsFees = _spy.Holdings.TotalFees;
                _previousClosedTradesCount = TradeBuilder.ClosedTrades.Count;
            }
        }

        /// <summary>
        /// This is used by the regression test system to indicate if the open source Lean repository has the required data to run this algorithm.
        /// </summary>
        public bool CanRunLocally { get; } = true;

        /// <summary>
        /// This is used by the regression test system to indicate which languages this algorithm is written in.
        /// </summary>
        public Language[] Languages { get; } = { Language.CSharp };

        /// <summary>
        /// This is used by the regression test system to indicate what the expected statistics are from running the algorithm
        /// </summary>
        public Dictionary<string, string> ExpectedStatistics => new Dictionary<string, string>
        {
            {"Total Trades", "6"},
            {"Average Win", "0.41%"},
            {"Average Loss", "-0.86%"},
            {"Compounding Annual Return", "-16.921%"},
            {"Drawdown", "1.100%"},
            {"Expectancy", "-0.262"},
            {"Net Profit", "-0.458%"},
            {"Sharpe Ratio", "-1.508"},
            {"Probabilistic Sharpe Ratio", "33.867%"},
            {"Loss Rate", "50%"},
            {"Win Rate", "50%"},
            {"Profit-Loss Ratio", "0.48"},
            {"Alpha", "-0.21"},
            {"Beta", "0.106"},
            {"Annual Standard Deviation", "0.087"},
            {"Annual Variance", "0.008"},
            {"Information Ratio", "-4.719"},
            {"Tracking Error", "0.185"},
            {"Treynor Ratio", "-1.241"},
            {"Total Fees", "$12.97"},
            {"Fitness Score", "0.037"},
            {"Kelly Criterion Estimate", "34.943"},
            {"Kelly Criterion Probability Value", "0.228"},
            {"Sortino Ratio", "-3.325"},
            {"Return Over Maximum Drawdown", "-15.116"},
            {"Portfolio Turnover", "0.499"},
            {"Total Insights Generated", "6"},
            {"Total Insights Closed", "5"},
            {"Total Insights Analysis Completed", "5"},
            {"Long Insight Count", "2"},
            {"Short Insight Count", "2"},
            {"Long/Short Ratio", "100%"},
            {"Estimated Monthly Alpha Value", "€13376903.3193"},
            {"Total Accumulated Estimated Alpha Value", "€4105966.1577"},
            {"Mean Population Estimated Insight Value", "€821193.2315"},
            {"Mean Population Direction", "80%"},
            {"Mean Population Magnitude", "0%"},
            {"Rolling Averaged Population Direction", "75.495%"},
            {"Rolling Averaged Population Magnitude", "0%"},
            {"OrderListHash", "-758852935"}
        };
    }
}
