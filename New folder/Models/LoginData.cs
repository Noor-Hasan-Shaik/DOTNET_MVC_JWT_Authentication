using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcDemo.Models
{
    public class LoginData
    {
        public string username;
        public string password;
    }

    public class RegisterData
    {
        public string username { get; set; }
        public string password { get; set; }
        public string email { get; set; }
    }
}