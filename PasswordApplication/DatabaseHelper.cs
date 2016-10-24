using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PasswordApplication
{
    /// <summary>
    /// Use to set up database connection, fetch data from db and return BindingSource to whoever uses the connection.
    /// </summary>
    class DatabaseHelper
    {
        //Define data source and data adapter
        private BindingSource bindingSource = new BindingSource();
        private SqlDataAdapter dataAdapter = new SqlDataAdapter();

        // Specify a connection string. Replace the given value with a 
        // valid connection string for a production database accessible to your system.
        private static String connectionString =
            "Integrated Security=SSPI;Persist Security Info=False;" +
            "Initial Catalog=HexylogyDB;" +       // Database name is HexylogyDB
            "Data Source=RYAN\\RYANMSSQLSERVER";  // Replace your SQL server name here.
        
        //Connecting to database and get the data for certain SQL statement
        public BindingSource GetData(string sqlCommand)
        {
            try
            {

                // Create a new data adapter based on the specified query.
                dataAdapter = new SqlDataAdapter(sqlCommand, connectionString);
                // Create a command builder to generate SQL update, insert, and
                // delete commands based on sqlCommand. These are used to
                // update the database.
                SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);

                // Populate a new data table and bind it to the BindingSource.
                DataTable table = new DataTable();
                table.Locale = System.Globalization.CultureInfo.InvariantCulture;
                dataAdapter.Fill(table);
                bindingSource.DataSource = table;

            }
            catch (SqlException)
            {
                MessageBox.Show("To run this example, replace the value of the " +
                    "connectionString variable with a connection string that is " +
                    "valid for your system.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception.Message: {0}", ex.Message);
            }
            finally
            {

            }

            return bindingSource;
        }
    }
}
