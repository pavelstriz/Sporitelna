
namespace Sporitelna
{
    partial class WF_NewContract1
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtNContractCompany = new Sporitelna.CustomControsl.SpTextBox1();
            this.label11 = new System.Windows.Forms.Label();
            this.txtNContractUserFullname = new Sporitelna.CustomControsl.SpTextBox1();
            this.txtNContractDescription = new System.Windows.Forms.RichTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtNContractUserId = new Sporitelna.CustomControsl.SpTextBox1();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.SpDateTimePicker2 = new Sporitelna.CustomControls.SpDateTimePicker();
            this.cbNContractInterestRate = new Sporitelna.CustomControls.SpComboBox();
            this.cbNContractCurrency = new Sporitelna.CustomControls.SpComboBox();
            this.cbNContractType = new Sporitelna.CustomControls.SpComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtNContractId = new System.Windows.Forms.Label();
            this.txtNContractInitialAmount = new Sporitelna.CustomControsl.SpTextBox1();
            this.label1 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnNContractStorno1 = new CustomControlsTest1.CustomControls.SpButton();
            this.btnNContractCreate1 = new CustomControlsTest1.CustomControls.SpButton();
            this.panel3 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.panel3, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 33F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 68F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(960, 526);
            this.tableLayoutPanel1.TabIndex = 20;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(83)))), ((int)(((byte)(164)))));
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 33);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(960, 425);
            this.panel1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.txtNContractCompany);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.txtNContractUserFullname);
            this.groupBox1.Controls.Add(this.txtNContractDescription);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtNContractUserId);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(484, 22);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(442, 371);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Zaměstnanec";
            // 
            // txtNContractCompany
            // 
            this.txtNContractCompany.BackColor = System.Drawing.SystemColors.Window;
            this.txtNContractCompany.BorderAimColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.txtNContractCompany.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtNContractCompany.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.txtNContractCompany.BorderSize = 2;
            this.txtNContractCompany.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.txtNContractCompany.Location = new System.Drawing.Point(157, 175);
            this.txtNContractCompany.Margin = new System.Windows.Forms.Padding(4);
            this.txtNContractCompany.Multiline = false;
            this.txtNContractCompany.Name = "txtNContractCompany";
            this.txtNContractCompany.Padding = new System.Windows.Forms.Padding(7);
            this.txtNContractCompany.PasswordChar = false;
            this.txtNContractCompany.Size = new System.Drawing.Size(251, 35);
            this.txtNContractCompany.TabIndex = 8;
            this.txtNContractCompany.Texts = "";
            this.txtNContractCompany.UnderlinedStyle = false;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.label11.ForeColor = System.Drawing.Color.White;
            this.label11.Location = new System.Drawing.Point(32, 244);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(101, 20);
            this.label11.TabIndex = 9;
            this.label11.Text = "Poznámka:";
            // 
            // txtNContractUserFullname
            // 
            this.txtNContractUserFullname.BackColor = System.Drawing.SystemColors.Window;
            this.txtNContractUserFullname.BorderAimColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.txtNContractUserFullname.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtNContractUserFullname.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.txtNContractUserFullname.BorderSize = 2;
            this.txtNContractUserFullname.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.txtNContractUserFullname.Location = new System.Drawing.Point(209, 111);
            this.txtNContractUserFullname.Margin = new System.Windows.Forms.Padding(4);
            this.txtNContractUserFullname.Multiline = false;
            this.txtNContractUserFullname.Name = "txtNContractUserFullname";
            this.txtNContractUserFullname.Padding = new System.Windows.Forms.Padding(7);
            this.txtNContractUserFullname.PasswordChar = false;
            this.txtNContractUserFullname.Size = new System.Drawing.Size(198, 35);
            this.txtNContractUserFullname.TabIndex = 7;
            this.txtNContractUserFullname.Texts = "";
            this.txtNContractUserFullname.UnderlinedStyle = false;
            // 
            // txtNContractDescription
            // 
            this.txtNContractDescription.Location = new System.Drawing.Point(36, 272);
            this.txtNContractDescription.Name = "txtNContractDescription";
            this.txtNContractDescription.Size = new System.Drawing.Size(371, 64);
            this.txtNContractDescription.TabIndex = 9;
            this.txtNContractDescription.Text = "";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(31, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(120, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Osobní číslo:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(31, 118);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(160, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Jméno a příjmení:";
            // 
            // txtNContractUserId
            // 
            this.txtNContractUserId.BackColor = System.Drawing.SystemColors.Window;
            this.txtNContractUserId.BorderAimColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.txtNContractUserId.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtNContractUserId.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.txtNContractUserId.BorderSize = 2;
            this.txtNContractUserId.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.txtNContractUserId.Location = new System.Drawing.Point(169, 48);
            this.txtNContractUserId.Margin = new System.Windows.Forms.Padding(4);
            this.txtNContractUserId.Multiline = false;
            this.txtNContractUserId.Name = "txtNContractUserId";
            this.txtNContractUserId.Padding = new System.Windows.Forms.Padding(7);
            this.txtNContractUserId.PasswordChar = false;
            this.txtNContractUserId.Size = new System.Drawing.Size(239, 35);
            this.txtNContractUserId.TabIndex = 6;
            this.txtNContractUserId.Texts = "";
            this.txtNContractUserId.UnderlinedStyle = false;
            this.txtNContractUserId._TextChanged += new System.EventHandler(this.TxtNContractUserId__TextChanged);
            this.txtNContractUserId.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtNContractUserId_KeyDown);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(31, 181);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(108, 20);
            this.label4.TabIndex = 3;
            this.label4.Text = "Společnost:";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.SpDateTimePicker2);
            this.groupBox2.Controls.Add(this.cbNContractInterestRate);
            this.groupBox2.Controls.Add(this.cbNContractCurrency);
            this.groupBox2.Controls.Add(this.cbNContractType);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.txtNContractId);
            this.groupBox2.Controls.Add(this.txtNContractInitialAmount);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.groupBox2.ForeColor = System.Drawing.Color.White;
            this.groupBox2.Location = new System.Drawing.Point(28, 22);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(442, 371);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Informace o smlouvě";
            // 
            // SpDateTimePicker2
            // 
            this.SpDateTimePicker2.BorderColor = System.Drawing.Color.Transparent;
            this.SpDateTimePicker2.BorderSize = 0;
            this.SpDateTimePicker2.CalendarTitleBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(176)))), ((int)(((byte)(0)))));
            this.SpDateTimePicker2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.SpDateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.SpDateTimePicker2.Location = new System.Drawing.Point(207, 299);
            this.SpDateTimePicker2.MinimumSize = new System.Drawing.Size(4, 30);
            this.SpDateTimePicker2.Name = "SpDateTimePicker2";
            this.SpDateTimePicker2.Size = new System.Drawing.Size(202, 30);
            this.SpDateTimePicker2.SkinColor = System.Drawing.Color.White;
            this.SpDateTimePicker2.TabIndex = 12;
            this.SpDateTimePicker2.TextColor = System.Drawing.Color.Black;
            // 
            // cbNContractInterestRate
            // 
            this.cbNContractInterestRate.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cbNContractInterestRate.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.cbNContractInterestRate.BorderSize = 1;
            this.cbNContractInterestRate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbNContractInterestRate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.cbNContractInterestRate.ForeColor = System.Drawing.Color.Black;
            this.cbNContractInterestRate.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(176)))), ((int)(((byte)(0)))));
            this.cbNContractInterestRate.Items.AddRange(new object[] {
            "21%",
            "15%"});
            this.cbNContractInterestRate.ListBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(228)))), ((int)(((byte)(245)))));
            this.cbNContractInterestRate.ListTextColor = System.Drawing.Color.DimGray;
            this.cbNContractInterestRate.Location = new System.Drawing.Point(88, 237);
            this.cbNContractInterestRate.Name = "cbNContractInterestRate";
            this.cbNContractInterestRate.Padding = new System.Windows.Forms.Padding(1);
            this.cbNContractInterestRate.Size = new System.Drawing.Size(89, 35);
            this.cbNContractInterestRate.TabIndex = 3;
            this.cbNContractInterestRate.Texts = "";
            // 
            // cbNContractCurrency
            // 
            this.cbNContractCurrency.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cbNContractCurrency.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.cbNContractCurrency.BorderSize = 1;
            this.cbNContractCurrency.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbNContractCurrency.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.cbNContractCurrency.ForeColor = System.Drawing.Color.Black;
            this.cbNContractCurrency.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(176)))), ((int)(((byte)(0)))));
            this.cbNContractCurrency.Items.AddRange(new object[] {
            "CZK",
            "EUR",
            "USD"});
            this.cbNContractCurrency.ListBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(228)))), ((int)(((byte)(245)))));
            this.cbNContractCurrency.ListTextColor = System.Drawing.Color.DimGray;
            this.cbNContractCurrency.Location = new System.Drawing.Point(299, 237);
            this.cbNContractCurrency.Name = "cbNContractCurrency";
            this.cbNContractCurrency.Padding = new System.Windows.Forms.Padding(1);
            this.cbNContractCurrency.Size = new System.Drawing.Size(110, 35);
            this.cbNContractCurrency.TabIndex = 4;
            this.cbNContractCurrency.Texts = "";
            // 
            // cbNContractType
            // 
            this.cbNContractType.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cbNContractType.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.cbNContractType.BorderSize = 1;
            this.cbNContractType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbNContractType.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.cbNContractType.ForeColor = System.Drawing.Color.Black;
            this.cbNContractType.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(176)))), ((int)(((byte)(0)))));
            this.cbNContractType.Items.AddRange(new object[] {
            "o spořícím účtu",
            "o zápůjčce"});
            this.cbNContractType.ListBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(228)))), ((int)(((byte)(245)))));
            this.cbNContractType.ListTextColor = System.Drawing.Color.DimGray;
            this.cbNContractType.Location = new System.Drawing.Point(168, 111);
            this.cbNContractType.Name = "cbNContractType";
            this.cbNContractType.Padding = new System.Windows.Forms.Padding(1);
            this.cbNContractType.Size = new System.Drawing.Size(241, 35);
            this.cbNContractType.TabIndex = 1;
            this.cbNContractType.Texts = "";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(233, 244);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(60, 20);
            this.label10.TabIndex = 10;
            this.label10.Text = "Měna:";
            // 
            // txtNContractId
            // 
            this.txtNContractId.AutoSize = true;
            this.txtNContractId.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.txtNContractId.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(176)))), ((int)(((byte)(0)))));
            this.txtNContractId.Location = new System.Drawing.Point(176, 55);
            this.txtNContractId.Name = "txtNContractId";
            this.txtNContractId.Size = new System.Drawing.Size(19, 20);
            this.txtNContractId.TabIndex = 8;
            this.txtNContractId.Text = "#";
            // 
            // txtNContractInitialAmount
            // 
            this.txtNContractInitialAmount.BackColor = System.Drawing.SystemColors.Window;
            this.txtNContractInitialAmount.BorderAimColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.txtNContractInitialAmount.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtNContractInitialAmount.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.txtNContractInitialAmount.BorderSize = 2;
            this.txtNContractInitialAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.txtNContractInitialAmount.Location = new System.Drawing.Point(195, 175);
            this.txtNContractInitialAmount.Margin = new System.Windows.Forms.Padding(4);
            this.txtNContractInitialAmount.Multiline = false;
            this.txtNContractInitialAmount.Name = "txtNContractInitialAmount";
            this.txtNContractInitialAmount.Padding = new System.Windows.Forms.Padding(7);
            this.txtNContractInitialAmount.PasswordChar = false;
            this.txtNContractInitialAmount.Size = new System.Drawing.Size(214, 35);
            this.txtNContractInitialAmount.TabIndex = 2;
            this.txtNContractInitialAmount.Texts = "";
            this.txtNContractInitialAmount.UnderlinedStyle = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(28, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(132, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Číslo smlouvy:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(28, 118);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(119, 20);
            this.label9.TabIndex = 7;
            this.label9.Text = "Typ smlouvy:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(28, 304);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(158, 20);
            this.label8.TabIndex = 6;
            this.label8.Text = "Datum splatnosti:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(28, 181);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(147, 20);
            this.label6.TabIndex = 5;
            this.label6.Text = "Počáteční vklad:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(28, 244);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(54, 20);
            this.label5.TabIndex = 4;
            this.label5.Text = "Úrok:";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(176)))), ((int)(((byte)(0)))));
            this.panel2.Controls.Add(this.btnNContractStorno1);
            this.panel2.Controls.Add(this.btnNContractCreate1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 458);
            this.panel2.Margin = new System.Windows.Forms.Padding(0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(960, 68);
            this.panel2.TabIndex = 1;
            // 
            // btnNContractStorno1
            // 
            this.btnNContractStorno1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNContractStorno1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(213)))), ((int)(((byte)(50)))));
            this.btnNContractStorno1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(213)))), ((int)(((byte)(50)))));
            this.btnNContractStorno1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(83)))), ((int)(((byte)(164)))));
            this.btnNContractStorno1.BorderRadius = 20;
            this.btnNContractStorno1.BorderSize = 1;
            this.btnNContractStorno1.FlatAppearance.BorderSize = 0;
            this.btnNContractStorno1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNContractStorno1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnNContractStorno1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(83)))), ((int)(((byte)(178)))));
            this.btnNContractStorno1.Location = new System.Drawing.Point(641, 10);
            this.btnNContractStorno1.Name = "btnNContractStorno1";
            this.btnNContractStorno1.Size = new System.Drawing.Size(150, 51);
            this.btnNContractStorno1.TabIndex = 11;
            this.btnNContractStorno1.Text = "Zrušit";
            this.btnNContractStorno1.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(83)))), ((int)(((byte)(178)))));
            this.btnNContractStorno1.UseVisualStyleBackColor = false;
            this.btnNContractStorno1.Click += new System.EventHandler(this.BtnNContractStorno1_Click);
            // 
            // btnNContractCreate1
            // 
            this.btnNContractCreate1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNContractCreate1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(213)))), ((int)(((byte)(50)))));
            this.btnNContractCreate1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(213)))), ((int)(((byte)(50)))));
            this.btnNContractCreate1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(83)))), ((int)(((byte)(164)))));
            this.btnNContractCreate1.BorderRadius = 20;
            this.btnNContractCreate1.BorderSize = 1;
            this.btnNContractCreate1.FlatAppearance.BorderSize = 0;
            this.btnNContractCreate1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNContractCreate1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnNContractCreate1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(83)))), ((int)(((byte)(178)))));
            this.btnNContractCreate1.Location = new System.Drawing.Point(797, 10);
            this.btnNContractCreate1.Name = "btnNContractCreate1";
            this.btnNContractCreate1.Size = new System.Drawing.Size(150, 51);
            this.btnNContractCreate1.TabIndex = 10;
            this.btnNContractCreate1.Text = "Vytvořit";
            this.btnNContractCreate1.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(83)))), ((int)(((byte)(178)))));
            this.btnNContractCreate1.UseVisualStyleBackColor = false;
            this.btnNContractCreate1.Click += new System.EventHandler(this.BtnNContractCreate1_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(176)))), ((int)(((byte)(0)))));
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Margin = new System.Windows.Forms.Padding(0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(960, 33);
            this.panel3.TabIndex = 2;
            // 
            // WF_NewContract1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(960, 526);
            this.Controls.Add(this.tableLayoutPanel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "WF_NewContract1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Nová smlouva";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.WF_NewContract1_FormClosing);
            this.Load += new System.EventHandler(this.WF_NewContract1_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private CustomControlsTest1.CustomControls.SpButton btnNContractStorno1;
        private CustomControlsTest1.CustomControls.SpButton btnNContractCreate1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label txtNContractId;
        private System.Windows.Forms.GroupBox groupBox2;
        private Sporitelna.CustomControsl.SpTextBox1 txtNContractInitialAmount;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private Sporitelna.CustomControsl.SpTextBox1 txtNContractUserId;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label10;
        private Sporitelna.CustomControsl.SpTextBox1 txtNContractUserFullname;
        private System.Windows.Forms.RichTextBox txtNContractDescription;
        private Sporitelna.CustomControsl.SpTextBox1 txtNContractCompany;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label8;
        private Sporitelna.CustomControls.SpComboBox cbNContractType;
        private Sporitelna.CustomControls.SpComboBox cbNContractCurrency;
        private Sporitelna.CustomControls.SpComboBox cbNContractInterestRate;
        private Sporitelna.CustomControls.SpDateTimePicker SpDateTimePicker2;
    }
}