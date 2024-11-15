using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjecteKanBan
{
    class ItemKanBan
    {
        public required int id { get; set; }
        public required string tasca {  get; set; }
        public required string estat {  get; set; }
        public required string color { get; set; }
        //public string responsable { get; set; }
        public required DateTime dataStart { get; set; }
        //public required DateTime dataFinish { get; set; }
    }
}
