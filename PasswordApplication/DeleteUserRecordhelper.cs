using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PasswordApplication.AbstractClass;
using PasswordApplication.Interfaces;
using System.Data.SqlClient;
using PasswordApplication.Model;

namespace PasswordApplication
{
    /// <summary>
    /// Delete Record from User Record table, accept Entity(UserRecord,UserAccount,Category)
    /// </summary>
    class DeleteUserRecordhelper : IDelete
    {
        public bool DeleteEntity(AbDatabaseEntity Entity)
        {
            //Initial connection maker to make a connection 
            SQLServerConnMaker SQLconn = new SQLServerConnMaker();

            //Initial UserRecord entity
            UserRecord userRecord = (UserRecord)Entity;
            

            // Create the DeleteCommand.
            // Delete record from UserRecord table
            SqlCommand deleteUserRecordCmd;
            deleteUserRecordCmd = new SqlCommand("DELETE FROM UserRecord WHERE RecordID = @RecordID", SQLconn.Connect());


            // Add the parameters for the DeleteCommand.
            deleteUserRecordCmd.Parameters.AddWithValue("@RecordID", userRecord.RecordID);

            try
            {
                SQLconn.Connect().Open();
                using (deleteUserRecordCmd) { deleteUserRecordCmd.ExecuteNonQuery(); }
            }
            catch (Exception e)
            {
                //show error in output
                Console.WriteLine(e.ToString());
            }
            finally
            {
                SQLconn.Connect().Close();
            }
            throw new NotImplementedException();
        }
    }
}
