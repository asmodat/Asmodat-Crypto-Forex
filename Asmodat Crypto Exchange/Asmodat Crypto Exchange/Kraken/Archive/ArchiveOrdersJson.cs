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
using Asmodat.Abbreviate;
using Asmodat.Extensions.Objects;
using Asmodat.Extensions.Collections.Generic;

namespace Asmodat.Kraken
{

    public static class ArchiveOrdersJsonEx
    {
        
    }

    public class ArchiveOrders
    {
        [JsonProperty(PropertyName = "closedord")]
        public OrderInfo[] ClosedOrders { get; set; }



        public void AddRangeClosedOrder(OrderInfo[] var)
        {
            if (ClosedOrders == null)
                ClosedOrders = new OrderInfo[0];

            if (var.IsNullOrEmpty())
                return;

            foreach(var v in var)
                this.AddClosedOrder(v);
        }

        public void AddClosedOrder(OrderInfo var)
        {
            if (ClosedOrders == null)
                ClosedOrders = new OrderInfo[0];

            if (var == null)
                return;

            var list = ClosedOrders.ToList();

            list.AddDistinct(var);
            ClosedOrders = list.ToArray();
        }


        /// <summary>
        /// Returns last, lates closed order
        /// </summary>
        /// <param name="json"></param>
        /// <returns></returns>
        public OrderInfo GetLastClosed()
        {
            if (ClosedOrders.IsNullOrEmpty())
                return null;

            OrderInfo last = null;
            foreach (var v in ClosedOrders)
            {
                if (last == null || last.StartTime > last.StartTime)
                    last = v;
            }

            return last;
        }

    }

   
}


/*while (pairs == null || pairs.Length <= 0)
            {
                if(Manager.Kraken != null)
                    pairs = Manager.Kraken.GetAssetPairs();
                Thread.Sleep(1000);
            }*/
