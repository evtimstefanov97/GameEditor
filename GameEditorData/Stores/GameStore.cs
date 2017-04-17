using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameEditorModels;

namespace GameEditorData.Stores
{
    public class GameStore
    {
        private GameEditorContext context = new GameEditorContext();

        public int ReturnGameCompanyId(string name)
        {
            return context.Companies.FirstOrDefault(x => x.Name == name).Id;
        }

        public int ReturnGenreId(string name)
        {
            return context.Genres.FirstOrDefault(x => x.Name == name).Id;
        }
        public List<Genre> ReturnGenres()
        {
            return context.Genres.ToList();
        }
        public List<GameCompany> ReturnCompanies()
        {
            return context.Companies.ToList();
        }
        public void AddGame(Game game)
        {
            context.Games.Add(game);
            context.SaveChanges();
        }
    }
}
