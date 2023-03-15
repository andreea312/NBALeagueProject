using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static NBALeagueRomania.Domain.JucatorActiv;

namespace NBALeagueRomania.Repository
{
    internal class JucatorActivRepo : Repo<int,Domain.JucatorActiv>
    {
        public JucatorActivRepo(string filename) : base(filename) {}

        public override Domain.JucatorActiv LineToEntity(String line)
        {
            List<string> attributes = line.Split(',').ToList();
            int id = Int32.Parse(attributes[0]);
            int idJucator = Int32.Parse(attributes[1]);
            int idMeci = Int32.Parse(attributes[2]);
            int nrPuncteInscrise = Int32.Parse(attributes[3]);
            string tip = attributes[4];
            return new Domain.JucatorActiv(id, idJucator, idMeci, nrPuncteInscrise, tip);
        }

        public Domain.JucatorActiv Get(int idJucator, int idMeci)
        {
            return GetAll().SingleOrDefault(s => s.idJucator == idJucator && s.idMeci == idMeci);
        }
    }
}
