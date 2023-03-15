using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBALeagueRomania.Domain
{
    internal class Meci: Entity<int>
    {
        public Echipa echipa1 { get; set; }
        public Echipa echipa2 { get; set; }
        public DateTime data { get; set; }

        public Meci(int id, Echipa echipa1, Echipa echipa2, DateTime data): base(id)
        {
            this.echipa1 = echipa1;
            this.echipa2 = echipa2;
            this.data = data;
        }

        public override string ToString()
        {
            return echipa1.ToString() + "  -  " + echipa2.ToString() + "  " + data.ToString("yyyy/MM/dd"); ;
        }
    }
}
