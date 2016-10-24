using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
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
        //set up Database helper stuff to get connection.
        private DatabaseHelper dbHelper = new DatabaseHelper();

        public MainForm()
        {
            InitializeComponent();
            
        }

        private void NewRecordButton_Click(object sender, EventArgs e)
        {
            Form NewRecordForm = new NewRecordForm();
            NewRecordForm.Show();
        }

        private void stopTreeViewSound(object sender, KeyEventArgs e)
        {
            e.Handled = e.SuppressKeyPress = true;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            DisplayUserRecordDataGrid();
        }


        // set up UserRecordDataGrid view's properties then connect to database and display the data.
        public void DisplayUserRecordDataGrid()
        {
            userRecordDataGridView.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            // Bind the DataGridView to the BindingSource
            // and load the data from the database.
            userRecordDataGridView.DataSource = dbHelper.GetData("select * from dbo.UserRecord");
            // Resize the DataGridView columns to fit the newly loaded content.
            userRecordDataGridView.AutoResizeColumns(
                DataGridViewAutoSizeColumnsMode.ColumnHeader);
            //Remove "RecordID" column from DataGrid
            userRecordDataGridView.Columns.Remove("RecordID");
            //Hide "Note","UserAccountID" columns from DataGrid
            userRecordDataGridView.Columns["UserAccountID"].Visible = false;
            userRecordDataGridView.Columns["Note"].Visible = false;
            // Rename columuns
            userRecordDataGridView.Columns[0].HeaderText = "USER NAME";
            userRecordDataGridView.Columns[1].HeaderText = "PASSWORD";
            userRecordDataGridView.ScrollBars = ScrollBars.Horizontal;
            
        }



        // DataGrid view cell formatting event handler -- Formatting password cell to hide password
        private void userRecordDataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            //Show toolTip for remaining user use click to copy user name or password to clipboard.
            DataGridViewCell cell = this.userRecordDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex];
            cell.ToolTipText = "Click cooresponding cell to copy user name or password";

            //Format password, hide password as '*'
            if (userRecordDataGridView.Columns[e.ColumnIndex].Name == "UserPassword" && e.Value != null)
            {
                userRecordDataGridView.Rows[e.RowIndex].Tag = e.Value;
                e.Value = new String('*', e.Value.ToString().Length);
            }
        }

        //Cast GridView column to textbox and use Textbox's passwordChar feature (GirdView should be editable)
        /*
        private void userRecordDataGridView_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (userRecordDataGridView.CurrentRow.Tag != null)
                e.Control.Text = userRecordDataGridView.CurrentRow.Tag.ToString();
        }
        */

        //DataGrid view mouse click event handler
        //when user click the cell, password and user name will be save to clipboard
        private void CopyPaste_Click(object sender, DataGridViewCellMouseEventArgs e)
        {
            //If current column is Password column, it pass the actual password to clipboard
            if (userRecordDataGridView.Columns[e.ColumnIndex].Name == "UserPassword")
            {
                try
                {
                    // Add the selection to the clipboard.
                    Clipboard.SetDataObject(userRecordDataGridView.CurrentRow.Tag);

                    // Replace the text box contents with the clipboard text.
                    //this.TextBox1.Text = Clipboard.GetText();
                }
                catch (System.Runtime.InteropServices.ExternalException)
                {
                    //("The Clipboard could not be accessed. Please try again.");
                }
            }
            //if not , that means it is user name column, it passes the user name to clipboard
            else
            {
                try
                {
                    // Add the selection to the clipboard.
                    Clipboard.SetDataObject(userRecordDataGridView.GetClipboardContent());

                    // Replace the text box contents with the clipboard text.
                    //this.TextBox1.Text = Clipboard.GetText();
                }
                catch (System.Runtime.InteropServices.ExternalException)
                {
                    //("The Clipboard could not be accessed. Please try again.");
                }
            }
        }
    }
}
