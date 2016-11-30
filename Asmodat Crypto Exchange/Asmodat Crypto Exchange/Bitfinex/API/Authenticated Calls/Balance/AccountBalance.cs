using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using Newtonsoft.Json;

namespace Asmodat.BitfinexV1.API
{
    public class AccountBalance
    {
        public Balance Trading;
        public Balance Deposit;
        public Balance Exchange;
        public Balance Total;


        public static AccountBalance FromJson(string json)
        {
            List<ObjWalletBalances> items = JsonConvert.DeserializeObject<List<ObjWalletBalances>>(json);

            return null;
        }

        private AccountBalance(List<ObjWalletBalances> items)
        {
            Trading = new Balance();
            Deposit = new Balance();
            Exchange = new Balance();
            Total = new Balance();

            Balance tmp = null;
            foreach (ObjWalletBalances wallet in items)
            {
                switch (wallet.type.ToLower())
                {
                    case "trading":
                        tmp = Trading;
                        break;
                    case "deposit":
                        tmp = Deposit;
                        break;
                    case "exchange":
                        tmp = Exchange;
                        break;
                }


                switch (wallet.currency.ToLower())
                {
                    case "usd":
                        tmp.USD = wallet.amount;
                        Total.USD += wallet.amount;
                        tmp.AvailableUSD = wallet.available;
                        Total.AvailableUSD += wallet.available;
                        break;
                    case "btc":
                        tmp.BTC = wallet.amount;
                        Total.BTC += wallet.amount;
                        tmp.AvailableBTC = wallet.available;
                        Total.AvailableBTC += wallet.available;
                        break;

                }


            }

        }
    }



}
