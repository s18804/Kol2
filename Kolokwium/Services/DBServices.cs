using Kolokwium.DTOs;
using Kolokwium.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace Kolokwium.Services
{
    public class DBServices: IDBServices
    {

        private readonly MyDbContext _context;

        public DBServices(MyDbContext context)
        {
            _context = context;
        }

        public async Task AddNewPlayerToTeam(int IdTeam, AddNewPlayerToTeamRequest request)
        {
            try
            {

                var playerInfo = (from p in _context.Player where p.FirstName == request.FirstName && p.LastName == request.LastName && p.DateOfBirth == request.BirthDate select p).FirstOrDefault();
                if (playerInfo == null) throw new Exception("Nie istnieje zawodnik o podanych danych");

                var IsInTeam = (from t in _context.PlayerTeam where t.IdPlayer == playerInfo.IdPlayer select t).FirstOrDefault();
                if (IsInTeam != null) throw new Exception("Zawodnik nalezy juz do druzyny");

                var maxAge = (from t in _context.Team where t.IdTeam == IdTeam select t.MaxAge).FirstOrDefault();
                if (maxAge == 0) throw new Exception("Druzyna o podanym id nie istnieje");

                if (DateTime.Now.Year - playerInfo.DateOfBirth.Year < maxAge)
                {
                    _context.PlayerTeam.Add(new PlayerTeam { IdPlayer = playerInfo.IdPlayer, IdTeam = IdTeam, Comment = request.Comment, NumOnShirt = request.NumOnShirt });
                    _context.SaveChanges();
                }
                else
                {
                    throw new Exception("Zawodnik jest za stary");
                }
            }catch(Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<List<GetChampionshipsResponse>> getChampionships(int id)
        {

                Console.WriteLine("id" + id);
                var res = (from c in _context.ChampionshipTeam
                           where c.IdChampionship == id
                           orderby c.Score ascending
                           select new GetChampionshipsResponse
                           {
                               Score = c.Score,
                               TeamName = c.Team.TeamName
                           }).ToList();

                return res;
            
        }
    }
}
