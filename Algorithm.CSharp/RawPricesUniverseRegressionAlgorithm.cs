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

using QuantConnect.Data.UniverseSelection;
using QuantConnect.Interfaces;
using QuantConnect.Orders.Fees;
using System;
using System.Collections.Generic;

namespace QuantConnect.Algorithm.CSharp
{
    /// <summary>
    /// In this algorithm we demonstrate how to use the UniverseSettings
    /// to define the data normalization mode (raw)
    /// </summary>
    /// <meta name="tag" content="using data" />
    /// <meta name="tag" content="universes" />
    /// <meta name="tag" content="coarse universes" />
    /// <meta name="tag" content="regression test" />
    public class RawPricesUniverseRegressionAlgorithm : QCAlgorithm, IRegressionAlgorithmDefinition
    {
        public override void Initialize()
        {
            // what resolution should the data *added* to the universe be?
            UniverseSettings.Resolution = Resolution.Daily;

            // Use raw prices
            UniverseSettings.DataNormalizationMode = DataNormalizationMode.Raw;

            SetStartDate(2014,3,24);
            SetEndDate(2014,4,7);
            SetCash(50000);

            // Set the security initializer with zero fees
            SetSecurityInitializer(x => x.SetFeeModel(new ConstantFeeModel(0)));

            AddUniverse("MyUniverse", Resolution.Daily, SelectionFunction);
        }

        public IEnumerable<string> SelectionFunction(DateTime dateTime)
        {
            return dateTime.Day % 2 == 0
                ? new[] { "SPY", "IWM", "QQQ" }
                : new[] { "AIG", "BAC", "IBM" };
        }

        // this event fires whenever we have changes to our universe
        public override void OnSecuritiesChanged(SecurityChanges changes)
        {
            foreach (var security in changes.RemovedSecurities)
            {
                if (security.Invested)
                {
                    Liquidate(security.Symbol);
                }
            }

            // we want 20% allocation in each security in our universe
            foreach (var security in changes.AddedSecurities)
            {
                SetHoldings(security.Symbol, 0.2m);
            }
        }

        /// <summary>
        /// This is used by the regression test system to indicate if the open source Lean repository has the required data to run this algorithm.
        /// </summary>
        public bool CanRunLocally { get; } = true;

        /// <summary>
        /// This is used by the regression test system to indicate which languages this algorithm is written in.
        /// </summary>
        public Language[] Languages { get; } = { Language.CSharp, Language.Python };

        /// <summary>
        /// This is used by the regression test system to indicate what the expected statistics are from running the algorithm
        /// </summary>
        public Dictionary<string, string> ExpectedStatistics => new Dictionary<string, string>
        {
            {"Total Trades", "27"},
            {"Average Win", "0.21%"},
            {"Average Loss", "-0.21%"},
            {"Compounding Annual Return", "-7.431%"},
            {"Drawdown", "0.800%"},
            {"Expectancy", "0.003"},
            {"Net Profit", "-0.317%"},
            {"Sharpe Ratio", "-1.316"},
            {"Probabilistic Sharpe Ratio", "28.828%"},
            {"Loss Rate", "50%"},
            {"Win Rate", "50%"},
            {"Profit-Loss Ratio", "1.01"},
            {"Alpha", "-0.058"},
            {"Beta", "0.005"},
            {"Annual Standard Deviation", "0.045"},
            {"Annual Variance", "0.002"},
            {"Information Ratio", "0.414"},
            {"Tracking Error", "0.111"},
            {"Treynor Ratio", "-12.203"},
            {"Total Fees", "$0.00"},
            {"Fitness Score", "0.072"},
            {"Kelly Criterion Estimate", "-60.144"},
            {"Kelly Criterion Probability Value", "0.901"},
            {"Sortino Ratio", "-1.207"},
            {"Return Over Maximum Drawdown", "-8.849"},
            {"Portfolio Turnover", "0.412"},
            {"Total Insights Generated", "27"},
            {"Total Insights Closed", "21"},
            {"Total Insights Analysis Completed", "21"},
            {"Long Insight Count", "15"},
            {"Short Insight Count", "0"},
            {"Long/Short Ratio", "100%"},
            {"Estimated Monthly Alpha Value", "$-2618243"},
            {"Total Accumulated Estimated Alpha Value", "$-1323668"},
            {"Mean Population Estimated Insight Value", "$-63031.79"},
            {"Mean Population Direction", "16.6667%"},
            {"Mean Population Magnitude", "0%"},
            {"Rolling Averaged Population Direction", "5.4846%"},
            {"Rolling Averaged Population Magnitude", "0%"},
            {"OrderListHash", "866464666"}
        };
    }
}
