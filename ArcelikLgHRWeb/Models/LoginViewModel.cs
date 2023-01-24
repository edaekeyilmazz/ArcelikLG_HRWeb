using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ArcelikLgHRWeb.Models
{
    public class LoginViewModel
    {
        [TCKimlikNoValidation]
        public string TCNo { get; set; }
        public string Password { get; set; }
    }
}