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

        public void TimerEntries()
        {
            if (Manager.Kraken.Archive.Entries.IsNullOrEmpty())
            {
                return;
            }

            this.UpdateEntriesPairNames();
            this.UpdateEntriesTimeFrames();
            this.UpdateEntriesChart();
        }


        private void TCmbxEntriesCurrencyPair_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.UpdateEntriesTimeFrames();
            this.UpdateEntriesChart();
        }

        private void TCmbxEntriesTimeFrame_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.UpdateEntriesChart();
        }

    }
}
