using static NBALeagueRomania.Repository.ElevRepo;
using static NBALeagueRomania.Repository.EchipaRepo;
using static NBALeagueRomania.Repository.JucatorRepo;
using static NBALeagueRomania.Repository.JucatorActivRepo;
using static NBALeagueRomania.Repository.MeciRepo;
using static NBALeagueRomania.Service.Service;
using static NBALeagueRomania.UI.Ui;

NBALeagueRomania.Repository.ElevRepo elevi = new NBALeagueRomania.Repository.ElevRepo ("C:/Users/andre/source/repos/NBALeagueRomania/NBALeagueRomania/elevi.txt");
NBALeagueRomania.Repository.EchipaRepo echipe = new NBALeagueRomania.Repository.EchipaRepo("C:/Users/andre/source/repos/NBALeagueRomania/NBALeagueRomania/echipe.txt");
NBALeagueRomania.Repository.JucatorRepo jucatori = new NBALeagueRomania.Repository.JucatorRepo("C:/Users/andre/source/repos/NBALeagueRomania/NBALeagueRomania/jucatori.txt", echipe);
NBALeagueRomania.Repository.JucatorActivRepo jucatoriactivi = new NBALeagueRomania.Repository.JucatorActivRepo("C:/Users/andre/source/repos/NBALeagueRomania/NBALeagueRomania/jucatoriactivi.txt");
NBALeagueRomania.Repository.MeciRepo meciuri = new NBALeagueRomania.Repository.MeciRepo("C:/Users/andre/source/repos/NBALeagueRomania/NBALeagueRomania/meciuri.txt", echipe);

NBALeagueRomania.Service.Service service = new NBALeagueRomania.Service.Service(elevi, echipe, jucatori, jucatoriactivi, meciuri);
NBALeagueRomania.UI.Ui ui = new NBALeagueRomania.UI.Ui(service);
ui.Start();