using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Asmodat.FormsControls;
using System.Threading;
using Asmodat.Abbreviate;using Asmodat.Extensions.Objects;

using Asmodat.Extensions.Drawing;

using Asmodat.Kraken;
using Asmodat.Extensions.Collections.Generic;
using Asmodat.IO;

using System.Windows.Forms.DataVisualization.Charting;

namespace Asmodat_CryptoForex
{
    public partial class Form1 : Form
    {


        private void UpdateEntriesChart()
        {
            string pair = GetEntriesPairName();
            string timeframe = TCmbxEntriesTimeFrame.Text;

            if (timeframe.IsNullOrWhiteSpace() || pair.IsNullOrWhiteSpace())
                return;

            var interval = Enums.ToEnumByDescription<OHLC.Interval>(timeframe);
            var entry = Manager.Kraken.Archive.Get(pair, interval);

            if (KrkECntrlEntries.Chart.CountPoints(pair) == entry.Entries.Length)
                return;

            KrkECntrlEntries.Chart.ClearSeries();

            var candles = entry.Entries.ToDataPoints(OHLCEx.DataPointType.Candle);

            KrkECntrlEntries.Chart.Add(pair, SeriesChartType.Candlestick);
            KrkECntrlEntries.Chart.AddRange(pair, candles, ChartValueType.DateTime, ChartValueType.Double);

        }

        private void UpdateEntriesTimeFrames()
        {
            string PairName = this.GetEntriesPairName();
            var intervals = Manager.Kraken.Archive.GetIntervals(PairName);

            if(intervals.IsNullOrEmpty())
            {
                TCmbxEntriesTimeFrame.ClearItems();
                return;
            }

            intervals = intervals.SortAscending(x => x).ToArray();

            TCmbxEntriesTimeFrame.AddItemsEnumDescriptions(intervals);
            if (TCmbxEntriesTimeFrame.Count > 0 && TCmbxEntriesTimeFrame.SelectedIndex < 0)
                TCmbxEntriesTimeFrame.SelectIndex(0);
        }

        private void UpdateEntriesPairNames()
        {
            string[] pairs = Manager.Kraken.Archive.GetPairNames();
            var touples = Asmodat.Kraken.Kraken.ToAssetTouple(pairs);
            var result = Asmodat.Kraken.Kraken.ToString(touples, Asmodat.Kraken.Kraken.AssetToupleFormat.NamesSeparated);

            TCmbxEntriesCurrencyPair.AddItems(result);
            if (TCmbxEntriesCurrencyPair.Text.IsNullOrWhiteSpace())
                TCmbxEntriesCurrencyPair.SelectIndex(0);
        }

        /// <summary>
        /// Returns PairName in correct format to use with archive
        /// </summary>
        /// <returns></returns>
        private string GetEntriesPairName()
        {
            string PairName = TCmbxEntriesCurrencyPair.Text;
            var touple = Asmodat.Kraken.Kraken.ToAssetTouple(PairName);
            PairName = Asmodat.Kraken.Kraken.ToString(touple, Asmodat.Kraken.Kraken.AssetToupleFormat.CurrencyNames);
            return PairName;
        }

    }
}
