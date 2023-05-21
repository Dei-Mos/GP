using System;
using System.Collections.Generic;
using System.Text;

namespace Client_Server
{
    [Serializable]
    public class Request
    {
        public int Type { get; set; }
        public List<String> Data { get; set; }

        public Request(int type, List<String> data)
        {
            Type = type;
            List<String> Data = new List<String>();
            Data.AddRange(data);
        }

        public Request()
        {
            Type = -1;
            Data = null;
        }
    }
}
