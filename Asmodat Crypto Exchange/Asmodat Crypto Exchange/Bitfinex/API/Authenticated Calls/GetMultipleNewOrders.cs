using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

using Asmodat.BitfinexV1.API;
using Newtonsoft.Json;

using Asmodat.Abbreviate;
using Asmodat.Debugging;
using System.IO;

namespace Asmodat.BitfinexV1
{
    public partial class BitfinexManager
    {
        /// <summary>
        /// Submit several new orders at once.
        /// Important: You can not place more than 10 orders at once.
        /// The request is an array of the array containing the order options sent with the previous call /order/new. 
        /// </summary>
        /// <param name="orders"></param>
        /// <returns></returns>
        public ObjNewOrder[] GetMultipleNewOrders(ObjRequestOrder[] orders)
        {

            ObjRequestMultipleNewOrders variable = new ObjRequestMultipleNewOrders(Nonce, orders);
            string response = this.Request(variable, "POST");

            ObjNewOrder[] result = JsonConvert.DeserializeObject<ObjNewOrder[]>(response);
            return result;

        }


        public ObjRequestOrder GetObjRequestOrder(
            ApiProperties.Symbols symbol,
            decimal amount,
            decimal price,
            ApiProperties.Exchange exchange,
            ApiProperties.OrderSide side,
            ApiProperties.OrderType type)
        {
            return new ObjRequestOrder(symbol.GetEnumName(), amount, price, exchange.GetEnumName(), side.GetEnumName(), type.GetEnumDescription());
        }




    }
}
