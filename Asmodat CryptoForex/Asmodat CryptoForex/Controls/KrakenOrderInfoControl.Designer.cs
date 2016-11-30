namespace Asmodat_CryptoForex
{
    partial class KrakenOrderInfoControl
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
            this.TDgvOrdersInfo = new Asmodat.FormsControls.ThreadedDataGridView();
            this.SuspendLayout();
            // 
            // TDgvOrdersInfo
            // 
            this.TDgvOrdersInfo.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.TDgvOrdersInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TDgvOrdersInfo.Location = new System.Drawing.Point(0, 0);
            this.TDgvOrdersInfo.Name = "TDgvOrdersInfo";
            this.TDgvOrdersInfo.RowsEnumaration = true;
            this.TDgvOrdersInfo.Size = new System.Drawing.Size(717, 409);
            this.TDgvOrdersInfo.TabIndex = 0;
            // 
            // KrakenOrderInfoControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightBlue;
            this.Controls.Add(this.TDgvOrdersInfo);
            this.Name = "KrakenOrderInfoControl";
            this.Size = new System.Drawing.Size(717, 409);
            this.ResumeLayout(false);

        }

        #endregion

        private Asmodat.FormsControls.ThreadedDataGridView TDgvOrdersInfo;
    }
}
