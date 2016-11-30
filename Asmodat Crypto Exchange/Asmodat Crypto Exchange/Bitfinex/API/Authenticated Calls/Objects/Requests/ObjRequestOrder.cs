﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using Asmodat.Abbreviate;

namespace Asmodat.BitfinexV1.API
{
    public class ObjRequestOrder
    {
        public ObjRequestOrder(
            ApiProperties.Symbols symbol,
            decimal amount,
            decimal price,
            ApiProperties.Exchange exchange,
            ApiProperties.OrderSide side,
            ApiProperties.OrderType type)
        {
            this.symbol = symbol.GetEnumName();
            this.amount = amount.ToString();
            this.price = price.ToString();
            this.exchange = exchange.GetEnumName();
            this.side = side.GetEnumName();
            this.type = type.GetEnumDescription();
        }


        public ObjRequestOrder(
            string symbol,
            decimal amount,
            decimal price,
            string exchange,
            string side,
            string type)
        {
            this.symbol = symbol;
            this.amount = amount.ToString();
            this.price = price.ToString();
            this.exchange = exchange;
            this.side = side;
            this.type = type;
        }

        /// <summary>
        /// The name of the symbol (see `/symbols`).
        /// </summary>
        public string symbol { get; set; }
        /// <summary>
        /// Order size: how much to buy or sell.
        /// </summary>
        public string amount { get; set; }
        /// <summary>
        /// Price to buy or sell at. Must be positive. Use random number for market orders.
        /// </summary>
        public string price { get; set; }
        /// <summary>
        /// "bitfinex"
        /// </summary>
        public string exchange { get; set; }
        /// <summary>
        /// Either "buy" or "sell".
        /// </summary>
        public string side { get; set; }
        /// <summary>
        /// Either "market" / "limit" / "stop" / "trailing-stop" / "fill-or-kill" 
        /// </summary>
        public string type { get; set; }

    }
}


/*
public ObjRequestNewOrder(
            string nonce, 
            string symbol, 
            decimal amount, 
            decimal price, 
            string side, 
            string type, 
            bool is_hidden = false)
        {
            this.nonce = nonce;
            this.symbol = symbol;
            this.amount = amount;//.ToString();
            this.price = price;
            this.side = side;
            this.type = type;
            this.is_hidden = is_hidden;

            this.request = ApiProperties.NewOrderRequestUrl; 
        }

        /// <summary>
        /// The name of the symbol (see `/symbols`).
        /// </summary>
        public string symbol { get; set; }
        /// <summary>
        /// Order size: how much to buy or sell.
        /// </summary>
        public decimal amount { get; set; }
        /// <summary>
        /// Price to buy or sell at. Must be positive. Use random number for market orders.
        /// </summary>
        public decimal price { get; set; }
        /// <summary>
        /// "bitfinex"
        /// </summary>
        public string exchange { get; set; }
        /// <summary>
        /// Either "buy" or "sell".
        /// </summary>
        public string side { get; set; }
        /// <summary>
        /// Either "market" / "limit" / "stop" / "trailing-stop" / "fill-or-kill" / "exchange market" / "exchange limit" / "exchange stop" / "exchange trailing-stop" / "exchange fill-or-kill". (type starting by "exchange " are exchange orders, others are margin trading orders)
        /// </summary>
        public string type { get; set; }
        /// <summary>
        /// true if the order should be hidden. Default is false.
        /// </summary>
        public bool is_hidden { get; set; } = false;

*/
