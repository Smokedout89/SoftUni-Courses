namespace P02_FootballBetting.Data
{
    using Models;
    using Microsoft.EntityFrameworkCore;

    public class FootballBettingContext : DbContext
    {
        public FootballBettingContext()
        {
        }

        public FootballBettingContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<Bet> Bets { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<PlayerStatistic> PlayersStatistics { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Town> Towns { get; set; }
        public DbSet<User> Users { get; set; }


        // Establishing connection with SQL Server
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Config.ConnectionString);
            }
        }

        // Define rules for creating DB
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Composite PK of mapping table
            modelBuilder
                .Entity<PlayerStatistic>(e =>
                {
                    // Define PK
                    e.HasKey(ps => new { ps.PlayerId, ps.GameId });
                });

            // Entities can cause cycle when delete 
            modelBuilder
                .Entity<Team>(e =>
                {
                    e
                        .HasOne(t => t.PrimaryKitColor)
                        .WithMany(c => c.PrimaryKitTeams)
                        .HasForeignKey(t => t.PrimaryKitColorId)
                        .OnDelete(DeleteBehavior.Restrict);

                    e 
                        .HasOne(t => t.SecondaryKitColor)
                        .WithMany(c => c.SecondaryKitTeams)
                        .HasForeignKey(t => t.SecondaryKitColorId)
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder
                .Entity<Game>(e =>
                {
                    e
                        .HasOne(g => g.HomeTeam)
                        .WithMany(t => t.HomeGames)
                        .HasForeignKey(g => g.HomeTeamId)
                        .OnDelete(DeleteBehavior.Restrict);

                    e
                        .HasOne(g => g.AwayTeam)
                        .WithMany(t => t.AwayGames)
                        .HasForeignKey(g => g.AwayTeamId)
                        .OnDelete(DeleteBehavior.Restrict);
                });
        }
    }
}
