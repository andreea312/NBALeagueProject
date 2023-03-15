using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBALeagueRomania.Domain
{
    internal class Jucator : Elev
    {
        public Echipa echipa { get; set; }
        public Jucator(int id, string nume, string scoala, Echipa echipa) : base(id, nume, scoala)
        {
            this.echipa = echipa;
        }

        public override string ToString()
        {
            return base.ToString() + " " + echipa.ToString();
        }
    }
}
