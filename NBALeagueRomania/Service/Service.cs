using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static NBALeagueRomania.Repository.ElevRepo;
using static NBALeagueRomania.Repository.EchipaRepo;
using static NBALeagueRomania.Repository.JucatorRepo;
using static NBALeagueRomania.Repository.JucatorActivRepo;
using static NBALeagueRomania.Repository.MeciRepo;

namespace NBALeagueRomania.Service
{
    internal class Service
    {
        NBALeagueRomania.Repository.ElevRepo elevi;
        NBALeagueRomania.Repository.EchipaRepo echipe;
        NBALeagueRomania.Repository.JucatorRepo jucatori;
        NBALeagueRomania.Repository.JucatorActivRepo jucatoriactivi;
        NBALeagueRomania.Repository.MeciRepo meciuri;

        public Service(NBALeagueRomania.Repository.ElevRepo elevi, NBALeagueRomania.Repository.EchipaRepo echipe,
             NBALeagueRomania.Repository.JucatorRepo jucatori, NBALeagueRomania.Repository.JucatorActivRepo jucatoriactivi,
             NBALeagueRomania.Repository.MeciRepo meciuri)
        {
            this.elevi = elevi;
            this.echipe = echipe;
            this.jucatori = jucatori;
            this.jucatoriactivi = jucatoriactivi;
            this.meciuri = meciuri;
        }

        public IEnumerable<Domain.Echipa> GetAllEchipe()
        {
            return echipe.GetAll();
        }

        public IEnumerable<Domain.Elev> GetAllElevi()
        {
            return elevi.GetAll();
        }

        public IEnumerable<Domain.Jucator> GetAllJucatori()
        {
            return jucatori.GetAll();
        }

        public IEnumerable<Domain.JucatorActiv> GetAllJucatoriActivi()
        {
            return jucatoriactivi.GetAll();
        }

        public IEnumerable<Domain.Meci> GetAllMeciuri()
        {
            return meciuri.GetAll();
        }



        public List<Domain.Jucator> JucatoriEchipa(int IdEchipa)
        {
            List<Domain.Jucator> jucatoriechipa = jucatori.GetAll()
                .Where(j => j.echipa == echipe.Get(IdEchipa))
                .ToList();
            return jucatoriechipa;
        }

        public List<Domain.JucatorActiv> JucatoriActiviEchipaMeci(int IdEchipa1, int IdEchipa2, DateTime Data)
        {
            List<int> idsJucatoriechipa1 = JucatoriEchipa(IdEchipa1).Select(je1 => je1.id).ToList();

            List<Domain.Meci> listaCuMeciul = meciuri.GetAll()
                .Where(m => (m.echipa1.id == IdEchipa1 && m.echipa2.id == IdEchipa2) ||
                (m.echipa1.id == IdEchipa2 && m.echipa2.id == IdEchipa1) && m.data == Data)
                .ToList();
            int idMeci = listaCuMeciul[0].id;

            List<Domain.JucatorActiv> jucatoriactiviechipameci = jucatoriactivi.GetAll()
                .Where(ja => ja.idMeci == idMeci && idsJucatoriechipa1.Contains(ja.idJucator))
                .ToList();

            return jucatoriactiviechipameci;
        }

        public List<Domain.Meci> MeciuriPerioada(DateTime DataStart, DateTime DataFinish)
        {
            List<Domain.Meci> meciuriperioada = meciuri.GetAll()
                .Where(m => m.data >= DataStart
                         && m.data <= DataFinish)
                .ToList();
            return meciuriperioada;
        }

        public string ScorMeci(int IdEchipa1, int IdEchipa2, DateTime Data)
        {
            List<Domain.JucatorActiv> l1 = JucatoriActiviEchipaMeci(IdEchipa1, IdEchipa2, Data);
            int p1 = l1.Sum(j => j.nrPuncteInscrise);
            List <Domain.JucatorActiv> l2 = JucatoriActiviEchipaMeci(IdEchipa2, IdEchipa1, Data);
            int p2 = l2.Sum(j => j.nrPuncteInscrise);
            return Math.Max(p1, p2).ToString() + " - " + Math.Min(p1, p2).ToString();
        }
    }
}
