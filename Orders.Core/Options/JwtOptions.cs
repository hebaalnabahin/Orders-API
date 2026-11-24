using System;
using System.Collections.Generic;
using System.Text;

namespace Orders.Core.Options
{
    public class JwtOptions
    {
        public string SecurityKey { get; set; }
        public string Issure { get; set; }
    }
}
