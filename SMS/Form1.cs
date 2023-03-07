using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Xml;

namespace Final.Project.C
{

    public partial class Form1 : Form
    {
        public SQLiteConnection myConnection;
        public SQLiteConnection myBaglanti;
        string Uname = "FinalProject";
        string datalocation;
        string datalocation2;
       
        


        public void dataLocation(String path)
        {   
            datalocation += System.AppContext.BaseDirectory;
            datalocation=datalocation.Substring(0, datalocation.Length - 10);
            datalocation += path;
        }
        
        public void connect()
        {
            string dataS = "Data Source = ";      
            dataS += System.AppContext.BaseDirectory;
            dataS = dataS.Substring(0,dataS.Length - 10);
            dataS += "database\\Databases\\"+Uname+".db";
            myConnection = new SQLiteConnection(dataS);
            myConnection.Open();

            /*myConnection = new SQLiteConnection("Data Source = C:\\..\\database\\FinalProject.db");
           
            myConnection.Open();*/
        }
        public void baglanti()
        {
            /*myBaglanti = new SQLiteConnection("Data Source = C:\\..\\database\\UserList.db");
            myBaglanti.Open();*/

            string dataS = "Data Source = ";
            
            dataS += System.AppContext.BaseDirectory;
            dataS = dataS.Substring(0, dataS.Length - 10);
            dataS += "database\\UserList.db";
            myBaglanti = new SQLiteConnection(dataS);
            myBaglanti.Open();
        }
 
        public Form1()
        {
            InitializeComponent();

        }
        
        int TermInfo;
        String CourseCode;
        String CourseName;
        int ECTS;
        String Grade;
        int ExamScore;
        String valuee;
        /// <summary>
        /// ///////////////////////////////////////////////////////////
        /// </summary>
        Boolean isCorrect = false;

