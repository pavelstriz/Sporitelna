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
using System.Configuration;
using System.Reflection;
using System.Xml.Serialization;
using System.IO;

namespace Sporitelna
{
    /*public static class ExtensionMethods
    {
        public static void DoubleBuffered(this DataGridView dgv, bool setting)
        {
            Type dgvType = dgv.GetType();
            PropertyInfo pi = dgvType.GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic);
            pi.SetValue(dgv, setting, null);
        }
    }*/
    public partial class UCEmployees1 : UserControl
    {
        public UCEmployees1()
        {
            InitializeComponent();
            //this.dgvUsers1.DoubleBuffered(true);
            //this.dgvContract1.DoubleBuffered(true);
        }
        SqlConnection conUsers = new SqlConnection(@"Data Source=pavel-lenovo\sqlexpress;Initial Catalog=Sporitelna;Integrated Security=True");
        SqlConnection conUsers2 = new SqlConnection(@"Data Source=pavel-lenovo\sqlexpress;Initial Catalog=Sporitelna;Integrated Security=True");
        SqlConnection conUsers3 = new SqlConnection(@"Data Source=pavel-lenovo\sqlexpress;Initial Catalog=Sporitelna;Integrated Security=True");
        SqlConnection conUsers4 = new SqlConnection(@"Data Source=pavel-lenovo\sqlexpress;Initial Catalog=Sporitelna;Integrated Security=True");

        public static string id;
        public static string userId;
        public string titul;
        public string firstName;
        public string lastName;
        public string address;
        public string nationality;
        public string birthdate;
        public string company;

        DataTable dt3;
        public void RefreshUserData()
        {

            string datum = "dd/MM/yyyy ";
            string čas = "HH:mm";




            conUsers.Open();
            String query = "SELECT * from tbl_Employees2";
            SqlCommand cmd = new SqlCommand(query, conUsers);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {

                titul = dr["titul"].ToString();
                firstName = dr["firstName"].ToString();
                lastName = dr["lastName"].ToString();
                address = dr["address"].ToString();
                nationality = dr["nationality"].ToString();
                birthdate = dr["birthdate"].ToString();
                company = dr["company"].ToString();
            }
            conUsers.Close();

            conUsers.Open();
            SqlDataAdapter SDA = new SqlDataAdapter("SELECT userId as 'Os. číslo', titul as 'Titul', firstName as 'Jméno', lastName as 'Příjmení', address as 'Bydliště', " +
                "nationality as 'Národnost', birthdate as 'Datum narození', company as 'Společnost' FROM tbl_Employees2", conUsers);
            dt3 = new DataTable();
            SDA.Fill(dt3);
            dgvUsers1.DataSource = dt3;
            conUsers.Close();

            dgvUsers1.Columns["Os. číslo"].Visible = Properties.Settings.Default.usersIdChecked;
            dgvUsers1.Columns["Titul"].Visible = Properties.Settings.Default.usersTitulChecked;
            dgvUsers1.Columns["Jméno"].Visible = Properties.Settings.Default.usersFirstNameChecked;
            dgvUsers1.Columns["Příjmení"].Visible = Properties.Settings.Default.usersLastNameChecked;
            dgvUsers1.Columns["Bydliště"].Visible = Properties.Settings.Default.usersAddressChecked;
            dgvUsers1.Columns["Národnost"].Visible = Properties.Settings.Default.usersNationalityChecked;
            dgvUsers1.Columns["Datum narození"].Visible = Properties.Settings.Default.usersBirthdateChecked;
            dgvUsers1.Columns["Společnost"].Visible = Properties.Settings.Default.usersCompanyChecked;

            

        }
        
        public void RefreshContractData()
        {
            string datum = "dd/MM/yyyy ";
            string čas = "HH:mm";


            conUsers3.Open();
            String query1 = "SELECT cId as 'Č. smlouvy', cFirstName as 'Jméno', cLastName as 'Příjmení', cFullName as 'Celé jméno'," +
                " cFinalAmount as 'Jistina', cInterestRate as 'Úrok', cTotal as 'Celkem', cCurrency as 'Měna', " +
                "cDateSince as 'Datum od', cDateTo as 'Datum do', cDescription as 'Popis', cStatus as 'Stav' FROM " + Constants.tableContract + " WHERE userId='" + userId + "'";
            SqlDataAdapter SDA1 = new SqlDataAdapter(query1, conUsers3);
            DataTable dt1 = new DataTable();
            SDA1.Fill(dt1);


            dgvContract1.DataSource = dt1;

            if(dgvContract1.SelectedRows.Count > 0)
                dgvContract1.Rows[dgvContractRowIndex].Selected = true;

            conUsers3.Close();

            dgvContract1.Columns["Č. smlouvy"].Visible = Properties.Settings.Default.contractsIdChecked;
            dgvContract1.Columns["Jméno"].Visible = Properties.Settings.Default.contractsFirstNameChecked;
            dgvContract1.Columns["Příjmení"].Visible = Properties.Settings.Default.contractsLastNameChecked;
            dgvContract1.Columns["Celé jméno"].Visible = Properties.Settings.Default.contractsFullNameChecked;
            dgvContract1.Columns["Jistina"].Visible = Properties.Settings.Default.contractsFinalAmountChecked;
            dgvContract1.Columns["Úrok"].Visible = Properties.Settings.Default.contractsInterestRateChecked;
            dgvContract1.Columns["Celkem"].Visible = Properties.Settings.Default.contractsTotalChecked;
            dgvContract1.Columns["Měna"].Visible = Properties.Settings.Default.contractsCurrencyChecked;
            dgvContract1.Columns["Datum od"].Visible = Properties.Settings.Default.contractsDateSinceChecked;
            dgvContract1.Columns["Datum do"].Visible = Properties.Settings.Default.contractsDateToChecked;
            dgvContract1.Columns["Popis"].Visible = Properties.Settings.Default.contractsDescriptionChecked;
            dgvContract1.Columns["Stav"].Visible = Properties.Settings.Default.contractsStatusChecked;
            



            RefreshContractInfoData();
            
            
           
            
        }

        public int subTotalIndex;
        public int subTotalNextRow; 
        public DataTable dt2;

        public DataRow rowSubtotal; //Řádek mezisoučtu
        public DataRow rowSummary; //Řádek shrnutí

        public int sumSubtotalBase = 0; //za rok částka
        public int sumSubInterest = 0; //za rok úrok
        public int sumSubTotal = 0; //za rok celkem

        public int sumTotal = 0; //sloupec Celkem (sečtené hodnoty)

        public int sumSummaryBase;
        public int sumSummaryInterest;
        public int sumSummaryTotal;

