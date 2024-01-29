using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.ComponentModel;

namespace CustomControlsTest1.CustomControls
{
    [DefaultEvent("_MouseLeave")]

    public class SpToggleButton : CheckBox
    {
        //Fields
        
        private Color onBackColor = Color.FromArgb(249, 176, 0);
        private Color onToggleColor = Color.FromArgb(21, 61, 138);
        private Color offBackColor = Color.Gray;
        private Color offToggleColor = Color.FromArgb(249, 176, 0);

        private Color aimColor = Color.FromArgb(21, 61, 138);
        private bool isAimed = false;

        private bool solidStyle = true;
        

        //Properties
        [Category("Misc settings")]
        public Color OnBackColor
        {
            get { return onBackColor; }
            set
            {
                onBackColor = value;
                this.Invalidate();
            }
        }
        [Category("Misc settings")]
        public Color OnToggleColor
        {
            get { return onToggleColor; }
            set
            {
                onToggleColor = value;
                this.Invalidate();
            }
        }
        [Category("Misc settings")]
        public Color OffBackColor
        {
            get { return offBackColor; }
            set
            {
                offBackColor = value;
                this.Invalidate();
            }
        }
        [Category("Misc settings")]
        public Color OffToggleColor
        {
            get { return offToggleColor; }
            set
            {
                offToggleColor = value;
                this.Invalidate();
            }
        }
        [Category("Misc settings")]
        public Color AimColor
        {
            get { return aimColor; }
            set { aimColor = value; }
        }
        [Browsable(false)]
        public override string Text
        {
            get { return base.Text; }
            set { }
        }
        [Category("Misc settings")]
        [DefaultValue(true)]
        public bool SolidStyle
        {
            get { return solidStyle; }
            set
            {
                solidStyle = value;
                this.Invalidate();
            }
        }
        public SpToggleButton()
        {
            this.MinimumSize = new Size(50, 20);
            this.MouseEnter += new EventHandler(SpCustomTextBox1_MouseEnter);
            this.MouseLeave += new EventHandler(SpToggleButton_MouseLeave);
            
        }
        //Methods
        private GraphicsPath GetFigurePath()
        {
            int arcSize = this.Height - 1;
            Rectangle leftArc = new Rectangle(0, 0, arcSize, arcSize);
            Rectangle rightArc = new Rectangle(this.Width - arcSize - 2, 0, arcSize, arcSize);
            GraphicsPath path = new GraphicsPath();
            path.StartFigure();
            path.AddArc(leftArc, 90, 180);
            path.AddArc(rightArc, 270, 180);
            path.CloseFigure();
            return path;
        }
        
        protected override void OnPaint(PaintEventArgs pevent)
        {
            int toggleSize = this.Height - 5;
            pevent.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            pevent.Graphics.Clear(this.Parent.BackColor);
            if (this.Checked) //ON
            {
                //Draw the control surface
                if (solidStyle)
                    pevent.Graphics.FillPath(new SolidBrush(onBackColor), GetFigurePath());
                else pevent.Graphics.DrawPath(new Pen(onBackColor, 2), GetFigurePath());
                //Draw the toggle
                pevent.Graphics.FillEllipse(new SolidBrush(onToggleColor),
                  new Rectangle(this.Width - this.Height + 1, 2, toggleSize, toggleSize));
            }
            else //OFF
            {
                //Draw the control surface
                if (solidStyle)
                    pevent.Graphics.FillPath(new SolidBrush(offBackColor), GetFigurePath());
                else pevent.Graphics.DrawPath(new Pen(offBackColor, 2), GetFigurePath());
                //Draw the toggle
                pevent.Graphics.FillEllipse(new SolidBrush(offToggleColor),
                  new Rectangle(2, 2, toggleSize, toggleSize));
            }
            if (isAimed)
            {
                if (!this.Checked)
                {
                    //pevent.Graphics.DrawPath(new Pen(aimColor, 1), GetFigurePath());
                    pevent.Graphics.FillPath(new SolidBrush(ColorBrightness.ChangeColorBrightness(Color.Gray, 0.1f)), GetFigurePath());

                    pevent.Graphics.FillEllipse(new SolidBrush(offToggleColor),
                      new Rectangle(2, 2, toggleSize, toggleSize));
                }
                else
                {
                    pevent.Graphics.FillPath(new SolidBrush(ColorBrightness.ChangeColorBrightness(Color.FromArgb(249, 176, 0), -0.08f)), GetFigurePath());
                    
                    pevent.Graphics.DrawPath(new Pen(offBackColor, 0), GetFigurePath()); //BORDER COLOR

                    pevent.Graphics.FillEllipse(new SolidBrush(onToggleColor),
                      new Rectangle(this.Width - this.Height + 1, 2, toggleSize, toggleSize));
                }
            }
            else
            {
                pevent.Graphics.DrawPath(new Pen(offBackColor, 0), GetFigurePath());
            }
        }

        //Events
        public event EventHandler _MouseEnter;
        public event EventHandler _MouseLeave;
        private void SpCustomTextBox1_MouseEnter(object sender, EventArgs e)
        {
            if(_MouseEnter != null)
            _MouseEnter.Invoke(sender, e);

            isAimed = true;
            this.Invalidate();
        }
        private void SpToggleButton_MouseLeave(object sender, EventArgs e)
        {
            if (_MouseLeave != null)
                _MouseLeave.Invoke(sender, e);

            isAimed = false;
            this.Invalidate();
            //this.OnMouseEnter(e);
        }

    }


}
