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
using PasswordApplication.Model;

namespace PasswordApplication
{
    //Create a new record screen
    public partial class NewRecordForm : Form
    {


        //CoreFunctions cf = new CoreFunctions();
        MainForm mainForm = new MainForm();
        Validation validate = new Validation();
        DatabaseHelper dh = new DatabaseHelper();

        UserNameValidator unv = new UserNameValidator();
        PasswordValidator pv = new PasswordValidator();
        NoteValidator nv = new NoteValidator();
        UserRecord userRecord = new UserRecord();
        

        SqlConnection conn;
        //private DataViewManager dsView;
        private DataSet ds;


        public NewRecordForm()
        {
            InitializeComponent();


            conn = new SqlConnection(@"Data Source=RYAN\RYANMSSQLSERVER; Initial Catalog=HexylogyDB;Integrated Security=SSPI");
            string getCategoryName = "SELECT DISTINCT d.CategoryID,d.CategoryName FROM UserRecord a INNER JOIN UserAccount b on b.UserAccountID = a.UserAccountID INNER JOIN UserRecordCategories c on c.RecordID = a.RecordID INNER JOIN Categories d on d.CategoryID = c.CategoryID WHERE b.UserAccountID = 1";
            SqlDataAdapter da = new SqlDataAdapter(getCategoryName,conn);
            

            // Build a dataset
            ds = new DataSet();
            da.Fill(ds, "Categories");
            // Table in Dataset
            

            DataSet ResultSet = new DataSet();
            DatabaseHelper.manupulateCategory(1).Fill(ResultSet, "Categories");
            foreach (DataRow dr1 in ResultSet.Tables[0].Rows)
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
				mainForm.Show();
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
            if (unv.Validate(UserNameTextBox.Text) == true)
            {
                //validation for username is correct
                errorProvider1.SetError(UserNameTextBox, "");
            }
            else
            {
                //validation for username is incorrect
                errorProvider1.SetError(UserNameTextBox, "Please enter username in alphabets and numbers only");
                return false;
            }
            if (pv.Validate(PasswordTextBox.Text) == true)
            {
                //validation for password is correct
                errorProvider1.SetError(PasswordTextBox, "");
                
            }
            else
            {
                //validation is incorrect
                errorProvider1.SetError(PasswordTextBox, "The password cannot contain any of the following: ‘,\\*&amp;$&lt;&gt;");
                return false;
            }
            if (PasswordTextBox.Text == VerifyPasswordTextBox.Text)
            {
                //validation for same password is correct
                errorProvider1.SetError(VerifyPasswordTextBox, "");
            }
            else
            {
                //validation for same password is incorrect
                errorProvider1.SetError(VerifyPasswordTextBox, "The passwords do not match.Please enter them again.");
                return false;
            }
            if (nv.Validate(NoteTextBox.Text) == true)
            {
                //correct validation
                errorProvider1.SetError(NoteTextBox, "");
                return true;
            }
            else
            {
                //incorrect validation
                errorProvider1.SetError(NoteTextBox, "Please don't put in any of the following characters ‘,\\*&amp;$&lt;&gt;");
                return false;
            }
        }

        //method to make Connection to database
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
