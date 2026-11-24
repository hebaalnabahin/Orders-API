using System;
using System.Collections.Generic;
using System.Text;

namespace Orders.Core.ViewModels
{
    public class AccessTokenViewModel
    {
        public string AccessToken { get; set; }
        public DateTime ExpiredAt { get; set; }
    }
}
