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
    public partial class WF_NewContract1 : Form
    {
        private UCEmployees1 uCEmployees;
        public WF_NewContract1(UCEmployees1 uCEmployees1)
        {
            InitializeComponent();
            uCEmployees = uCEmployees1;
        }
        SqlConnection conUsers = new SqlConnection(@"Data Source=pavel-lenovo\sqlexpress;Initial Catalog=Sporitelna;Integrated Security=True");
        SqlConnection conUsers2 = new SqlConnection(@"Data Source=pavel-lenovo\sqlexpress;Initial Catalog=Sporitelna;Integrated Security=True");

        private void WF_NewContract1_Load(object sender, EventArgs e)
        {
            CreateNewUniqueRow();
            cbNContractType.SelectedIndex = 0;
            cbNContractInterestRate.Texts = Constants.InterestRate.ToString() + "%";
            cbNContractCurrency.SelectedIndex = 0;



            //TextFormat
        }
        
        private void CreateNewUniqueRow()
        {
            
            conUsers.Open();
            string query2 = "INSERT INTO " + Constants.tableContract + " (cFullName) VALUES(@cFullName)";
            SqlCommand cmd2 = new SqlCommand(query2, conUsers);
            cmd2.Parameters.AddWithValue("@cFullName", String.Empty);
            cmd2.ExecuteNonQuery();
            conUsers.Close();

            conUsers.Open();
            String query = "SELECT IDENT_CURRENT ('"+Constants.tableContract+"')";//"SELECT CAST(SCOPE_IDENTITY() AS INT) FROM tbl_Contract6";//"SELECT SCOPE_IDENTITY() from tbl_Contract6";
            SqlCommand cmd = new SqlCommand(query, conUsers);
            String lastContractId = cmd.ExecuteScalar().ToString();
            txtNContractId.Text = (Int32.Parse(lastContractId)).ToString();
            conUsers.Close();
        }

        private void BtnNContractStorno1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public bool btnCreateContract = false;
        private void BtnNContractCreate1_Click(object sender, EventArgs e)
        {
            btnCreateContract = true;
            //přidat JMENO + PŘÍJMENÍ 
                if (!String.IsNullOrEmpty(txtNContractInitialAmount.Texts) && !String.IsNullOrEmpty(txtNContractUserId.Texts) &&
                    !String.IsNullOrEmpty(txtNContractUserFullname.Texts))
                {
                conUsers.Open();
                string query2 = "UPDATE " + Constants.tableContract + " SET userId=@userId, cFullName=@cFullName, cFinalAmount=@cFinalAmount, cInterestRate=@cInterestRate," +
                    "cTotal=@cTotal, cCurrency=@cCurrency, cDateSince=@cDateSince, cDescription=@cDescription" +
                    " WHERE cId="+ txtNContractId.Text + "";
                SqlCommand cmd2 = new SqlCommand(query2, conUsers);
                cmd2.Parameters.AddWithValue("@userId", txtNContractUserId.Texts);
                cmd2.Parameters.AddWithValue("@cFullName", txtNContractUserFullname.Texts);
                cmd2.Parameters.AddWithValue("@cFinalAmount", txtNContractInitialAmount.Texts);
                cmd2.Parameters.AddWithValue("@cInterestRate", 0);
                cmd2.Parameters.AddWithValue("@cTotal", Int32.Parse(txtNContractInitialAmount.Texts) + 0);
                cmd2.Parameters.AddWithValue("@cCurrency", cbNContractCurrency.Texts);
                cmd2.Parameters.AddWithValue("@cDateSince", DateTime.Now.ToShortDateString());
                cmd2.Parameters.AddWithValue("@cDescription", txtNContractDescription.Text);

                cmd2.ExecuteNonQuery();
                conUsers.Close();


                conUsers2.Open();
                string query3 = "INSERT INTO " + Constants.tableContractInfo + " (cId, userId, action, actionValue, interestRate, date)" +
                    "VALUES(@cId, @userId, @action, @actionValue, @interestRate, @date)";
                SqlCommand cmd3 = new SqlCommand(query3, conUsers2);
                cmd3.Parameters.AddWithValue("@cId", txtNContractId.Text);
                cmd3.Parameters.AddWithValue("@userId", txtNContractUserId.Texts);
                cmd3.Parameters.AddWithValue("@action", "Vklad");
                cmd3.Parameters.AddWithValue("@actionValue", txtNContractInitialAmount.Texts);
                cmd3.Parameters.AddWithValue("@interestRate", 0);
                cmd3.Parameters.AddWithValue("@date", DateTime.Now.ToShortDateString());

                cmd3.ExecuteNonQuery();
                conUsers2.Close();
                this.Close();
                }
                else
                {
                    txtNContractInitialAmount.BorderColor = Color.Red;
                    txtNContractUserId.BorderColor = Color.Red;
                    txtNContractUserFullname.BorderColor = Color.Red;
                    MessageBox.Show("Vyplňte prosím všechna označená pole a zkuste to znovu.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                uCEmployees.RefreshContractData();
           // }
        }

        private void TxtNContractUserId_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    conUsers.Open();
                    String query = "SELECT firstName, lastName, company from " + Constants.tableEmployees + " WHERE userId=" + txtNContractUserId.Texts + "";
                    SqlCommand cmd = new SqlCommand(query, conUsers);
                    IDataReader dr = cmd.ExecuteReader();


                    txtNContractUserFullname.Text = dr["firstName"].ToString() + " " + dr["lastName"].ToString();
                    txtNContractCompany.Text = dr["company"].ToString();
                    conUsers.Close();
                }
                catch
                {
                    MessageBox.Show("User id doesnt exist.");
                }
            }
        }

        private void TxtNContractUserId__TextChanged(object sender, EventArgs e)
        {
            /*if(txtNContractUserId.Focused)
            {

            }*/
            
            try
            {
                int uid = Int32.Parse(txtNContractUserId.Texts);
                conUsers.Open();
                String query = "SELECT firstName, lastName, company from " + Constants.tableEmployees + " WHERE userId=" + uid + "";
                SqlCommand cmd = new SqlCommand(query, conUsers);
                SqlDataReader dr = cmd.ExecuteReader();
                if (!dr.Read())
                {
                    txtNContractUserFullname.Texts = String.Empty;
                    txtNContractCompany.Texts = String.Empty;
                }
                else
                {
                    txtNContractUserFullname.Texts = dr["lastName"].ToString() + " " + dr["firstName"].ToString();
                    txtNContractCompany.Texts = dr["company"].ToString();
                }
                conUsers.Close();
            }
            catch
            {

            }
        }

        private void WF_NewContract1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (btnCreateContract == false)
            {
                conUsers.Open();
                string query2 = "DELETE FROM " + Constants.tableContract + " WHERE cId='" + txtNContractId.Text + "'";
                SqlCommand cmd2 = new SqlCommand(query2, conUsers);
                cmd2.ExecuteNonQuery();
                conUsers.Close();
            }
        }
    }
}
