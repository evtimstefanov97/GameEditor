using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEditorModels
{
    public class GameCompany
    {
        public GameCompany()
        {
            this.GamesProduced=new List<Game>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Game> GamesProduced { get; set; }
    }
}
