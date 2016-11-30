namespace Asmodat_CryptoForex
{
    partial class KrakenLoginControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.TTbxAPIKey = new Asmodat.FormsControls.ThreadedTextBox();
            this.BtnEditSave = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.TTbxPrivateKey = new Asmodat.FormsControls.ThreadedTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // TTbxAPIKey
            // 
            this.TTbxAPIKey.AutoscrollFocusDisable = true;
            this.TTbxAPIKey.AutoscrollLeft = false;
            this.TTbxAPIKey.AutoscrollTop = false;
            this.TTbxAPIKey.DisplayMode = Asmodat.FormsControls.ThreadedTextBox.Mode.Text;
            this.TTbxAPIKey.Enabled = false;
            this.TTbxAPIKey.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TTbxAPIKey.Location = new System.Drawing.Point(27, 62);
            this.TTbxAPIKey.Name = "TTbxAPIKey";
            this.TTbxAPIKey.Size = new System.Drawing.Size(537, 30);
            this.TTbxAPIKey.TabIndex = 16;
            this.TTbxAPIKey.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TTbxAPIKey.UseSystemPasswordChar = true;
            // 
            // BtnEditSave
            // 
            this.BtnEditSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnEditSave.Location = new System.Drawing.Point(192, 204);
            this.BtnEditSave.Name = "BtnEditSave";
            this.BtnEditSave.Size = new System.Drawing.Size(216, 51);
            this.BtnEditSave.TabIndex = 15;
            this.BtnEditSave.Text = "EDIT";
            this.BtnEditSave.UseVisualStyleBackColor = true;
            this.BtnEditSave.Click += new System.EventHandler(this.BtnEditSave_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(248, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 25);
            this.label2.TabIndex = 14;
            this.label2.Text = "API Key";
            // 
            // TTbxPrivateKey
            // 
            this.TTbxPrivateKey.AutoscrollFocusDisable = true;
            this.TTbxPrivateKey.AutoscrollLeft = false;
            this.TTbxPrivateKey.AutoscrollTop = false;
            this.TTbxPrivateKey.DisplayMode = Asmodat.FormsControls.ThreadedTextBox.Mode.Text;
            this.TTbxPrivateKey.Enabled = false;
            this.TTbxPrivateKey.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TTbxPrivateKey.Location = new System.Drawing.Point(27, 139);
            this.TTbxPrivateKey.Name = "TTbxPrivateKey";
            this.TTbxPrivateKey.Size = new System.Drawing.Size(537, 30);
            this.TTbxPrivateKey.TabIndex = 18;
            this.TTbxPrivateKey.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TTbxPrivateKey.UseSystemPasswordChar = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(238, 111);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 25);
            this.label1.TabIndex = 17;
            this.label1.Text = "Private Key";
            // 
            // KrakenLoginControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightBlue;
            this.Controls.Add(this.TTbxPrivateKey);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TTbxAPIKey);
            this.Controls.Add(this.BtnEditSave);
            this.Controls.Add(this.label2);
            this.Name = "KrakenLoginControl";
            this.Size = new System.Drawing.Size(600, 300);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Asmodat.FormsControls.ThreadedTextBox TTbxAPIKey;
        private System.Windows.Forms.Button BtnEditSave;
        private System.Windows.Forms.Label label2;
        private Asmodat.FormsControls.ThreadedTextBox TTbxPrivateKey;
        private System.Windows.Forms.Label label1;
    }
}
