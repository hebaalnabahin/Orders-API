using System;
using System.Collections.Generic;
using System.Text;

namespace Orders.Core.Exceptions
{
    public class InvalidUsernameOrPassword : Exception
    {
        public InvalidUsernameOrPassword():base("Invalid Username or Password")
        {

        }
    }
}
