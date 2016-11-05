using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PasswordApplication.Interfaces;
using System.Text.RegularExpressions;
using PasswordApplication.Model;


namespace PasswordApplication
{
    /// <summary>
    /// Validate userName input.
    /// Pattern is ?????
    /// </summary>
    class UserNameValidator : IValidation
    {
        // create pattern
        private string pattern = " ^[a - z | A - Z |] +[a - z | A - Z | 0 - 9] * ";
        //Regular expression
        Regex regex;
        UserRecord userRecord;
        
        public bool Validate(string UserInput)
        {   
            
            regex = new Regex(pattern);
            userRecord.UserName = UserInput;
            if (regex.Match(UserInput).Success)
            {
                return true;
            }
            else
            {
                return false;
            }
       }
    }
}
