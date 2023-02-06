
using NetworkCommsDotNet;

namespace HanabiServeur
{
    partial class IndexServeur
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(IndexServeur));
            this.lblNetworkInfo = new System.Windows.Forms.Label();
            this.grbNetwork = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.grbNetwork.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblNetworkInfo
            // 
            this.lblNetworkInfo.AutoSize = true;
            this.lblNetworkInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNetworkInfo.Location = new System.Drawing.Point(18, 28);
            this.lblNetworkInfo.Name = "lblNetworkInfo";
            this.lblNetworkInfo.Size = new System.Drawing.Size(70, 25);
            this.lblNetworkInfo.TabIndex = 0;
            this.lblNetworkInfo.Text = "label1";
            // 
            // grbNetwork
            // 
            this.grbNetwork.Controls.Add(this.lblNetworkInfo);
            this.grbNetwork.Location = new System.Drawing.Point(12, 46);
            this.grbNetwork.Name = "grbNetwork";
            this.grbNetwork.Size = new System.Drawing.Size(320, 151);
            this.grbNetwork.TabIndex = 1;
            this.grbNetwork.TabStop = false;
            this.grbNetwork.Text = "Information IP du serveur";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(194, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(138, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Historique des parties";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.ShowHistorique_Click);
            // 
            // IndexServeur
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(344, 209);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.grbNetwork);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "IndexServeur";
            this.Text = "Serveur";
            this.grbNetwork.ResumeLayout(false);
            this.grbNetwork.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblNetworkInfo;
        private System.Windows.Forms.GroupBox grbNetwork;
        private System.Windows.Forms.Button button1;
    }
}

