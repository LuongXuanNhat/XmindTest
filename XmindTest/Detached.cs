using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XmindTest
{
    internal class Detached
    {
        public string id { get; set; }
        public string title { get; set; }
        public bool titleUnedited { get; set; }
        public Position position { get; set; }
        public Children children { get; set; }
    }
}
