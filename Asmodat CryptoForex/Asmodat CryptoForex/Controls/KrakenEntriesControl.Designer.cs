namespace Asmodat_CryptoForex.Controls
{
    partial class KrakenEntriesControl
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
            this.TChartMain = new Asmodat.FormsControls.ThreadedChart();
            this.SuspendLayout();
            // 
            // TChartMain
            // 
            this.TChartMain.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.TChartMain.BackColor = System.Drawing.SystemColors.Desktop;
            this.TChartMain.Collisions = false;
            this.TChartMain.Cooridinates = false;
            this.TChartMain.Cursors = false;
            this.TChartMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TChartMain.ID = null;
            this.TChartMain.Location = new System.Drawing.Point(0, 0);
            this.TChartMain.Margin = new System.Windows.Forms.Padding(0);
            this.TChartMain.Name = "TChartMain";
            this.TChartMain.Size = new System.Drawing.Size(865, 511);
            this.TChartMain.TabIndex = 0;
            // 
            // KrakenEntriesControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightBlue;
            this.Controls.Add(this.TChartMain);
            this.Name = "KrakenEntriesControl";
            this.Size = new System.Drawing.Size(865, 511);
            this.ResumeLayout(false);

        }

        #endregion

        private Asmodat.FormsControls.ThreadedChart TChartMain;
    }
}
