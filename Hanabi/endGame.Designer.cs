
namespace Hanabi
{
    partial class endGame
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
            this.label1 = new System.Windows.Forms.Label();
            this.lblText = new System.Windows.Forms.Label();
            this.pbxAnimation2 = new System.Windows.Forms.PictureBox();
            this.pbxAnimation1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbxAnimation2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxAnimation1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(226, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(244, 39);
            this.label1.TabIndex = 0;
            this.label1.Text = "Fin de la partie";
            // 
            // lblText
            // 
            this.lblText.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblText.Location = new System.Drawing.Point(226, 65);
            this.lblText.Name = "lblText";
            this.lblText.Size = new System.Drawing.Size(244, 81);
            this.lblText.TabIndex = 1;
            this.lblText.Text = "Félicitations vous avez fait XXX point";
            this.lblText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pbxAnimation2
            // 
            this.pbxAnimation2.Image = global::Hanabi.Properties.Resources.feuxArtifice;
            this.pbxAnimation2.Location = new System.Drawing.Point(476, 10);
            this.pbxAnimation2.Name = "pbxAnimation2";
            this.pbxAnimation2.Size = new System.Drawing.Size(208, 168);
            this.pbxAnimation2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbxAnimation2.TabIndex = 2;
            this.pbxAnimation2.TabStop = false;
            this.pbxAnimation2.Visible = false;
            // 
            // pbxAnimation1
            // 
            this.pbxAnimation1.Image = global::Hanabi.Properties.Resources.feuxArtifice;
            this.pbxAnimation1.Location = new System.Drawing.Point(12, 10);
            this.pbxAnimation1.Name = "pbxAnimation1";
            this.pbxAnimation1.Size = new System.Drawing.Size(208, 168);
            this.pbxAnimation1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbxAnimation1.TabIndex = 0;
            this.pbxAnimation1.TabStop = false;
            // 
            // endGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(694, 186);
            this.Controls.Add(this.lblText);
            this.Controls.Add(this.pbxAnimation2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pbxAnimation1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "endGame";
            this.Text = "endGame";
            ((System.ComponentModel.ISupportInitialize)(this.pbxAnimation2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxAnimation1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbxAnimation1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pbxAnimation2;
        private System.Windows.Forms.Label lblText;
    }
}