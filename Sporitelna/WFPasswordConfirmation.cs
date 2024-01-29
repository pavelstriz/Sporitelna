using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sporitelna
{
    public partial class WFPasswordConfirmation : Form
    {
        SqlConnection conUsers = new SqlConnection(@"Data Source=pavel-lenovo\sqlexpress;Initial Catalog=Sporitelna;Integrated Security=True");


        private WF_NewCommand1 wF_NewCommand11;
        private MainForm mainForm;
        public WFPasswordConfirmation(WF_NewCommand1 wF_NewCommand1, MainForm mainForm1)
        {
            InitializeComponent();
            wF_NewCommand11 = wF_NewCommand1;
            mainForm = mainForm1;
            
            
            //this.BackColor = Color.FromArgb(50, Color.Red);
        }
        
        private void WFPasswordConfirmation_Load(object sender, EventArgs e)
        {

            //txtConfirmPass1.Size = new System.Drawing.Size(133, 35);
            this.BringToFront();

            //txtConfirmPass1.MaximumSize = new Size(133, 35);

            //txtConfirmPass1.Size = new Size(133, 35);
            //label1.Text = "Escape -> Zpátky | Enter -> Ok";
            //SpTextBox11.Enabled = false;
            //label2.Text = "test";
            //label2.ForeColor = Color.Black;
            //this.panel1.BackColor = Color.Turquoise;

            this.TransparencyKey = this.BackColor;


            //MainForm mainForm = new MainForm();

        }


        public string actionTemp;
        private void WFPasswordConfirmation_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == System.Windows.Forms.Keys.Escape)
            {
                //wF_NewCommand11.shadowPanel.Visible = false;
                wF_NewCommand11.SpShadowPanel.Visible = false;
                this.Close();
                //this.Dispose();
                //return;
            }
            if(e.KeyCode == System.Windows.Forms.Keys.Enter && txtConfirmPass1.Texts == Constants.confirmPass)
            {
                //wF_NewCommand11.shadowPanel.Visible = false;
                wF_NewCommand11.SpShadowPanel.Visible = false;
                wF_NewCommand11.isPasswordCorrect = true;
                wF_NewCommand11.Close();
                
                //MessageBox.Show("PŘIDANÝ PŘÍKAZ!");

                //UpdateContractTotalValues();
                //MessageBox.Show(sumSummaryBase.ToString());


                this.Close();

            }
            else if (e.KeyCode == System.Windows.Forms.Keys.Enter && txtConfirmPass1.Texts != Constants.confirmPass)
            {
                wF_NewCommand11.isPasswordCorrect = false;
                MessageBox.Show("Špatné heslo.");
            }

        }
        public int sumTotal = 0; //sloupec Celkem (sečtené hodnoty)

        public int sumSummaryBase;
        public int sumSummaryInterest;
        public int sumSummaryTotal;
        public void UpdateContractTotalValues()
        {
            conUsers.Open();
            String query = "SELECT actionValue FROM "+Constants.tableContractInfo+" WHERE cId="+UCEmployees1.cId+"";//"SELECT CAST(SCOPE_IDENTITY() AS INT) FROM tbl_Contract6";//"SELECT SCOPE_IDENTITY() from tbl_Contract6";
            SqlCommand cmd = new SqlCommand(query, conUsers);
            SqlDataReader dr = cmd.ExecuteReader();

            while(dr.Read())
            {
                sumSummaryBase += Int32.Parse(dr["actionValue"].ToString());
            }
            conUsers.Close();
            
        }

    }
}
