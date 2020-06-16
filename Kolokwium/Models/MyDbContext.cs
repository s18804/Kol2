using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kolokwium.Models
{
    public class MyDbContext: DbContext
    {

        public MyDbContext(DbContextOptions options): base(options) { }


        public DbSet<Championship> Championship { get; set; }
        public DbSet<Player> Player { get; set; }
        public DbSet<Team> Team { get; set; }
        public DbSet<PlayerTeam> PlayerTeam { get; set; }
        public DbSet<ChampionshipTeam> ChampionshipTeam { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            List<Player> players = new List<Player>();
            players.Add(new Player { IdPlayer = 1, FirstName = "Adam", LastName = "Pierzchala", DateOfBirth = DateTime.Parse("04-02-1999")});

            modelBuilder.Entity<Player>(e =>
            {
                e.HasKey(c => c.IdPlayer);
                e.Property(c => c.FirstName).HasMaxLength(30).IsRequired();
                e.Property(c => c.LastName).HasMaxLength(50).IsRequired();
                e.Property(c => c.DateOfBirth).IsRequired();
                e.HasData(players);
            });

            List<Team> teams = new List<Team>();
            teams.Add(new Team { IdTeam = 1, MaxAge = 20, TeamName = "hulaho" });

            modelBuilder.Entity<Team>(e =>
            {
                e.HasKey(c => c.IdTeam);
                e.Property(c => c.TeamName).HasMaxLength(30).IsRequired();
                e.Property(c => c.MaxAge).IsRequired();
                e.HasData(teams);
            });

            List<Championship> championships = new List<Championship>();
            championships.Add(new Championship { IdChampionship = 1, OfficialName = "mistrzostwo", Year = 2020 });

            modelBuilder.Entity<Championship>(e =>
            {
                e.HasKey(c => c.IdChampionship);
                e.Property(c => c.OfficialName).HasMaxLength(100).IsRequired();
                e.Property(c => c.Year).IsRequired();
                e.HasData(championships);
            });

            List<ChampionshipTeam> championshipTeams = new List<ChampionshipTeam>();
            championshipTeams.Add(new ChampionshipTeam { IdTeam = 1, IdChampionship = 1, Score = 3.4f });

            modelBuilder.Entity<ChampionshipTeam>(e =>
            {
                e.HasOne(c => c.Championship).WithMany(c => c.ChampionshipTeams).HasForeignKey(c => c.IdChampionship).OnDelete(DeleteBehavior.ClientSetNull);
                e.HasOne(c => c.Team).WithMany(c => c.ChampionshipTeams).HasForeignKey(c => c.IdTeam).OnDelete(DeleteBehavior.ClientSetNull);
                e.Property(c => c.Score).IsRequired();
                e.HasData(championshipTeams);
            });
            modelBuilder.Entity<ChampionshipTeam>().ToTable("Championship_Team");
            modelBuilder.Entity<ChampionshipTeam>().HasKey(e => new
            {
                e.IdTeam,
                e.IdChampionship
            });

            List<PlayerTeam> playerTeams = new List<PlayerTeam>();
            playerTeams.Add(new PlayerTeam { IdPlayer = 1, IdTeam = 1, NumOnShirt = 10 });

            modelBuilder.Entity<PlayerTeam>(e =>
            {
                e.HasOne(c => c.Team).WithMany(c => c.PlayerTeams).HasForeignKey(c => c.IdTeam).OnDelete(DeleteBehavior.ClientSetNull);
                e.HasOne(c => c.Player).WithMany(c => c.PlayerTeams).HasForeignKey(c => c.IdPlayer).OnDelete(DeleteBehavior.ClientSetNull);
                e.Property(c => c.NumOnShirt).IsRequired();
                e.Property(c => c.Comment).HasMaxLength(300);
                e.HasData(playerTeams);
            });
            modelBuilder.Entity<PlayerTeam>().ToTable("Player_Team");
            modelBuilder.Entity<PlayerTeam>().HasKey(e => new
            {
                e.IdPlayer,
                e.IdTeam
            });
        }

    }
}
