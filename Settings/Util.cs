using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Settings
{
    public static class Util
    {
        public static int getSiteID()
        {
            return 1;
        }


        public static UserInfo getCurrentUser()
        {
            return new UserInfo()
            {
                UserID = 1,
                UserAccount = "host",
                Email = "host@gmail.com",
                UserName = "Super User",
                FirstName = "host",
                LastName = "host",
                isSuperUser = true
            };
        }
    }
}
