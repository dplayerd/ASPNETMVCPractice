using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Settings
{
    public class UserInfo
    {
        public UserInfo()
        {
            this.MiddleName = new List<string>();
        }

        public int UserID { get; set; }

        public string UserName { get; set; }

        public string UserAccount { get; set; }

        public string Email { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public List<string> MiddleName { get; set; }

        public bool isSuperUser { get; set; }
    }
}
