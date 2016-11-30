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

        private void T2SBtnKrakenStartStop_OnClickOn(object source, ThreadedTwoStateButtonClickStatesEventArgs e)
        {
            this.T2SBtnKrakenStartStop.Switch();

            Manager.Kraken = new KrakenManager(KrkLCntrlAuthentication.APIKey, KrkLCntrlAuthentication.PrivateKey);

            
            Timers.Run(() => TimerEntries(), 2000, null, false, true);
            Timers.Run(() => TimerOrders(), 5000, null, false, true);
        }



       

        private void T2SBtnKrakenStartStop_OnClickOff(object source, ThreadedTwoStateButtonClickStatesEventArgs e)
        {
            this.T2SBtnKrakenStartStop.Switch();

            Timers.TerminateAll();
        }

    }
}
