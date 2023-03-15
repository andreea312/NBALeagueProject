using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static NBALeagueRomania.Domain.Meci;

namespace NBALeagueRomania.Repository
{
    internal class MeciRepo : Repo<int,Domain.Meci>
    {
        private EchipaRepo er;
        public MeciRepo(string filename, EchipaRepo er) : base(filename, false) {
            this.er = er;
            Load();
        }

        public override Domain.Meci LineToEntity(String line)
        {
            List<string> attributes = line.Split(',').ToList();
            int id = Int32.Parse(attributes[0]);
            int idEchipa1 = Int32.Parse(attributes[1]);
            int idEchipa2 = Int32.Parse(attributes[2]);
            DateTime data = Convert.ToDateTime(attributes[3]);
            Domain.Echipa echipa1 = er.Get(idEchipa1);
            Domain.Echipa echipa2 = er.Get(idEchipa2);
            return new Domain.Meci(id, echipa1, echipa2, data);
        }

        public Domain.Meci Get(int id)
        {
            return GetAll().SingleOrDefault(s => s.id == id);
        }
    }
}
