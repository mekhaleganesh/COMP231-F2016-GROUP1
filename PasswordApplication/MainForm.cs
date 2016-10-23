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
        //set up Database stuff.
        private DataGridView userRecordListDataGrid = new DataGridView();
        private BindingSource bindingSource = new BindingSource();
        private SqlDataAdapter dataAdapter = new SqlDataAdapter();

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
            // Bind the DataGridView to the BindingSource
            // and load the data from the database.
            userRecordDataGridView.DataSource = bindingSource;
            userRecordDataGridView.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            GetData("select * from dbo.UserRecord");
        }


        // GetDate from the database
        private void GetData(string selectCommand)
        {
            try
            {
                // Specify a connection string. Replace the given value with a 
                // valid connection string for a Northwind SQL Server sample
                // database accessible to your system.
                String connectionString =
                    "Integrated Security=SSPI;Persist Security Info=False;" +
                    "Initial Catalog=HexylogyDB;Data Source=RYAN\\RYANMSSQLSERVER";

                // Create a new data adapter based on the specified query.
                dataAdapter = new SqlDataAdapter(selectCommand, connectionString);

                // Create a command builder to generate SQL update, insert, and
                // delete commands based on selectCommand. These are used to
                // update the database.
                SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);

                // Populate a new data table and bind it to the BindingSource.
                DataTable table = new DataTable();
                table.Locale = System.Globalization.CultureInfo.InvariantCulture;
                dataAdapter.Fill(table);
                bindingSource.DataSource = table;

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
                userRecordDataGridView.HorizontalScrollingOffset = 1;
                

            }
            catch (SqlException)
            {
                MessageBox.Show("To run this example, replace the value of the " +
                    "connectionString variable with a connection string that is " +
                    "valid for your system.");
            }
        }



        // Forgetting password cell to hide password
        private void userRecordDataGridView_CellFormatting_1(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (userRecordDataGridView.Columns[e.ColumnIndex].Name == "UserPassword" && e.Value != null)
            {
                userRecordDataGridView.Rows[e.RowIndex].Tag = e.Value;
                e.Value = new String('*', e.Value.ToString().Length);
            }
        }

        /*
                 private void userRecordDataGridView_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (userRecordDataGridView.CurrentRow.Tag != null)
                e.Control.Text = userRecordDataGridView.CurrentRow.Tag.ToString();
        
         }
         */

        //when user click the cell, password and user name will be save to clipboard
        private void CopyPasteButton_Click(object sender, DataGridViewCellMouseEventArgs e)
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
