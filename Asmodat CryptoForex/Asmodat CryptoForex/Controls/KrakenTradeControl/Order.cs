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


        private void BtnOrder_Click(object sender, EventArgs e)
        {
            var assetFee = this.GetAssetFee();
            var buy = this.GetAssetBuy();
            var sell = this.GetAssetSell();
            var ticker = this.GetTicker();
            string leverage = this.GetLeverage();

            decimal volume;

            Asmodat.Kraken.Kraken.OrderKind type;
            List<Asmodat.Kraken.Kraken.OrderFlags> flags = new List<Asmodat.Kraken.Kraken.OrderFlags>();

            if (ticker.IsBase(buy) && ticker.IsQuote(sell))
            {
                type = Asmodat.Kraken.Kraken.OrderKind.Buy;
                volume = this.GetBuyVolume();
            }
            else if (ticker.IsBase(sell) && ticker.IsQuote(buy))
            {
                type = Asmodat.Kraken.Kraken.OrderKind.Sell;
                volume = this.GetSellVolume();
            }
            else
                return;

            if(!assetFee.IsNull())
            {
                if(ticker.IsBase(assetFee))
                    flags.Add(Asmodat.Kraken.Kraken.OrderFlags.FeeInBaseCurrency);
                else if (ticker.IsQuote(assetFee))
                    flags.Add(Asmodat.Kraken.Kraken.OrderFlags.FeeInQuoteCurrency);
            }

            Asmodat.Kraken.Kraken.OrderFlags[] flags_result = null;
            if (!flags.IsNullOrEmpty())
                flags_result = flags.ToArray();

            var result = Manager.Kraken.AddMarketOrder(ticker.Name,type, volume, leverage, flags_result);

            if (result.Error.IsNullOrEmpty())
                MessageBox.Show("Order Failed: " + result.Error);
            else
                MessageBox.Show("Order Success: " + result.Info);

        }

    }
}
