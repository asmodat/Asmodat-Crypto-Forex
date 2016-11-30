using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Asmodat.IO;
using System.Security;
using Asmodat.Cryptography;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Asmodat_CryptoForex
{

    public partial class KrakenLoginControl : UserControl
    {
        public class LoginJson
        {
            [JsonProperty(PropertyName = "apikey")]
            public string APIKey { get; set; }

            [JsonProperty(PropertyName = "privatekey")]
            public string PrivateKey { get; set; }
        }


        public KrakenLoginControl()
        {
            InitializeComponent();
          //  TTbxAPIKey.Initialize(this);
          //  TTbxPrivateKey.Initialize(this);
        }

        private string Username { get; set; }
        private SecureString Password { get; set; }

        private JsonDataBase<KrakenLoginControl.LoginJson> Data { get; set; } = null;

        private string Key
        {
            get
            {
                return "KrakenLoginControl-" + this.Name + "-" + this.Username;
            }
        }

        private string Path
        {
            get
            {
                return @"\DataBase\" + this.Key;
            }
        }

        private KrakenLoginControl.LoginJson _DataJson;
        private KrakenLoginControl.LoginJson DataJson
        {
            get
            {
                _DataJson = Data.Get(this.Key);
                return _DataJson;
            }
            set
            {
                _DataJson = value;
                Data.Set(this.Key, _DataJson, true);
            }
        }

        public string APIKey
        {
            get
            {
                if (Data == null || DataJson == null) return null;
                return DataJson.APIKey;
            }
            private set
            {
                if (DataJson == null) DataJson = new LoginJson();
                DataJson.APIKey = value;
                DataJson = DataJson;
            }
        }

        public string PrivateKey
        {
            get
            {
                if (Data == null || DataJson == null) return null;
                return DataJson.PrivateKey;
            }
            private set
            {
                if (DataJson == null) DataJson = new LoginJson();
                DataJson.PrivateKey = value;
                DataJson = DataJson;
            }
        }


        public void Initialize(string Username, SecureString Password)
        {
            this.Username = Username;
            this.Password = Password;
            Data = new JsonDataBase<KrakenLoginControl.LoginJson>(@"\DataBase\" + Username, true, true, Password);
            this.TTbxAPIKey.Text = APIKey;
            this.TTbxPrivateKey.Text = PrivateKey;
        }
        
        

        private void BtnEditSave_Click(object sender, EventArgs e)
        {
            bool enabled = false;
            if (BtnEditSave.Text == "EDIT")
            {
                BtnEditSave.Text = "SAVE";
                enabled = true;
            }
            else if (BtnEditSave.Text == "SAVE")
            {
                BtnEditSave.Text = "EDIT";
                enabled = false;
                this.APIKey = TTbxAPIKey.Text;
                this.PrivateKey = TTbxPrivateKey.Text;
            }


            TTbxAPIKey.Enabled = enabled;
            TTbxPrivateKey.Enabled = enabled;
        }
    }
}
