using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PasswordApplication.Interfaces;
using System.Data.SqlClient;

namespace PasswordApplication
{
    /// <summary>
    /// Keep the connction string only in here.
    /// If need, just call SQLServerConnMake-->Connect() to return the SQL connection;
    /// </summary>
    class SQLServerConnMaker : IDatabaseConnection
    {
        private static String  connectionString =
            "Integrated Security=SSPI;Persist Security Info=False;" +
            //"MultipleActiveResultSets=True;" +        // Enabling Multiple Active Result Sets
            "Initial Catalog=HexylogyDB;" +       // Database name is HexylogyDB
            "Data Source=Lenovo-PC\\Dom";  // Replace your SQL server name here.;

        public SqlConnection Connect()
        {
            //Return SqlConnection for the connectionString
            return new SqlConnection(connectionString);
        }

    }
}
