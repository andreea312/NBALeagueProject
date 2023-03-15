using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static NBALeagueRomania.Service.Service;
using static NBALeagueRomania.Domain.Echipa;
using static NBALeagueRomania.Domain.Meci;
using static NBALeagueRomania.Domain.Jucator;
using static NBALeagueRomania.Domain.JucatorActiv;

namespace NBALeagueRomania.UI
{
    public delegate string StringDelegate(string text);
    internal class Ui
    {
        NBALeagueRomania.Service.Service service;
       
        public Ui(NBALeagueRomania.Service.Service service)
        {
            this.service = service;
        }
        
        public void Start()
        {
            while(true)
            {
                Functioning();
            }
        }

        private void Functioning()
        {
            PrintMenu();
            string command = Console.ReadLine();
            try
            {
                switch (command) {
                    case "1":  
                        JucatoriEchipa();
                        break;
                    case "2": 
                        JucatoriActiviEchipaMeci();
                        break;
                    case "3": 
                        MeciuriPerioada();
                        break;
                    case "4": 
                        ScorMeci();
                        break;
                    default:
                        break;
                }
            }
            catch (Exception e) { Console.WriteLine(e.Message); }
        }

        private static void PrintMenu()
        {
            Console.WriteLine("OPTIONS:");
            Console.WriteLine("1. Toti jucatorii unei echipe date");
            Console.WriteLine("2. Toti jucatorii activi ai unei echipe de la un anumit meci");
            Console.WriteLine("3. Toate meciurile dintr-o anumita perioada calendaristica");
            Console.WriteLine("4. Scorul de la un anumit meci");
        }
        public static string Require(string text)
        {
            Console.WriteLine(text);
            string required = Console.ReadLine();
            return required;
        }

        public void JucatoriEchipa()
        {
            StringDelegate sd = Require;
            int IdEchipa = Convert.ToInt32(sd("Id echipa: "));
            List<Domain.Jucator> jucatori = service.JucatoriEchipa(IdEchipa);
            foreach (Domain.Jucator j in jucatori)
            {
                Console.WriteLine(j.ToString());
            }
        }

        public void JucatoriActiviEchipaMeci()
        {
            StringDelegate sd = Require;
            int IdEchipa1 = Convert.ToInt32(sd("Id echipa1: "));
            int IdEchipa2 = Convert.ToInt32(sd("Id echipa2: "));
            DateTime Data = DateTime.ParseExact(sd("Data: "), "yyyy/MM/dd", System.Globalization.CultureInfo.InvariantCulture);
            List<Domain.JucatorActiv> jucatoriactivi = service.JucatoriActiviEchipaMeci(IdEchipa1, IdEchipa2, Data);
            foreach (Domain.JucatorActiv ja in jucatoriactivi)
            {
                Console.WriteLine(ja.ToString());
            }
        }

        public void MeciuriPerioada()
        {
            StringDelegate sd = Require;
            DateTime DataStart = DateTime.ParseExact(sd("Data start: "), "yyyy/MM/dd", System.Globalization.CultureInfo.InvariantCulture);
            DateTime DataFinish = DateTime.ParseExact(sd("Data finish: "), "yyyy/MM/dd", System.Globalization.CultureInfo.InvariantCulture);
            List <Domain.Meci> meciuriperioada = service.MeciuriPerioada(DataStart, DataFinish);
            foreach(Domain.Meci meci in meciuriperioada)
            {
                Console.WriteLine(meci.ToString());
            }
        }

        public void ScorMeci()
        {
            StringDelegate sd = Require;
            int IdEchipa1 = Convert.ToInt32(sd("Id echipa1: "));
            int IdEchipa2 = Convert.ToInt32(sd("Id echipa2: "));
            DateTime Data = DateTime.ParseExact(sd("Data: "), "yyyy/MM/dd", System.Globalization.CultureInfo.InvariantCulture);
            string scor = service.ScorMeci(IdEchipa1, IdEchipa2, Data);
            Console.WriteLine(scor);
        }
    }
}
