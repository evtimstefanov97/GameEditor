using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEditorData
{
    using GameEditorModels;
    public class DBInitializer :CreateDatabaseIfNotExists<GameEditorContext>
    {
        protected override void Seed(GameEditorContext context)
        {
            List<Genre> genres=new List<Genre>();
            genres.Add(new Genre()
            {
                Name = "Arcade",
                GamesOfGenre = new List<Game>()
            });
            genres.Add(new Genre()
            {
                Name = "RPG",
                GamesOfGenre = new List<Game>()
            });
            genres.Add(new Genre()
            {
                Name = "FPS",
                GamesOfGenre = new List<Game>()
            });
            genres.Add(new Genre()
            {
                Name = "MOBA",
                GamesOfGenre = new List<Game>()
            });
            genres.Add(new Genre()
            {
                Name = "MMORPG",
                GamesOfGenre = new List<Game>()
            });
            genres.Add(new Genre()
            {
                Name = "HnS",
                GamesOfGenre = new List<Game>()
            });
            genres.Add(new Genre()
            {
                Name = "Indie",
                GamesOfGenre = new List<Game>()
            });
            genres.Add(new Genre()
            {
                Name = "Racing",
                GamesOfGenre = new List<Game>()
            });
            genres.Add(new Genre()
            {
                Name = "Survival",
                GamesOfGenre = new List<Game>()
            });
            context.Genres.AddRange(genres);

            List<GameCompany> companies=new List<GameCompany>();
            companies.Add(new GameCompany()
            {
                Name = "EA",
                GamesProduced = new List<Game>()
            });
            companies.Add(new GameCompany()
            {
                Name = "Ubisoft",
                GamesProduced = new List<Game>()
            });
            companies.Add(new GameCompany()
            {
                Name = "Nintendo",
                GamesProduced = new List<Game>()
            });
            companies.Add(new GameCompany()
            {
                Name = "Valve",
                GamesProduced = new List<Game>()
            });
            companies.Add(new GameCompany()
            {
                Name = "Rockstar Games",
                GamesProduced = new List<Game>()
            });
            companies.Add(new GameCompany()
            {
                Name = "Blizzard",
                GamesProduced = new List<Game>()
            });
            companies.Add(new GameCompany()
            {
                Name = "Activision",
                GamesProduced = new List<Game>()
            });
            companies.Add(new GameCompany()
            {
                Name = "Sony",
                GamesProduced = new List<Game>()
            });
            companies.Add(new GameCompany()
            {
                Name = "Square Enix Holdings Co. Ltd",
                GamesProduced = new List<Game>()
            });
            companies.Add(new GameCompany()
            {
                Name = "Bethesda",
                GamesProduced = new List<Game>()
            });
            context.Companies.AddRange(companies);
            context.SaveChanges();
            
        }
    }
}
