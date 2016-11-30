using Asmodat.Debugging;
using Asmodat.Networking;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Asmodat.Abbreviate;
using Asmodat.Blockchain.API;
using Asmodat.Extensions.Objects;

namespace Asmodat.Blockchain
{
    public partial class BlockchainManager
    {
        /// <summary>
        /// A public note to include with the transaction -- can only be attached when outputs are greater than 0.005 BTC. 
        /// </summary>
        public long PublicNoteOutputMinimum { get; private set; } = 5000001;

        /// <summary>
        /// All transactions include a 0.0001 BTC miners fee.
        /// </summary>
        public long TransactionMinersFee { get; private set; } = 10000;

        /// <summary>
        /// $main_password Your Main My wallet password
        /// $second_password Your second My Wallet password if double encryption is enabled.
        /// $to Recipient Bitcoin Address.
        /// $amount Amount to send in satoshi.
        /// $from Send from a specific Bitcoin Address (Optional)
        /// $fee Transaction fee value in satoshi(Must be greater than default fee) (Optional)
        /// $note A public note to include with the transaction -- can only be attached when outputs are greater than 0.005 BTC. (Optional)
        /// https://blockchain.info/merchant/$guid/payment?password=$main_password&second_password=$second_password&to=$address&amount=$amount&from=$from&fee=$fee&note=$note
        /// </summary>
        public string GetRequestURL_OutgoingPayment(string to, long amount, string from = null, long? fee = null, string note = null)
        {
            if (to.IsNullOrWhiteSpace() || amount <= 0)
                throw new ArgumentException(string.Format("OutgoingPayment: Inavlid recipient adress: {0}, or insufficient amount {1}", to, amount));


            if (amount < PublicNoteOutputMinimum)
                note = null;

            string fresult;
            string fsecondpass;
            string ffrom;
            string ffee;
            string fnote;

            if (!PasswordSecond.IsNullOrWhiteSpace())
                fsecondpass = string.Format(@"&second_password={0}", PasswordSecond);
            else fsecondpass = null;

            if (!from.IsNullOrWhiteSpace())
                ffrom = string.Format(@"&from=", from);
            else ffrom = null;

            if (fee != null && fee.Value > 0)
                ffee = string.Format(@"&fee=", fee.Value);
            else ffee = null;

            if (!note.IsNullOrWhiteSpace())
                fnote = string.Format(@"&note=", note);
            else fnote = null;


            fresult = string.Format(@"https://blockchain.info/merchant/{0}/payment?password={1}{2}&to={3}&amount={4}{5}{6}{7}", 
            GUID, 
            PasswordMain,
            fsecondpass,
            to,
            amount,
            ffrom,
            ffee,
            fnote
            );

            return fresult;
        }


        /// <summary>
        /// Send bitcoin from your wallet to another bitcoin address. All transactions include a 0.0001 BTC miners fee.
        /// Rsponse: { "message" : "Response Message" , "tx_hash": "Transaction Hash", "notice" : "Additional Message" }
        /// https://blockchain.info/merchant/$guid/payment?password=$main_password&second_password=$second_password&to=$address&amount=$amount&from=$from&fee=$fee&note=$note
        /// </summary>
        public ObjOutgoingPayment OutgoingPayment(string to, long amount, string from = null, long? fee = null, string note = null)
        {
            try
            {
                string url = GetRequestURL_OutgoingPayment(to, amount, from, fee, note);
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
