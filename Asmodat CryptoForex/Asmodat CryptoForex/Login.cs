using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Asmodat.FormsControls;
using System.Threading;
using Asmodat.Abbreviate;using Asmodat.Extensions.Objects;

using Asmodat.Extensions.Drawing;
using System.Security;
using Asmodat.Cryptography;

namespace Asmodat_CryptoForex
{
    public partial class Form1 : Form
    {
        Form _AccessForm = new Form();
        LoginControl _AccessLogin = new LoginControl();
        public bool LoggedIn { get; set; } = false;

        public void ShowLoginWindows()
        {
            this.Visible = false;
            _AccessForm = new Form();
            _AccessForm.Controls.Add(_AccessLogin);
            _AccessForm.AutoSize = true;
            _AccessForm.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            _AccessForm.Show(this);

            _AccessLogin.Username = "Administrator";
            _AccessLogin.Password = "admin"; 
            //_AccessLogin.Anchor = (AnchorStyles)(1 | 2 | 4 | 8);
            _AccessLogin.LoginButton.Click += LoginButton_Click;

        }
        private SecureString Password { get; set; } = new SecureString();
        private string Username { get; set; } = "Administrator";

        private void LoginButton_Click(object sender, EventArgs e)
        {
            this.Password = new SecureString();
            this.Password = this.Password.Add(_AccessLogin.Password);

            this.Username = _AccessLogin.Username;
            _AccessForm.Dispose();
            this.Visible = true;
            LoggedIn = true;
            KrkLCntrlAuthentication.Initialize(this.Username, this.Password);
        }
    }
}
