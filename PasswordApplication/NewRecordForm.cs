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
        DatabaseHelper dh = new DatabaseHelper();

        //private DataViewManager dsView;
        private DataSet ds;

        public NewRecordForm()
        {
            InitializeComponent();

            SqlConnection conn = new SqlConnection(dh.connectionString);
            string getCategoryName = "SELECT CategoryName FROM Categories WHERE UserAccountID = 1; ";
            SqlDataAdapter da = new SqlDataAdapter(getCategoryName, conn);

            // Build a dataset
            ds = new DataSet();
            da.Fill(ds, "Categories");
            // Table in Dataset

            foreach (DataRow dr1 in ds.Tables[0].Rows)
            {
                CategoryOptionComboBox.Items.Add(dr1["CategoryName"].ToString());
            }

        }
        private void NewRecordForm_Load(object sender, EventArgs e)
        {
            CategoryOptionComboBox.SelectedIndex = 0;


        }
        private void CancelButton_Click(object sender, EventArgs e)
        {
            //Close New Record window
            this.Close();
        }

        private void SaveNewRecordButton_Click(object sender, EventArgs e)
        {
            if (validating() == true)
            {

                //pass information to DB
                passInput();
                MessageBox.Show("Success");
                this.Close();
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
            dh.PassCategory = CategoryOptionComboBox.Text;
            dh.PassUserName = UserNameTextBox.Text;
            dh.PassPassword = PasswordTextBox.Text;
            dh.PassNote = NoteTextBox.Text;
            dh.passInput();
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
