using PasswordApplication.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using PasswordApplication.Model;

namespace PasswordApplication
{
    class PasswordValidator : IValidation
    {
        //pattern
        private string pattern = "^([1-zA-Z0-1@.\\s]{1,255})$";
        Regex regex;
        UserRecord userRecord;

        public bool Validate(string UserInput)
        {
            userRecord.UserPassword = UserInput;
            regex = new Regex(pattern);
            if (regex.Match(UserInput).Success)
            {
                return true;
            }
            else
            {
                return false;
            }
            throw new NotImplementedException();
        }
    }
}
