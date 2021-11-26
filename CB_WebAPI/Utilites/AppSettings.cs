using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CB_WebAPI.Utilites
{
    public class AppSettingsModel
    {
        public string SecretKey { get; set; }
        public string JwtExpireDays { get; set; }
        public string JwtIssuer { get; set; }
    }
}
