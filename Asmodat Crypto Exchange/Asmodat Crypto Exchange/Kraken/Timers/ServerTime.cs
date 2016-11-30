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
using Asmodat.Types;
using Asmodat.Debugging;
//using PennedObjects.RateLimiting;

namespace Asmodat.Kraken
{

    public partial class KrakenManager
    {
        public TickTime ServerTime { get; private set; } = TickTime.Default;

        public TickTimeout TimeoutServerTime { get; private set; } = new TickTimeout(3000, TickTime.Unit.ms, TickTime.Default);


        public void InitializeServerTime()
        {
            if (!Timers.Contains("TimrServerTime"))
                Timers.Run(() => TimrServerTime(), 1000, "TimrServerTime", true, false);
        }


        public void TimrServerTime()
        {
            if (!TimeoutServerTime.IsTriggered)
                return;

            TimeoutServerTime.Forced = true;

            TickTime time = this.GetServerTime();

            if (time.IsDefault)
                return;

            this.ServerTime = time;
            TimeoutServerTime.Reset();
        }




    }
}
