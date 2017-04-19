using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
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

        public List<Game> ReturnGames()
        {
            return context.Games.ToList();
        }

        public bool isGameAlreadyExisting(string gametitle)
        {
            return context.Games.Any(x => x.Title == gametitle);
        }
        public void AddGame(Game game)
        {
            context.Games.AddOrUpdate(x=>x.Title,game);
            context.SaveChanges();
        }

        public Game ReturnGame(string gamename)
        {
            return context.Games.FirstOrDefault(x => x.Title == gamename);
        }

        public void SaveChanges()
        {
            context.SaveChanges();
        }

        public void DeleteEntry(Game game)
        {
            context.Games.Remove(game);
        }
    }
}
