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
using Asmodat.Extensions.Collections.Generic;
using Asmodat.Extensions.Objects;
using Asmodat.Extensions;
using Asmodat.Kraken;

namespace Asmodat_CryptoForex
{
    public partial class KrakenTradeControl : UserControl
    {
        public KrakenTradeControl()
        {
            InitializeComponent();

            TTbxVolumePrimary.Click += TTbxVolumePrimary_Click;
            TTbxVolumeSecondary.Click += TTbxVolumeSecondary_Click;
            TTbxVolumePrimary.TextChanged += TTbxVolumePrimary_TextChanged;
            TTbxVolumeSecondary.TextChanged += TTbxVolumeSecondary_TextChanged;

            TCmbxAssetPrimary.SelectedIndexChanged += TCmbxAssetPrimary_SelectedIndexChanged;
            TCmbxAssetSecondary.SelectedIndexChanged += TCmbxAssetSecondary_SelectedIndexChanged;
            TCmbxAssetFee.SelectedIndexChanged += TCmbxAssetFee_SelectedIndexChanged;
            
            TTSBtnPrimary.OnClick += TTSBtnPrimary_OnClick;
            TTSBtnSecondary.OnClick += TTSBtnSecondary_OnClick;

            BtnOrder.Click += BtnOrder_Click;


            Timers.Run(() => TimerUpdate(), 5000);

            this.SetFixedSecondary();
        }

        

        public void Initialize(Control Invoker)
        {
            this.Invoker = Invoker;
            /*TTbxVolumePrimary.Initialize(this.Invoker);
            TTbxVolumeSecondary.Initialize(this.Invoker);
            TTbxVolumeFee.Initialize(this.Invoker);

            TCmbxAssetPrimary.Initialize(this.Invoker);
            TCmbxAssetSecondary.Initialize(this.Invoker);
            TCmbxAssetFee.Initialize(this.Invoker);
            TCmbxLeverage.Initialize(this.Invoker);

            TTSBtnPrimary.Initialize(this.Invoker);
            TTSBtnSecondary.Initialize(this.Invoker);*/
        }




        private void TimerUpdate()
        {
            if (Manager.Kraken == null) return;

            this.UpdateSecondarySell();
            this.UpdatePrimaryBuy();
            this.UpdateLeverage();
            this.UpdateVolume();

            var v = Manager.Kraken.GetAssetPair("");
            //if (v.IsNullOrEmpty())
            //    return;

            //v.Count();
        }


        

        public decimal GetFee()
        {
            var ticker = this.GetTicker();
            if (ticker == null || ticker.Name.IsNullOrWhiteSpace())
                return 0;

            try
            {
                return Manager.Kraken.GetFee(ticker.Name);
            }
            catch
            {
                return 0;
            }
        }

        public Ticker GetTicker()
        {
            return Manager.Kraken.Tickers.GetAny(this.GetAssetBuy(), this.GetAssetSell());
        }

        public Asset GetAssetInfoBuy()
        {
            return Manager.Kraken.AssetInfo(this.GetAssetBuy());
        }

        public Asset GetAssetInfoSell()
        {
            return Manager.Kraken.AssetInfo(this.GetAssetSell());
        }

        
        

        


        


        
    }
}
