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
    //Password App main screen
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void NewRecordButton_Click(object sender, EventArgs e)
        {
            Form NewRecordForm = new NewRecordForm();
            NewRecordForm.Show();
        }
    }
}
