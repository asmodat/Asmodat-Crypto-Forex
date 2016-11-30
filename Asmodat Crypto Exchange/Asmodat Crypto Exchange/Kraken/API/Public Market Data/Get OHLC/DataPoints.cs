using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Configuration;
using System.IO;
using System.Security.Cryptography;
using Asmodat.Abbreviate;
using Asmodat.Types;
using System.Collections;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Asmodat.Debugging;
using System.ComponentModel;
using System.Windows.Forms.DataVisualization.Charting;

namespace Asmodat.Kraken
{





    public static class OHLCEx
    {
        public static DataPoint ToCandle(this OHLCEntry entry)
        {
            DataPoint DPoint = new DataPoint();
            DPoint.SetValueXY((DateTime)entry.Time, entry.High, entry.Low, entry.Open, entry.Close);
            return DPoint;
        }

        /// <summary>
        /// This data pont can be used as HighLow High Low stick inside chart
        /// </summary>
        /// <param name="CPoint"></param>
        public static DataPoint ToHihgLow(this OHLCEntry entry)
        {
            DataPoint DPoint = new DataPoint();
            DPoint.SetValueXY((DateTime)entry.Time, entry.High, entry.Low);
            return DPoint;
        }

        /// <summary>
        /// This data pont can be used as HighLow AskBid stick inside chart
        /// </summary>
        /// <param name="CPoint"></param>
        public static DataPoint ToOpenClose(this OHLCEntry entry)
        {
            DataPoint DPoint = new DataPoint();
            DPoint.SetValueXY((DateTime)entry.Time, entry.Open, entry.Close);
            return DPoint;
        }

        /// <summary>
        /// This method coverts chart points to data points
        /// </summary>
        /// <param name="points"></param>
        /// <returns></returns>
        public static DataPoint[] ToDataPoints(this OHLCEntry[] entries, DataPointType type)
        {
            DataPoint[] ADPoints = new DataPoint[entries.Length];

            Parallel.For(0, entries.Length, i =>
            {
                if (type == DataPointType.Candle)
                    ADPoints[i] = OHLCEx.ToCandle(entries[i]);
                else if (type == DataPointType.HiLo)
                    ADPoints[i] = OHLCEx.ToHihgLow(entries[i]);
                else if (type == DataPointType.OpenClose)
                    ADPoints[i] = OHLCEx.ToOpenClose(entries[i]);
                else throw new ArgumentException("Unknown data point type !");
            });

            return ADPoints;
        }


        public enum DataPointType
        {
            Null = 0,
            Candle = 1,
            HiLo = 3,
            OpenClose = 4,
        }
    }
}
