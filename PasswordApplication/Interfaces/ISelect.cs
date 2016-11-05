using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PasswordApplication.AbstractClass;
using System.Data.Common;

namespace PasswordApplication.Interfaces
{
    /// <summary>
    /// Select User Record,Category,User Account from Database
    /// Return dataAdapter from select command.
    /// </summary>
    interface ISelect
    {
        //DatabaseEntity can be UserRecord,Category,UserAccount
        DataAdapter SelectEntity(AbDatabaseEntity Entity);
    }
}
