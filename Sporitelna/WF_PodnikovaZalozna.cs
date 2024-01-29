using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sporitelna.CustomControsl;

namespace Sporitelna
{
    public partial class WF_PodnikovaZalozna : Form
    {
        public WF_PodnikovaZalozna()
        {
            InitializeComponent();
        }

        private void WF_PodnikovaZalozna_Load(object sender, EventArgs e)
        {
            this.BackColor = Color.FromArgb(249, 176, 0);
            txtPathAs.Texts = Properties.Settings.Default.txtAsPath;
            txtPathHolding.Texts = Properties.Settings.Default.txtHoldingPath;
            txtPathBus.Texts = Properties.Settings.Default.txtBusPath;
            txtPathLogistics.Texts = Properties.Settings.Default.txtLogisticsPath;
            txtPathServis.Texts = Properties.Settings.Default.txtServisPath;



        }

        private void BtnPZclose1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //fileContent INFO
        public string fcPersonalNumber;
        public string fcIndex;
        public string fcValue;
        
        private void BtnPZSavePath_Click(object sender, EventArgs e)
        {
            //UpdatePath
            
            
            
            for (int numberOfTFiles = 0; numberOfTFiles <= 4; numberOfTFiles++)
            {
                //MessageBox.Show(filePath[numberOfTFiles]);

                
                string[] lines = File.ReadAllLines(filePath[numberOfTFiles]);



                using (StreamReader sr = new StreamReader(filePath[numberOfTFiles]))
                {
                    //MessageBox.Show(lines[1].ToString());

                    foreach (string line in lines)
                    {
                        //MessageBox.Show(line.ToString());

                        Regex r = new Regex(" +"); //Rozdělí slova na řádku podle mezer
                        string[] lineContent = r.Split(line
                        );
                        try
                        {
                            fcPersonalNumber = lineContent[0];
                            fcIndex = lineContent[1];
                            fcValue = lineContent[2];
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                        MessageBox.Show(fcPersonalNumber + " " + fcIndex + " " + fcValue);



                        //UPDATE BALANCE JEDNOTLIVÝM UŽIVATELŮM WHERE OS ID = fcPersonalNumber




                    }



                }
            }
        }
        public Image[] img = new Image[5];
        public PictureBox[] pb = new PictureBox[5];

        Image imgAS;
        Image imgHolding;
        Image imgBus;
        Image imgLogistics;
        Image imgServis;

        public string[] filePath = new string[5];
        public string[] lastModifiedTime = new string[5];
        public void ShowLastModified(bool show, string[] lastModifiedTime)
        {
            if (show == true)
            {
                FileInfo fi = new FileInfo(filePath[0]);
                lastModifiedTime[0] = fi.LastWriteTime.ToString();
            }
        }
        private void BtnPZTestDrives_Click(object sender, EventArgs e)
        {
            for (int numberOfTFiles = 0; numberOfTFiles <= 4; numberOfTFiles++)
            {
                //img[numberOfTFiles] = new Image();
                pb[numberOfTFiles] = new PictureBox();
                // Thread.Sleep(1000);
                //try
                //{
                if (File.Exists(filePath[numberOfTFiles]) && filePath[numberOfTFiles].Contains("MZDY.T_"))
                {

                    img[numberOfTFiles] = Properties.Resources.pbOk1;

                    FileInfo fi = new FileInfo(filePath[numberOfTFiles]);
                    lastModifiedTime[numberOfTFiles] = fi.LastWriteTime.ToShortDateString();

                    

                }
                else
                {
                    img[numberOfTFiles] = Properties.Resources.pbStorno2;
                }
                pb[numberOfTFiles].BackgroundImage = img[numberOfTFiles];
            }
            pbAScheck.BackgroundImage = pb[0].BackgroundImage;
            pbHOLDINGcheck.BackgroundImage = pb[1].BackgroundImage;
            pbBUScheck.BackgroundImage = pb[2].BackgroundImage;
            pbLOGISTICScheck.BackgroundImage = pb[3].BackgroundImage;
            pbSERVIScheck.BackgroundImage = pb[4].BackgroundImage;


            /*txtPathAs.Texts = filePath[0] + "\t" + lastModifiedTime[0];
            txtPathHolding.Texts = filePath[1] + "\t" + lastModifiedTime[1];
            txtPathBus.Texts = filePath[2] + "\t" + lastModifiedTime[2];
            txtPathLogistics.Texts = filePath[3] + "\t" + lastModifiedTime[3];
            txtPathServis.Texts = filePath[4] + "\t" + lastModifiedTime[4];*/
        }

        private void TxtPathAs__TextChanged(object sender, EventArgs e)
        {
            filePath[0] = txtPathAs.Texts;
            
        }

        private void TxtPathHolding__TextChanged(object sender, EventArgs e)
        {
            filePath[1] = txtPathHolding.Texts;
            
        }

        private void TxtPathBus__TextChanged(object sender, EventArgs e)
        {
            filePath[2] = txtPathBus.Texts;
            
        }

        private void TxtPathLogistics__TextChanged(object sender, EventArgs e)
        {
            filePath[3] = txtPathLogistics.Texts;
            
        }

        private void TxtPathServis__TextChanged(object sender, EventArgs e)
        {
            filePath[4] = txtPathServis.Texts;
        }

        public string odFileContent;
        public string odFilePath;

        private void OpenPathDialog(SpTextBox1 selectedCompany)
        {
            //odFileContent = string.Empty;
            //odFilePath = string.Empty;

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    

                    selectedCompany.Texts = openFileDialog.FileName;

                    
                }
            }
        }

