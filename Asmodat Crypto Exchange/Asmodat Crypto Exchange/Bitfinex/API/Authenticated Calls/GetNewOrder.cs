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

        public ObjNewOrder GetNewOrder(
            ApiProperties.Symbols symbol,
            decimal amount,
            decimal price,
            ApiProperties.Exchange exchange,
            ApiProperties.OrderSide side,
            ApiProperties.OrderType type)
        {

            return this.GetNewOrder(symbol.GetEnumName(), amount, price, exchange.GetEnumName(), side.GetEnumName(), type.GetEnumDescription());
        }

        /// <summary>
        /// Submit a new order.
        /// </summary>
        /// <param name="symbol">The name of the symbol (see `/symbols`).</param>
        /// <param name="amount">Order size: how much to buy or sell.</param>
        /// <param name="price">Price to buy or sell at. Must be positive. Use random number for market orders.</param>
        /// <param name="side"></param>
        /// <param name="type"></param>
        /// <param name="is_hidden"></param>
        /// <returns></returns>
        public ObjNewOrder GetNewOrder(
            string symbol,
            decimal amount,
            decimal price,
            string exchange,
            string side,
            string type)
        {

            ObjRequestNewOrder variable = new ObjRequestNewOrder(Nonce, symbol, amount, price, exchange, side, type);
            string response = this.Request(variable, "POST");

            ObjNewOrder result = JsonConvert.DeserializeObject<ObjNewOrder>(response);
            return result;
        }

       

    }
}
