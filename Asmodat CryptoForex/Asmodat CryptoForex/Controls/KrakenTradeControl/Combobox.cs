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
        

        public Asmodat.Kraken.Kraken.Asset? GetAssetFee()
        {
            return Asmodat.Kraken.Kraken.ToAsset(TCmbxAssetFee.Text);
        }

        public Asmodat.Kraken.Kraken.Asset? GetAssetPrimary()
        {
            return Asmodat.Kraken.Kraken.ToAsset(TCmbxAssetPrimary.Text);
        }

        public Asmodat.Kraken.Kraken.Asset? GetAssetSecondary()
        {
            return Asmodat.Kraken.Kraken.ToAsset(TCmbxAssetSecondary.Text);
        }


        public string GetLeverage()
        {
            return TCmbxLeverage.Text;
        }

        public AssetPair GetAssetPair()
        {
            return Manager.Kraken.GetAssetPairAny(this.GetAssetBuy(), this.GetAssetSell());
        }

        public decimal[] GetLeverages()
        {
            var pair = this.GetAssetPair();

            if (pair.IsBase(this.GetAssetBuy()))
                return pair.LeverageBuy;
            else if (pair.IsBase(this.GetAssetSell()))
                return pair.LeverageSell;

            return null;
        }

        private void TCmbxAssetPrimary_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.UpdatePrimaryBuy();
            this.UpdateSecondarySell();
            this.UpdateVolume();
            this.UpdatePreferedFee();
            this.UpdateFee();
            this.UpdateLeverage();
        }

        private void TCmbxAssetSecondary_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.UpdatePrimaryBuy();
            this.UpdateSecondarySell();
            this.UpdateVolume();
            this.UpdatePreferedFee();
            this.UpdateFee();
            this.UpdateLeverage();
        }

        private void TCmbxAssetFee_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.UpdateFee();
        }

        

        public void UpdatePrimaryBuy()
        {
            string[] results = null;

            var asset_sell = this.GetAssetSell();
            var assets_all = Manager.Kraken.AssetPairs;
            results = Asmodat.Kraken.Kraken.ToString(assets_all.GetComplementaryAssets(asset_sell)).DistinctArray();

            if (IsPrimaryBuy)
                this.UpdatePrimaryList(results);
            else if (IsSecondaryBuy)
                this.UpdateSecondaryList(results);
            else
            {
                this.UpdatePrimaryList(null);
                this.UpdateSecondaryList(null);
            }
        }

        public void UpdateSecondarySell()
        {
            string[] results = null;
            var assets = Manager.Kraken.AvailableAssets();
            results = Asmodat.Kraken.Kraken.ToString(assets);

            if (IsPrimarySell)
                this.UpdatePrimaryList(results);
            else if (IsSecondarySell)
                this.UpdateSecondaryList(results);
            else
            {
                this.UpdatePrimaryList(null);
                this.UpdateSecondaryList(null);
            }
        }

        public void UpdatePreferedFee()
        {
            string[] items = null;
            var buy = this.GetAssetBuy();
            var sell = this.GetAssetSell();
            items = Asmodat.Kraken.Kraken.ToString(new Asmodat.Kraken.Kraken.Asset[] { buy.Value, sell.Value }).DistinctArray();


            if (items.IsNullOrEmpty())
            {
                TCmbxAssetFee.ClearItems();
                return;
            }

            TCmbxAssetFee.AddItems(items);

            if (TCmbxAssetFee.Text.IsNullOrWhiteSpace())
                TCmbxAssetFee.SelectIndex(0);
        }

        public void UpdateLeverage()
        {
            var leverages = this.GetLeverages();

            List<string> items = new List<string>() { "none" };

            if(!leverages.IsNullOrEmpty())
                items.AddRange(leverages.ToStringArray());

            TCmbxLeverage.AddItems(items);

            if (TCmbxLeverage.Text.IsNullOrWhiteSpace())
                TCmbxLeverage.SelectIndex(0);
        }

        public void UpdatePrimaryList(string[] items)
        {
            if (items.IsNullOrEmpty())
            {
                TCmbxAssetPrimary.ClearItems();
                return;
            }

            TCmbxAssetPrimary.AddItems(items);

            if (TCmbxAssetPrimary.Text.IsNullOrWhiteSpace())
                TCmbxAssetPrimary.SelectIndex(0);
        }

        public void UpdateSecondaryList(string[] items)
        {
            if (items.IsNullOrEmpty())
            {
                TCmbxAssetSecondary.ClearItems();
                return;
            }

            TCmbxAssetSecondary.AddItems(items);

            if (TCmbxAssetSecondary.Text.IsNullOrWhiteSpace())
                TCmbxAssetSecondary.SelectIndex(0);
        }

    }
}