        private void Auth()
        {



            String xId = "";
            String xMail = "";
            String xFullName = "";
            String xPhoneNumber = "";
            String xBirth = "";


            baglanti();
            SQLiteCommand command2 = new SQLiteCommand("select Mail, PassWord,FullName,ID,PhoneNumber,Birth from UserList order by 1 ", myBaglanti);
            SQLiteDataReader sqReader = command2.ExecuteReader();

            while (sqReader.Read())
            {
                if (textBox13.Text == sqReader["Mail"].ToString())
                {
                    if (textBox14.Text == sqReader["PassWord"].ToString())
                    {
                        xId = sqReader["ID"].ToString();
                        xMail = sqReader["Mail"].ToString();
                        xFullName = sqReader["FullName"].ToString();
                        xPhoneNumber = sqReader["PhoneNumber"].ToString();
                        xBirth = sqReader["Birth"].ToString();
                        this.isCorrect = true;


                    }

                }


            }


            if (this.isCorrect == false)
            {
                MessageBox.Show("Wrong Credentials. Please Check Your Mail and Password !", "Unauthorized", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            else if (this.isCorrect == true)
            {
                MessageBox.Show("Welcome Back !", "Welcome", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Uname = textBox13.Text;
                actSt.Text = "Active Student Info";
                actSt.Visible = true;
                textBox13.Enabled = false;
                textBox14.Enabled = false;
                textBox13.Text = "**************";
                textBox14.Text = "**************";
                tabPage1.Enabled = true;
                tabPage2.Enabled = true;
                tabPage3.Enabled = true;
                tabPage4.Enabled = true;
                tabPage5.Enabled = true;
                tabPage6.Enabled = true;
                tabPage1.Show();
                tabPage2.Show();
                tabPage3.Show();
                tabPage4.Show();
                tabPage5.Show();


                label25.Text = "ID :\n\t\t" + xId + "\n\nName :\n\t\t" + xFullName + "\nPhone Number :\n\t\t" + xPhoneNumber + "\n\nE-mail :\n\t\t" + xMail + "\n\nBirth Date :\n\t\t" + xBirth;
                label25.Visible = true;
                button14.Visible = true;
                button14.Enabled = true;
                button19.Visible = false;
                button19.Enabled = false;


                string dataS ="";

                dataS += System.AppContext.BaseDirectory;
                dataS = dataS.Substring(0, dataS.Length - 10);
                dataS += "images\\userPP\\"+xId+".jpg";
                // dataS += "images\\index.jpg";";      
              

                try
                {
                    pictureBox2.Image = Image.FromFile(dataS);
                }
                catch (Exception e)
                {
                    MessageBox.Show("User Profile Photo Couldn't Found.\n"+e);
                }


                pictureBox2.Visible = true;
                




                button15.Enabled = false;
                
                label30.Visible = false;
                linkLabel1.Visible = false;
            }

            myBaglanti.Close();


            /* connect();
            SQLiteCommand command1 = new SQLiteCommand("select ECTS,TermInfo,LetterGrade from FinalProject order by 1 ", myConnection);
            SQLiteDataReader sqReader = command1.ExecuteReader();
            while (sqReader.Read())
            {
                if (comboBox1.Text == sqReader["TermInfo"].ToString())
                {
                    if (sqReader["LetterGrade"].ToString() == "AA")
                    {
                        gpa += (4.00 * Convert.ToInt16(sqReader["ECTS"]));
                    }
                    else if (sqReader["LetterGrade"].ToString() == "BA") */




        }



        /// <summary>
        /// /////////////////////////////////////////////////////////////
        /// </summary>
        String TryID;
        String TryPass;
        public void textBox1_TextChanged(object sender, EventArgs e)
        {
            //this.TermInfo = Convert.ToInt16(textBox1.Text);

            if (!int.TryParse(textBox1.Text.Trim(), out this.TermInfo)) 
            {
                
                MessageBox.Show("You Entered Wrong Character. \n( Term Value Only Accepts Integer Value. )","Attention", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
            }
            else
            {
                this.TermInfo= Convert.ToInt16(textBox1.Text);
            }

        }

        public void textBox2_TextChanged(object sender, EventArgs e)
        {
            this.CourseCode = textBox2.Text;
        }

        public void textBox3_TextChanged(object sender, EventArgs e)
        {
          this.CourseName = textBox3.Text;
        }

        public void textBox4_TextChanged(object sender, EventArgs e)
        {
            // this.ECTS = Convert.ToInt16(textBox4.Text);
            if (!int.TryParse(textBox4.Text.Trim(), out this.ECTS))
            {

                MessageBox.Show("You Entered Wrong Character. \n( ECTS Value Only Accepts Integer Value. )", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {
                this.ECTS = Convert.ToInt16(textBox4.Text);
            }
        }

        public void textBox5_TextChanged(object sender, EventArgs e)
        {

            //this.ExamScore = Convert.ToInt16(textBox5.Text);


            if (!int.TryParse(textBox5.Text.Trim(), out this.ExamScore))
            {

                MessageBox.Show("You Entered Wrong Character. \n( Exam Score Value Only Accepts Integer Value. )", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {
                this.ExamScore = Convert.ToInt16(textBox5.Text);
            }
            




            if (this.ExamScore >= 0 && this.ExamScore < 50)
            {
                this.Grade = "FF";
            }
            else if(this.ExamScore >= 50 && this.ExamScore < 60)
            {
                this.Grade = "FD";
            }
            else if (this.ExamScore >= 60 && this.ExamScore < 65)
            {
                this.Grade = "DD";
            }
            else if(this.ExamScore >= 65 && this.ExamScore < 70)
            {
                this.Grade = "DC";
            }
            else if (this.ExamScore >= 70 && this.ExamScore < 75)
            {
                this.Grade = "CC";
            }
            else if (this.ExamScore >= 75 && this.ExamScore < 80)
            {
                this.Grade = "CB";
            }
            else if (this.ExamScore >= 80 && this.ExamScore < 85)
            {
                this.Grade = "BB";
            }
            else if (this.ExamScore >= 85 && Convert.ToInt64(textBox5.Text) < 90)
            {
                this.Grade = "BA";
            }
            else if (this.ExamScore >= 90 && this.ExamScore < 101)
            {
                this.Grade = "AA";
            }
            
            else
            {
                MessageBox.Show("You Entered Wrong Number ...");
                return;
            }
        }

        public void button1_Click(object sender, EventArgs e)
        {
            connect();
            SQLiteCommand command = new SQLiteCommand();
            command.CommandText = "select TermInfo, CourseCode, CourseName, ECTS, ExamScore, LetterGrade from StudentData order by 1 ";
            command.Connection = myConnection;
            SQLiteDataAdapter adapter = new SQLiteDataAdapter(command);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
            myConnection.Close();
            
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

     
        private void Form1_Load_1(object sender, EventArgs e)
        {
            button14.Visible = false;
            button14.Enabled = false;
            datalocation2 += System.AppContext.BaseDirectory;
            datalocation2 = datalocation2.Substring(0, datalocation2.Length - 10);
            datalocation2 +="images\\123.jpg";
            Image myimage = new Bitmap(datalocation2);
            this.BackgroundImage = myimage;
            timer1.Start();
            timer1.Enabled = true;
            tabPage4.Text = "Web Browser";
            label25.Visible = false;
            actSt.Visible = false;
      
            this.MaximizeBox = false;
            datalocation += System.AppContext.BaseDirectory;
            datalocation = datalocation.Substring(0, datalocation.Length - 10);
            datalocation += "images\\";
            string dataiconloc = datalocation+"icons\\";

            this.pictureBox1.Image = Image.FromFile(datalocation + "uskudar-university-logo.png");

            ///// ///// ///// ////////// ///// ///// /////
            string today = "http://www.tcmb.gov.tr/kurlar/today.xml";

            var xmlDoc = new XmlDocument();
            xmlDoc.Load(today);

            // Xml içinden tarihi alma - gerekli olabilir
            DateTime exchangeDate = Convert.ToDateTime(xmlDoc.SelectSingleNode("//Tarih_Date").Attributes["Tarih"].Value);

            string USD = xmlDoc.SelectSingleNode("Tarih_Date/Currency[@Kod='USD']/BanknoteSelling").InnerXml;
            string EURO = xmlDoc.SelectSingleNode("Tarih_Date/Currency[@Kod='EUR']/BanknoteSelling").InnerXml;
            string POUND = xmlDoc.SelectSingleNode("Tarih_Date/Currency[@Kod='GBP']/BanknoteSelling").InnerXml;
            string CAD = xmlDoc.SelectSingleNode("Tarih_Date/Currency[@Kod='CAD']/BanknoteSelling").InnerXml;
            string AUD = xmlDoc.SelectSingleNode("Tarih_Date/Currency[@Kod='AUD']/BanknoteSelling").InnerXml;
            string DKK = xmlDoc.SelectSingleNode("Tarih_Date/Currency[@Kod='DKK']/BanknoteSelling").InnerXml;
            label33.Text = "    USD : " + USD + "    EUR : " + EURO + "    POUND : " + POUND + "    CAD : " + CAD + "    AUD : " + AUD + "    DKK: " + DKK + "  Last Updated : " + exchangeDate;
           






      
            ///// ///// ///// ////////// ///// ///// /////


        }

        int W;
        
        private void timer1_Tick(object sender, EventArgs e)
        {
            label6.Text = DateTime.Now.ToLongDateString();
            label7.Text = DateTime.Now.ToLongTimeString();
            ///// ///// ///// ////////// ///// ///// /////
            //label33.Text = label33.Text.Substring(1) + label33.Text.Substring(0, 1);
            
            timer1.Interval = 10;
            
            if (label33.Left > -1250)
            {
                label33.Left -= 2;

            }
            else
            {
                label33.Left = 950;
            }

            ///// ///// ///// ////////// ///// ///// /////
        }

        private void button2_Click(object sender, EventArgs e)
        {
            connect();
            SQLiteCommand command = new SQLiteCommand();
            command.CommandText = "INSERT INTO StudentData (TermInfo, CourseCode, CourseName, ECTS, ExamScore, LetterGrade) VALUES (@Terminfo, @CCode, @CName, @ECTS, @ExmScore, @LGrade)";
            command.Connection = myConnection;
            String tb1 = textBox1.Text;
            String tb2 = textBox2.Text;
            String tb3 = textBox3.Text;
            String tb4 = textBox4.Text;
            String tb5 = textBox5.Text;


            if (tb1 != "" && tb2 != "" && tb3 != "" && tb4 != "" && tb5 != "")
            {
                command.Parameters.AddWithValue("@Terminfo", tb1);
                command.Parameters.AddWithValue("@CCode", tb2);
                command.Parameters.AddWithValue("@CName", tb3);
                command.Parameters.AddWithValue("@ECTS",tb4);
                command.Parameters.AddWithValue("@ExmScore", tb5);
                command.Parameters.AddWithValue("@LGrade", Grade);
                command.ExecuteNonQuery();
            }
            else
            {
                MessageBox.Show("Empty Values are not allowed !","Attention",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            button1_Click(sender,e);
 
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void button3_Click(object sender, EventArgs e)
        {
            connect();
            SQLiteCommand command = new SQLiteCommand();
            command.CommandText = "select Number, TermInfo, CourseCode, CourseName, ECTS, ExamScore, LetterGrade from StudentData order by 1 ";
            command.Connection = myConnection;
            SQLiteDataAdapter adapter = new SQLiteDataAdapter(command);
            DataTable dt2 = new DataTable();
            adapter.Fill(dt2);
            dataGridView2.DataSource = dt2;
            myConnection.Close();
        }
        private void button4_Click(object sender, EventArgs e)
        {
            connect();
            string NumberDelete = this.valuee;       
            SQLiteCommand sqlCmd = new SQLiteCommand();
            sqlCmd.CommandText = "Delete from StudentData where Number='" + NumberDelete + "'";
            sqlCmd.Connection = myConnection;
            sqlCmd.ExecuteNonQuery();
            button1_Click(sender, e);
            progressBar1.Minimum = 0;
            progressBar1.Maximum = 100;
            for (int i = 0; i <= 100; i++)
            {
                progressBar1.Value = i;
                
            }
            MessageBox.Show("Data Removed Successfully...", ";)", MessageBoxButtons.OK, MessageBoxIcon.Information);
            progressBar1.Value = 0;
            myConnection.Close();
            button3_Click(sender, e);
        }
        private void textBox6_TextChanged(object sender, EventArgs e)
        {
           this.valuee = (textBox6.Text);
        }
        private void button5_Click(object sender, EventArgs e)
        {
            connect();
            SQLiteCommand command = new SQLiteCommand();
            command.CommandText = "select TermInfo, CourseCode, CourseName, ECTS, ExamScore, LetterGrade from StudentData order by 1 ";
            command.Connection = myConnection;
            SQLiteDataAdapter adapter = new SQLiteDataAdapter(command);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGridView3.DataSource = dt;
            myConnection.Close();
        }
        private void textBox7_TextChanged(object sender, EventArgs e)
        {
  

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
         
        }
        private void button6_Click(object sender, EventArgs e)
        {
            SQLiteCommand command = new SQLiteCommand();
            command.CommandText = "select CourseCode, TermInfo, CourseName, ECTS, ExamScore, LetterGrade from StudentData WHERE CourseCode LIKE '" + textBox7.Text + "%' AND TermInfo LIKE '" + textBox8.Text + "%' AND LetterGrade LIKE '" + textBox9.Text + "%' AND CourseName LIKE '" + textBox10.Text + "%' AND ECTS LIKE '" + textBox11.Text + "%'";
            command.Connection = myConnection;
            SQLiteDataAdapter adapter = new SQLiteDataAdapter(command);
            DataTable dt1 = new DataTable();
            adapter.Fill(dt1);
            dataGridView3.DataSource = dt1;
            myConnection.Close();
        }
        private void textBox12_TextChanged(object sender, EventArgs e)
        {
            textBox7.Clear();
            textBox8.Clear();
            textBox9.Clear();
            textBox10.Clear();
            textBox11.Clear();
            SQLiteCommand command = new SQLiteCommand();
            command.CommandText = "select CourseCode, TermInfo, CourseName, ECTS, ExamScore, LetterGrade from StudentData WHERE CourseCode LIKE '" + textBox12.Text + "%' OR TermInfo LIKE '" + textBox12.Text + "%' OR LetterGrade LIKE '" + textBox12.Text + "%' OR CourseName LIKE '" + textBox12.Text + "%' OR ECTS LIKE '" + textBox12.Text + "%'";
            command.Connection = myConnection;
            SQLiteDataAdapter adapter = new SQLiteDataAdapter(command);
            DataTable dt1 = new DataTable();
            adapter.Fill(dt1);
            dataGridView3.DataSource = dt1;
            myConnection.Close();
        }
        private void tabControl1_MouseClick(object sender, MouseEventArgs e)
        {

            if (this.isCorrect == false)
            {
                tabPage1.Hide();
                tabPage2.Hide();
                tabPage3.Hide();
                tabPage4.Hide();
                tabPage5.Hide();

                tabPage1.Enabled = false;
                tabPage2.Enabled = false;
                tabPage3.Enabled = false;
                tabPage4.Enabled = false;
                tabPage5.Enabled = false;
                tabPage6.Enabled = true;

                MessageBox.Show("Authentiaction Failed. You Must Log in to System First.", "Invalid User", MessageBoxButtons.OK, MessageBoxIcon.Question);
                tabControl1.SelectedTab = tabPage6;

            }
            else if (this.isCorrect == true)
            {
                label19.Text = "Choose Term Number ...";
                label20.Text = "Choose Term Number ...";
                label22.Text = "Choose Term Number ...";
                label24.Text = "Choose Term Number ...";
                connect();
                SQLiteCommand command = new SQLiteCommand(myConnection);
                command.CommandText = "select TermInfo, CourseCode, CourseName, ECTS, ExamScore, LetterGrade from StudentData";
                command.Connection = myConnection;
                SQLiteDataAdapter adapter = new SQLiteDataAdapter(command);
                DataTable dt = new DataTable();

                adapter.Fill(dt);
                dataGridView4.DataSource = dt;
                SQLiteCommand command2 = new SQLiteCommand("select * from StudentData order by 1 ", myConnection);
                SQLiteDataReader sqReader = command2.ExecuteReader();
                while (sqReader.Read())
                {
                    if (comboBox1.Items.Contains(sqReader["TermInfo"]))
                    {

                    }
                    else
                    {
                        comboBox1.Items.Add(sqReader["TermInfo"]);
                    }
                }
                myConnection.Close();




            }






        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            label19.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            label20.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            label22.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            label24.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));

            int cgpaTermValue = 0;
            double cgpa = 0;
            double cgpaFinal = 0;
            double gpaFinal = 0;
            double gpa = 0;
            int termValue = 0;
            int MaxCred = 0;
            //
            connect();
            SQLiteCommand command1 = new SQLiteCommand("select ECTS,TermInfo,LetterGrade from StudentData order by 1 ", myConnection);
            SQLiteDataReader sqReader = command1.ExecuteReader();
            while (sqReader.Read())
            {
                if (comboBox1.Text == sqReader["TermInfo"].ToString())
                {
                    if (sqReader["LetterGrade"].ToString() == "AA")
                    {
                        gpa += (4.00 * Convert.ToInt16(sqReader["ECTS"]));
                    }
                    else if(sqReader["LetterGrade"].ToString() == "BA")
                    {
                        gpa += (3.50 * Convert.ToInt16(sqReader["ECTS"]));
                    }
                    else if (sqReader["LetterGrade"].ToString() == "BB")
                    {
                        gpa += (3.00 * Convert.ToInt16(sqReader["ECTS"]));
                    }
                    else if (sqReader["LetterGrade"].ToString() == "CB")
                    {
                        gpa += (2.50 * Convert.ToInt16(sqReader["ECTS"]));
                    }
                    else if (sqReader["LetterGrade"].ToString() == "CC")
                    {
                        gpa += (2.00 * Convert.ToInt16(sqReader["ECTS"]));
                    }
                    else if (sqReader["LetterGrade"].ToString() == "DC")
                    {
                        gpa += (1.50 * Convert.ToInt16(sqReader["ECTS"]));
                    }
                    else if (sqReader["LetterGrade"].ToString() == "DD")
                    {
                        gpa += (1.00 * Convert.ToInt16(sqReader["ECTS"]));
                    }
                    else if (sqReader["LetterGrade"].ToString() == "FD")
                    {
                        gpa += (0.50 * Convert.ToInt16(sqReader["ECTS"]));
                    }
                    else if (sqReader["LetterGrade"].ToString() == "FF")
                    {
                        gpa += 0;
                    }
                    termValue += Convert.ToInt16(sqReader["ECTS"]);
                    gpaFinal = gpa / termValue;
                    if (comboBox1.Text == "1")
                    {
                        MaxCred = 31;
                    }
                    else if(comboBox1.Text == "2")
                    {
                        MaxCred = 29;
                    }
                    else if (comboBox1.Text == "3")
                    {
                        MaxCred = 30;
                    }
                    else if (comboBox1.Text == "4")
                    {
                        MaxCred = 30;
                    }
                    else if (comboBox1.Text == "5")
                    {
                        MaxCred = 32;
                    }
                    else if (comboBox1.Text == "6")
                    {
                        MaxCred = 30;
                    }
                    else if (comboBox1.Text == "7")
                    {
                        MaxCred = 30;
                    }
                    else if (comboBox1.Text == "8")
                    {
                        MaxCred = 30;
                    }
                }
                if (sqReader["LetterGrade"].ToString() == "AA")
                {
                    cgpa += (4.00 * Convert.ToInt16(sqReader["ECTS"]));
                }
                    else if (sqReader["LetterGrade"].ToString() == "BA")
                {
                    cgpa += (3.50 * Convert.ToInt16(sqReader["ECTS"]));
                }
                else if (sqReader["LetterGrade"].ToString() == "BB")
                {
                    cgpa += (3.00 * Convert.ToInt16(sqReader["ECTS"]));
                }
                else if (sqReader["LetterGrade"].ToString() == "CB")
                {
                    cgpa += (2.50 * Convert.ToInt16(sqReader["ECTS"]));
                }
                else if (sqReader["LetterGrade"].ToString() == "CC")
                {
                    cgpa += (2.00 * Convert.ToInt16(sqReader["ECTS"]));
                }
                else if (sqReader["LetterGrade"].ToString() == "DC")
                {
                    cgpa += (1.50 * Convert.ToInt16(sqReader["ECTS"]));
                }
                else if (sqReader["LetterGrade"].ToString() == "DD")
                {
                    cgpa += (1.00 * Convert.ToInt16(sqReader["ECTS"]));
                }
                else if (sqReader["LetterGrade"].ToString() == "FD")
                {
                    cgpa += (0.50 * Convert.ToInt16(sqReader["ECTS"]));
                }
                else if (sqReader["LetterGrade"].ToString() == "FF")
                {
                    cgpa += 0;
                }
                cgpaTermValue += Convert.ToInt16(sqReader["ECTS"]);
                cgpaFinal = cgpa / cgpaTermValue;
            }
            myConnection.Close();
            label19.Text = termValue.ToString() +" / "+MaxCred;
            label20.Text = gpaFinal.ToString("f");
            label22.Text= cgpaFinal.ToString("f");
            label24.Text = cgpaTermValue.ToString();
        }
        private void button7_Click(object sender, EventArgs e)
        {
            string WebPage = "https://uskudar.edu.tr/tr/uek";
            webBrowser1.Navigate(WebPage);
            

        }
        private void button12_Click(object sender, EventArgs e)
        {
            if (webBrowser1.CanGoBack)
            {
            
                webBrowser1.GoBack();
            }
        }
        private void button11_Click(object sender, EventArgs e)
        {
            webBrowser1.GoHome();
       
        }
        private void button10_Click(object sender, EventArgs e)
        {
            webBrowser1.Refresh();
        
        }
        private void button13_Click(object sender, EventArgs e)
        {
            if (webBrowser1.CanGoForward)
            {
                webBrowser1.GoForward();
            

            }
        }
        private void button8_Click(object sender, EventArgs e)
        {
            string WebPage = "https://obs.uskudar.edu.tr/oibs/ogrenci/login.aspx";
            webBrowser1.Navigate(WebPage);
 
        }
        private void button9_Click(object sender, EventArgs e)
        {
            string WebPage = "https://stix.uskudar.edu.tr/login";
            webBrowser1.Navigate(WebPage);
    
        }
        private void button14_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Information for new User\n\n\n\nYou can add/delete courses and search courses from this application.\n\nIn 'View All Grades' section, you can see your gpa and cgpa calculations (wheter you can change your grades or deleted them something in the list it gives in time correct calculation).\n\nYou can surf on the internet by 'Web Browser' and can directly go through your University's selected learning system tab.\n\n\n\n\t  Stay Safe, good luck with your dreams.\n\n\t\t\t\t\tA5li", "\t\tHi !",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }

        public void button15_Click(object sender, EventArgs e)
        {
            this.TryID = textBox13.Text;
            this.TryPass = textBox14.Text;   
            
            Auth();

         
        }

     

        private void button16_Click(object sender, EventArgs e)
        {
            Clipboard.SetText("alper.besli@st.uskudar.edu.tr");
            MessageBox.Show("Username Copied Succesfully...  ", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button17_Click(object sender, EventArgs e)
        {
            Clipboard.SetText("A190209030!");
            MessageBox.Show("Password Copied Succesfully...  ", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button18_Click(object sender, EventArgs e)
        {
            String asdl = textBox15.Text;
            if (!string.IsNullOrEmpty(asdl))
            {
                webBrowser1.Navigate("https://www.google.com/search?q="+asdl);
                textBox15.Text ="https://www.google.com/search?q=" + asdl;
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Register register = new Register();
            register.Show();
        }

        private void label25_Click(object sender, EventArgs e)
        {

        }

        private void textBox14_TextChanged(object sender, EventArgs e)
        {
            textBox14.UseSystemPasswordChar = true;
        }

        private void button19_Click(object sender, EventArgs e)
        {
            textBox13.Text = "alper.besli@st.uskudar.edu.tr";
            textBox14.Text = "A190209030!";
            button15_Click(sender, e);

        }

        private void button20_Click(object sender, EventArgs e)
        {
            DialogResult x = MessageBox.Show("Are You Sure You Want To Exit ?","Exiting", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (x == DialogResult.Yes)
            {
                this.Close();
            }
            else if (x == DialogResult.No)
            {
                
            }
        }

        private void tabPage6_Click(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void textBox13_TextChanged(object sender, EventArgs e)
        {

        }

        private void label27_Click(object sender, EventArgs e)
        {

        }

        private void button14_Click_1(object sender, EventArgs e)
        {

            
            MessageBox.Show("Logged Out !", "Goodbye !", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Uname = textBox13.Text;
            this.TryID = "";
            this.TryPass = "";
            textBox13.Clear();
            textBox14.Clear();
            
            actSt.Visible = false;
            textBox13.Enabled = true;
            textBox14.Enabled = true;
            
            tabPage1.Enabled = true;
            tabPage2.Enabled = true;
            tabPage3.Enabled = true;
            tabPage4.Enabled = true;
            tabPage5.Enabled = true;
            tabPage6.Enabled = true;

            label25.Visible = false;

            pictureBox2.Visible = false;


            button15.Enabled = true;

            label30.Visible = true;
            linkLabel1.Visible = true;
            this.isCorrect = false;
            if (this.isCorrect == false)
            {
                tabPage1.Hide();
                tabPage2.Hide();
                tabPage3.Hide();
                tabPage4.Hide();
                tabPage5.Hide();

                tabPage1.Enabled = false;
                tabPage2.Enabled = false;
                tabPage3.Enabled = false;
                tabPage4.Enabled = false;
                tabPage5.Enabled = false;
                tabPage6.Enabled = true;
                tabControl1.SelectedTab = tabPage6;

            }
            button14.Visible = false;
            button14.Enabled = false;
            button19.Visible = true;
            button19.Enabled = true;

        }
    }
}
