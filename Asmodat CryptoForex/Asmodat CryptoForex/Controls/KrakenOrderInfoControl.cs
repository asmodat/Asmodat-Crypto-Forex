using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Asmodat.IO;
using System.Security;
using Asmodat.Cryptography;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Asmodat_CryptoForex
{

    public partial class KrakenOrderInfoControl : UserControl
    {

        public KrakenOrderInfoControl()
        {
            InitializeComponent();

        }

        public Control Invoker { get; private set; }
        public void Initialize(Control Invoker)
        {
            this.Invoker = Invoker;
        }



    }
}