        public DataTable dtSubTotal;
        private void AddSubtotalRows2()
        {
            for (int i = 0; i <= dt2.Rows.Count - 1; i++)
            {
                //MessageBox.Show(dt2.Rows[i]["Datum"].ToString());
                //MessageBox.Show(dt2.Rows[i]["Částka"].ToString());
                //if (i > 0)
                // {
                rowSubtotal = dt2.NewRow();
                rowSubtotal["Datum"] = "Za rok";
                rowSubtotal["Příkaz"] = "";




                // sum += Convert.ToInt32(dgvContractInfo1.Rows[i + 1].Cells[2].Value);
                if (String.IsNullOrEmpty(dt2.Rows[i]["Částka"].ToString()))
                {
                    //return;
                }
                else
                {


                    sumSubtotalBase += Convert.ToInt32(dt2.Rows[i]["Částka"].ToString());
                    sumSummaryBase += Convert.ToInt32(dt2.Rows[i]["Částka"].ToString());



                }
                if (dt2.Rows[i]["Úrok"] == null)
                {
                    return;
                }
                else
                {
                    try
                    {
                        sumSubInterest += Convert.ToInt32(dt2.Rows[i]["Úrok"].ToString());
                        sumSummaryInterest += Convert.ToInt32(dt2.Rows[i]["Úrok"].ToString());
                    }
                    catch
                    {

                    }
                }
                try
                {
                    sumTotal = Convert.ToInt32(dt2.Rows[i]["Částka"].ToString()) + Convert.ToInt32(dt2.Rows[i]["Úrok"].ToString());
                }
                catch
                {

                }

                dt2.Rows[i]["Celkem"] = sumTotal;

                if (dt2.Rows[i]["Datum"].ToString().Contains("31.12."))
                {
                    try
                    {
                        sumSubTotal = sumSubtotalBase + sumSubInterest;
                        rowSubtotal["Částka"] = sumSubtotalBase;
                        rowSubtotal["Úrok"] = sumSubInterest;
                        rowSubtotal["Celkem"] = sumSubTotal;
                    }
                    catch { }

                    dt2.Rows.InsertAt(rowSubtotal, i + 1);
                    sumSubInterest = 0;
                    sumSubtotalBase = 0;
                    sumSubTotal = 0;
                    i++;
                }

            }

            dgvContractInfo1.DataSource = dt2;

            foreach (DataGridViewRow row in dgvContractInfo1.Rows)
            {
                if (row.Cells[0].Value.ToString().Equals("Za rok"))
                {
                    dgvContractInfo1.Rows[row.Index].Cells[0].Style.Font = new Font("Microsoft Sans Serif", 7.5f, FontStyle.Bold);
                    dgvContractInfo1.Rows[row.Index].Cells[2].Style.Font = new Font("Microsoft Sans Serif", 7.5f, FontStyle.Bold);
                    dgvContractInfo1.Rows[row.Index].Cells[3].Style.Font = new Font("Microsoft Sans Serif", 7.5f, FontStyle.Bold);
                    dgvContractInfo1.Rows[row.Index].Cells[4].Style.Font = new Font("Microsoft Sans Serif", 7.5f, FontStyle.Bold);

                }
            }


            //SUMMARY ROW
            DataTable dtSummaryRow = new DataTable();
            dtSummaryRow.Columns.Add(new DataColumn("Datum", typeof(string)));
            dtSummaryRow.Columns.Add(new DataColumn("Příkaz", typeof(string)));
            dtSummaryRow.Columns.Add(new DataColumn("Částka", typeof(int)));
            dtSummaryRow.Columns.Add(new DataColumn("Úrok", typeof(int)));
            dtSummaryRow.Columns.Add(new DataColumn("Celkem", typeof(int)));
            rowSummary = dtSummaryRow.NewRow();
            rowSummary["Datum"] = "Souhrn";
            rowSummary["Příkaz"] = "";
            rowSummary["Částka"] = sumSummaryBase;
            rowSummary["Úrok"] = sumSummaryInterest;

            try
            {
                sumSummaryTotal = sumSummaryBase + sumSummaryInterest;
            }
            catch { }
            rowSummary["Celkem"] = sumSummaryTotal;
            dtSummaryRow.Rows.Add(rowSummary);


            dgvContractInfoSummary1.DataSource = dtSummaryRow;

            foreach (DataGridViewRow row in dgvContractInfoSummary1.Rows)
            {

                if (row.Cells[0].Value.ToString().Equals("Souhrn"))
                {
                    //rowIndex = row.Index;
                    dgvContractInfoSummary1.Rows[row.Index].Cells[0].Style.Font = new Font("Microsoft Sans Serif", 7.5f, FontStyle.Bold);
                    dgvContractInfoSummary1.Rows[row.Index].Cells[2].Style.Font = new Font("Microsoft Sans Serif", 7.5f, FontStyle.Bold);
                    dgvContractInfoSummary1.Rows[row.Index].Cells[3].Style.Font = new Font("Microsoft Sans Serif", 7.5f, FontStyle.Bold);
                    dgvContractInfoSummary1.Rows[row.Index].Cells[4].Style.Font = new Font("Microsoft Sans Serif", 7.5f, FontStyle.Bold);
                    dgvContractInfoSummary1.Rows[row.Index].HeaderCell.Style.BackColor = Color.LightGray;
                    dgvContractInfoSummary1.Rows[row.Index].DefaultCellStyle.BackColor = Color.LightGray;

                }

            }

            conUsers2.Close();

            foreach (DataGridViewColumn column in dgvContractInfo1.Columns) //DISABLE CLICK SORTING
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }
        private void AddSubtotalRows() //after click Toggle button subtotal add foreach users -> create new datatable in load()
        {
            dtSubTotal = new DataTable();
            dtSubTotal.Columns.Add(new DataColumn("userId", typeof(string)));
            dtSubTotal.Columns.Add(new DataColumn("Datum", typeof(string)));
            dtSubTotal.Columns.Add(new DataColumn("Příkaz", typeof(string)));
            dtSubTotal.Columns.Add(new DataColumn("Částka", typeof(string)));
            dtSubTotal.Columns.Add(new DataColumn("Úrok", typeof(string)));
            dtSubTotal.Columns.Add(new DataColumn("Celkem", typeof(string)));
            DataRow drTemp;
            
            foreach (DataRow dr in dt2.Rows)
            {
                string drCellValue0 = dr["userId"].ToString();

                
                if (drCellValue0 == userId.ToString())
                {
                    // MessageBox.Show("NEW");
                    drTemp = dtSubTotal.NewRow();

                    drTemp["userId"] = Int32.Parse(dr["userId"].ToString());
                    drTemp["Datum"] = dr["Datum"].ToString();
                    drTemp["Příkaz"] = dr["Příkaz"].ToString();
                    drTemp["Částka"] = dr["Částka"].ToString();
                    drTemp["Úrok"] = dr["Úrok"].ToString();
                    drTemp["Celkem"] = dr["Celkem"].ToString();

                    dtSubTotal.Rows.Add(drTemp);
                    dgvContractInfo1.DataSource = dtSubTotal;
                }
                
            }

            /*DataView contractInfoDataView = new DataView();

            contractInfoDataView = new DataView(dtSubTotal);
            contractInfoDataView.RowFilter = "userId=" + userId + "";
            dgvContractInfo1.DataSource = contractInfoDataView;

            if (dgvContractInfo1.Columns.Contains("userId") == true)
            {
                dgvContractInfo1.Columns[0].Visible = false;
            }*/
            /*
           
          
           
            for (int i = 0; i <= dtSubTotal.Rows.Count - 1; i++)
            {
                //MessageBox.Show(dtt.Rows[i]["Datum"].ToString());
                //MessageBox.Show(dtt.Rows[i]["Částka"].ToString());
                //if (i > 0)
                // {
                rowSubtotal = dtSubTotal.NewRow();
                rowSubtotal["Datum"] = "Za rok";
                rowSubtotal["Příkaz"] = "";



                // sum += Convert.ToInt32(dgvContractInfo1.Rows[i + 1].Cells[2].Value);
                if (String.IsNullOrEmpty(dtSubTotal.Rows[i]["Částka"].ToString()))
                {
                    //return;
                }
                else
                {


                    sumSubtotalBase += Convert.ToInt32(dtSubTotal.Rows[i]["Částka"].ToString());
                    sumSummaryBase += Convert.ToInt32(dtSubTotal.Rows[i]["Částka"].ToString());



                }
                if (dtSubTotal.Rows[i]["Úrok"] == null)
                {
                    return;
                }
                else
                {
                    try
                    {
                        sumSubInterest += Convert.ToInt32(dtSubTotal.Rows[i]["Úrok"].ToString());
                        sumSummaryInterest += Convert.ToInt32(dtSubTotal.Rows[i]["Úrok"].ToString());
                    }
                    catch
                    {

                    }
                }
                try
                {
                    sumTotal = Convert.ToInt32(dtSubTotal.Rows[i]["Částka"].ToString()) + Convert.ToInt32(dtSubTotal.Rows[i]["Úrok"].ToString());
                }
                catch
                {

                }

                dtSubTotal.Rows[i]["Celkem"] = sumTotal;

                if (dtSubTotal.Rows[i]["Datum"].ToString().Contains("31.12."))
                {
                    try
                    {
                        sumSubTotal = sumSubtotalBase + sumSubInterest;
                        rowSubtotal["Částka"] = sumSubtotalBase;
                        rowSubtotal["Úrok"] = sumSubInterest;
                        rowSubtotal["Celkem"] = sumSubTotal;
                    }
                    catch { }

                    dtSubTotal.Rows.InsertAt(rowSubtotal, i + 1);
                    sumSubInterest = 0;
                    sumSubtotalBase = 0;
                    sumSubTotal = 0;
                    i++;
                }

            }

            


            foreach (DataGridViewRow row in dgvContractInfo1.Rows)
            {
                if (row.Cells[0].Value.ToString().Equals("Za rok"))
                {
                    dgvContractInfo1.Rows[row.Index].Cells[0].Style.Font = new Font("Microsoft Sans Serif", 7.5f, FontStyle.Bold);
                    dgvContractInfo1.Rows[row.Index].Cells[2].Style.Font = new Font("Microsoft Sans Serif", 7.5f, FontStyle.Bold);
                    dgvContractInfo1.Rows[row.Index].Cells[3].Style.Font = new Font("Microsoft Sans Serif", 7.5f, FontStyle.Bold);
                    dgvContractInfo1.Rows[row.Index].Cells[4].Style.Font = new Font("Microsoft Sans Serif", 7.5f, FontStyle.Bold);

                }
            }

           
            //SUMMARY ROW
            DataTable dtSummaryRow = new DataTable();
            dtSummaryRow.Columns.Add(new DataColumn("Datum", typeof(string)));
            dtSummaryRow.Columns.Add(new DataColumn("Příkaz", typeof(string)));
            dtSummaryRow.Columns.Add(new DataColumn("Částka", typeof(int)));
            dtSummaryRow.Columns.Add(new DataColumn("Úrok", typeof(int)));
            dtSummaryRow.Columns.Add(new DataColumn("Celkem", typeof(int)));
            rowSummary = dtSummaryRow.NewRow();
            rowSummary["Datum"] = "Souhrn";
            rowSummary["Příkaz"] = "";
            rowSummary["Částka"] = sumSummaryBase;
            rowSummary["Úrok"] = sumSummaryInterest;

            try
            {
                sumSummaryTotal = sumSummaryBase + sumSummaryInterest;
            }
            catch { }
            rowSummary["Celkem"] = sumSummaryTotal;
            dtSummaryRow.Rows.Add(rowSummary);


            //dgvContractInfoSummary1.DataSource = dtSummaryRow;

            foreach (DataGridViewRow row in dgvContractInfoSummary1.Rows)
            {

                if (row.Cells[0].Value.ToString().Equals("Souhrn"))
                {
                    //rowIndex = row.Index;
                    dgvContractInfoSummary1.Rows[row.Index].Cells[0].Style.Font = new Font("Microsoft Sans Serif", 7.5f, FontStyle.Bold);
                    dgvContractInfoSummary1.Rows[row.Index].Cells[2].Style.Font = new Font("Microsoft Sans Serif", 7.5f, FontStyle.Bold);
                    dgvContractInfoSummary1.Rows[row.Index].Cells[3].Style.Font = new Font("Microsoft Sans Serif", 7.5f, FontStyle.Bold);
                    dgvContractInfoSummary1.Rows[row.Index].Cells[4].Style.Font = new Font("Microsoft Sans Serif", 7.5f, FontStyle.Bold);
                    dgvContractInfoSummary1.Rows[row.Index].HeaderCell.Style.BackColor = Color.LightGray;
                    dgvContractInfoSummary1.Rows[row.Index].DefaultCellStyle.BackColor = Color.LightGray;

                    //dgvContractInfo1.CurrentCell = dgv.Rows.Cast<DataGridViewRow>().Last().Cells[0];
                    //break;
                }

            }

            conUsers2.Close();

            foreach (DataGridViewColumn column in dgvContractInfo1.Columns) //DISABLE CLICK SORTING
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            */
        }

