using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBALeagueRomania.Domain
{
    internal class Elev : Entity<int>
    {
        public string nume { get; set; }
        public string scoala { get; set; }

        public Elev(int id, string nume, string scoala): base(id)
        {
            this.nume = nume;
            this.scoala = scoala;
        }

        public override string ToString()
        {
            return nume + " " + scoala;
        }
    }
}
