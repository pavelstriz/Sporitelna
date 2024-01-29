using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sporitelna.CustomControls
{
    public partial class SpShadowPanel : Form
    {
        public SpShadowPanel()
        {
            InitializeComponent();
        }

        private void SpShadowPanel_Load(object sender, EventArgs e)
        {
            this.BackColor = Color.LightGray;
            this.Opacity = .50;

            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
            this.WindowState = FormWindowState.Maximized;

        }

    }
}
