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
        public void UpdateFee()
        {
            TTbxVolumeFee.Text = this.GetFeeVolume() + "";
        }

        public decimal GetFeeVolume()
        {
            var asset = this.GetAssetFee();
            decimal fee = this.GetFee();
            Asset info = null;
            decimal volume = 0;

            if (asset.ValueEquals(this.GetAssetBuy()))
            {
                volume = this.GetBuyVolume();
                info = this.GetAssetInfoBuy();
            }
            else if (asset.ValueEquals(this.GetAssetSell()))
            {
                volume = this.GetSellVolume();
                info = this.GetAssetInfoSell();
            }

            if (info == null || volume <= 0 || fee <= 0)
                return 0;

            return (volume.FindValueByPercentages(100, fee)).MathRound(info.DisplayDecimals);
        }


        public void UpdateVolume()
        {
            decimal volumeFixed = this.GetFixedVolume();
            decimal volume = this.GetNonFixedVoulume();

            if (IsFixedPrimary)
                TTbxVolumeSecondary.Text = volume + "";
            else if (IsFixedSecondary)
                TTbxVolumePrimary.Text = volume + "";
        }

        public decimal GetFixedVolume()
        {
            string text = null;
            Asset info = null;
            if (IsFixedPrimary)
            {
                text = TTbxVolumePrimary.Text;
                info = Manager.Kraken.AssetInfo(this.GetAssetPrimary());
            }
            else if (IsFixedSecondary)
            {
                text = TTbxVolumeSecondary.Text;
                info = Manager.Kraken.AssetInfo(this.GetAssetSecondary());
            }

            if (text.IsNullOrWhiteSpace() || info == null)
                return 0;


            decimal volume = text.ParseDecimal(0).MathRound(info.DisplayDecimals);
            return volume;
        }

        /// <summary>
        /// Non fixed volume
        /// </summary>
        public decimal GetNonFixedVoulume()
        {
            var _buy = this.GetAssetBuy();
            var _sell = this.GetAssetSell();
            var info_buy = this.GetAssetInfoBuy();
            var info_sell = this.GetAssetInfoSell();
            Ticker _ticker = this.GetTicker();
            decimal _fee = this.GetFee();

            if (info_buy == null || info_sell == null || _ticker == null)
                return 0;


            decimal volumeFixed = this.GetFixedVolume();
            decimal volume = 0;

            if (IsFixedBuy)
            {
                volume = _ticker.BuyPrice(_buy.Value, volumeFixed, _fee).MathRound(info_sell.DisplayDecimals);
            }
            else if (IsFixedSell)
            {
                volume = _ticker.SellPrice(_sell.Value, volumeFixed, _fee).MathRound(info_buy.DisplayDecimals);
            }

            return volume;
        }


        public decimal GetBuyVolume()
        {
            if (IsFixedBuy)
                return this.GetFixedVolume();
            else
                return this.GetNonFixedVoulume();
        }

        public decimal GetSellVolume()
        {
            if (IsFixedSell)
                return this.GetFixedVolume();
            else
                return this.GetNonFixedVoulume();
        }


        

        public void SetFixedPrimary()
        {
            TTbxVolumePrimary.SetFontStyle(FontStyle.Bold);
            TTbxVolumeSecondary.SetFontStyle(FontStyle.Regular);
            IsFixedPrimary = true;
            IsFixedSecondary = false;
        }

        public void SetFixedSecondary()
        {
            TTbxVolumeSecondary.SetFontStyle(FontStyle.Bold);
            TTbxVolumePrimary.SetFontStyle(FontStyle.Regular);
            IsFixedSecondary = true;
            IsFixedPrimary = false;
        }

        private void TTbxVolumeSecondary_Click(object sender, EventArgs e)
        {
            this.SetFixedSecondary();
        }

        private void TTbxVolumePrimary_Click(object sender, EventArgs e)
        {
            this.SetFixedPrimary();
        }

        private void TTbxVolumePrimary_TextChanged(object sender, EventArgs e)
        {
            if (IsFixedPrimary)
                this.UpdateVolume();

            UpdateFee();
        }

        private void TTbxVolumeSecondary_TextChanged(object sender, EventArgs e)
        {
            if (IsFixedSecondary)
                this.UpdateVolume();

            UpdateFee();
        }
    }
}
