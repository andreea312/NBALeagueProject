using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBALeagueRomania.Domain
{
    internal class JucatorActiv: Entity<int>
    {
        public int idJucator { get; set; }
        public int idMeci { get; set; }
        public int nrPuncteInscrise { get; set; }
        public string tip { get; set; } //Rezerva, Participant

        public JucatorActiv(int id, int idJucator, int idMeci, int nrPuncteInscrise, string tip): base(id)
        {
            this.idJucator = idJucator;
            this.idMeci = idMeci;
            this.nrPuncteInscrise = nrPuncteInscrise;
            this.tip = tip;

        }

        public override string ToString()
        {
            return idJucator.ToString() + " " + idMeci.ToString() + " " + nrPuncteInscrise.ToString() + " " + tip;
        }
    }
}
