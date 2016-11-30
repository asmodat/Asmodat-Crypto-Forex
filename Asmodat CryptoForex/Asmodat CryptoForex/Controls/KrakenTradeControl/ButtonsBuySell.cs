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
        private void TTSBtnSecondary_OnClick(object source, Asmodat.FormsControls.ThreadedTwoStateButtonClickStatesEventArgs e)
        {
            TTSBtnPrimary.Switch();
            TTSBtnSecondary.Switch();
            this.UpdateVolume();
            this.UpdateSecondarySell();
            this.UpdatePrimaryBuy();
            this.UpdateLeverage();
        }
        private void TTSBtnPrimary_OnClick(object source, Asmodat.FormsControls.ThreadedTwoStateButtonClickStatesEventArgs e)
        {
            TTSBtnPrimary.Switch();
            TTSBtnSecondary.Switch();
            this.UpdateVolume();
            this.UpdateSecondarySell();
            this.UpdatePrimaryBuy();
            this.UpdateLeverage();
        }

        public bool IsPrimaryBuy
        {
            get
            {
                if (TTSBtnPrimary.On) return true;
                else return false;
            }
        }
        public bool IsPrimarySell
        {
            get
            {
                if (TTSBtnPrimary.Off) return true;
                else return false;
            }
        }

        public bool IsSecondaryBuy
        {
            get
            {
                if (TTSBtnSecondary.On) return true;
                else return false;
            }
        }
        public bool IsSecondarySell
        {
            get
            {
                if (TTSBtnSecondary.Off) return true;
                else return false;
            }
        }

        public Asmodat.Kraken.Kraken.Asset? GetAssetBuy()
        {
            if (IsPrimaryBuy)
                return this.GetAssetPrimary();
            else if (IsSecondaryBuy)
                return this.GetAssetSecondary();

            return null;
        }
        public Asmodat.Kraken.Kraken.Asset? GetAssetSell()
        {
            if (IsPrimarySell)
                return this.GetAssetPrimary();
            else if (IsSecondarySell)
                return this.GetAssetSecondary();

            return null;
        }


        public bool IsFixedBuy
        {
            get
            {
                if (IsPrimaryBuy && IsFixedPrimary)
                    return true;
                else if (IsSecondaryBuy && IsFixedSecondary)
                    return true;
                else
                    return false;
            }
        }
        public bool IsFixedSell
        {
            get
            {
                if (IsPrimarySell && IsFixedPrimary)
                    return true;
                else if (IsSecondarySell && IsFixedSecondary)
                    return true;
                else
                    return false;
            }
        }


    }
}
