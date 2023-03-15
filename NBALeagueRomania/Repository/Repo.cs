using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBALeagueRomania.Repository
{
    internal abstract class Repo<ID,T> : IRepo<ID,T> where T : Domain.Entity<ID>
    {
        private readonly string filename;
        private List<T> entities = new List<T>();

        public Repo(string filename, bool loadEntities = true)
        {
            this.filename = filename;
            if(loadEntities)
                Load();
        }

        public IEnumerable<T> GetAll()
        {
            return entities.AsEnumerable();
        }

        public void Load()
        {
            List<string> lines = System.IO.File.ReadLines(filename).ToList();
            foreach(string line in lines)
            {
                T entity = LineToEntity(line);
                Console.WriteLine(entity.ToString());
                entities.Add(entity);
            }
        }

        public abstract T LineToEntity(string line);
    }
}
