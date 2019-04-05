using Dal.Helper;
using Dal.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.Repository
{
    public class GamerRepository : BaseRepository<Gamer>
    {
        public GamerRepository() : base("Gamers") { }
        
    }
}
