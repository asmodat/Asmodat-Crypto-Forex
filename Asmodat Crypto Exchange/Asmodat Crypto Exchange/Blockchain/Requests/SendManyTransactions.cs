using Asmodat.Debugging;
using Asmodat.Networking;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Asmodat.Abbreviate;
using Asmodat.Extensions.Objects;
using Asmodat.Blockchain.API;

namespace Asmodat.Blockchain
{
    public partial class BlockchainManager
    {

        /// <summary>
        /// $main_password Your Main My wallet password
        /// $second_password Your second My Wallet password if double encryption is enabled.
        /// $recipients Is a JSON Object using Bitcoin Addresses as keys and the amounts to send as values (See below).
        /// $fee Transaction fee value in satoshi(Must be greater than default fee) (Optional)
        /// https://blockchain.info/merchant/$guid/sendmany?password=$main_password&second_password=$second_password&recipients=$recipients&fee=$fee
        /// </summary>
        public string GetRequestURL_SendManyTransactions(KeyValuePair<string, long>[] recipients, long? fee = null)
        {
            if (recipients == null || recipients.Length <= 0)
                    throw new ArgumentException(string.Format("SendManyTransactions: No recipients specified."));


            string frecipients = null;


            for (int i = 0; i < recipients.Length; i++)
            {
                string to = recipients[i].Key;
                long amount = recipients[i].Value;

                if (to.IsNullOrWhiteSpace() || amount <= 0)
                    throw new ArgumentException(string.Format("SendManyTransactions: Inavlid recipient adress: {0}, or insufficient amount {1}", to, amount));

                frecipients += string.Format("\"{0}\": {1}", to, amount);

                if (recipients.Length < recipients.Length - 1)
                    frecipients += ",";
            }

            frecipients = "{" + frecipients + "}";


            string fresult;
            string fsecondpass;
            string ffee;

            if (!PasswordSecond.IsNullOrWhiteSpace())
                fsecondpass = string.Format(@"&second_password={0}", PasswordSecond);
            else fsecondpass = null;

            if (fee != null && fee.Value > 0)
                ffee = string.Format(@"&fee=", fee.Value);
            else ffee = null;


            fresult = string.Format(@"https://blockchain.info/merchant/{0}/sendmany?password={1}&second_password={2}&recipients={3}{4}", 
            GUID, 
            PasswordMain,
            fsecondpass,
            frecipients,
            ffee
            );

            return fresult;
        }


        /// <summary>
        /// Send a transaction to multiple recipients in the same transaction.
        /// Rsponse: { "message" : "Response Message" , "tx_hash": "Transaction Hash" }
        /// https://blockchain.info/merchant/$guid/sendmany?password=$main_password&second_password=$second_password&recipients=$recipients&fee=$fee
        /// </summary>
        public ObjOutgoingPayment SendManyTransactions(KeyValuePair<string, long>[] recipients, long? fee = null)
        {
            try
            {
                string url = GetRequestURL_SendManyTransactions(recipients, fee);
                string data = this.Request(url);
                ObjOutgoingPayment obj = JsonConvert.DeserializeObject<ObjOutgoingPayment>(data);

                return obj;
            }
            catch(Exception ex)
            {
                ex.ToOutput();
                return new ObjOutgoingPayment() { error = ex.Message };
            }

        }
    }
}
