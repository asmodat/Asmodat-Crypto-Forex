using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

using PayPal;
using PayPal.Api;
using Asmodat.Debugging;

namespace Asmodat.PayPal
{
    public partial class PayPalManager
    {
        /// <summary>
        /// Live ID
        /// </summary>
        public string ClientID { get; private set; } = null;

        /// <summary>
        /// Live secret
        /// </summary>
        public string Secret { get; private set; } = null;


        public APIContext Context { get; private set; } = null;


        public string Token { get; private set; } = null;


        public Dictionary<string, string> Config { get; private set; } = null;


        /// <summary>
        /// Payment intent
        /// </summary>
        public enum PaymentIntent
        {
            /// <summary>
            /// immediate payment
            /// </summary>
            sale = 0, 
            /// <summary>
            ///  delayed payment to be captured at a later time
            /// </summary>
            authorize = 1,
            /// <summary>
            /// create order
            /// </summary>
            order = 2
        }

        /// <summary>
        /// Payment method used
        /// </summary>
        public enum PaymentMethod
        {
            paypal = 0,
            credit_card = 1
        }



    }
}
