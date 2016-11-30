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
using Asmodat.Types;
using Asmodat.PayPal.Api;

using Asmodat.Abbreviate;
using Asmodat.Extensions.Objects;

namespace Asmodat.PayPal
{
    public static class PayPalManagerSEx
    {
        public static bool IsCreated(this Payment payment)
        {
            if (payment != null && !payment.state.IsNullOrWhiteSpace() && payment.state.ToLowerInvariant() == "created")
                return true;

            return false;
        }
    }


        public partial class PayPalManager
    {
        /// <summary>
        /// Can be called using: payment.GetApprovalUrl();
        /// </summary>
        /// <param name="amount"></param>
        /// <param name="currency"></param>
        /// <param name="description"></param>
        /// <param name="returnURL"></param>
        /// <param name="cancelURL"></param>
        /// <returns></returns>
        public Payment RequestPayment(
            decimal amount, 
            ApiProperties.Currency currency, 
            string description,
            string returnURL, //@"https://www.google.pl/search?q=return"
            string cancelURL //@"https://www.google.pl/search?q=cancel"
            )
        {

            if (amount <= 0)
                return null;

            RedirectUrls redirect_urls = new RedirectUrls();
            Transaction transaction = new Transaction();
            Amount Amount = new Amount();
            Payer payer = new Payer();
            
            ApiProperties.PaymentIntent intent = ApiProperties.PaymentIntent.sale;
            ApiProperties.PaymentMethod payment_method = ApiProperties.PaymentMethod.paypal;


            redirect_urls.return_url = returnURL;
            redirect_urls.cancel_url = cancelURL;
            Amount.currency = currency.GetEnumName();
            Amount.total = string.Format("{0:0.00}", amount);
            transaction.amount = Amount;
            transaction.description = description;
            payer.payment_method = payment_method.GetEnumName();

            Payment payment = new Payment();
            payment.intent = intent.GetEnumName();
            payment.redirect_urls = redirect_urls;
            payment.payer = payer;
            payment.transactions = new List<Transaction>() { transaction };

            return payment.Create(this.Context);
        }
    }
}
