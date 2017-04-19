using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace GameEditorModels
{
    public class Game
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime DateCreated { get; set; }
        public string Description { get; set; }
        public float Price { get; set; }
        public byte[] Image { get; set; }
        public int Rate { get; set; }
        public int GenreId { get; set; }
        [JsonIgnore]
        public virtual Genre Genre { get; set; }
        public int CreatorCompanyId { get; set; }
        [JsonIgnore]
        public virtual GameCompany CreatorCompany { get; set; }
    }
}
