using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
namespace CustomControlsTest1.CustomControls
{
    class SpRadioButton : RadioButton
    {


        //Fields
        private Color checkedColor = Color.FromArgb(249, 176, 0);
        private Color unCheckedColor = Color.White;

        private Color backGroundColor = Color.FromArgb(21, 61, 138);//White;
        private Color foreColor = Color.White;
        private bool isAimed = false;

        //Properties
        public Color BackGroundColor
        {
            get { return backGroundColor; }
            set
            {
                backGroundColor = value;
                this.Invalidate();
            }
        }
        public Color CheckedColor
        {
            get { return checkedColor; }
            set
            {
                checkedColor = value;
                this.Invalidate();
            }
        }
        public Color UnCheckedColor
        {
            get { return unCheckedColor; }
            set
            {
                unCheckedColor = value;
                this.Invalidate();
            }
        }
        //Constructor
        public SpRadioButton()
        {
            this.MinimumSize = new Size(0, 21);
            //Add a padding of 10 to the left to have a considerable distance between the text and the RadioButton.
            this.Padding = new Padding(10, 0, 0, 0);
            this.ForeColor = foreColor;

            this.MouseEnter += new EventHandler(SpCustomTextBox1_MouseEnter);
            this.MouseLeave += new EventHandler(SpToggleButton_MouseLeave);
        }

        //Overridden methods
        protected override void OnPaint(PaintEventArgs pevent)
        {
            //Fields
            Graphics graphics = pevent.Graphics;
            graphics.SmoothingMode = SmoothingMode.AntiAlias;
            float rbBorderSize = 14F;
            float rbCheckSize = 8F;
            float rbBackgroundSize = 14;
            RectangleF rectRbBorder = new RectangleF()
            {
                X = 0.5F,
                Y = (this.Height - rbBorderSize) / 2, //Center
                Width = rbBorderSize,
                Height = rbBorderSize
            };
            RectangleF rectRbCheck = new RectangleF()
            {
                X = rectRbBorder.X + ((rectRbBorder.Width - rbCheckSize) / 2), //Center
                Y = (this.Height - rbCheckSize) / 2, //Center
                Width = rbCheckSize,
                Height = rbCheckSize
            };
            RectangleF rectRbBackground = new RectangleF()
            {
                X = 0.5F,
                Y = (this.Height - rbBackgroundSize) / 2, //Center
                Width = rbBackgroundSize,
                Height = rbBackgroundSize - 0.1f
            };
            //Drawing
            Pen penBorder = new Pen(checkedColor, 1.6F);
            SolidBrush brushRbBackground = new SolidBrush(checkedColor);
            SolidBrush brushRbCheck = new SolidBrush(checkedColor);
            SolidBrush brushText = new SolidBrush(this.ForeColor);
            
                //Draw surface
                graphics.Clear(this.BackColor);
            //Draw Radio Button
            if (this.Checked)
            {
                
                graphics.DrawEllipse(penBorder, rectRbBorder);//Circle border
                graphics.FillEllipse(brushRbCheck, rectRbCheck); //Circle Radio Check
            }
            else
            {
                //brushRbBackground.Color = backGroundColor;
                //graphics.FillEllipse(brushRbBackground, rectRbBackground); //Circle Radio Check



                penBorder.Color = unCheckedColor;
                graphics.DrawEllipse(penBorder, rectRbBorder); //Circle border
            }

                //Draw text
                graphics.DrawString(this.Text, this.Font, brushText,
                    rbBorderSize + 8, (this.Height - TextRenderer.MeasureText(this.Text, this.Font).Height) / 2);//Y=Center

            if (isAimed)
            {
                if (this.Checked)
                {
                    

                    //graphics.DrawEllipse(penBorder, rectRbBorder);//Circle border
                    //graphics.FillEllipse(brushRbCheck, rectRbCheck); //Circle Radio Check
                }
                else
                {
                    brushRbBackground.Color = ColorBrightness.ChangeColorBrightness(backGroundColor, 0.1f); //0.02
                    graphics.FillEllipse(brushRbBackground, rectRbBackground); //Circle Radio Check
                    //graphics.DrawEllipse(penBorder, rectRbBackground); //Circle border

                    penBorder.Color = unCheckedColor;
                    graphics.DrawEllipse(penBorder, rectRbBorder); //Circle border
                }
            }
            else
            {

            }
        }
        //Events
        public event EventHandler _MouseEnter;
        public event EventHandler _MouseLeave;
        private void SpCustomTextBox1_MouseEnter(object sender, EventArgs e)
        {
            if (_MouseEnter != null)
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
        //X-> Obsolete code, this was replaced by the Padding property in the constructor
        //(this.Padding = new Padding(10,0,0,0);)
        //protected override void OnResize(EventArgs e)
        //{
        //    base.OnResize(e);
        //    this.Width = TextRenderer.MeasureText(this.Text, this.Font).Width + 30;
        //}
    }
}
