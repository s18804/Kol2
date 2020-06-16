using Kolokwium.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kolokwium.Services
{
    public interface IDBServices
    {

        public Task<List<GetChampionshipsResponse>> getChampionships(int id);
        public Task AddNewPlayerToTeam(int IdTeam, AddNewPlayerToTeamRequest request);
    }
}
