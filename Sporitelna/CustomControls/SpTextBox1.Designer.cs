
namespace Sporitelna.CustomControsl
{
    partial class SpTextBox1
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

        #region Kód vygenerovaný pomocí Návrháře komponent

        /// <summary> 
        /// Metoda vyžadovaná pro podporu Návrháře - neupravovat
        /// obsah této metody v editoru kódu.
        /// </summary>
        private void InitializeComponent()
        {
            this.SpCustomTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // SpCustomTextBox
            // 
            this.SpCustomTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.SpCustomTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SpCustomTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.5F);
            this.SpCustomTextBox.Location = new System.Drawing.Point(7, 7);
            this.SpCustomTextBox.Name = "SpCustomTextBox";
            this.SpCustomTextBox.Size = new System.Drawing.Size(216, 15);
            this.SpCustomTextBox.TabIndex = 0;
            this.SpCustomTextBox.Click += new System.EventHandler(this.SpCustomTextBox1_Click);
            this.SpCustomTextBox.TextChanged += new System.EventHandler(this.SpCustomTextBox1_TextChanged);
            this.SpCustomTextBox.Enter += new System.EventHandler(this.SpCustomTextBox1_Enter);
            this.SpCustomTextBox.Leave += new System.EventHandler(this.SpCustomTextBox1_Leave);
            this.SpCustomTextBox.MouseEnter += new System.EventHandler(this.SpCustomTextBox1_MouseEnter);
            this.SpCustomTextBox.MouseLeave += new System.EventHandler(this.SpCustomTextBox1_MouseLeave);
            this.SpCustomTextBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.SpCustomTextBox1_MouseMove);
            // 
            // SpTextBox1
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.Controls.Add(this.SpCustomTextBox);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "SpTextBox1";
            this.Padding = new System.Windows.Forms.Padding(7);
            this.Size = new System.Drawing.Size(230, 30);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox SpCustomTextBox;
    }
}
