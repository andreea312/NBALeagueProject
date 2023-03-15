using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBALeagueRomania.Domain
{
    internal class Echipa : Entity<int>
    {
        public string nume { get; set; }

        public Echipa(int id, string nume): base(id)
        {
            this.nume = nume;
        }

        public override string ToString()
        {
            return nume;
        }
    }
}
