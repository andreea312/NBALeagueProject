using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static NBALeagueRomania.Domain.Echipa;

namespace NBALeagueRomania.Repository
{
    internal class EchipaRepo : Repo<int, Domain.Echipa>
    {
        public EchipaRepo(string filename) : base(filename){}

        public override Domain.Echipa LineToEntity(String line)
        {
            List<string> attributes = line.Split(',').ToList();
            int id = Int32.Parse(attributes[0]);
            string nume = attributes[1];
            return new Domain.Echipa(id, nume);
        }

        public Domain.Echipa Get(int id)
        {
            return GetAll().SingleOrDefault(s => s.id == id);
        }
    }
}
  