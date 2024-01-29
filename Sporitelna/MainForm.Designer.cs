
namespace Sporitelna
{
    partial class MainForm
    {
        /// <summary>
        /// Vyžaduje se proměnná návrháře.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Uvolněte všechny používané prostředky.
        /// </summary>
        /// <param name="disposing">hodnota true, když by se měl spravovaný prostředek odstranit; jinak false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kód generovaný Návrhářem Windows Form

        /// <summary>
        /// Metoda vyžadovaná pro podporu Návrháře - neupravovat
        /// obsah této metody v editoru kódu.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.souborToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tiskToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.konecToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zobrazitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nápovědaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tlpMain1 = new System.Windows.Forms.TableLayoutPanel();
            this.tblButtons = new System.Windows.Forms.TableLayoutPanel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnShowContracts1 = new CustomControlsTest1.CustomControls.SpButton();
            this.btnShowUsers1 = new CustomControlsTest1.CustomControls.SpButton();
            this.btnCommand1 = new CustomControlsTest1.CustomControls.SpButton();
            this.tlpTop1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCompany = new System.Windows.Forms.Label();
            this.txtDateTime = new System.Windows.Forms.Label();
            this.timeTick1 = new System.Windows.Forms.Timer(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.menuStrip1.SuspendLayout();
            this.tlpMain1.SuspendLayout();
            this.tblButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tlpTop1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.souborToolStripMenuItem,
            this.zobrazitToolStripMenuItem,
            this.nápovědaToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // souborToolStripMenuItem
            // 
            this.souborToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tiskToolStripMenuItem,
            this.konecToolStripMenuItem});
            this.souborToolStripMenuItem.Name = "souborToolStripMenuItem";
            this.souborToolStripMenuItem.Size = new System.Drawing.Size(57, 20);
            this.souborToolStripMenuItem.Text = "Soubor";
            // 
            // tiskToolStripMenuItem
            // 
            this.tiskToolStripMenuItem.Name = "tiskToolStripMenuItem";
            this.tiskToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.tiskToolStripMenuItem.Text = "Tisk";
            // 
            // konecToolStripMenuItem
            // 
            this.konecToolStripMenuItem.Name = "konecToolStripMenuItem";
            this.konecToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.konecToolStripMenuItem.Text = "Konec";
            // 
            // zobrazitToolStripMenuItem
            // 
            this.zobrazitToolStripMenuItem.Name = "zobrazitToolStripMenuItem";
            this.zobrazitToolStripMenuItem.Size = new System.Drawing.Size(62, 20);
            this.zobrazitToolStripMenuItem.Text = "Zobrazit";
            // 
            // nápovědaToolStripMenuItem
            // 
            this.nápovědaToolStripMenuItem.Name = "nápovědaToolStripMenuItem";
            this.nápovědaToolStripMenuItem.Size = new System.Drawing.Size(73, 20);
            this.nápovědaToolStripMenuItem.Text = "Nápověda";
            // 
            // tlpMain1
            // 
            this.tlpMain1.BackColor = System.Drawing.Color.White;
            this.tlpMain1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tlpMain1.ColumnCount = 1;
            this.tlpMain1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain1.Controls.Add(this.tblButtons, 0, 0);
            this.tlpMain1.Controls.Add(this.tlpTop1, 0, 1);
            this.tlpMain1.Controls.Add(this.panel1, 0, 2);
            this.tlpMain1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMain1.Location = new System.Drawing.Point(0, 24);
            this.tlpMain1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tlpMain1.Name = "tlpMain1";
            this.tlpMain1.RowCount = 4;
            this.tlpMain1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.5F));
            this.tlpMain1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4F));
            this.tlpMain1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 89.5F));
            this.tlpMain1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 21F));
            this.tlpMain1.Size = new System.Drawing.Size(800, 398);
            this.tlpMain1.TabIndex = 2;
            // 
            // tblButtons
            // 
            this.tblButtons.ColumnCount = 6;
            this.tblButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 32.54206F));
            this.tblButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 1.658195F));
            this.tblButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.10366F));
            this.tblButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.10366F));
            this.tblButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.10366F));
            this.tblButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 17.48877F));
            this.tblButtons.Controls.Add(this.pictureBox1, 0, 0);
            this.tblButtons.Controls.Add(this.btnShowContracts1, 3, 0);
            this.tblButtons.Controls.Add(this.btnShowUsers1, 2, 0);
            this.tblButtons.Controls.Add(this.btnCommand1, 4, 0);
            this.tblButtons.Dock = System.Windows.Forms.DockStyle.Left;
            this.tblButtons.Location = new System.Drawing.Point(3, 3);
            this.tblButtons.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tblButtons.Name = "tblButtons";
            this.tblButtons.RowCount = 1;
            this.tblButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblButtons.Size = new System.Drawing.Size(304, 20);
            this.tblButtons.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::Sporitelna.Properties.Resources.headerBors1;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(2, 2);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(94, 16);
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // btnShowContracts1
            // 
            this.btnShowContracts1.BackColor = System.Drawing.Color.White;
            this.btnShowContracts1.BackgroundColor = System.Drawing.Color.White;
            this.btnShowContracts1.BackgroundImage = global::Sporitelna.Properties.Resources.pbContract4;
            this.btnShowContracts1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnShowContracts1.BorderColor = System.Drawing.Color.Silver;
            this.btnShowContracts1.BorderRadius = 5;
            this.btnShowContracts1.BorderSize = 0;
            this.btnShowContracts1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnShowContracts1.FlatAppearance.BorderSize = 0;
            this.btnShowContracts1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnShowContracts1.ForeColor = System.Drawing.Color.Black;
            this.btnShowContracts1.Location = new System.Drawing.Point(151, 0);
            this.btnShowContracts1.Margin = new System.Windows.Forms.Padding(0);
            this.btnShowContracts1.Name = "btnShowContracts1";
            this.btnShowContracts1.Size = new System.Drawing.Size(48, 20);
            this.btnShowContracts1.TabIndex = 4;
            this.btnShowContracts1.TextColor = System.Drawing.Color.Black;
            this.btnShowContracts1.UseVisualStyleBackColor = false;
            // 
            // btnShowUsers1
            // 
            this.btnShowUsers1.BackColor = System.Drawing.Color.White;
            this.btnShowUsers1.BackgroundColor = System.Drawing.Color.White;
            this.btnShowUsers1.BackgroundImage = global::Sporitelna.Properties.Resources.pbUsers4;
            this.btnShowUsers1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnShowUsers1.BorderColor = System.Drawing.Color.Silver;
            this.btnShowUsers1.BorderRadius = 5;
            this.btnShowUsers1.BorderSize = 0;
            this.btnShowUsers1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnShowUsers1.FlatAppearance.BorderSize = 0;
            this.btnShowUsers1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnShowUsers1.ForeColor = System.Drawing.Color.Black;
            this.btnShowUsers1.Location = new System.Drawing.Point(103, 0);
            this.btnShowUsers1.Margin = new System.Windows.Forms.Padding(0);
            this.btnShowUsers1.Name = "btnShowUsers1";
            this.btnShowUsers1.Size = new System.Drawing.Size(48, 20);
            this.btnShowUsers1.TabIndex = 5;
            this.btnShowUsers1.TextColor = System.Drawing.Color.Black;
            this.btnShowUsers1.UseVisualStyleBackColor = false;
            this.btnShowUsers1.Paint += new System.Windows.Forms.PaintEventHandler(this.BtnShowUsers1_Paint);
            // 
            // btnCommand1
            // 
            this.btnCommand1.BackColor = System.Drawing.Color.White;
            this.btnCommand1.BackgroundColor = System.Drawing.Color.White;
            this.btnCommand1.BackgroundImage = global::Sporitelna.Properties.Resources.pbCorporateBank2;
            this.btnCommand1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnCommand1.BorderColor = System.Drawing.Color.White;
            this.btnCommand1.BorderRadius = 5;
            this.btnCommand1.BorderSize = 0;
            this.btnCommand1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnCommand1.FlatAppearance.BorderSize = 0;
            this.btnCommand1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCommand1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnCommand1.ForeColor = System.Drawing.Color.White;
            this.btnCommand1.Location = new System.Drawing.Point(199, 0);
            this.btnCommand1.Margin = new System.Windows.Forms.Padding(0);
            this.btnCommand1.Name = "btnCommand1";
            this.btnCommand1.Size = new System.Drawing.Size(48, 20);
            this.btnCommand1.TabIndex = 18;
            this.btnCommand1.TextColor = System.Drawing.Color.White;
            this.btnCommand1.UseVisualStyleBackColor = false;
            this.btnCommand1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // tlpTop1
            // 
            this.tlpTop1.BackColor = System.Drawing.Color.White;
            this.tlpTop1.ColumnCount = 3;
            this.tlpTop1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpTop1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpTop1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpTop1.Controls.Add(this.label1, 0, 0);
            this.tlpTop1.Controls.Add(this.txtCompany, 1, 0);
            this.tlpTop1.Controls.Add(this.txtDateTime, 2, 0);
            this.tlpTop1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpTop1.Location = new System.Drawing.Point(1, 26);
            this.tlpTop1.Margin = new System.Windows.Forms.Padding(0);
            this.tlpTop1.Name = "tlpTop1";
            this.tlpTop1.RowCount = 1;
            this.tlpTop1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpTop1.Size = new System.Drawing.Size(798, 14);
            this.tlpTop1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(11, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(11, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(253, 14);
            this.label1.TabIndex = 6;
            this.label1.Text = "Evidence půjček zaměstnanců";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtCompany
            // 
            this.txtCompany.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtCompany.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txtCompany.Location = new System.Drawing.Point(268, 0);
            this.txtCompany.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.txtCompany.Name = "txtCompany";
            this.txtCompany.Size = new System.Drawing.Size(262, 14);
            this.txtCompany.TabIndex = 5;
            this.txtCompany.Text = "BORS";
            this.txtCompany.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtDateTime
            // 
            this.txtDateTime.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtDateTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txtDateTime.Location = new System.Drawing.Point(534, 0);
            this.txtDateTime.Margin = new System.Windows.Forms.Padding(2, 0, 11, 0);
            this.txtDateTime.Name = "txtDateTime";
            this.txtDateTime.Size = new System.Drawing.Size(253, 14);
            this.txtDateTime.TabIndex = 4;
            this.txtDateTime.Text = "Datum";
            this.txtDateTime.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // timeTick1
            // 
            this.timeTick1.Tick += new System.EventHandler(this.TimeTick1_Tick);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(1, 41);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(798, 332);
            this.panel1.TabIndex = 1;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 422);
            this.Controls.Add(this.tlpMain1);
            this.Controls.Add(this.menuStrip1);
            this.DoubleBuffered = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Spořitelna";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tlpMain1.ResumeLayout(false);
            this.tblButtons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tlpTop1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem souborToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tiskToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem konecToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem zobrazitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nápovědaToolStripMenuItem;
        private System.Windows.Forms.TableLayoutPanel tlpMain1;
        private System.Windows.Forms.TableLayoutPanel tlpTop1;
        private System.Windows.Forms.Label txtDateTime;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label txtCompany;
        private System.Windows.Forms.Timer timeTick1;
        private System.Windows.Forms.TableLayoutPanel tblButtons;
        private System.Windows.Forms.PictureBox pictureBox1;
        private CustomControlsTest1.CustomControls.SpButton btnShowContracts1;
        private CustomControlsTest1.CustomControls.SpButton btnShowUsers1;
        private CustomControlsTest1.CustomControls.SpButton btnCommand1;
        public System.Windows.Forms.Panel panel1;
    }
}

