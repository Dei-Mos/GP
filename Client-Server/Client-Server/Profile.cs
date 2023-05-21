using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client_Server
{
    [Serializable]
    public class Profile
    {
        public String UserType { get; set; }
        public String Name { get; set; }

        public String Date { get; set; }
        public String Mail { get; set; }
        public String Number { get; set; }
        public String GroupPost { get; set; }

        public Profile()
        {

        }
    }
}
