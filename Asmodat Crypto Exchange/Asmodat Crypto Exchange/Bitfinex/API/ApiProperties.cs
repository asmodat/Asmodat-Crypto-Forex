using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.ComponentModel;

namespace Asmodat.BitfinexV1.API
{
    public class ApiProperties
    {
        //HTML Headers
        public const string ApiBfxApiKey = "X-BFX-APIKEY";
        public const string ApiBfxPayload = "X-BFX-PAYLOAD";
        public const string ApiBfxSignature = "X-BFX-SIGNATURE";

        //Unauthenticated Calls
        public const string TickerRequestUrl = @"/v1/pubticker";
        public const string StatsRequestUrl = @"/v1/stats";
        public const string LendbookRequestUrl = @"/v1/lendbook";
        public const string OrderbookRequestUrl = @"/v1/book";
        public const string TradesRequestUrl = @"/v1/trades";
        public const string LendsRequestUrl = @"/v1/lends";
        public const string SymbolsRequestUrl = @"/v1/symbols";
        public const string SymbolsDetailsRequestUrl = @"/v1/symbols_details";

        //Authenticated Calls
        public const string AccountInfosRequestUrl = @"/v1/account_infos";
        public const string NewDepositRequestUrl = @"/v1/deposit/new";
        public const string NewOrderRequestUrl = @"/v1/order/new";
        public const string MultipleNewOrdersRequestUrl = @"/v1/order/new/multi";
        public const string CancelOrderRequestUrl = @"/v1/order/cancel";
        public const string CancelMultipleOrdersRequestUrl = @"/v1/order/cancel/multi";
        public const string CancelAllActiveOrdersRequestUrl = @"/v1/order/cancel/all";
        public const string ReplaceOrderRequestUrl = @"/v1/order/cancel/replace";
        public const string OrderStatusRequestUrl = @"/v1/order/status";
        public const string ActiveOrdersRequestUrl = @"/v1/orders";
        public const string ActivePositionsRequestUrl = @"/v1/positions";
        public const string ClaimPositionRequestUrl = @"/v1/position/claim";
        public const string BalanceHistoryRequestUrl = @"/v1/history";

        /// <summary>
        /// DepositAndWithdrawlsHistoryRequestUrl
        /// </summary>
        public const string MovementsHistoryRequestUrl = @"/v1/history/movements";

        public const string PastTradesRequestUrl = @"/v1/mytrades";
        public const string NewOfferRequestUrl = @"/v1/offer/new";
        public const string CancelOfferRequestUrl = @"/v1/offer/cancel";
        public const string OfferStatusRequestUrl = @"/v1/offer/status";
        public const string ActiveOffersRequestUrl = @"/v1/offers";

        public const string ActiveCreditsRequestUrl = @"/v1/credits";
        public const string ActiveSwapsRequestUrl = @"/v1/taken_swaps";
        public const string TotalActiveSwapsRequestUrl = @"/v1/total_taken_swaps";
        public const string CloseSwapRequestUrl = @"/v1/swap/close";
        public const string WalletBalanceRequestUrl = @"/v1/balances";
        public const string MarginInfosRequestUrl = @"/v1/margin_infos";
        public const string TransferRequestUrl = @"/v1/transfer";
        public const string WithdrawalRequestUrl = @"/v1/withdraw";

       
        /// <summary>
        /// Base URL
        /// </summary>
        public const string BaseBitfinexUrl = @"https://api.bitfinex.com";

        /// <summary>
        /// Also known as pairs
        /// </summary>
        public enum Symbols
        {
            ltcbtc = 0,
            btcusd = 1,
            ltcusd = 2
        }


        public enum Directions
        {
            lend = 0,
            loan = 1,
        }

        public enum Currency
        {
            ltc = 0,
            btc = 1,
            usd = 2,
            drk = 3
        }

        public enum CurrencyName
        {
            bitcoin = 0,
            litecoin = 1,
            darkcoin = 2,
            mastercoin = 3
        }

        public enum Methods
        {
            bitcoin = 0,
            litecoin = 1,
            darkcoin = 2,
            wire = 3
        }


        public enum WalletName
        {
            trading = 0,
            exchange = 1,
            deposit = 2
        }

        public enum Exchange
        {
            bitfinex = 0
        }

        public enum OrderSide
        {
            buy = 0,
            sell = 1
        }

        public enum WithdrawType
        {
            bitcoin = 0,
            litecoin,
            darkcoin,
            tether
        }

        /// <summary>
        /// (type starting by "exchange " are exchange orders, others are margin trading orders)
        /// </summary>
        public enum OrderType
        {
            [Description("market")]
            market = 0,
            [Description("limit")]
            limit = 1,
            [Description("stop")]
            stop = 2,
            [Description("trailing-stop")]
            trailing_stop = 3,
            [Description("fill-or-kill")]
            fill_or_kill = 4,
            [Description("exchange market")]
            exchange_market = 5,
            [Description("exchange limit")]
            exchange_limit = 6,
            [Description("exchange stop")]
            exchange_stop = 7,
            [Description("exchange trailing-stop")]
            exchange_trailing_stop = 8,
            [Description("exchange fill-or-kill")]
            exchange_fill_or_kill = 9,
        }

        public enum OrderMarginType
        {
            [Description("market")]
            market = 0,
            [Description("limit")]
            limit = 1,
            [Description("stop")]
            stop = 2,
            [Description("trailing-stop")]
            trailing_stop = 3,
            [Description("fill-or-kill")]
            fill_or_kill = 4
        }

        public enum OrderExchangeType
        {
            [Description("exchange market")]
            exchange_market = 5,
            [Description("exchange limit")]
            exchange_limit = 6,
            [Description("exchange stop")]
            exchange_stop = 7,
            [Description("exchange trailing-stop")]
            exchange_trailing_stop = 8,
            [Description("exchange fill-or-kill")]
            exchange_fill_or_kill = 9,
        }
    }
}
