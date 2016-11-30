using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Jayrock.Json;
using Jayrock.Json.Conversion;
using System.Net;
using System.Configuration;
using System.IO;
using System.Security.Cryptography;
using Asmodat.Abbreviate;
using Asmodat.Extensions.Objects;
using Asmodat.Types;
using AsmodatMath;
//using PennedObjects.RateLimiting;

namespace Asmodat.Kraken
{

    public partial class KrakenManager
    {

        public ThreadedTimers Timers = new ThreadedTimers(100);

        public Archive Archive { get; private set; }


        public KrakenManager(string APIKey, string PrivateKey)
        {
            this.APIKey = APIKey;
            this.PrivateKey = PrivateKey;
            this.AntiFlood = new ThreadedAntiFlood(TickTime.Default, 5000, TickTime.Unit.ms);

            this.Archive = new Archive(this);
            Timers.Run(() => TimerArchive(), 10000, null, false, true);

            InitializeServerTime();
            InitializeAssetPairs();
            InitializeBalance();
            InitializeTickers();
            InitializeAssetInfos();
            InitializeTradeVolume();


        }



        public void TimerArchive()
        {
            this.Archive.LoadFrames();
        }



    }

    
}
