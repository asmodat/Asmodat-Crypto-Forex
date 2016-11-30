using Asmodat.Kraken;
using Asmodat.Types;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using Asmodat.IO;
using Asmodat.Abbreviate;using Asmodat.Extensions.Objects;
using Asmodat.Extensions.Collections.Generic;
using Asmodat.Extensions;

namespace Asmodat.Kraken
{


    public partial class Archive
    {
        public ThreadedTimers Timers = new ThreadedTimers(100);
        public ThreadedMethod Methods = new ThreadedMethod(100);


        public Archive(KrakenManager Manager)
        {
            this.Manager = Manager;

      
            Methods.Run(() => this.Initialize(), null);
            Timers.Run(() => this.TimerOrders(), 10000, null, true, true);
        }


        /// <summary>
        /// Returns pair names of cryptocurrencies inside archive
        /// </summary>
        /// <returns></returns>
        public string[] GetPairNames()
        {
            if (Entries.IsNullOrEmpty())
                return null;

            List<string> list = new List<string>();
            foreach(var json in Entries)
            {
                if (json.Value == null || json.Value.Entries.IsNullOrEmpty())
                    continue;

                list.AddDistinct(json.Value.PairName);
            }

            return list.ToArray();
        }

        /// <summary>
        /// Returns intervals of specified pair inside archive
        /// </summary>
        /// <returns></returns>
        public OHLC.Interval[] GetIntervals(string PairName)
        {
            if (Entries.IsNullOrEmpty())
                return null;

            List<OHLC.Interval> list = new List<OHLC.Interval>();

            foreach (var json in Entries)
            {
                if (json.Value == null || json.Value.Entries.IsNullOrEmpty() || json.Value.PairName != PairName)
                    continue;

                list.AddDistinct(json.Value.Interval);
            }

            return list.ToArray();
        }


        /// <summary>
        /// Returns archive key storage for currency pair and specified interval
        /// </summary>
        /// <param name="pair"></param>
        /// <param name="interval"></param>
        /// <returns></returns>
        public string GetKey(string pair, OHLC.Interval interval)
        {
            if (pair == null)
                return null;

            return pair + (int)interval; //pair.Name
        }

        public ArchiveEntriesJson Get(string pair, OHLC.Interval interval)
        {
            string key = this.GetKey(pair, interval);
            return this.Get(key);
        }

        public ArchiveEntriesJson Get(string key)
        {
            if (Entries.IsNullOrEmpty())
                return null;
            return Entries.Get(key);
        }


        public void Initialize()
        {
            this.InitializeOrders();
            this.InitializeEntries();
        }

        public void InitializeOrders()
        {
            if (Orders == null)
                Orders = new JsonStorage<ArchiveOrders>(Path + @"\Orders", "ArchiveOrders", true, false, null);

            var orders = Orders.Get();

            if (orders == null)
            {
                orders = new ArchiveOrders();
                Orders.Set(orders, true);
            }
        }

        public void InitializeEntries()
        {
            if (Entries == null)
                Entries = new JsonDataBase<ArchiveEntriesJson>(Path + @"\DataEntries", true, false, null);
        }

        public void TimerOrders()
        {
            this.LoadOrders();
        }

        public void TimerFrames()
        {
            this.LoadFrames();
        }


        public void LoadOrders()
        {
            if (Orders == null)
                return;

            var orders = Orders.Get();


            string closeStartID = null;
            if (orders != null && !orders.ClosedOrders.IsNullOrEmpty())
            {
                var last = orders.GetLastClosed();
                if (last != null && last.OpenTime > 0)
                    closeStartID = last.ID;
            }
            

            OrderInfo[] closedInfo = null;
            if(!closeStartID.IsNullOrWhiteSpace())
            {
                closedInfo = Manager.GetClosedOrders(true,null,closeStartID);
            }
            else
            {
                closedInfo = Manager.GetClosedOrders(true);
            }

            if(!closedInfo.IsNullOrEmpty())
            {
                orders.ClosedOrders = orders.ClosedOrders.AddRangeDistinct(closedInfo);
                Orders.Set(orders, true);
            }



        }

        public void LoadFrames()
        {
            if (Entries == null)
                return;
            

            var pairs = Manager.GetAssetPairsNames();

            this.LoadEntries(pairs, OHLC.Intervals);


        }


        public void LoadEntries(string[] pairs, OHLC.Interval[] intervals)
        {
            if (pairs == null || intervals == null || pairs.Length <= 0 || intervals.Length <= 0)
                return;

            foreach (OHLC.Interval interval in intervals)
            {
                foreach (string pair in pairs)
                {
                    string key = this.GetKey(pair, interval);
                    var entries = Entries.Get(key);

                    TickTime last = new TickTime(0);
                    int minutes = (int)interval;
                    if (entries != null)
                    {
                        
                        if (entries.Last.AddMinutes(minutes) > TickTime.Now)
                            continue;

                        last = entries.Last;
                    }
                    else
                    {
                        entries = new ArchiveEntriesJson();
                        entries.PairName = pair;
                        entries.Interval = interval;
                        entries.Last = last;
                        entries.Entries = new OHLCEntry[0];
                    }

                    if(last > new TickTime(0).AddMinutes(minutes))
                        last = last.AddMinutes(-minutes);

                    OHLC ohlc = null;
                    try
                    {

                        ohlc = Manager.GetOHLC(pair, interval, last);
                    }
                    catch
                    {
                        continue;
                    }

                    if (ohlc == null)
                        continue;


                    var _old = entries.Entries.ToDistinctKeyDictionary(x => x.Time, x => x);
                    var _new = ohlc.Entries.ToDistinctKeyDictionary(x => x.Time, x => x);
                    _old.AddOrUpdate(_new);

                    List<OHLCEntry> list = _old.Values.ToList();

                    if (list == null || list.Count <= 0)
                        continue;

                    entries.Entries = list.ToArray();
                    entries.Last = list.Last().Time;
                    Entries.Set(key, entries, true);

                }
            }

        }


    }
}


/*
public ArchiveEntriesJson GetArchiveEntriesJson(string key)
        {
            if (DataEntries == null || DataEntries.Count <= 0)
                return null;



            return null;
        }
    
    
    while (pairs == null || pairs.Length <= 0)
            {
                if(Manager.Kraken != null)
                    pairs = Manager.Kraken.GetAssetPairs();
                Thread.Sleep(1000);
            }*/
