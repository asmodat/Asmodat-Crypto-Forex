using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Configuration;
using System.IO;
using System.Security.Cryptography;
using Asmodat.Abbreviate;
using Asmodat.Extensions.Objects;
using Asmodat.Types;
using System.Collections;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Asmodat.Debugging;
using Asmodat.Extensions.Collections;

namespace Asmodat.Kraken
{

    public partial class KrakenManager
    {
        
        public OrderInfo[] GetClosedOrders(bool trades = false, string userref = null, string start = null, string end = null, string ofs = null, string closetime = null)
        {
            string props = string.Format("&trades={0}", trades.ToString().ToLower());

            if (!userref.IsNullOrEmpty())
                props += string.Format("&userref={0}", userref);
            if (!start.IsNullOrEmpty())
                props += string.Format("&start={0}", start);
            if (!end.IsNullOrEmpty())
                props += string.Format("&end={0}", end);
            if (!ofs.IsNullOrEmpty())
                props += string.Format("&ofs={0}", ofs);
            if (!closetime.IsNullOrEmpty())
                props += string.Format("&closetime={0}", closetime);

            string response = this.QueryPrivate("ClosedOrders", props);

            if (response.IsNullOrWhiteSpace())
                return null;

            ObjResult result = JsonConvert.DeserializeObject<ObjResult>(response);

            if (!result.Error.IsNullOrEmpty())
                return null;

            JProperty closed = (JProperty)result.Result.Children().First();

            if (closed.Name.ToLower() != "closed")
                return null;

            List <OrderInfo> list = new List<OrderInfo>();

            foreach (JProperty property in closed.Value.Children())
            {
                try
                {
                    OrderInfo info = JsonConvert.DeserializeObject<OrderInfo>(property.Value.ToString());

                    if (info == null)
                        continue;

                    info.ID = property.Name;
                    list.Add(info);
                }
                catch (Exception ex)
                {
                    ex.ToOutput();
                    continue;
                }
            }

            return list.ToArray();
        }

    }


  
}
