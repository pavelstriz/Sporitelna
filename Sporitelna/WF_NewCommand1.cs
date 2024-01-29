using Sporitelna.CustomControls;
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
    public partial class WF_NewCommand1 : Form
    {
        SqlConnection conUsers = new SqlConnection(@"Data Source=pavel-lenovo\sqlexpress;Initial Catalog=Sporitelna;Integrated Security=True");
        SqlConnection conUsers2 = new SqlConnection(@"Data Source=pavel-lenovo\sqlexpress;Initial Catalog=Sporitelna;Integrated Security=True");
        private UCEmployees1 uCEmployees;
        public SpShadowPanel SpShadowPanel;
        public WF_NewCommand1(UCEmployees1 uCEmployees1)
        {
            InitializeComponent();
            uCEmployees = uCEmployees1;
        }
        public static int ncBalance = 0;
        public int NcBalanceStored
        {
            get { return ncBalance; }
            set { ncBalance = value; }
        }
        public static bool ncWithdraw;
        public bool NcWithdrawStored
        {
            get { return ncWithdraw; }
            set { ncWithdraw = value; }
        }
        public static bool ncDeposit;
        public bool NcDepositStored
        {
            get { return ncDeposit; }
            set { ncDeposit = value; }
        }
        public static string ncAmount;
        public string NcAmountStored
        {
            get { return ncAmount; }
            set { ncAmount = value; }
        }
        private void WF_NewCommand1_Load(object sender, EventArgs e)
        {
            rbDeposit1.Checked = true;
            cmdAction = "Vklad";

            conUsers.Open();
            String query = "SELECT cTotal FROM "+Constants.tableContract+" WHERE cId = '"+ UCEmployees1.cId + "'";//"SELECT CAST(SCOPE_IDENTITY() AS INT) FROM tbl_Contract6";//"SELECT SCOPE_IDENTITY() from tbl_Contract6";
            SqlCommand cmd = new SqlCommand(query, conUsers);
            SqlDataReader dr = cmd.ExecuteReader();

            while(dr.Read())
            {
                txtBalance1.Texts = dr["cTotal"].ToString();
            }
            //MessageBox.Show("testt");
            conUsers.Close();

            //ncBalance = Convert.ToInt32(txtBalance1.Texts);
            //ncAmount = Convert.ToInt32(txtAmount1.Texts);
        }
        public bool? isPasswordCorrect;
        private void BtnPZSavePath_Click(object sender, EventArgs e)
        {

            if (!String.IsNullOrEmpty(txtBalance1.Texts))
                ncBalance = Int32.Parse(txtBalance1.Texts);

            if (rbWithdraw1.Checked)
                ncWithdraw = true;
            else ncWithdraw = false;

            if (rbDeposit1.Checked)
                ncDeposit = true;
            else ncDeposit = false;
            /*
            shadowPanel = new OpacityPanel();
            //ŁshadowPanel.BackColor = Color.LightGray;
            shadowPanel.Location = new Point(90, 90);
            shadowPanel.Size = new Size(90, 90);
            shadowPanel.Dock = DockStyle.Fill;
            uCEmployees.Controls.Add(shadowPanel);

            //MainForm mainForm = new MainForm();
            //mainForm.panel1.Controls.Add(shadowPanel);

            shadowPanel.Show();
            shadowPanel.BringToFront();*/
            //MainForm mainForm = new MainForm();


            SpShadowPanel = new SpShadowPanel();
            //SpShadowPanel.Size = mainForm.Size; 
            SpShadowPanel.Show(this);
            SpShadowPanel.BringToFront();
            
            WFPasswordConfirmation WFPasswordConfirmation = new WFPasswordConfirmation(this, null);
            WFPasswordConfirmation.ShowDialog(this);
            WFPasswordConfirmation.BringToFront();

            if (!String.IsNullOrEmpty(txtAmount1.Texts))
                ncAmount = txtAmount1.Texts;

            if (isPasswordCorrect == true)
            {
                conUsers.Open();
                string query3 = "INSERT INTO " + Constants.tableContractInfo + " (cId, userId, action, actionValue, interestRate, date)" +
                    "VALUES(@cId, @userId, @action, @actionValue, @interestRate, @date)";
                SqlCommand cmd3 = new SqlCommand(query3, conUsers);
                cmd3.Parameters.AddWithValue("@cId", UCEmployees1.cId);
                cmd3.Parameters.AddWithValue("@userId", UCEmployees1.userId);
                cmd3.Parameters.AddWithValue("@action", WF_NewCommand1.cmdAction);
                if (WF_NewCommand1.cmdAction == "Vklad")
                {
                    cmd3.Parameters.AddWithValue("@actionValue", Int32.Parse(NcAmountStored));
                }
                else if (WF_NewCommand1.cmdAction == "Výběr")
                {
                    cmd3.Parameters.AddWithValue("@actionValue", Int32.Parse("-" + NcAmountStored));
                }
                cmd3.Parameters.AddWithValue("@interestRate", 0);
                cmd3.Parameters.AddWithValue("@date", DateTime.Now.ToShortDateString());

                cmd3.ExecuteNonQuery();
                conUsers.Close();

                UpdateContractTotalValues();




                uCEmployees.RefreshContractData();
            }
            else if (isPasswordCorrect == false)
            {

            }
                //this.Close();
            //MessageBox.Show(ncBalance.ToString() + ncDeposit.ToString() + ncWithdraw.ToString() + ncAmount.ToString());

        }
        public void UpdateContractTotalValues()
        {
            sumSummaryBaseFinal = 0;
            sumSummaryInterestRateFinal = 0;
            conUsers.Open();
            String query = "SELECT actionValue, interestRate FROM " + Constants.tableContractInfo + " WHERE cId=" + UCEmployees1.cId + "";//"SELECT CAST(SCOPE_IDENTITY() AS INT) FROM tbl_Contract6";//"SELECT SCOPE_IDENTITY() from tbl_Contract6";
            SqlCommand cmd = new SqlCommand(query, conUsers);
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                try
                {
                    sumSummaryBaseFinal += Int32.Parse(dr["actionValue"].ToString());
                    sumSummaryInterestRateFinal += Int32.Parse(dr["interestRate"].ToString());
                    sumSummaryTotalFinal = sumSummaryBaseFinal + sumSummaryInterestRateFinal;
                }
                catch
                {

                }
            

            

            conUsers2.Open();
            //string queryy = "UPDATE " + Constants.tableEmployees + " SET titul=@titul, firstName=@firstname, lastName=@lastName, address=@address," +
            //    " nationality=@nationality, birthdate=@birthdate, company=@company WHERE id= '" + _id + "'";
            string query2 = "UPDATE " + Constants.tableContract + " SET cFinalAmount=@cFinalAmount, cInterestRate=@cInterestRate, cTotal=@cTotal WHERE cId=" + UCEmployees1.cId + "";
            SqlCommand cmd2 = new SqlCommand(query2, conUsers2);


            cmd2.Parameters.AddWithValue("@cFinalAmount", sumSummaryBaseFinal);
            cmd2.Parameters.AddWithValue("@cInterestRate", sumSummaryInterestRateFinal);
            cmd2.Parameters.AddWithValue("@cTotal", sumSummaryTotalFinal);
                
            cmd2.ExecuteNonQuery();
            conUsers2.Close();
            }
            conUsers.Close();

        }
        private int sumSummaryBaseFinal;
        private int sumSummaryInterestRateFinal;
        private int sumSummaryTotalFinal;
        private void BtnPZStorno1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public static string cmdAction;
        private void RbDeposit1_CheckedChanged(object sender, EventArgs e)
        {
            if (rbDeposit1.Checked)
                cmdAction = "Vklad";
        }

        private void RbWithdraw1_CheckedChanged(object sender, EventArgs e)
        {
            
            if (rbWithdraw1.Checked)
                cmdAction = "Výběr";
        }

        private void TxtAmount1__TextChanged(object sender, EventArgs e)
        {
            ncAmount = txtAmount1.Texts;
        }
    }
}
