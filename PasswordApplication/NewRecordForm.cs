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

namespace PasswordApplication
{
    //Create a new record screen
    public partial class NewRecordForm : Form
    {
        //CoreFunctions cf = new CoreFunctions();
        MainForm mainForm = new MainForm();
        Validation validate = new Validation();

        public NewRecordForm()
        {
            InitializeComponent();

        }
        private void NewRecordForm_Load(object sender, EventArgs e)
        {
            CategoryOptionComboBox.SelectedIndex = 0;


        }
        private void CancelButton_Click(object sender, EventArgs e)
        {
            //Close New Record window
            this.Close();
            //show the main screen form
            mainForm.Show();

        }

        private void SaveNewRecordButton_Click(object sender, EventArgs e)
        {
            if (validating() == true)
            {

                //pass information to DB
                //passInput();
                MessageBox.Show("Success");
            }
            else
            {
                //when missing/incorrect information still required.
                MessageBox.Show("Please enter the correct information and try again.");
                return;
            }


        }
        private bool validating()
        {
            //instantiating objects
            Validation userName = new Validation();
            Validation password = new Validation();
            Validation verifyPassword = new Validation();
            Validation verifyCategory = new Validation();
            Validation verifyNote = new Validation();
            userName.SUserName = UserNameTextBox.Text;
            password.SPassword = PasswordTextBox.Text;
            verifyPassword.SVerifyPassword = VerifyPasswordTextBox.Text;
            verifyPassword.SPassword = PasswordTextBox.Text;
            verifyCategory.SCategory = CategoryOptionComboBox.Text;
            verifyNote.SNote = NoteTextBox.Text;

            //if wrong validation, show error message
            while (true)
            {
                if (!userName.ValidateUserName())
                {
                    errorProvider1.SetError(UserNameTextBox, "Please enter username in alphabers and numbers only");
                    return false;
                }
                else
                {
                    errorProvider1.SetError(UserNameTextBox, "");
                }
                if (!password.ValidatePassword())
                {
                    errorProvider1.SetError(PasswordTextBox, "The password cannot contain any of the following: ‘,\\*&amp;$&lt;&gt;");
                    return false;
                }
                else
                {
                    errorProvider1.SetError(PasswordTextBox, "");
                }
                if (!verifyPassword.VerifyPassword())
                {
                    errorProvider1.SetError(VerifyPasswordTextBox, "The passwords do not match.Please enter them again.");
                    return false;
                }
                else
                {
                    errorProvider1.SetError(VerifyPasswordTextBox, "");

                }
                if (!verifyCategory.VerifyCategory())
                {
                    errorProvider1.SetError(CategoryOptionComboBox, "Please select a category");
                    return false;
                }
                else
                {
                    errorProvider1.SetError(CategoryOptionComboBox, "");
                }
                if (!verifyNote.VerifyNote())
                {
                    errorProvider1.SetError(NoteTextBox, "Please don't put in any of the following characters ‘,\\*&amp;$&lt;&gt;");
                    return false;
                }
                else
                {
                    errorProvider1.SetError(NoteTextBox, "");
                    return true;
                }
            }
        }

        //method to make connection to database
        //this method will go to different class if ryan's pull request gets approved.
        private void passInput()
        {
            string getConnectionString;
            //connection string needs to be changed once db is set up.
            getConnectionString = @"Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=HexylogyDB;Data Source=Lenovo-PC";

            //specify connection string here
            SqlConnection conn = new SqlConnection(getConnectionString);
            SqlCommand cmd;
            //SqlDataAdapter adpt;

            //input SQL Commands
            try
            {
                cmd = new SqlCommand("INSERT INTO UserRecord(UserName,UserPassword,Note) VALUES(@Username,@Password,@Notes)", conn);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@Username", UserNameTextBox.Text);
                cmd.Parameters.AddWithValue("@Password", PasswordTextBox.Text);
                //cmd.Parameters.AddWithValue("@Verify", VerifyPasswordTextBox.Text);
                cmd.Parameters.AddWithValue("@Notes", NoteTextBox.Text);
                //cmd.Parameters.AddWithValue("@Category", CategoryOptionComboBox.SelectedText);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                //show error in output
                Console.WriteLine(e.ToString());
            }
            finally
            {
                conn.Close();
            }
        }
        //method to show masked characters when checkbox is selected
        private void ShowPasswordChkBox_CheckedChanged_1(object sender, EventArgs e)
        {
            if (ShowPasswordChkBox.Checked == true)
            {
                PasswordTextBox.PasswordChar = '\0';
                VerifyPasswordTextBox.PasswordChar = '\0';
            }
            else
            {
                PasswordTextBox.PasswordChar = '*';
                VerifyPasswordTextBox.PasswordChar = '*';

            }
        }
    }
}
