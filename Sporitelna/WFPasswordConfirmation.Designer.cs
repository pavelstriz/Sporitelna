
namespace Sporitelna
{
    partial class WFPasswordConfirmation
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
            this.txtConfirmPass1 = new Sporitelna.CustomControsl.SpTextBox1();
            this.SuspendLayout();
            // 
            // txtConfirmPass1
            // 
            this.txtConfirmPass1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtConfirmPass1.BackColor = System.Drawing.SystemColors.Window;
            this.txtConfirmPass1.BorderAimColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(176)))), ((int)(((byte)(0)))));
            this.txtConfirmPass1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(176)))), ((int)(((byte)(0)))));
            this.txtConfirmPass1.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(176)))), ((int)(((byte)(0)))));
            this.txtConfirmPass1.BorderSize = 2;
            this.txtConfirmPass1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.txtConfirmPass1.Location = new System.Drawing.Point(3, 4);
            this.txtConfirmPass1.Margin = new System.Windows.Forms.Padding(4);
            this.txtConfirmPass1.Multiline = false;
            this.txtConfirmPass1.Name = "txtConfirmPass1";
            this.txtConfirmPass1.Padding = new System.Windows.Forms.Padding(7);
            this.txtConfirmPass1.PasswordChar = true;
            this.txtConfirmPass1.Size = new System.Drawing.Size(133, 35);
            this.txtConfirmPass1.TabIndex = 9;
            this.txtConfirmPass1.Texts = "";
            this.txtConfirmPass1.UnderlinedStyle = false;
            // 
            // WFPasswordConfirmation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.ClientSize = new System.Drawing.Size(139, 42);
            this.ControlBox = false;
            this.Controls.Add(this.txtConfirmPass1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "WFPasswordConfirmation";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.WFPasswordConfirmation_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.WFPasswordConfirmation_KeyDown);
            this.ResumeLayout(false);

        }

        #endregion

        private Sporitelna.CustomControsl.SpTextBox1 txtConfirmPass1;
    }
}