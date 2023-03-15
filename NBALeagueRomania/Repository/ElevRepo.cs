using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using static NBALeagueRomania.Domain.Elev;


namespace NBALeagueRomania.Repository
{
    internal class ElevRepo : Repo<int,Domain.Elev>
    {
        public ElevRepo(string filename) : base(filename) {}

        public override Domain.Elev LineToEntity(String line)
        {
            List<string> attributes = line.Split(',').ToList();
            int id = Int32.Parse(attributes[0]);
            string nume = attributes[1];
            string scoala = attributes[2];
            return new Domain.Elev(id, nume, scoala);
        }

        public Domain.Elev Get(int id)
        {
            return GetAll().SingleOrDefault(s => s.id == id);
        }
    }
}
