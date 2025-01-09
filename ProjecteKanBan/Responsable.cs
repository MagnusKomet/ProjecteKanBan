using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjecteKanBan
{
    public class Responsable
    {
        static int idsTotals = 1;

        public string nom { get; set; }
        public string cognom { get; set; }
        public string correu { get; set; }
        public int id { get; set; }

        public Responsable(string nom, string cognom, string correu) {

            this.nom = nom;
            this.cognom = cognom;
            this.correu = correu;
            this.id = idsTotals;
            idsTotals++;
        }

    }
}
