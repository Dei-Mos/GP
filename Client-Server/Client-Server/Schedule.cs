using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client_Server
{
    [Serializable]
    public class Schedule
    {
        public String TimeStart { get; set; }
        public String TimeEnd { get; set; }
        public String Subject { get; set; }
        public String Cabinet { get; set; }
        public String Group { get; set; }
        public Schedule()
        {

        }
    }
}
