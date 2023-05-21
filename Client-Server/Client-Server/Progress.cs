using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client_Server
{
    [Serializable]
    public class Progress
    {
        public String Name { get; set; }
        public String Grade { get; set; }
        public String Date { get; set; }
        public Progress()
        {

        }
    }
}