        private void BtnFindPathAs_Click(object sender, EventArgs e)
        {
            OpenPathDialog(txtPathAs);

            Properties.Settings.Default.txtAsPath = txtPathAs.Texts;
            Properties.Settings.Default.Save();
        }

        private void BtnFindPathHolding_Click(object sender, EventArgs e)
        {
            OpenPathDialog(txtPathHolding);
            Properties.Settings.Default.txtHoldingPath = txtPathHolding.Texts;
            Properties.Settings.Default.Save();
        }

        private void BtnFindPathBus_Click(object sender, EventArgs e)
        {
            OpenPathDialog(txtPathBus);
            Properties.Settings.Default.txtBusPath = txtPathBus.Texts;
            Properties.Settings.Default.Save();
        }

        private void BtnFindPathLogistics_Click(object sender, EventArgs e)
        {
            OpenPathDialog(txtPathLogistics);
            Properties.Settings.Default.txtLogisticsPath = txtPathLogistics.Texts;
            Properties.Settings.Default.Save();
        }

        private void BtnFindPathServis_Click(object sender, EventArgs e)
        {
            OpenPathDialog(txtPathServis);
            Properties.Settings.Default.txtServisPath = txtPathServis.Texts;
            Properties.Settings.Default.Save();
        }

        private void BtnDefaultSettings1_Click(object sender, EventArgs e)
        {

            txtPathAs.Texts = @"P:\PAM\MZDY.T_0";
            txtPathHolding.Texts = @"P:\PAM\holding\MZDY.T_1";
            txtPathBus.Texts = @"P:\PAM\bus\MZDY.T_1";
            txtPathLogistics.Texts = @"P:\PAM\logistics\MZDY.T_1";
            txtPathServis.Texts = @"P:\PAM\servis\MZDY.T_1";

            Properties.Settings.Default.txtAsPath = txtPathAs.Texts;
            Properties.Settings.Default.txtHoldingPath = txtPathHolding.Texts;
            Properties.Settings.Default.txtBusPath = txtPathBus.Texts;
            Properties.Settings.Default.txtLogisticsPath = txtPathLogistics.Texts;
            Properties.Settings.Default.txtServisPath = txtPathServis.Texts;
            Properties.Settings.Default.Save();
        }
    }
}
