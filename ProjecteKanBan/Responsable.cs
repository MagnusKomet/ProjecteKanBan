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
        static long idsTotals = MaxIdResponsables() + 1;

        public string nom { get; set; }
        public string cognom { get; set; }
        public string correu { get; set; }
        public long id { get; set; }

        public Responsable(string nom, string cognom, string correu) {

            idsTotals = MaxIdResponsables() + 1;
            this.nom = nom;
            this.cognom = cognom;
            this.correu = correu;
            this.id = idsTotals;
        }

        public static long MaxIdResponsables()
        {
            long maxId = 0;
            foreach (Responsable responsable in MainWindow.llistaResponsables)
            {

                if (maxId < responsable.id)
                {
                    maxId = responsable.id;
                }
            }

            return maxId;
        }

    }
}
