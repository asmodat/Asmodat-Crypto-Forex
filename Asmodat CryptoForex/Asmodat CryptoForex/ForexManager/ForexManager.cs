using Asmodat.Kraken;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asmodat_CryptoForex
{
    public class ForexManager
    {
        private static ForexManager _instance;
        public static ForexManager Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new ForexManager();
                return _instance;
            }
        }

       /* public void InitializeKraken(string APIKey, string PrivateKey)
        {
            Kraken = new KrakenManager(APIKey, PrivateKey);
        }*/


        public KrakenManager Kraken { get; set; } = null;


    }
}
