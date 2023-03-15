using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBALeagueRomania.Domain
{
    internal class Entity<ID>
    {
        public ID id { get; set; }
      
        public Entity(ID id)
        {
            this.id = id;
        }
    }
}
