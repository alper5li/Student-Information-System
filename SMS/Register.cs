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
using System.IO;
namespace Final.Project.C
{
    public partial class Register : Form
    {
        public SQLiteConnection myConnection;
        public Register()
        {
            InitializeComponent();
        }
        string Uname = "";
        string datalocation;
        public void connect()
        {

            string dataS = "Data Source = ";

            dataS += System.AppContext.BaseDirectory;
            dataS = dataS.Substring(0, dataS.Length - 10);
            dataS += "database\\UserList.db";
            myConnection = new SQLiteConnection(dataS);
            myConnection.Open();


        }

        public void connect2()
        {





            string dataS = "Data Source = ";

            dataS += System.AppContext.BaseDirectory;
            dataS = dataS.Substring(0, dataS.Length - 10);
            dataS += "database\\Databases\\" + Uname + ".db";

                SQLiteConnection conn = new SQLiteConnection(dataS);

                try
                {

                    SQLiteCommand cmd = new SQLiteCommand("CREATE TABLE StudentData(TermInfo INTEGER, CourseCode TEXT,CourseName TEXT, ECTS INTEGER, ExamScore INTEGER, LetterGrade TEXT, Number INTEGER UNIQUE, PRIMARY KEY(Number))", conn);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Table Created Successfully...");
                    conn.Close();
                }
                catch (Exception e)
                {
                    MessageBox.Show("exception occured while creating table:\n" + e.Message + "\t" + e.GetType());
                }




            

        }

   
        

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            TermCon TermCon = new TermCon();
            TermCon.Show();
        }
       
       
   
        public void button1_Click(object sender, EventArgs e)
        {
            connect();
            SQLiteCommand command = new SQLiteCommand();
            command.CommandText = "INSERT INTO UserList (FullName, ID, Mail, PhoneNumber, PassWord, Birth) VALUES (@FullName, @ID, @Mail, @Phone, @Pass, @Birth)";
            command.Connection = myConnection;
            var tb5 = "Empty";
            var tb7 = "Empty";
            var tb3 = "Empty";
            var tb1 = "Empty";
            var tb2 = "Empty";
            var tb4 = "Empty";

            

            
      

            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && textBox5.Text != "" && textBox7.Text != "" && textBox5.Text==textBox6.Text)
            {


                tb4 = textBox4.Text;
                tb2=textBox2.Text;    
             tb1 = textBox1.Text;
             tb3 = textBox3.Text;
             tb5 = textBox5.Text;
             tb7 = textBox7.Text.ToString();
               
            }
            if (checkBox1.Checked) 
            {
                if (tb1 != "" && tb2!= ""&& tb3 != "" && tb4 !=""&& tb5 != "" && tb7 != "" && textBox5.Text == textBox6.Text && label9.Text!= "Waiting to Upload Profile Picture....")
                {
                    try
                    {
                        command.Parameters.AddWithValue("@FullName", tb1);
                        command.Parameters.AddWithValue("@ID", tb2);
                        command.Parameters.AddWithValue("@Mail", tb3);
                        command.Parameters.AddWithValue("@Phone", tb4);
                        command.Parameters.AddWithValue("@Pass", tb5);
                        command.Parameters.AddWithValue("@Birth", tb7);
                        command.ExecuteNonQuery();
                        this.Uname = tb3.ToString();
                        MessageBox.Show("You've Registered ! \n\nYou Can Log in into System Right Now.", "Welcome", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        string dataS = "";
                        dataS += System.AppContext.BaseDirectory;
                        dataS = dataS.Substring(0, dataS.Length - 10);
                        dataS += "images\\userPP\\"+tb2+".jpg";


                        try
                        {
                            File.Copy(label9.Text,dataS);
                            label9.Text = "Image Saved !";
                        }

                        // Catch exception if the file was already copied.
                        catch (IOException copyError)
                        {
                            Console.WriteLine(copyError.Message);
                        }


                       
                       
                      
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    
                    try { connect2(); }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    finally
                    {
                        this.Close();
                    }        



                     
                                   
                }
                else
                {
                    MessageBox.Show("Empty Values are not allowed !", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            else
            {
                MessageBox.Show("You should have accept Terms and Conditions.", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            if (textBox5.Text != textBox6.Text)
            {
                MessageBox.Show("Password isnt Matching.", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            if(label9.Text == "Waiting to Upload Profile Picture....")
            {
                MessageBox.Show("You should add profile picture", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            myConnection.Close();
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            textBox5.UseSystemPasswordChar = true;
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            textBox6.UseSystemPasswordChar=true;
        }

        private void Register_Load(object sender, EventArgs e)
        {
            datalocation += System.AppContext.BaseDirectory;
            datalocation = datalocation.Substring(0, datalocation.Length - 10);
            datalocation += "images\\uskudar-university-logo.png";
            this.pictureBox1.Image = Image.FromFile(datalocation);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Reminder :\nYou can just select jpg images...", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Information);
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Image Files(*.jpg;)|*.jpg;";
            // open.Filter = "Image Files(*.jpg;)|*.jpg;";
            open.Multiselect = false;
            open.Title = "Select Profile Picture (*.jpg) Only...";
            
            if(open.ShowDialog() == DialogResult.OK)
            {
                label9.Text = open.FileName;
                pictureBox2.Image = new Bitmap(open.FileName);

            }

        }
    }
}
