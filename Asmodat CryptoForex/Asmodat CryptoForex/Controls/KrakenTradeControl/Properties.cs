using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Asmodat.Extensions.Windows.Forms;
using Asmodat.Abbreviate;

namespace Asmodat_CryptoForex
{
    public partial class KrakenTradeControl : UserControl
    {
        ThreadedMethod Methods = new ThreadedMethod(100);
        ThreadedTimers Timers = new ThreadedTimers(100);
        public static ForexManager Manager = ForexManager.Instance;

        public Control Invoker { get; private set; }


        public bool IsFixedPrimary { get; private set; } = false;
        public bool IsFixedSecondary { get; private set; } = true;
    }
}
