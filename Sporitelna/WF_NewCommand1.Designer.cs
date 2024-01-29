
namespace Sporitelna
{
    partial class WF_NewCommand1
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.rbWithdraw1 = new CustomControlsTest1.CustomControls.SpRadioButton();
            this.rbDeposit1 = new CustomControlsTest1.CustomControls.SpRadioButton();
            this.txtAmount1 = new Sporitelna.CustomControsl.SpTextBox1();
            this.label5 = new System.Windows.Forms.Label();
            this.txtBalance1 = new Sporitelna.CustomControsl.SpTextBox1();
            this.label4 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnPZStorno1 = new CustomControlsTest1.CustomControls.SpButton();
            this.btnPZSavePath = new CustomControlsTest1.CustomControls.SpButton();
            this.panel3 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.panel3, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.96928F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 87.03072F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 68F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(495, 330);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(83)))), ((int)(((byte)(164)))));
            this.panel1.Controls.Add(this.rbWithdraw1);
            this.panel1.Controls.Add(this.rbDeposit1);
            this.panel1.Controls.Add(this.txtAmount1);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.txtBalance1);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 33);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(495, 228);
            this.panel1.TabIndex = 0;
            // 
            // rbWithdraw1
            // 
            this.rbWithdraw1.AutoSize = true;
            this.rbWithdraw1.BackGroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(61)))), ((int)(((byte)(138)))));
            this.rbWithdraw1.CheckedColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(176)))), ((int)(((byte)(0)))));
            this.rbWithdraw1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.rbWithdraw1.ForeColor = System.Drawing.Color.White;
            this.rbWithdraw1.Location = new System.Drawing.Point(264, 109);
            this.rbWithdraw1.MinimumSize = new System.Drawing.Size(0, 21);
            this.rbWithdraw1.Name = "rbWithdraw1";
            this.rbWithdraw1.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.rbWithdraw1.Size = new System.Drawing.Size(94, 24);
            this.rbWithdraw1.TabIndex = 14;
            this.rbWithdraw1.Text = "Vybrat";
            this.rbWithdraw1.UnCheckedColor = System.Drawing.Color.White;
            this.rbWithdraw1.UseVisualStyleBackColor = true;
            this.rbWithdraw1.CheckedChanged += new System.EventHandler(this.RbWithdraw1_CheckedChanged);
            // 
            // rbDeposit1
            // 
            this.rbDeposit1.AutoSize = true;
            this.rbDeposit1.BackGroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(61)))), ((int)(((byte)(138)))));
            this.rbDeposit1.Checked = true;
            this.rbDeposit1.CheckedColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(176)))), ((int)(((byte)(0)))));
            this.rbDeposit1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.rbDeposit1.ForeColor = System.Drawing.Color.White;
            this.rbDeposit1.Location = new System.Drawing.Point(143, 109);
            this.rbDeposit1.MinimumSize = new System.Drawing.Size(0, 21);
            this.rbDeposit1.Name = "rbDeposit1";
            this.rbDeposit1.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.rbDeposit1.Size = new System.Drawing.Size(88, 24);
            this.rbDeposit1.TabIndex = 13;
            this.rbDeposit1.TabStop = true;
            this.rbDeposit1.Text = "Vložit";
            this.rbDeposit1.UnCheckedColor = System.Drawing.Color.White;
            this.rbDeposit1.UseVisualStyleBackColor = true;
            this.rbDeposit1.CheckedChanged += new System.EventHandler(this.RbDeposit1_CheckedChanged);
            // 
            // txtAmount1
            // 
            this.txtAmount1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAmount1.BackColor = System.Drawing.SystemColors.Window;
            this.txtAmount1.BorderAimColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.txtAmount1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtAmount1.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.txtAmount1.BorderSize = 2;
            this.txtAmount1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.txtAmount1.Location = new System.Drawing.Point(175, 165);
            this.txtAmount1.Margin = new System.Windows.Forms.Padding(4);
            this.txtAmount1.Multiline = false;
            this.txtAmount1.Name = "txtAmount1";
            this.txtAmount1.Padding = new System.Windows.Forms.Padding(7);
            this.txtAmount1.PasswordChar = false;
            this.txtAmount1.Size = new System.Drawing.Size(234, 35);
            this.txtAmount1.TabIndex = 12;
            this.txtAmount1.Texts = "";
            this.txtAmount1.UnderlinedStyle = false;
            this.txtAmount1._TextChanged += new System.EventHandler(this.TxtAmount1__TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(88, 172);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 20);
            this.label5.TabIndex = 11;
            this.label5.Text = "Částka:";
            // 
            // txtBalance1
            // 
            this.txtBalance1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBalance1.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtBalance1.BorderAimColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtBalance1.BorderColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtBalance1.BorderFocusColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtBalance1.BorderSize = 2;
            this.txtBalance1.Enabled = false;
            this.txtBalance1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.txtBalance1.Location = new System.Drawing.Point(175, 42);
            this.txtBalance1.Margin = new System.Windows.Forms.Padding(4);
            this.txtBalance1.Multiline = false;
            this.txtBalance1.Name = "txtBalance1";
            this.txtBalance1.Padding = new System.Windows.Forms.Padding(7);
            this.txtBalance1.PasswordChar = false;
            this.txtBalance1.Size = new System.Drawing.Size(234, 35);
            this.txtBalance1.TabIndex = 10;
            this.txtBalance1.Texts = "";
            this.txtBalance1.UnderlinedStyle = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(75, 48);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(86, 20);
            this.label4.TabIndex = 9;
            this.label4.Text = "Zůstatek:";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(176)))), ((int)(((byte)(0)))));
            this.panel2.Controls.Add(this.btnPZStorno1);
            this.panel2.Controls.Add(this.btnPZSavePath);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 261);
            this.panel2.Margin = new System.Windows.Forms.Padding(0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(495, 69);
            this.panel2.TabIndex = 1;
            // 
            // btnPZStorno1
            // 
            this.btnPZStorno1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPZStorno1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(213)))), ((int)(((byte)(50)))));
            this.btnPZStorno1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(213)))), ((int)(((byte)(50)))));
            this.btnPZStorno1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(83)))), ((int)(((byte)(164)))));
            this.btnPZStorno1.BorderRadius = 20;
            this.btnPZStorno1.BorderSize = 1;
            this.btnPZStorno1.FlatAppearance.BorderSize = 0;
            this.btnPZStorno1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPZStorno1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnPZStorno1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(83)))), ((int)(((byte)(178)))));
            this.btnPZStorno1.Location = new System.Drawing.Point(176, 11);
            this.btnPZStorno1.Name = "btnPZStorno1";
            this.btnPZStorno1.Size = new System.Drawing.Size(150, 51);
            this.btnPZStorno1.TabIndex = 17;
            this.btnPZStorno1.Text = "Zrušit";
            this.btnPZStorno1.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(83)))), ((int)(((byte)(178)))));
            this.btnPZStorno1.UseVisualStyleBackColor = false;
            this.btnPZStorno1.Click += new System.EventHandler(this.BtnPZStorno1_Click);
            // 
            // btnPZSavePath
            // 
            this.btnPZSavePath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPZSavePath.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(213)))), ((int)(((byte)(50)))));
            this.btnPZSavePath.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(213)))), ((int)(((byte)(50)))));
            this.btnPZSavePath.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(83)))), ((int)(((byte)(164)))));
            this.btnPZSavePath.BorderRadius = 20;
            this.btnPZSavePath.BorderSize = 1;
            this.btnPZSavePath.FlatAppearance.BorderSize = 0;
            this.btnPZSavePath.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPZSavePath.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnPZSavePath.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(83)))), ((int)(((byte)(178)))));
            this.btnPZSavePath.Location = new System.Drawing.Point(332, 11);
            this.btnPZSavePath.Name = "btnPZSavePath";
            this.btnPZSavePath.Size = new System.Drawing.Size(150, 51);
            this.btnPZSavePath.TabIndex = 16;
            this.btnPZSavePath.Text = "Ok";
            this.btnPZSavePath.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(83)))), ((int)(((byte)(178)))));
            this.btnPZSavePath.UseVisualStyleBackColor = false;
            this.btnPZSavePath.Click += new System.EventHandler(this.BtnPZSavePath_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(176)))), ((int)(((byte)(0)))));
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Margin = new System.Windows.Forms.Padding(0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(495, 33);
            this.panel3.TabIndex = 2;
            // 
            // WF_NewCommand1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(495, 330);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "WF_NewCommand1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Příkaz";
            this.Load += new System.EventHandler(this.WF_NewCommand1_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private Sporitelna.CustomControsl.SpTextBox1 txtAmount1;
        private System.Windows.Forms.Label label5;
        private Sporitelna.CustomControsl.SpTextBox1 txtBalance1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel2;
        private CustomControlsTest1.CustomControls.SpButton btnPZStorno1;
        private CustomControlsTest1.CustomControls.SpButton btnPZSavePath;
        private System.Windows.Forms.Panel panel3;
        private CustomControlsTest1.CustomControls.SpRadioButton rbWithdraw1;
        private CustomControlsTest1.CustomControls.SpRadioButton rbDeposit1;
    }
}