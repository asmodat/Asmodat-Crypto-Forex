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
        ThreadedMethod Methods = new ThreadedMethod(100);
        ThreadedTimers Timers = new ThreadedTimers(100);

        public Form1()
        {
            InitializeComponent();

            this.Shown += Form1_Shown;
            //this.OnVisibleChanged += 
            //Methods.Run(() => ShowLoginWindows(), null);

            //while (true)  Thread.Sleep(1000);
            //this.T2SBtnKrakenStartStop.Initialize(this);
            this.KrkECntrlEntries.Initialize(this);
            this.KrkCntrlTrade.Initialize(this);
            this.KrkCntrlOrderInfoClosed.Initialize(this);

            //this.TCmbxEntriesCurrencyPair.Initialize(this);
            //this.TCmbxEntriesTimeFrame.Initialize(this);
            this.T2SBtnKrakenStartStop.OnClickOn += T2SBtnKrakenStartStop_OnClickOn;
            this.T2SBtnKrakenStartStop.OnClickOff += T2SBtnKrakenStartStop_OnClickOff;

            this.TCmbxEntriesTimeFrame.SelectedIndexChanged += TCmbxEntriesTimeFrame_SelectedIndexChanged;
            this.TCmbxEntriesCurrencyPair.SelectedIndexChanged += TCmbxEntriesCurrencyPair_SelectedIndexChanged;
        }

        public static ForexManager Manager = ForexManager.Instance;


        public static DataPoint ToCandle(OHLCEntry entry)
        {
            DataPoint DPoint = new DataPoint();
            DPoint.SetValueXY((DateTime)entry.Time, entry.High, entry.Low, entry.Open, entry.Close);
            return DPoint;
        }



        private void Form1_Shown(object sender, EventArgs e)
        {
            ShowLoginWindows();
        }


    }
}
