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

namespace Asmodat.PayPal
{
    public partial class PayPalManager
    {
        /// <summary>
        /// Initializes Context
        /// </summary>
        /// <param name="mode">true - live, flase - sandbox</param>
        public void InitializeContext(ApiProperties.ContextMode mode)
        {
            Config = new Dictionary<string, string>();
            Config.Add("mode", mode.GetEnumName());
            this.Token = new OAuthTokenCredential(this.ClientID, this.Secret, Config).GetAccessToken();
            Context = new APIContext(this.Token);
        }

        


        public PayPalManager(string ClientID, string Secret, ApiProperties.ContextMode mode)
        {
            
            this.ClientID = ClientID;
            this.Secret = Secret;

            this.InitializeContext(mode);

        }

        /// <summary>
        /// Send payment.GetApprovalUrl(); to user, to get aproval from him
        /// </summary>
        /// <returns></returns>
        public Payment CreatePayment()
        {
            RedirectUrls redirect_urls = new RedirectUrls();
            Transaction transaction = new Transaction();
            Amount amount = new Amount();
            Payer payer = new Payer();

            ApiProperties.PaymentIntent intent = ApiProperties.PaymentIntent.sale;
            ApiProperties.PaymentMethod payment_method = ApiProperties.PaymentMethod.paypal;
            ApiProperties.Currency curremcy = ApiProperties.Currency.USD;
            string description = "descriptiontest";
            decimal total = 1.1M;
            redirect_urls.return_url = @"https://www.google.pl/search?q=return";
            redirect_urls.cancel_url = @"https://www.google.pl/search?q=cancel";
            amount.currency = curremcy.GetEnumName();
            amount.total = string.Format("{0:0.00}",total);
            transaction.amount = amount;
            transaction.description = description;
            payer.payment_method = payment_method.GetEnumName();
         
            Payment payment = new Payment();
            payment.intent = intent.GetEnumName();
            payment.redirect_urls = redirect_urls;
            payment.payer = payer;
            payment.transactions = new List<Transaction>() { transaction };
          

            return payment.Create(this.Context);
        }


        public void ExecutePayment(Payment payment)
        {
            PaymentExecution exe = new PaymentExecution();

            payment = Payment.Get(this.Context, payment.id);
            exe.payer_id = payment.payer.payer_info.payer_id;

            payment = payment.Execute(this.Context, exe);
        }

        public void GetPaymentHistory()
        {
            try
            {

                PaymentHistory history = Payment.List(this.Context, count: 10);
                //Order.Get(, )

                /* PaymentHistory history = Payment.List(
                     this.Context, 100, null, null, null, null,
                     TickTime.Now.AddDays(2).ToRFC3339(), TickTime.Now.AddDays(-2).ToRFC3339());*/

               // history = null;
                //pp2 = null;
            }

            catch(Exception ex)
            {
                ex.ToOutput();
            }
        }


    }
}
