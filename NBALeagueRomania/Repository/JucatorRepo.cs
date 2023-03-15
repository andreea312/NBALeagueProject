using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static NBALeagueRomania.Domain.Jucator;
using static NBALeagueRomania.Repository.EchipaRepo;

namespace NBALeagueRomania.Repository
{
    internal class JucatorRepo : Repo<int,Domain.Jucator>
    {
        private EchipaRepo er;
        public JucatorRepo(string filename, EchipaRepo er) : base(filename, false) {
            this.er = er;
            Load();
        }

        public override Domain.Jucator LineToEntity(String line)
        {
            List<string> attributes = line.Split(',').ToList();
            int idJucator = Int32.Parse(attributes[0]);
            string nume = attributes[1];
            string scoala = attributes[2];
            int idEchipa = Int32.Parse(attributes[3]);
            Console.WriteLine(idEchipa);
            Domain.Echipa echipa = er.Get(idEchipa);
            return new Domain.Jucator(idJucator, nume, scoala, echipa);
        }

        public Domain.Jucator Get(int id)
        {
            return GetAll().SingleOrDefault(s => s.id == id);
        }
    }
}
