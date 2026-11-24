using System;
using System.Collections.Generic;
using System.Text;

namespace Orders.Core.ViewModels
{
    public class LoginResponseViewModel
    {
        public AccessTokenViewModel AccessToken { get; set; }
        public UserViewModel User { get; set; }
    }
}
