using System.Data.Entity.Infrastructure.Interception;
using GameEditorModels;

namespace GameEditorData
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class GameEditorContext : DbContext
    {
       
        public GameEditorContext()
            : base("name=GameEditorContext")
        {
            Database.SetInitializer(new DBInitializer());
        }

        public virtual DbSet<Game> Games { get; set; }
        public virtual DbSet<GameCompany> Companies { get; set; }
        public virtual DbSet<Genre> Genres { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Game>().HasRequired(gc=>gc.CreatorCompany).WithMany(g=>g.GamesProduced).WillCascadeOnDelete(false);
            modelBuilder.Entity<Game>()
                .HasRequired(ge => ge.Genre)
                .WithMany(g => g.GamesOfGenre)
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<Game>().Property(g => g.Image).HasColumnType("image");
            base.OnModelCreating(modelBuilder);
        }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}