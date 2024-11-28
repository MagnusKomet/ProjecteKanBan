using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ProjecteKanBan
{
    public class ItemKanBan
    {
        public required int id { get; set; }
        public required string tasca { get; set; }
        public required string estat { get; set; }
        public required string color { get; set; }
        public required string responsable { get; set; }
        public required string dataStart { get; set; }
        public required string dataFinish { get; set; }

    }

}

