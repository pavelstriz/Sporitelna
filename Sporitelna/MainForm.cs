using Sporitelna.SplashScreen;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sporitelna
{
    public partial class MainForm : Form
    {
        public MainForm()
        {

            //Thread t = new Thread(new ThreadStart(StartForm));
            //t.Start();
            //Thread.Sleep(5000);

            
            InitializeComponent();
            //initialize

            //t.Abort();

        }


        public void StartForm()
        {
            Application.Run(new WF_SplashScreen());
        }


        public static Image ResizeImage(Image imgToResize, Size size)
        {
            return (Image)(new Bitmap(imgToResize, size));
        }


        public UCEmployees1 uCEmployees1;
        public Image img;
        int x, y;
        private void MainForm_Load(object sender, EventArgs e)
        {
            Activate();
            x = 10;
            y = 0;
            img = Properties.Resources.pbUsers4;
            btnShowUsers1.BackgroundImage = img;

            txtDateTime.Text = DateTime.Now.ToLongDateString() + " " + DateTime.Now.ToLongTimeString();

            //timeTick1.Start();

            uCEmployees1 = new UCEmployees1();
            uCEmployees1.Dock = DockStyle.Fill;
            uCEmployees1.Margin = new Padding(0,0,0,0);
            panel1.Controls.Add(uCEmployees1);
        }

        private void TimeTick1_Tick(object sender, EventArgs e)
        {

            txtDateTime.Text = DateTime.Now.ToLongDateString() + " " + DateTime.Now.ToLongTimeString();
            timeTick1.Start();
            
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            WF_PodnikovaZalozna wF_PodnikovaZalozna = new WF_PodnikovaZalozna();
            wF_PodnikovaZalozna.ShowDialog();
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            //Application.Exit();
            ColumnOrderAndWidth.SaveWidthAndOrder_USERS(uCEmployees1.dgvUsers1);
            ColumnOrderAndWidth.SaveWidthAndOrder_CONTRACTS(uCEmployees1.dgvContract1);
            Environment.Exit(0);
        }

        private void BtnShowUsers1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImage(img, new Point(30, y));
        }
    }
}
