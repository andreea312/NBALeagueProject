using NBALeagueRomania.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBALeagueRomania.Repository
{
    public interface IRepo<ID,T> where T : class
    {
        IEnumerable<T> GetAll();
        void Load();
        T LineToEntity(string line);
    }
}
