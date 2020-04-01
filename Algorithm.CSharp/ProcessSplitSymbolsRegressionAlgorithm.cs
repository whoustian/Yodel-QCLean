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
using QuantConnect.Data;
using QuantConnect.Interfaces;
using QuantConnect.Securities;

namespace QuantConnect.Algorithm.CSharp
{
    /// <summary>
    /// This test algorithm reproduces GH issue 2848 where an exception is thrown
    /// in the AlgorithmManager.ProcessSplitSymbols when removing the equity having a split
    /// </summary>
    public class ProcessSplitSymbolsRegressionAlgorithm : QCAlgorithm, IRegressionAlgorithmDefinition
    {
        private Security _aapl;
        private Security _goog;

        /// <summary>
        /// Initialise the data and resolution required, as well as the cash and start-end dates for your algorithm. All algorithms must initialized.
        /// </summary>
        public override void Initialize()
        {
            SetStartDate(2014, 06, 05);  //Set Start Date
            SetEndDate(2014, 06, 09);    //Set End Date
            SetCash(100000);             //Set Strategy Cash

            _aapl = AddEquity("AAPL", Resolution.Daily);
            _goog = AddEquity("GOOG", Resolution.Daily);
        }

        /// <summary>
        /// OnData event is the primary entry point for your algorithm. Each new data point will be pumped in here.
        /// </summary>
        /// <param name="data">Slice object keyed by symbol containing the stock data</param>
        public override void OnData(Slice data)
        {
            if (data.Time == new DateTime(2014, 06, 06))
            {
                RemoveSecurity(_aapl.Symbol);
            }
            if (!Portfolio.Invested)
            {
                SetHoldings(_goog.Symbol, 1);
                Debug("Purchased Stock");
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
            {"Total Trades", "1"},
            {"Average Win", "0%"},
            {"Average Loss", "0%"},
            {"Compounding Annual Return", "674.734%"},
            {"Drawdown", "0%"},
            {"Expectancy", "0"},
            {"Net Profit", "2.844%"},
            {"Sharpe Ratio", "50.812"},
            {"Probabilistic Sharpe Ratio", "100%"},
            {"Loss Rate", "0%"},
            {"Win Rate", "0%"},
            {"Profit-Loss Ratio", "0"},
            {"Alpha", "4.198"},
            {"Beta", "1.53"},
            {"Annual Standard Deviation", "0.096"},
            {"Annual Variance", "0.009"},
            {"Information Ratio", "54.898"},
            {"Tracking Error", "0.081"},
            {"Treynor Ratio", "3.186"},
            {"Total Fees", "$1.00"},
            {"Fitness Score", "0.246"},
            {"Kelly Criterion Estimate", "0"},
            {"Kelly Criterion Probability Value", "0"},
            {"Sortino Ratio", "79228162514264337593543950335"},
            {"Return Over Maximum Drawdown", "79228162514264337593543950335"},
            {"Portfolio Turnover", "0.246"},
            {"Total Insights Generated", "1"},
            {"Total Insights Closed", "0"},
            {"Total Insights Analysis Completed", "0"},
            {"Long Insight Count", "1"},
            {"Short Insight Count", "0"},
            {"Long/Short Ratio", "100%"},
            {"Estimated Monthly Alpha Value", "$0"},
            {"Total Accumulated Estimated Alpha Value", "$0"},
            {"Mean Population Estimated Insight Value", "$0"},
            {"Mean Population Direction", "0%"},
            {"Mean Population Magnitude", "0%"},
            {"Rolling Averaged Population Direction", "0%"},
            {"Rolling Averaged Population Magnitude", "0%"},
            {"OrderListHash", "-2145299952"}
        };
    }
}