        private void RefreshContractInfoData()
        {
            sumSubtotalBase = 0; //za rok částka
            sumSubInterest = 0; //za rok úrok
            sumSubTotal = 0; //za rok celkem
            sumSummaryBase = 0;
            sumSummaryInterest = 0;
            sumSummaryTotal = 0;


            subTotalIndex = 0;
            subTotalNextRow = 0;
            //MessageBox.Show(userId);
            conUsers2.Open();
            String query1 = "SELECT date as 'Datum', action as 'Příkaz', actionValue as 'Částka', interestRate as 'Úrok'," +
                " finalAmount as 'Celkem' FROM " + Constants.tableContractInfo + " WHERE cid = '" + cId + "'";// AND date = '"++"'";// ORDER BY date ASC"; //UPRAVIT NA ČÍSLO SMLOUVY NE ČÍSLO UŽIVATELE
            
            SqlDataAdapter SDA1 = new SqlDataAdapter(query1, conUsers2);
            dt2 = new DataTable();
            SDA1.Fill(dt2);

            EnumerableRowCollection<DataRow> query = from row in dt2.AsEnumerable()
                                                     orderby DateTime.Parse(row.Field<string>("Datum")) ascending
                                                     select row;
            dt2 = query.AsDataView().ToTable();

            conUsers2.Close();
            for (int i = 0; i <= dt2.Rows.Count - 1; i++)
            {
                if (String.IsNullOrEmpty(dt2.Rows[i]["Částka"].ToString()))
                {
                    dt2.Rows[i]["Částka"] = 0;
                    //return;
                }else if (String.IsNullOrEmpty(dt2.Rows[i]["Úrok"].ToString()))
                {
                    dt2.Rows[i]["Úrok"] = 0;
                }
                try
                {
                    sumTotal = Convert.ToInt32(dt2.Rows[i]["Částka"].ToString()) + Convert.ToInt32(dt2.Rows[i]["Úrok"].ToString());
                }
                catch
                {

                }

                dt2.Rows[i]["Celkem"] = sumTotal;
            }

                dgvContractInfo1.DataSource = dt2;

        }
        public static void DoubleBuffered(DataGridView dgv, bool setting)
        {
            Type dgvType = dgv.GetType();
            PropertyInfo pi = dgvType.GetProperty("DoubleBuffered",
                  BindingFlags.Instance | BindingFlags.NonPublic);
            pi.SetValue(dgv, setting, null);
        }
        private void UCEmployees1_Load(object sender, EventArgs e)
        {
            DoubleBuffered(dgvUsers1, true);
            DoubleBuffered(dgvContract1, true);

            btntDetails1.Checked = Properties.Settings.Default.btntDetails1Cache;
            cbFilterByYear.Texts = Properties.Settings.Default.cbFilterSelectedYear;

            //if(cbFilterByYear.Texts)
            //filterByYear = cbFilterByYear.Texts;

            //dgvUsers1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;



                SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            
            RefreshUserData();
            //userId = dgvUsers1.Rows[dgvUsers1.CurrentCell.RowIndex].Cells[0].Value.ToString();
            userId = dt3.Rows[0][0].ToString();
           
            DataGridViewSettings(dgvUsers1);
            dgvUsers1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvUsers1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            dgvUsers1.Columns[dgvUsers1.Columns.Count - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            
            //dgvUsers1.Columns[5].Width = 40;
            //dgvUsers1.Columns[6].Width = 40;
            //dgvUsers1.Columns[7].Width = 60;


            RefreshContractData(); //NAČTE VŠE
            RefreshContractInfoData();
            


            DataGridViewSettings(dgvContract1);
            dgvContract1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvContract1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            dgvContract1.Columns[dgvContract1.Columns.Count - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;


            DGV_ContextMenus();

            ColumnFilters.Users.miId.Checked = Properties.Settings.Default.usersIdChecked;
            ColumnFilters.Users.miTitul.Checked = Properties.Settings.Default.usersTitulChecked;
            ColumnFilters.Users.miFirstName.Checked = Properties.Settings.Default.usersFirstNameChecked;
            ColumnFilters.Users.miLastName.Checked = Properties.Settings.Default.usersLastNameChecked;
            ColumnFilters.Users.miAddress.Checked = Properties.Settings.Default.usersAddressChecked;
            ColumnFilters.Users.miNationality.Checked = Properties.Settings.Default.usersNationalityChecked;
            ColumnFilters.Users.miBirth.Checked = Properties.Settings.Default.usersBirthdateChecked;
            ColumnFilters.Users.miCompany.Checked = Properties.Settings.Default.usersCompanyChecked;
            Properties.Settings.Default.Save();

            ColumnFilters.Contracts.miId.Checked = Properties.Settings.Default.contractsIdChecked;
            ColumnFilters.Contracts.miFirstName.Checked = Properties.Settings.Default.contractsFirstNameChecked;
            ColumnFilters.Contracts.miLastName.Checked = Properties.Settings.Default.contractsLastNameChecked;
            ColumnFilters.Contracts.miFullName.Checked = Properties.Settings.Default.contractsFullNameChecked;
            ColumnFilters.Contracts.miFinalAmount.Checked = Properties.Settings.Default.contractsFinalAmountChecked;
            ColumnFilters.Contracts.miInterestRate.Checked = Properties.Settings.Default.contractsInterestRateChecked;
            ColumnFilters.Contracts.miTotal.Checked = Properties.Settings.Default.contractsTotalChecked;
            ColumnFilters.Contracts.miCurrency.Checked = Properties.Settings.Default.contractsCurrencyChecked;
            ColumnFilters.Contracts.miDateSince.Checked = Properties.Settings.Default.contractsDateSinceChecked;
            ColumnFilters.Contracts.miDateTo.Checked = Properties.Settings.Default.contractsDateToChecked;
            ColumnFilters.Contracts.miDescription.Checked = Properties.Settings.Default.contractsDescriptionChecked;
            ColumnFilters.Contracts.miStatus.Checked = Properties.Settings.Default.contractsStatusChecked;
            Properties.Settings.Default.Save();

            dgvUsers1.ContextMenu = ColumnFilters.Users.cmDgvUsersHeader;
            dgvContract1.ContextMenu = ColumnFilters.Contracts.cmDgvContractsHeader;


            ColumnOrderAndWidth.LoadDGVsWidthAndOrder_USERS(dgvUsers1);
            ColumnOrderAndWidth.LoadDGVsWidthAndOrder_Contracts(dgvContract1);

            //MessageBox.Show(Properties.Settings.Default.dgvUsersWidth0.ToString());
            /*dgvUsers1.Columns[0].Width = Properties.Settings.Default.dgvUsersWidth0;
            dgvUsers1.Columns[1].Width = Properties.Settings.Default.dgvUsersWidth1;
            dgvUsers1.Columns[2].Width = Properties.Settings.Default.dgvUsersWidth2;
            dgvUsers1.Columns[3].Width = Properties.Settings.Default.dgvUsersWidth3;
            dgvUsers1.Columns[4].Width = Properties.Settings.Default.dgvUsersWidth4;
            dgvUsers1.Columns[5].Width = Properties.Settings.Default.dgvUsersWidth5;
            dgvUsers1.Columns[6].Width = Properties.Settings.Default.dgvUsersWidth6;
            dgvUsers1.Columns[7].Width = Properties.Settings.Default.dgvUsersWidth7;
            */
            //https://www.codeproject.com/Articles/37087/DataGridView-that-Saves-Column-Order-Width-and-Vis
            /*
            dgvUsers1.Columns[0].Width = 114;
            dgvUsers1.Columns[1].Width = 114;
            dgvUsers1.Columns[2].Width = 212;
            dgvUsers1.Columns[3].Width = 211;
            dgvUsers1.Columns[4].Width = 227;
            dgvUsers1.Columns[5].Width = 212;
            dgvUsers1.Columns[6].Width = 213;
            dgvUsers1.Columns[7].Width = 212;*/



        }

        public void DataGridViewSettings(DataGridView dgv)
        {
            foreach (DataGridViewColumn column in dgv.Columns)
            {
                column.DefaultCellStyle.Font = new Font("Tahoma", 8.5F, FontStyle.Regular);  //GraphicsUnit.Pixel);
            }

            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", 9.75F, FontStyle.Bold);
            dgv.RowHeadersVisible = false;
            dgv.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None; // manualni změna velikosti řad
            dgv.AllowUserToResizeRows = false;
            dgv.AllowUserToOrderColumns = true;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.MultiSelect = false; 
            dgv.ReadOnly = true;
            dgv.RowPrePaint += new DataGridViewRowPrePaintEventHandler(DgvUsers1_RowPrePaint);
            dgv.EnableHeadersVisualStyles = false;
            //dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(128, 191, 255); //cyan
            //dataGridView1.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.FromArgb(128, 191, 255); //cyan
            //dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(95, 144, 255);
            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(247, 213, 50);
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(19,83,178);//(23,99,214); //(14, 61, 139);
            dgv.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.FromArgb(247, 213, 50);



            try
            {
                dgv.Columns[0].HeaderCell.Style.Padding = new Padding(15, 0, 0, 0);
                dgv.Columns[0].CellTemplate.Style.Padding = new Padding(15, 0, 0, 0);
                dgv.Columns[1].HeaderCell.Style.Padding = new Padding(15, 0, 0, 0);
                dgv.Columns[1].CellTemplate.Style.Padding = new Padding(15, 0, 0, 0);
                dgv.Columns[2].HeaderCell.Style.Padding = new Padding(15, 0, 0, 0);
                dgv.Columns[2].CellTemplate.Style.Padding = new Padding(15, 0, 0, 0);
                dgv.Columns[3].HeaderCell.Style.Padding = new Padding(15, 0, 0, 0);
                dgv.Columns[3].CellTemplate.Style.Padding = new Padding(15, 0, 0, 0);
                dgv.Columns[4].HeaderCell.Style.Padding = new Padding(15, 0, 0, 0);
                dgv.Columns[4].CellTemplate.Style.Padding = new Padding(15, 0, 0, 0);
                dgv.Columns[5].HeaderCell.Style.Padding = new Padding(15, 0, 0, 0);
                dgv.Columns[5].CellTemplate.Style.Padding = new Padding(15, 0, 0, 0);
                dgv.Columns[6].HeaderCell.Style.Padding = new Padding(15, 0, 0, 0);
                dgv.Columns[6].CellTemplate.Style.Padding = new Padding(15, 0, 0, 0);
                dgv.Columns[7].HeaderCell.Style.Padding = new Padding(15, 0, 0, 0);
                dgv.Columns[7].CellTemplate.Style.Padding = new Padding(15, 0, 0, 0);
            }
            catch { }
            //VÝŠKA ŘÁDKU
            dgv.RowTemplate.Height = 30;


        }
        private void DgvUsers1_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            e.PaintParts &= ~DataGridViewPaintParts.Focus;
        }
        public string VARIABLE;
        public DataGridViewRow curRow1;
        public DataGridViewRow curRow2;
        

        private string searchedText;
        private void TxtSearchUsers1_TextChanged(object sender, EventArgs e)
        {

            if (!String.IsNullOrEmpty(txtSearchUsers1.Texts))
            {

                //create data view
                DataView searchlistview;
                searchlistview = new DataView(dt3);


                searchlistview.RowFilter = "Convert([Os. číslo], System.String) LIKE '" + txtSearchUsers1.Texts + "%' OR " +
                                         "Titul LIKE '" + txtSearchUsers1.Texts.Trim().ToUpper() + "%' OR " +
                                         "Jméno LIKE '" + txtSearchUsers1.Texts.Trim().ToUpper() + "%' OR " +
                                         "Příjmení LIKE '" + txtSearchUsers1.Texts.Trim().ToUpper() + "%' OR " +
                                         "Bydliště LIKE '" + txtSearchUsers1.Texts.Trim().ToUpper() + "%' OR " +
                                         "Národnost LIKE '" + txtSearchUsers1.Texts.Trim().ToUpper() + "%' OR " +
                                         "[Datum narození] LIKE '" + txtSearchUsers1.Texts.Trim().ToUpper() + "%' OR " +
                                         "Společnost LIKE '" + txtSearchUsers1.Texts.Trim().ToUpper() + "%'";

                dgvUsers1.DataSource = searchlistview;

                RefreshContractData();

                if (clicks == 1)
                    AddSubtotalRows2();

            }
            else
            {
                RefreshUserData();
            }
        }

        private void EditMode(DataGridView dgv)
        {
            //alowDelete = true;

            dgv.SelectionMode = DataGridViewSelectionMode.CellSelect;
            //dgv_bookmark.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            dgv.ReadOnly = false;
            //dgv_bookmark.Columns[0].ReadOnly = true;
            //DataGridViewCell selectedCell = dgv.Rows[0].Cells[0];
            //dgv.CurrentCell = selectedCell;
            dgv.BeginEdit(true);
            dgv.GridColor = Color.LightGray;
            dgv.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            dgv.MultiSelect = true;
            dgv.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableWithoutHeaderText;

            dgv.DefaultCellStyle.BackColor = Color.White;
            dgv.DefaultCellStyle.SelectionBackColor = Color.White;


            button6.Text = "Uložit";
        }
        private void NormalMode(DataGridView dgv)
        {
            //alowDelete = true;

            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.ReadOnly = true;
            dgv.MultiSelect = false;
            //dgv.CurrentRow.Cells[0].Selected = true;
            dgv.GridColor = Color.White;
            dgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;

            dgv.DefaultCellStyle.SelectionBackColor = Color.LightGray;
            editModeClickCount = 0;
            button6.Text = "Upravit uživatele";
        }
        int editModeClickCount = 0;
        private void Button6_Click(object sender, EventArgs e)
        {
            
            editModeClickCount++;
            if (editModeClickCount == 1)
            {
                EditMode(dgvUsers1);

                
                   // textBox1.SelectionStart = 0;
                   // textBox1.SelectionLength = textBox1.Text.Length;
                

            }
            else if (editModeClickCount > 1)
            {
                

                for (int i = 0; i < dgvUsers1.Rows.Count; i++)
                {
                   

                    //COLUMNHEADERCELLCHANGED EVENT 
                    int userId2 = Int32.Parse(dgvUsers1.Rows[i].Cells[0].Value.ToString());
                    string titul = dgvUsers1.Rows[i].Cells[1].Value.ToString();
                    string birthdate = dgvUsers1.Rows[i].Cells[6].Value.ToString();
                    string company = dgvUsers1.Rows[i].Cells[7].Value.ToString();
                    
                    
                    string firstName = dgvUsers1.Rows[i].Cells[1].Value.ToString();
                    string lastName = dgvUsers1.Rows[i].Cells[2].Value.ToString();
                    string address = dgvUsers1.Rows[i].Cells[3].Value.ToString();
                    string nationality = dgvUsers1.Rows[i].Cells[4].Value.ToString();
                    //string birthdate = dgvUsers1.Rows[i].Cells[5].Value.ToString();
                    //string company = dgvUsers1.Rows[i].Cells[6].Value.ToString();

                    conUsers.Open();
                   string query = "UPDATE " + Constants.tableEmployees + " SET titul=@titul, birthdate=@birthdate, company=@company WHERE userId=@userId";
                    SqlCommand cmd2 = new SqlCommand(query, conUsers);


                    cmd2.Parameters.AddWithValue("@userId", userId2);
                    cmd2.Parameters.AddWithValue("@titul", titul);
                    cmd2.Parameters.AddWithValue("@birthdate", birthdate);
                    cmd2.Parameters.AddWithValue("@company", company);
                    cmd2.ExecuteNonQuery();
                    conUsers.Close();
                }

                NormalMode(dgvUsers1);
            }

        }
        
        private void DGV_ContextMenus()
        {
            //Employees table

            ColumnFilters.Users.miDefault = new MenuItem();
            ColumnFilters.Users.miDefault.Text = "Výchozí";
            ColumnFilters.Users.miDefault.Click += Default_Click;

            ColumnFilters.Users.miId = new MenuItem();
            ColumnFilters.Users.miId.Text = "Id";
            ColumnFilters.Users.miId.Click += UsersId_Click;

            ColumnFilters.Users.miTitul = new MenuItem();
            ColumnFilters.Users.miTitul.Text = "Titul";
            ColumnFilters.Users.miTitul.Click += UsersTitul_Click;

            ColumnFilters.Users.miFirstName = new MenuItem();
            ColumnFilters.Users.miFirstName.Text = "Jméno";
            ColumnFilters.Users.miFirstName.Click += UsersFirstName_Click;

            ColumnFilters.Users.miLastName = new MenuItem();
            ColumnFilters.Users.miLastName.Text = "Příjmení";
            ColumnFilters.Users.miLastName.Click += UsersLastName_Click;

            ColumnFilters.Users.miAddress = new MenuItem();
            ColumnFilters.Users.miAddress.Text = "Bydliště";
            ColumnFilters.Users.miAddress.Click += UsersAddress_Click;

            ColumnFilters.Users.miNationality = new MenuItem();
            ColumnFilters.Users.miNationality.Text = "Národnost";
            ColumnFilters.Users.miNationality.Click += UsersNationality_Click;

            ColumnFilters.Users.miBirth = new MenuItem();
            ColumnFilters.Users.miBirth.Text = "Datum narození";
            ColumnFilters.Users.miBirth.Click += UsersBirth_Click;

            ColumnFilters.Users.miCompany = new MenuItem();
            ColumnFilters.Users.miCompany.Text = "Společnost";
            ColumnFilters.Users.miCompany.Click += UsersCompany_Click;

            ColumnFilters.Users.cmDgvUsersHeader = new ContextMenu();
            ColumnFilters.Users.cmDgvUsersHeader.MenuItems.Add(ColumnFilters.Users.miDefault);
            ColumnFilters.Users.cmDgvUsersHeader.MenuItems.Add(ColumnFilters.Users.miId);
            ColumnFilters.Users.cmDgvUsersHeader.MenuItems.Add(ColumnFilters.Users.miTitul);
            ColumnFilters.Users.cmDgvUsersHeader.MenuItems.Add(ColumnFilters.Users.miFirstName);
            ColumnFilters.Users.cmDgvUsersHeader.MenuItems.Add(ColumnFilters.Users.miLastName);
            ColumnFilters.Users.cmDgvUsersHeader.MenuItems.Add(ColumnFilters.Users.miAddress);
            ColumnFilters.Users.cmDgvUsersHeader.MenuItems.Add(ColumnFilters.Users.miNationality);
            ColumnFilters.Users.cmDgvUsersHeader.MenuItems.Add(ColumnFilters.Users.miBirth);
            ColumnFilters.Users.cmDgvUsersHeader.MenuItems.Add(ColumnFilters.Users.miCompany);
           

            dgvUsers1.ContextMenu = ColumnFilters.Users.cmDgvUsersHeader;


            ColumnFilters.Contracts.miDefault = new MenuItem();
            ColumnFilters.Contracts.miDefault.Text = "Výchozí";
            ColumnFilters.Contracts.miDefault.Click += ContractsDefault_Click;

            ColumnFilters.Contracts.miId = new MenuItem();
            ColumnFilters.Contracts.miId.Text = "Č. smlouvy";
            ColumnFilters.Contracts.miId.Click += ContractsId_Click;

            ColumnFilters.Contracts.miFirstName = new MenuItem();
            ColumnFilters.Contracts.miFirstName.Text = "Jméno";
            ColumnFilters.Contracts.miFirstName.Click += ContractsFirstName_Click;

            ColumnFilters.Contracts.miLastName = new MenuItem();
            ColumnFilters.Contracts.miLastName.Text = "Příjmení";
            ColumnFilters.Contracts.miLastName.Click += ContractsLastName_Click;

            ColumnFilters.Contracts.miFullName = new MenuItem();
            ColumnFilters.Contracts.miFullName.Text = "Celé jméno";
            ColumnFilters.Contracts.miFullName.Click += ContractsFullName_Click;

            ColumnFilters.Contracts.miFinalAmount = new MenuItem();
            ColumnFilters.Contracts.miFinalAmount.Text = "Jistina";
            ColumnFilters.Contracts.miFinalAmount.Click += ContractsFinalAmount_Click;

            ColumnFilters.Contracts.miInterestRate = new MenuItem();
            ColumnFilters.Contracts.miInterestRate.Text = "Úrok";
            ColumnFilters.Contracts.miInterestRate.Click += ContractsInterestRate_Click;

            ColumnFilters.Contracts.miTotal = new MenuItem();
            ColumnFilters.Contracts.miTotal.Text = "Celkem";
            ColumnFilters.Contracts.miTotal.Click += ContractsTotal_Click;

            ColumnFilters.Contracts.miCurrency = new MenuItem();
            ColumnFilters.Contracts.miCurrency.Text = "Měna";
            ColumnFilters.Contracts.miCurrency.Click += ContractsCurrency_Click;

            ColumnFilters.Contracts.miDateSince = new MenuItem();
            ColumnFilters.Contracts.miDateSince.Text = "Smlouva od";
            ColumnFilters.Contracts.miDateSince.Click += ContractsDateSince_Click;
            
            ColumnFilters.Contracts.miDateTo = new MenuItem();
            ColumnFilters.Contracts.miDateTo.Text = "Smlouva do";
            ColumnFilters.Contracts.miDateTo.Click += ContractsDateTo_Click;

            ColumnFilters.Contracts.miDescription = new MenuItem();
            ColumnFilters.Contracts.miDescription.Text = "Popis";
            ColumnFilters.Contracts.miDescription.Click += ContractsDescription_Click;

            ColumnFilters.Contracts.miStatus = new MenuItem();
            ColumnFilters.Contracts.miStatus.Text = "Stav";
            ColumnFilters.Contracts.miStatus.Click += ContractsStatus_Click;

            ColumnFilters.Contracts.cmDgvContractsHeader = new ContextMenu();
            ColumnFilters.Contracts.cmDgvContractsHeader.MenuItems.Add(ColumnFilters.Contracts.miDefault);
            ColumnFilters.Contracts.cmDgvContractsHeader.MenuItems.Add(ColumnFilters.Contracts.miId);
            ColumnFilters.Contracts.cmDgvContractsHeader.MenuItems.Add(ColumnFilters.Contracts.miFirstName);
            ColumnFilters.Contracts.cmDgvContractsHeader.MenuItems.Add(ColumnFilters.Contracts.miLastName);
            ColumnFilters.Contracts.cmDgvContractsHeader.MenuItems.Add(ColumnFilters.Contracts.miFullName);
            ColumnFilters.Contracts.cmDgvContractsHeader.MenuItems.Add(ColumnFilters.Contracts.miFinalAmount);
            ColumnFilters.Contracts.cmDgvContractsHeader.MenuItems.Add(ColumnFilters.Contracts.miInterestRate);
            ColumnFilters.Contracts.cmDgvContractsHeader.MenuItems.Add(ColumnFilters.Contracts.miTotal);
            ColumnFilters.Contracts.cmDgvContractsHeader.MenuItems.Add(ColumnFilters.Contracts.miCurrency);
            ColumnFilters.Contracts.cmDgvContractsHeader.MenuItems.Add(ColumnFilters.Contracts.miDateSince);
            ColumnFilters.Contracts.cmDgvContractsHeader.MenuItems.Add(ColumnFilters.Contracts.miDateTo);
            ColumnFilters.Contracts.cmDgvContractsHeader.MenuItems.Add(ColumnFilters.Contracts.miDescription);
            ColumnFilters.Contracts.cmDgvContractsHeader.MenuItems.Add(ColumnFilters.Contracts.miStatus);


            dgvContract1.ContextMenu = ColumnFilters.Contracts.cmDgvContractsHeader;


        }
        private void Default_Click(Object sender, System.EventArgs e)
        {
            //menu item checkbox
            ColumnFilters.Users.miId.Checked = true;
            ColumnFilters.Users.miTitul.Checked = true;
            ColumnFilters.Users.miFirstName.Checked = true;
            ColumnFilters.Users.miLastName.Checked = true;
            ColumnFilters.Users.miAddress.Checked = true;
            ColumnFilters.Users.miNationality.Checked = true;
            ColumnFilters.Users.miBirth.Checked = true;
            ColumnFilters.Users.miCompany.Checked = true;

            //column visibility
            dgvUsers1.Columns["Os. číslo"].Visible = true;
            dgvUsers1.Columns["Titul"].Visible = true;
            dgvUsers1.Columns["Jméno"].Visible = true;
            dgvUsers1.Columns["Příjmení"].Visible = true;
            dgvUsers1.Columns["Bydliště"].Visible = true;
            dgvUsers1.Columns["Národnost"].Visible = true;
            dgvUsers1.Columns["Datum narození"].Visible = true;
            dgvUsers1.Columns["Společnost"].Visible = true;

            //program cache
            Properties.Settings.Default.usersIdChecked = true;
            Properties.Settings.Default.usersTitulChecked = true;
            Properties.Settings.Default.usersFirstNameChecked = true;
            Properties.Settings.Default.usersLastNameChecked = true;
            Properties.Settings.Default.usersAddressChecked = true;
            Properties.Settings.Default.usersNationalityChecked = true;
            Properties.Settings.Default.usersBirthdateChecked = true;
            Properties.Settings.Default.usersCompanyChecked = true;
            Properties.Settings.Default.Save();

            ColumnOrderAndWidth.ResetWidthAndOrder_USERS(dgvUsers1);

            dgvUsers1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvUsers1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            dgvUsers1.Columns[dgvUsers1.Columns.Count - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            
            ColumnOrderAndWidth.SaveWidthAndOrder_USERS(dgvUsers1);


            //dgvUsers1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

        }
        private void UsersId_Click(Object sender, System.EventArgs e)
        {
            ColumnFilters.Users.miId.Checked = !ColumnFilters.Users.miId.Checked;
            if(ColumnFilters.Users.miId.Checked == true)
            {
                dgvUsers1.Columns["Os. číslo"].Visible = true;
                Properties.Settings.Default.usersIdChecked = true;
            }
            else
            {
                dgvUsers1.Columns["Os. číslo"].Visible = false;
                Properties.Settings.Default.usersIdChecked = false;
            }
            Properties.Settings.Default.Save();

        }
        private void UsersTitul_Click(Object sender, System.EventArgs e)
        {
            ColumnFilters.Users.miTitul.Checked = !ColumnFilters.Users.miTitul.Checked;

            if (ColumnFilters.Users.miTitul.Checked == true)
            {
                dgvUsers1.Columns["Titul"].Visible = true;
                Properties.Settings.Default.usersTitulChecked = true;
            }
            else
            {
                dgvUsers1.Columns["Titul"].Visible = false;
                Properties.Settings.Default.usersTitulChecked = false;
            }
            Properties.Settings.Default.Save();
        }
        private void UsersFirstName_Click(Object sender, System.EventArgs e)
        {
            ColumnFilters.Users.miFirstName.Checked = !ColumnFilters.Users.miFirstName.Checked;

            if (ColumnFilters.Users.miFirstName.Checked == true)
            {
                dgvUsers1.Columns["Jméno"].Visible = true;
                Properties.Settings.Default.usersFirstNameChecked = true;
            }
            else
            {
                dgvUsers1.Columns["Jméno"].Visible = false;
                Properties.Settings.Default.usersFirstNameChecked = false;
            }
            Properties.Settings.Default.Save();
        }
        private void UsersLastName_Click(Object sender, System.EventArgs e)
        {
            ColumnFilters.Users.miLastName.Checked = !ColumnFilters.Users.miLastName.Checked;

            if (ColumnFilters.Users.miLastName.Checked == true)
            {
                dgvUsers1.Columns["Příjmení"].Visible = true;
                Properties.Settings.Default.usersLastNameChecked = true;
            }
            else
            {
                dgvUsers1.Columns["Příjmení"].Visible = false;
                Properties.Settings.Default.usersLastNameChecked = false;
            }
            Properties.Settings.Default.Save();
        }
        private void UsersAddress_Click(Object sender, System.EventArgs e)
        {
            ColumnFilters.Users.miAddress.Checked = !ColumnFilters.Users.miAddress.Checked;

            if (ColumnFilters.Users.miAddress.Checked == true)
            {
                dgvUsers1.Columns["Bydliště"].Visible = true;
                Properties.Settings.Default.usersAddressChecked = true;
            }
            else
            {
                dgvUsers1.Columns["Bydliště"].Visible = false;
                Properties.Settings.Default.usersAddressChecked = false;
            }
            Properties.Settings.Default.Save();
        }
        private void UsersNationality_Click(Object sender, System.EventArgs e)
        {
            ColumnFilters.Users.miNationality.Checked = !ColumnFilters.Users.miNationality.Checked;

            if (ColumnFilters.Users.miNationality.Checked == true)
            {
                dgvUsers1.Columns["Národnost"].Visible = true;
                Properties.Settings.Default.usersNationalityChecked = true;
            }
            else
            {
                dgvUsers1.Columns["Národnost"].Visible = false;
                Properties.Settings.Default.usersNationalityChecked = false;
            }
            Properties.Settings.Default.Save();
        }
        private void UsersBirth_Click(Object sender, System.EventArgs e)
        {
            ColumnFilters.Users.miBirth.Checked = !ColumnFilters.Users.miBirth.Checked;

            if (ColumnFilters.Users.miBirth.Checked == true)
            {
                dgvUsers1.Columns["Datum narození"].Visible = true;
                Properties.Settings.Default.usersBirthdateChecked = true;
            }
            else
            {
                dgvUsers1.Columns["Datum narození"].Visible = false;
                Properties.Settings.Default.usersBirthdateChecked = false;
            }
            Properties.Settings.Default.Save();
        }
        private void UsersCompany_Click(Object sender, System.EventArgs e)
        {
            ColumnFilters.Users.miCompany.Checked = !ColumnFilters.Users.miCompany.Checked;

            if (ColumnFilters.Users.miCompany.Checked == true)
            {
                dgvUsers1.Columns["Společnost"].Visible = true;
                Properties.Settings.Default.usersCompanyChecked = true;
            }
            else
            {
                dgvUsers1.Columns["Společnost"].Visible = false;
                Properties.Settings.Default.usersCompanyChecked = false;
            }
            Properties.Settings.Default.Save();
        }

        private void ContractsDefault_Click(Object sender, System.EventArgs e)
        {
            //menu item checkbox
            ColumnFilters.Contracts.miId.Checked = true;
            ColumnFilters.Contracts.miFirstName.Checked = false;
            ColumnFilters.Contracts.miLastName.Checked = false;
            ColumnFilters.Contracts.miFullName.Checked = false;
            ColumnFilters.Contracts.miFinalAmount.Checked = true;
            ColumnFilters.Contracts.miInterestRate.Checked = true;
            ColumnFilters.Contracts.miTotal.Checked = true;
            ColumnFilters.Contracts.miCurrency.Checked = true;
            ColumnFilters.Contracts.miDateSince.Checked = false;
            ColumnFilters.Contracts.miDateTo.Checked = false;
            ColumnFilters.Contracts.miDescription.Checked = false;
            ColumnFilters.Contracts.miStatus.Checked = false;

            //column visibility
            dgvContract1.Columns["Č. smlouvy"].Visible = true;
            dgvContract1.Columns["Jméno"].Visible = false;
            dgvContract1.Columns["Příjmení"].Visible = false;
            dgvContract1.Columns["Celé jméno"].Visible = false;
            dgvContract1.Columns["Jistina"].Visible = true;
            dgvContract1.Columns["Úrok"].Visible = true;
            dgvContract1.Columns["Celkem"].Visible = true;
            dgvContract1.Columns["Měna"].Visible = true;
            dgvContract1.Columns["Datum od"].Visible = false;
            dgvContract1.Columns["Datum do"].Visible = false;
            dgvContract1.Columns["Popis"].Visible = false;
            dgvContract1.Columns["Stav"].Visible = false;
            
            //program cache
            Properties.Settings.Default.contractsIdChecked = true;
            Properties.Settings.Default.contractsFirstNameChecked = false;
            Properties.Settings.Default.contractsLastNameChecked = false;
            Properties.Settings.Default.contractsFullNameChecked = false;
            Properties.Settings.Default.contractsFinalAmountChecked = true;
            Properties.Settings.Default.contractsInterestRateChecked = true;
            Properties.Settings.Default.contractsTotalChecked = true;
            Properties.Settings.Default.contractsCurrencyChecked = true;
            Properties.Settings.Default.contractsDateSinceChecked = false;
            Properties.Settings.Default.contractsDateToChecked = false;
            Properties.Settings.Default.contractsDescriptionChecked = false;
            Properties.Settings.Default.contractsStatusChecked = false;
            Properties.Settings.Default.Save();

            ColumnOrderAndWidth.ResetWidthAndOrder_CONTRACTS(dgvContract1);

            dgvContract1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            //dgvContract1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            dgvContract1.Columns[dgvContract1.Columns.Count - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            ColumnOrderAndWidth.SaveWidthAndOrder_CONTRACTS(dgvContract1);


        }
        private void ContractsId_Click(Object sender, System.EventArgs e)
        {
            ColumnFilters.Contracts.miId.Checked = !ColumnFilters.Contracts.miId.Checked;
            if (ColumnFilters.Contracts.miId.Checked == true)
            {
                dgvContract1.Columns["Č. smlouvy"].Visible = true;
                Properties.Settings.Default.contractsIdChecked = true;
            }
            else
            {
                dgvContract1.Columns["Č. smlouvy"].Visible = false;
                Properties.Settings.Default.contractsIdChecked = false;
            }
            Properties.Settings.Default.Save();

        }
        private void ContractsFirstName_Click(Object sender, System.EventArgs e)
        {
            ColumnFilters.Contracts.miFirstName.Checked = !ColumnFilters.Contracts.miFirstName.Checked;

            if (ColumnFilters.Contracts.miFirstName.Checked == true)
            {
                dgvContract1.Columns["Jméno"].Visible = true;
                Properties.Settings.Default.contractsFirstNameChecked = true;
            }
            else
            {
                dgvContract1.Columns["Jméno"].Visible = false;
                Properties.Settings.Default.contractsFirstNameChecked = false;
            }
            Properties.Settings.Default.Save();
        }
        private void ContractsLastName_Click(Object sender, System.EventArgs e)
        {
            ColumnFilters.Contracts.miLastName.Checked = !ColumnFilters.Contracts.miLastName.Checked;

            if (ColumnFilters.Contracts.miLastName.Checked == true)
            {
                dgvContract1.Columns["Příjmení"].Visible = true;
                Properties.Settings.Default.contractsLastNameChecked = true;
            }
            else
            {
                dgvContract1.Columns["Příjmení"].Visible = false;
                Properties.Settings.Default.contractsLastNameChecked = false;
            }
            Properties.Settings.Default.Save();
        }
        private void ContractsFullName_Click(Object sender, System.EventArgs e)
        {
            ColumnFilters.Contracts.miFullName.Checked = !ColumnFilters.Contracts.miFullName.Checked;

            if (ColumnFilters.Contracts.miFullName.Checked == true)
            {
                dgvContract1.Columns["Celé jméno"].Visible = true;
                Properties.Settings.Default.contractsFullNameChecked = true;
            }
            else
            {
                dgvContract1.Columns["Celé jméno"].Visible = false;
                Properties.Settings.Default.contractsFullNameChecked = false;
            }
            Properties.Settings.Default.Save();
        }
        private void ContractsFinalAmount_Click(Object sender, System.EventArgs e)
        {
            ColumnFilters.Contracts.miFinalAmount.Checked = !ColumnFilters.Contracts.miFinalAmount.Checked;

            if (ColumnFilters.Contracts.miFinalAmount.Checked == true)
            {
                dgvContract1.Columns["Jistina"].Visible = true;
                Properties.Settings.Default.contractsFinalAmountChecked = true;
            }
            else
            {
                dgvContract1.Columns["Jistina"].Visible = false;
                Properties.Settings.Default.contractsFinalAmountChecked = false;
            }
            Properties.Settings.Default.Save();
        }
        private void ContractsInterestRate_Click(Object sender, System.EventArgs e)
        {
            ColumnFilters.Contracts.miInterestRate.Checked = !ColumnFilters.Contracts.miInterestRate.Checked;

            if (ColumnFilters.Contracts.miInterestRate.Checked == true)
            {
                dgvContract1.Columns["Úrok"].Visible = true;
                Properties.Settings.Default.contractsInterestRateChecked = true;
            }
            else
            {
                dgvContract1.Columns["Úrok"].Visible = false;
                Properties.Settings.Default.contractsInterestRateChecked = false;
            }
            Properties.Settings.Default.Save();
        }
        private void ContractsTotal_Click(Object sender, System.EventArgs e)
        {
            ColumnFilters.Contracts.miTotal.Checked = !ColumnFilters.Contracts.miTotal.Checked;

            if (ColumnFilters.Contracts.miTotal.Checked == true)
            {
                dgvContract1.Columns["Celkem"].Visible = true;
                Properties.Settings.Default.contractsTotalChecked = true;
            }
            else
            {
                dgvContract1.Columns["Celkem"].Visible = false;
                Properties.Settings.Default.contractsTotalChecked = false;
            }
            Properties.Settings.Default.Save();
        }
        private void ContractsCurrency_Click(Object sender, System.EventArgs e)
        {
            ColumnFilters.Contracts.miCurrency.Checked = !ColumnFilters.Contracts.miCurrency.Checked;

            if (ColumnFilters.Contracts.miCurrency.Checked == true)
            {
                dgvContract1.Columns["Měna"].Visible = true;
                Properties.Settings.Default.contractsCurrencyChecked = true;
            }
            else
            {
                dgvContract1.Columns["Měna"].Visible = false;
                Properties.Settings.Default.contractsCurrencyChecked = false;
            }
            Properties.Settings.Default.Save();
        }
        private void ContractsDateSince_Click(Object sender, System.EventArgs e)
        {
            ColumnFilters.Contracts.miDateSince.Checked = !ColumnFilters.Contracts.miDateSince.Checked;

            if (ColumnFilters.Contracts.miDateSince.Checked == true)
            {
                dgvContract1.Columns["Datum od"].Visible = true;
                Properties.Settings.Default.contractsDateSinceChecked = true;
            }
            else
            {
                dgvContract1.Columns["Datum od"].Visible = false;
                Properties.Settings.Default.contractsDateSinceChecked = false;
            }
            Properties.Settings.Default.Save();
        }
        private void ContractsDateTo_Click(Object sender, System.EventArgs e)
        {
            ColumnFilters.Contracts.miDateTo.Checked = !ColumnFilters.Contracts.miDateTo.Checked;

            if (ColumnFilters.Contracts.miDateTo.Checked == true)
            {
                dgvContract1.Columns["Datum do"].Visible = true;
                Properties.Settings.Default.contractsDateToChecked = true;
            }
            else
            {
                dgvContract1.Columns["Datum do"].Visible = false;
                Properties.Settings.Default.contractsDateToChecked = false;
            }
            Properties.Settings.Default.Save();
        }
        private void ContractsDescription_Click(Object sender, System.EventArgs e)
        {
            ColumnFilters.Contracts.miDescription.Checked = !ColumnFilters.Contracts.miDescription.Checked;

            if (ColumnFilters.Contracts.miDescription.Checked == true)
            {
                dgvContract1.Columns["Popis"].Visible = true;
                Properties.Settings.Default.contractsDescriptionChecked = true;
            }
            else
            {
                dgvContract1.Columns["Popis"].Visible = false;
                Properties.Settings.Default.contractsDescriptionChecked = false;
            }
            Properties.Settings.Default.Save();
        }
        private void ContractsStatus_Click(Object sender, System.EventArgs e)
        {
            ColumnFilters.Contracts.miStatus.Checked = !ColumnFilters.Contracts.miStatus.Checked;

            if (ColumnFilters.Contracts.miStatus.Checked == true)
            {
                dgvContract1.Columns["Stav"].Visible = true;
                Properties.Settings.Default.contractsStatusChecked = true;
            }
            else
            {
                dgvContract1.Columns["Stav"].Visible = false;
                Properties.Settings.Default.contractsStatusChecked = false;
            }
            Properties.Settings.Default.Save();
        }
        DataGridViewColumn aimColumn;
        private void DgvUsers1_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                aimColumn = dgvUsers1.Columns[e.ColumnIndex];
                aimColumn.HeaderCell.Style.BackColor = Color.FromArgb(235, 199, 25);
                aimColumn.HeaderCell.Style.SelectionBackColor = Color.FromArgb(235, 199, 25);
            }
        }
        
