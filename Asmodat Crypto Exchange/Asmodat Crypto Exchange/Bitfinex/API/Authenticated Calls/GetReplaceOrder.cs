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

        public ObjNewOrder GetReplaceOrder(
            int order_id,
            ApiProperties.Symbols symbol,
            decimal amount,
            decimal price,
            ApiProperties.Exchange exchange,
            ApiProperties.OrderSide side,
            ApiProperties.OrderType type)
        {

            return this.GetReplaceOrder(order_id, symbol.GetEnumName(), amount, price, exchange.GetEnumName(), side.GetEnumName(), type.GetEnumDescription());
        }

        /// <summary>
        /// Replace an orders with a new one.
        /// </summary>
        /// <param name="order_id">The order ID (to be replaced) given by `/order/new`.</param>
        /// <param name="symbol">The name of the symbol (see `/symbols`).</param>
        /// <param name="amount">Order size: how much to buy or sell.</param>
        /// <param name="price">Price to buy or sell at. May omit if a market order.</param>
        /// <param name="exchange">"bitfinex", "bitstamp", "all" (for no routing).</param>
        /// <param name="side">Either "buy" or "sell".</param>
        /// <param name="type">Either "market" / "limit" / "stop" / "trailing-stop" / "fill-or-kill" / "exchange market" / "exchange limit" / "exchange stop" / "exchange trailing-stop" / "exchange fill-or-kill". (type starting by "exchange " are exchange orders, others are margin trading orders)</param>
        /// <returns></returns>
        public ObjNewOrder GetReplaceOrder(
            int order_id,
            string symbol,
            decimal amount,
            decimal price,
            string exchange,
            string side,
            string type)
        {


            ObjRequestReplaceOrder variable = new ObjRequestReplaceOrder(Nonce, order_id, symbol, amount, price, exchange, side, type);
            string response = this.Request(variable, "POST");

            ObjNewOrder result = JsonConvert.DeserializeObject<ObjNewOrder>(response);
            return result;
        }

       

    }
}
