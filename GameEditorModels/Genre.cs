using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEditorModels
{
    public class Genre
    {
        public Genre()
        {
            this.GamesOfGenre=new List<Game>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Game> GamesOfGenre { get; set; }
    }
}
