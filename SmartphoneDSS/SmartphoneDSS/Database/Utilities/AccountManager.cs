using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartphoneDSS.Database.Utilities
{

    class AccountManager
    {
        public enum LoginStatus { LoggedAsAnon, LoggedAsAdmin };
        public static String ADMIN_LOGIN = "admin";
        public static String ADMIN_PASSWORD = "admin";
        public static LoginStatus loginStatus { get; set; }
    }
}
