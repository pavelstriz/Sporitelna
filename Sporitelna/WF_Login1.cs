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
    public partial class WF_Login1 : Form
    {
        public WF_Login1()
        {
            
            InitializeComponent();
            //initialize
            
        }

        SqlConnection conLoginAdapter = new SqlConnection(@"Data Source=pavel-lenovo\sqlexpress;Initial Catalog=Sporitelna;Integrated Security=True");
        SqlConnection conLoginReader = new SqlConnection(@"Data Source=pavel-lenovo\sqlexpress;Initial Catalog=Sporitelna;Integrated Security=True");


        public static string fullName; //&&& pro použití proměných v jiných formulářích
        public static string fullPassword;

        public static string FullNameStored
        {
            get { return fullName; }
            set { fullName = value; }
        }
        public static string FullPasswordStored
        {
            get { return fullPassword; }
            set { fullPassword = value; }
        }                              //&&&

       
        private void BtnLogin_Click(object sender, EventArgs e)
        {
            this.Hide();
            bool userExists;
            //FINDPRIORITY();

            /*String sqlSelectQuery = "SELECT * FROM tbl_Login2 WHERE userName='" + formLogin.fullNameStored + "' and userPassword='" + formLogin.fullPasswordStored + "'";
            SqlCommand cmd = new SqlCommand(sqlSelectQuery, conLogin);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                fName = (dr["firstName"].ToString());
                lName = (dr["lastName"].ToString());
                formMenuOptionName.Text = fName + " " + lName;
                //formMenuOptionCompany.Text = (dr["company"].ToString());

            }*/

            if ((txtUsername.Text ?? txtPassword.Text) != "")
            {

                conLoginAdapter.Open();
                SqlDataAdapter sda = new SqlDataAdapter("select userId from tbl_Login1 where userName='" + txtUsername.Text + "' and userPassword='" + txtPassword.Text + "'", conLoginAdapter);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                //da.Fill(testT.Text);

                
                if (dt.Rows.Count == 1)
                {

                    



                                //MessageBox.Show("Priorita uživatele je: " + "3");
                                MainForm main = new MainForm();
                                main.Show();
                                this.Hide();
                            
                     


                    

                }
                else
                {
                    //userExists = false;

                    MessageBox.Show("Nesprávné uživatelské jméno a nebo heslo. Zkuste to prosím znovu.");
                    txtUsername.Text = "";
                    txtPassword.Text = "";

                }
                conLoginAdapter.Close();

            }
            else
            {
                MessageBox.Show("Zadejte uživatelské jméno a heslo.");
                txtUsername.Text = "";
                txtPassword.Text = "";
            }
            
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void WF_Login1_Load(object sender, EventArgs e)
        {
            Activate();
        }
    }
}
