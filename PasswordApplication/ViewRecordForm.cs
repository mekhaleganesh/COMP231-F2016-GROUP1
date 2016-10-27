using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PasswordApplication
{
    public partial class ViewRecordForm : Form
    {
        public ViewRecordForm()
        {
            InitializeComponent();
        }
        private string pUserName;
        private string pPassword;
        private string pNote;

        //getter and setter
        public string ViewUserName
        {
            get { return pUserName; }
            set { pUserName = value; }
        }
        public string ViewPassword
        {
            get { return pPassword; }
            set { pPassword = value; }
        }
        public string ViewNote        {
            get { return pNote; }
            set { pNote = value; }
        }

        private void ViewRecordForm_Load(object sender, EventArgs e)
        {
            //display the selected information
            //get information from DB and show the necessary information
            UserNameTextBox.Text = pUserName;
            PasswordTextBox.Text = pPassword;
            NoteTextBox.Text = pNote;

        }
        private void EditRecordButton_Click(object sender, EventArgs e)
        {
            //open edit records form
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
