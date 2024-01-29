using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sporitelna.CustomControsl
{
    [DefaultEvent("_TextChanged")]
    public partial class SpTextBox1 : UserControl
    {
        //Constructor
        public SpTextBox1()
        {
            InitializeComponent();
        }

        //Fields
        private Color borderColor = Color.FromArgb(224, 224, 224);
        private int borderSize = 2;
        private bool underlinedStyle = false;
        private Color borderFocusColor = Color.FromArgb(255, 192, 128);
        private Color borderAimColor = Color.FromArgb(255, 224, 192);
        private bool isFocused = false;
        private bool isAimed = false;


        //Events
        public event EventHandler _TextChanged;

        //Properties
        [Category("Misc")]
        public Color BorderColor
        {
            get { return borderColor; }
            set
            {
                borderColor = value;
                this.Invalidate();
            }
        }
        [Category("Misc")]
        public int BorderSize
        {
            get { return borderSize; }
            set
            {
                borderSize = value;
                this.Invalidate();
            }
        }

        [Category("Misc")]
        public bool UnderlinedStyle
        {
            get { return underlinedStyle; }
            set
            {
                underlinedStyle = value;
                this.Invalidate();
            }
        }

        [Category("Misc")]
        public bool PasswordChar
        {
            get { return SpCustomTextBox.UseSystemPasswordChar; }
            set { SpCustomTextBox.UseSystemPasswordChar = value; }
        }

        [Category("Misc")]
        public bool Multiline
        {
            get { return SpCustomTextBox.Multiline; }
            set { SpCustomTextBox.Multiline = value; }
        }

        [Category("Misc")]
        public override Color BackColor
        {
            get { return base.BackColor; }
            set
            {
                base.BackColor = value;
                SpCustomTextBox.BackColor = value;
            }
        }

        [Category("Misc")]
        public override Color ForeColor
        {
            get { return base.ForeColor; }
            set
            {
                base.ForeColor = value;
                SpCustomTextBox.ForeColor = value;
            }
        }

        [Category("Misc")]
        public override Font Font
        {
            get { return base.Font; }
            set
            {
                base.Font = value;
                SpCustomTextBox.Font = value;
                if (this.DesignMode)
                    UpdateControlHeight();
            }
        }

        [Category("Misc")]
        public string Texts
        {
            get { return SpCustomTextBox.Text; }
            set { SpCustomTextBox.Text = value; }
        }

        [Category("Misc")]
        public Color BorderFocusColor
        {
            get { return borderFocusColor; }
            set { borderFocusColor = value; }
        }
        [Category("Misc")]
        public Color BorderAimColor
        {
            get { return borderAimColor; }
            set { borderAimColor = value; }
        }

        //Overridden methods

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics graph = e.Graphics;

            //Draw border
            using (Pen penBorder = new Pen(borderColor, borderSize))
            {
                penBorder.Alignment = System.Drawing.Drawing2D.PenAlignment.Inset;
                if (isFocused) penBorder.Color = borderFocusColor;
                if (isAimed && !isFocused) penBorder.Color = borderAimColor;

                if (underlinedStyle) //Line Style
                    graph.DrawLine(penBorder, 0, this.Height - 1, this.Width, this.Height - 1);
                else //Normal Style
                    graph.DrawRectangle(penBorder, 0, 0, this.Width, this.Height);//0.5F);

            }
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            if (this.DesignMode)
                UpdateControlHeight();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            UpdateControlHeight();
        }

        //Private methods
        private void UpdateControlHeight()
        {
            if (SpCustomTextBox.Multiline == false)
            {
                int txtHeight = TextRenderer.MeasureText("Text", this.Font).Height + 1;
                SpCustomTextBox.Multiline = true;
                SpCustomTextBox.MinimumSize = new Size(0, txtHeight);
                SpCustomTextBox.Multiline = false;

                this.Height = SpCustomTextBox.Height + this.Padding.Top + this.Padding.Bottom;
            }
        }

        //TextBox events
        private void SpCustomTextBox1_TextChanged(object sender, EventArgs e)
        {
            if (_TextChanged != null)
                _TextChanged.Invoke(sender, e);
        }

        private void SpCustomTextBox1_Click(object sender, EventArgs e)
        {
            this.OnClick(e);
        }

        private void SpCustomTextBox1_MouseEnter(object sender, EventArgs e)
        {
            this.OnMouseEnter(e);
        }

        private void SpCustomTextBox1_MouseLeave(object sender, EventArgs e)
        {
            this.OnMouseLeave(e);
            isAimed = false;
            this.Invalidate();
            //MessageBox.Show("False");
        }

        private void SpCustomTextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.OnKeyPress(e);
        }

        private void SpCustomTextBox1_Enter(object sender, EventArgs e)
        {
            isFocused = true;
            this.Invalidate();
        }

        private void SpCustomTextBox1_Leave(object sender, EventArgs e)
        {
            isFocused = false;
            this.Invalidate();
        }

        private void SpCustomTextBox1_MouseMove(object sender, MouseEventArgs e)
        {
            isAimed = true;
            this.Invalidate();
        }
    }
}
