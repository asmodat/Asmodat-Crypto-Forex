using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Asmodat.FormsControls;

namespace Asmodat_CryptoForex.Controls
{
    public partial class KrakenEntriesControl : UserControl
    {
        public KrakenEntriesControl()
        {
            InitializeComponent();
        }

        public Control Invoker { get; private set; }

        public void Initialize(Control Invoker)
        {
            this.Invoker = Invoker;
            this.Chart.Start();
        }


        public ThreadedChart Chart
        {
            get
            {
                return this.TChartMain;
            }
        }
    }
}
