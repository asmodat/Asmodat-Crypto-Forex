namespace Asmodat_CryptoForex
{
    partial class Form1
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.TbCntrlMain = new System.Windows.Forms.TabControl();
            this.TbPgKraken = new System.Windows.Forms.TabPage();
            this.TbCntrlKraken = new System.Windows.Forms.TabControl();
            this.TbPgKrakenStart = new System.Windows.Forms.TabPage();
            this.T2SBtnKrakenStartStop = new Asmodat.FormsControls.ThreadedTwoStateButton();
            this.TbPgKrakenEntries = new System.Windows.Forms.TabPage();
            this.TCmbxEntriesTimeFrame = new Asmodat.FormsControls.ThreadedComboBox();
            this.TCmbxEntriesCurrencyPair = new Asmodat.FormsControls.ThreadedComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.TbPgKrakenTrade = new System.Windows.Forms.TabPage();
            this.TbPgKrakenOrders = new System.Windows.Forms.TabPage();
            this.KrkLCntrlAuthentication = new Asmodat_CryptoForex.KrakenLoginControl();
            this.KrkECntrlEntries = new Asmodat_CryptoForex.Controls.KrakenEntriesControl();
            this.KrkCntrlTrade = new Asmodat_CryptoForex.KrakenTradeControl();
            this.KrkCntrlOrderInfoClosed = new Asmodat_CryptoForex.KrakenOrderInfoControl();
            this.TbCntrlMain.SuspendLayout();
            this.TbPgKraken.SuspendLayout();
            this.TbCntrlKraken.SuspendLayout();
            this.TbPgKrakenStart.SuspendLayout();
            this.TbPgKrakenEntries.SuspendLayout();
            this.TbPgKrakenTrade.SuspendLayout();
            this.TbPgKrakenOrders.SuspendLayout();
            this.SuspendLayout();
            // 
            // TbCntrlMain
            // 
            this.TbCntrlMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TbCntrlMain.Controls.Add(this.TbPgKraken);
            this.TbCntrlMain.Location = new System.Drawing.Point(12, 12);
            this.TbCntrlMain.Name = "TbCntrlMain";
            this.TbCntrlMain.SelectedIndex = 0;
            this.TbCntrlMain.Size = new System.Drawing.Size(936, 656);
            this.TbCntrlMain.TabIndex = 0;
            // 
            // TbPgKraken
            // 
            this.TbPgKraken.Controls.Add(this.TbCntrlKraken);
            this.TbPgKraken.Location = new System.Drawing.Point(4, 25);
            this.TbPgKraken.Name = "TbPgKraken";
            this.TbPgKraken.Padding = new System.Windows.Forms.Padding(3);
            this.TbPgKraken.Size = new System.Drawing.Size(928, 627);
            this.TbPgKraken.TabIndex = 0;
            this.TbPgKraken.Text = "Kraken";
            this.TbPgKraken.UseVisualStyleBackColor = true;
            // 
            // TbCntrlKraken
            // 
            this.TbCntrlKraken.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TbCntrlKraken.Controls.Add(this.TbPgKrakenStart);
            this.TbCntrlKraken.Controls.Add(this.TbPgKrakenEntries);
            this.TbCntrlKraken.Controls.Add(this.TbPgKrakenTrade);
            this.TbCntrlKraken.Controls.Add(this.TbPgKrakenOrders);
            this.TbCntrlKraken.Location = new System.Drawing.Point(6, 6);
            this.TbCntrlKraken.Name = "TbCntrlKraken";
            this.TbCntrlKraken.SelectedIndex = 0;
            this.TbCntrlKraken.Size = new System.Drawing.Size(916, 615);
            this.TbCntrlKraken.TabIndex = 1;
            // 
            // TbPgKrakenStart
            // 
            this.TbPgKrakenStart.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.TbPgKrakenStart.Controls.Add(this.T2SBtnKrakenStartStop);
            this.TbPgKrakenStart.Controls.Add(this.KrkLCntrlAuthentication);
            this.TbPgKrakenStart.Location = new System.Drawing.Point(4, 25);
            this.TbPgKrakenStart.Name = "TbPgKrakenStart";
            this.TbPgKrakenStart.Padding = new System.Windows.Forms.Padding(3);
            this.TbPgKrakenStart.Size = new System.Drawing.Size(908, 586);
            this.TbPgKrakenStart.TabIndex = 0;
            this.TbPgKrakenStart.Text = "Start";
            // 
            // T2SBtnKrakenStartStop
            // 
            this.T2SBtnKrakenStartStop.BackColor = System.Drawing.Color.Transparent;
            this.T2SBtnKrakenStartStop.BackColorNull = System.Drawing.Color.Empty;
            this.T2SBtnKrakenStartStop.BackColorOff = System.Drawing.Color.Empty;
            this.T2SBtnKrakenStartStop.BackColorOn = System.Drawing.Color.Empty;
            this.T2SBtnKrakenStartStop.EnabledBackColor = false;
            this.T2SBtnKrakenStartStop.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.T2SBtnKrakenStartStop.Location = new System.Drawing.Point(344, 397);
            this.T2SBtnKrakenStartStop.Name = "T2SBtnKrakenStartStop";
            this.T2SBtnKrakenStartStop.Off = false;
            this.T2SBtnKrakenStartStop.On = true;
            this.T2SBtnKrakenStartStop.Size = new System.Drawing.Size(230, 72);
            this.T2SBtnKrakenStartStop.TabIndex = 17;
            this.T2SBtnKrakenStartStop.Text = "START";
            this.T2SBtnKrakenStartStop.TextNull = "";
            this.T2SBtnKrakenStartStop.TextOff = "STOP";
            this.T2SBtnKrakenStartStop.TextOn = "START";
            this.T2SBtnKrakenStartStop.UseVisualStyleBackColor = false;
            // 
            // TbPgKrakenEntries
            // 
            this.TbPgKrakenEntries.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.TbPgKrakenEntries.Controls.Add(this.TCmbxEntriesTimeFrame);
            this.TbPgKrakenEntries.Controls.Add(this.TCmbxEntriesCurrencyPair);
            this.TbPgKrakenEntries.Controls.Add(this.label1);
            this.TbPgKrakenEntries.Controls.Add(this.label2);
            this.TbPgKrakenEntries.Controls.Add(this.KrkECntrlEntries);
            this.TbPgKrakenEntries.ForeColor = System.Drawing.Color.Transparent;
            this.TbPgKrakenEntries.Location = new System.Drawing.Point(4, 25);
            this.TbPgKrakenEntries.Name = "TbPgKrakenEntries";
            this.TbPgKrakenEntries.Size = new System.Drawing.Size(908, 586);
            this.TbPgKrakenEntries.TabIndex = 1;
            this.TbPgKrakenEntries.Text = "Entries";
            // 
            // TCmbxEntriesTimeFrame
            // 
            this.TCmbxEntriesTimeFrame.DisplayMode = Asmodat.FormsControls.ThreadedComboBox.Mode.Text;
            this.TCmbxEntriesTimeFrame.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.TCmbxEntriesTimeFrame.EnableTextAlign = true;
            this.TCmbxEntriesTimeFrame.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TCmbxEntriesTimeFrame.FormattingEnabled = true;
            this.TCmbxEntriesTimeFrame.Location = new System.Drawing.Point(312, 50);
            this.TCmbxEntriesTimeFrame.Name = "TCmbxEntriesTimeFrame";
            this.TCmbxEntriesTimeFrame.Size = new System.Drawing.Size(199, 33);
            this.TCmbxEntriesTimeFrame.TabIndex = 18;
            this.TCmbxEntriesTimeFrame.TextAlign = Asmodat.FormsControls.ThreadedComboBox.TextAlignType.Center;
            // 
            // TCmbxEntriesCurrencyPair
            // 
            this.TCmbxEntriesCurrencyPair.DisplayMode = Asmodat.FormsControls.ThreadedComboBox.Mode.Text;
            this.TCmbxEntriesCurrencyPair.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.TCmbxEntriesCurrencyPair.EnableTextAlign = true;
            this.TCmbxEntriesCurrencyPair.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TCmbxEntriesCurrencyPair.FormattingEnabled = true;
            this.TCmbxEntriesCurrencyPair.Location = new System.Drawing.Point(43, 50);
            this.TCmbxEntriesCurrencyPair.Name = "TCmbxEntriesCurrencyPair";
            this.TCmbxEntriesCurrencyPair.Size = new System.Drawing.Size(199, 33);
            this.TCmbxEntriesCurrencyPair.TabIndex = 17;
            this.TCmbxEntriesCurrencyPair.TextAlign = Asmodat.FormsControls.ThreadedComboBox.TextAlignType.Center;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(350, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 25);
            this.label1.TabIndex = 16;
            this.label1.Text = "Time Frame";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(72, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(131, 25);
            this.label2.TabIndex = 15;
            this.label2.Text = "Currency Pair";
            // 
            // TbPgKrakenTrade
            // 
            this.TbPgKrakenTrade.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.TbPgKrakenTrade.Controls.Add(this.KrkCntrlTrade);
            this.TbPgKrakenTrade.Location = new System.Drawing.Point(4, 25);
            this.TbPgKrakenTrade.Name = "TbPgKrakenTrade";
            this.TbPgKrakenTrade.Size = new System.Drawing.Size(908, 586);
            this.TbPgKrakenTrade.TabIndex = 2;
            this.TbPgKrakenTrade.Text = "Trade";
            // 
            // TbPgKrakenOrders
            // 
            this.TbPgKrakenOrders.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.TbPgKrakenOrders.Controls.Add(this.KrkCntrlOrderInfoClosed);
            this.TbPgKrakenOrders.Location = new System.Drawing.Point(4, 25);
            this.TbPgKrakenOrders.Name = "TbPgKrakenOrders";
            this.TbPgKrakenOrders.Size = new System.Drawing.Size(908, 586);
            this.TbPgKrakenOrders.TabIndex = 3;
            this.TbPgKrakenOrders.Text = "Orders";
            // 
            // KrkLCntrlAuthentication
            // 
            this.KrkLCntrlAuthentication.BackColor = System.Drawing.Color.LightBlue;
            this.KrkLCntrlAuthentication.Location = new System.Drawing.Point(159, 64);
            this.KrkLCntrlAuthentication.Name = "KrkLCntrlAuthentication";
            this.KrkLCntrlAuthentication.Size = new System.Drawing.Size(600, 300);
            this.KrkLCntrlAuthentication.TabIndex = 0;
            // 
            // KrkECntrlEntries
            // 
            this.KrkECntrlEntries.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.KrkECntrlEntries.BackColor = System.Drawing.Color.LightBlue;
            this.KrkECntrlEntries.Location = new System.Drawing.Point(18, 119);
            this.KrkECntrlEntries.Name = "KrkECntrlEntries";
            this.KrkECntrlEntries.Size = new System.Drawing.Size(864, 453);
            this.KrkECntrlEntries.TabIndex = 0;
            // 
            // KrkCntrlTrade
            // 
            this.KrkCntrlTrade.BackColor = System.Drawing.Color.LightBlue;
            this.KrkCntrlTrade.Location = new System.Drawing.Point(70, 68);
            this.KrkCntrlTrade.Name = "KrkCntrlTrade";
            this.KrkCntrlTrade.Size = new System.Drawing.Size(707, 413);
            this.KrkCntrlTrade.TabIndex = 1;
            // 
            // KrkCntrlOrderInfoClosed
            // 
            this.KrkCntrlOrderInfoClosed.BackColor = System.Drawing.Color.LightBlue;
            this.KrkCntrlOrderInfoClosed.Location = new System.Drawing.Point(33, 33);
            this.KrkCntrlOrderInfoClosed.Name = "KrkCntrlOrderInfoClosed";
            this.KrkCntrlOrderInfoClosed.Size = new System.Drawing.Size(717, 420);
            this.KrkCntrlOrderInfoClosed.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(960, 680);
            this.Controls.Add(this.TbCntrlMain);
            this.Name = "Form1";
            this.Text = "Asmodat CryptoForex";
            this.TbCntrlMain.ResumeLayout(false);
            this.TbPgKraken.ResumeLayout(false);
            this.TbCntrlKraken.ResumeLayout(false);
            this.TbPgKrakenStart.ResumeLayout(false);
            this.TbPgKrakenEntries.ResumeLayout(false);
            this.TbPgKrakenEntries.PerformLayout();
            this.TbPgKrakenTrade.ResumeLayout(false);
            this.TbPgKrakenOrders.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl TbCntrlMain;
        private System.Windows.Forms.TabPage TbPgKraken;
        private System.Windows.Forms.TabControl TbCntrlKraken;
        private System.Windows.Forms.TabPage TbPgKrakenStart;
        private KrakenLoginControl KrkLCntrlAuthentication;
        private Asmodat.FormsControls.ThreadedTwoStateButton T2SBtnKrakenStartStop;
        private System.Windows.Forms.TabPage TbPgKrakenEntries;
        private Controls.KrakenEntriesControl KrkECntrlEntries;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private Asmodat.FormsControls.ThreadedComboBox TCmbxEntriesTimeFrame;
        private Asmodat.FormsControls.ThreadedComboBox TCmbxEntriesCurrencyPair;
        private System.Windows.Forms.TabPage TbPgKrakenTrade;
        private KrakenTradeControl KrkCntrlTrade;
        private System.Windows.Forms.TabPage TbPgKrakenOrders;
        private KrakenOrderInfoControl KrkCntrlOrderInfoClosed;
    }
}

