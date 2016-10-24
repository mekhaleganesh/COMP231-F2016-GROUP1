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
    //Create a new record screen
    public partial class NewRecordForm : Form
    {
        public NewRecordForm()
        {
            InitializeComponent();
        }




        private void CancelButton_Click(object sender, EventArgs e)
        {
            //Close New Record window
            this.Close();
        }

        private void SaveNewRecordButton_Click(object sender, EventArgs e)
        {
            //Do something database stuff

            //If save is success then Pop up confirm
            ConfirmAlertForm confirmAlert = new ConfirmAlertForm();
            confirmAlert.Show();
        }
    }
}