        private void DgvUsers1_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {

            aimColumn = dgvUsers1.Columns[e.ColumnIndex];
            aimColumn.HeaderCell.Style.BackColor = Color.FromArgb(247, 213, 50);
            aimColumn.HeaderCell.Style.SelectionBackColor = Color.FromArgb(247, 213, 50);
            //dgvUsers1.ColumnHeadersDefaultCellStyle.BackColor = 

        }
        private void DgvContract1_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {

            aimColumn = dgvContract1.Columns[e.ColumnIndex];
            aimColumn.HeaderCell.Style.BackColor = Color.FromArgb(247, 213, 50);
            aimColumn.HeaderCell.Style.SelectionBackColor = Color.FromArgb(247, 213, 50);
            //dgvUsers1.ColumnHeadersDefaultCellStyle.BackColor = 

        }
        private void DgvContract1_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                aimColumn = dgvContract1.Columns[e.ColumnIndex];
                aimColumn.HeaderCell.Style.BackColor = Color.FromArgb(235, 199, 25);
                aimColumn.HeaderCell.Style.SelectionBackColor = Color.FromArgb(235, 199, 25);
            }
        }

        private void DgvUsers1_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
        {

            if (dgvUsers1.Rows.Count > 0)
            {
                /*  Properties.Settings.Default.dgvUsersWidth0 = dgvUsers1.Columns[0].Width;
                  Properties.Settings.Default.Save();
                  Properties.Settings.Default.dgvUsersWidth1 = dgvUsers1.Columns[1].Width;
                  Properties.Settings.Default.Save();
                  Properties.Settings.Default.dgvUsersWidth2 = dgvUsers1.Columns[2].Width;
                  Properties.Settings.Default.Save();
                  Properties.Settings.Default.dgvUsersWidth3 = dgvUsers1.Columns[3].Width;
                  Properties.Settings.Default.Save();
                  Properties.Settings.Default.dgvUsersWidth4 = dgvUsers1.Columns[4].Width;
                  Properties.Settings.Default.Save();
                  Properties.Settings.Default.dgvUsersWidth5 = dgvUsers1.Columns[5].Width;
                  Properties.Settings.Default.Save();
                  Properties.Settings.Default.dgvUsersWidth6 = dgvUsers1.Columns[6].Width;
                  Properties.Settings.Default.Save();
                  Properties.Settings.Default.dgvUsersWidth7 = dgvUsers1.Columns[7].Width;
                  Properties.Settings.Default.Save();
                  Properties.Settings.Default.Upgrade();
                */


                

                //MessageBox.Show(Properties.Settings.Default.dgvUsersWidth0.ToString());
            }



        }


        private void DgvUsers1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            dgvUsers1.BeginEdit(true);
            
        }

        public int click;
        private void BtnRollGrid1_Click(object sender, EventArgs e)
        {
            

            click++;
            //tblBottom1.Hide();
            //tblMain1.RowStyles[2].SizeType = SizeType.Absolute;
            if (click == 1)
            {
                //tblBottom1.Visible = false;
                
                Thread.Sleep(100);
                tblMain1.RowStyles[2].SizeType = SizeType.Percent;
                tblMain1.RowStyles[2].Height = 0;

                tblMain1.RowStyles[0].SizeType = SizeType.Percent;
                tblMain1.RowStyles[0].Height = 92.88f;
                tblMain1.RowStyles[1].SizeType = SizeType.Percent;
                tblMain1.RowStyles[1].Height = 7.12f;

                btnRollGrid1.Text = @"/\";
            }
            else if(click == 2)
            {
                //tblBottom1.Visible = true;
                Thread.Sleep(100);
                click = 0;
                tblMain1.RowStyles[0].SizeType = SizeType.Percent;
                tblMain1.RowStyles[0].Height = 43.68f;

                tblMain1.RowStyles[2].Height = 49.39f;

                
                tblMain1.RowStyles[1].SizeType = SizeType.Percent;
                tblMain1.RowStyles[1].Height = 7.12f;

                btnRollGrid1.Text = @"\/";
            }
            

        }

        private void BtnCommand1_Click(object sender, EventArgs e)
        {
            WF_NewCommand1 wF_NewCommand1 = new WF_NewCommand1(this);
            wF_NewCommand1.Show(this);

            
        }
        public Panel hidePanel1;

        private void BtntDetails1_CheckStateChanged(object sender, EventArgs e)
        {
            if (!btntDetails1.Checked)
            {
                hidePanel1 = new Panel();
                hidePanel1.Anchor = (AnchorStyles.Bottom | AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Top);
                hidePanel1.Size = panel4.Size;
                hidePanel1.Location = panel4.Location;
                hidePanel1.BackColor = Color.Silver;
                panel1.Controls.Add(hidePanel1);
                panel4.Hide();

                dgvContractInfo1.Enabled = false;
                dgvContractInfoSummary1.Enabled = false;
                hidePanel1.BringToFront();

                Properties.Settings.Default.btntDetails1Cache = btntDetails1.Checked;
                Properties.Settings.Default.Save();
            }
            else
            {
                
                panel4.Show();
                dgvContractInfo1.Enabled = true;
                dgvContractInfoSummary1.Enabled = true;
                hidePanel1.SendToBack();
                RefreshContractInfoData();

                if (clicks == 1)
                    AddSubtotalRows2();

                Properties.Settings.Default.btntDetails1Cache = btntDetails1.Checked;
                Properties.Settings.Default.Save();
            }
        }


        private void DgvContract1_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            if (dgvContract1.Rows.Count >= 1)
            {
                //create data view
                /*DataView contractInfoDataView = new DataView();

                contractInfoDataView = new DataView(dt2);
                contractInfoDataView.RowFilter = "AJDY=" + userId + "";
                dgvContractInfo1.DataSource = contractInfoDataView;

                if (dgvContractInfo1.Columns.Contains("AJDY") == true)
                {
                    dgvContractInfo1.Columns[0].Visible = false;
                }*/
            }
        }
        public int clicks;
        private void BtnSubtotals1_Click(object sender, EventArgs e)
        {
            
            clicks++;

            if(clicks == 1)
            {
                

                btnSubtotals1.BackColor = Color.FromArgb(249, 176, 0);
                AddSubtotalRows2();


            }
            else if(clicks == 2)
            {
                
                RefreshContractInfoData();

                dgvContractInfoSummary1.DataSource = null;

                foreach (DataGridViewColumn column in dgvContractInfo1.Columns) //DISABLE CLICK SORTING
                {
                    column.SortMode = DataGridViewColumnSortMode.Automatic;
                }

                btnSubtotals1.BackColor = Color.Transparent;

                clicks = 0;
            }
        }
        private void DgvUsers1_SelectionChanged(object sender, EventArgs e)
        {
            dgvContractRowIndex = 0;
            curRow1 = dgvUsers1.CurrentRow;

            if (curRow1 != null)
            {
                userId = dgvUsers1.Rows[dgvUsers1.CurrentCell.RowIndex].Cells[0].Value.ToString();

            }

            RefreshContractData();
            if (dgvContractInfo1.SelectedRows.Count > 0 && btntDetails1.Checked == true)
            {
                
                RefreshContractInfoData();
                if (clicks == 1)
                    AddSubtotalRows2();

            }

        }
        private void DgvUsers1_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                return;
            }

        }
        private void DgvUsers1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                return;
            }
        }
        private void BtnNewContract1_Click(object sender, EventArgs e)
        {
            WF_NewContract1 wF_NewContract1 = new WF_NewContract1(this);
            wF_NewContract1.Show(this);
        }

        public static int cId;
        public int CIdStored
        {
            get { return cId; }
            set { cId = value; }
        }
        public static int dgvContractRowIndex = 0;
        private void DgvContract1_SelectionChanged(object sender, EventArgs e)
        {

        }
        private void DgvContract1_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                return;
            }
            dgvContractRowIndex = e.RowIndex;
            cId = Int32.Parse(dgvContract1.Rows[dgvContractRowIndex].Cells[0].Value.ToString());
            RefreshContractInfoData();
            if (clicks == 1)
                AddSubtotalRows2();
        }
        private void DgvContract1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            if(dgvContract1.SelectedRows.Count > 0)
                cId = Int32.Parse(dgvContract1.Rows[dgvContractRowIndex].Cells[0].Value.ToString());
        }
        private void DgvUsers1_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                ColumnFilters.Users.cmDgvUsersHeader.Show(dgvUsers1, dgvUsers1.PointToClient(Cursor.Position));
            }
        }

        private void DgvContract1_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                ColumnFilters.Contracts.cmDgvContractsHeader.Show(dgvUsers1, dgvUsers1.PointToClient(Cursor.Position));
            }
        }
        public static string filterByYear = String.Empty;
        private void CbFilterByYear_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.cbFilterSelectedYear = cbFilterByYear.Texts;
            Properties.Settings.Default.Save();

            //selectedFilterYear = cbFilterByYear.Texts;
        }
    }
}
