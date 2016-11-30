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

namespace Asmodat.PayPal.Api
{
    public partial class ApiProperties
    {
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

        public enum Currency
        {
            USD = 0,
            EUR = 1

        }


        public enum ContextMode
        {
            sandbox = 0,
            live = 1
        }

    }
}
