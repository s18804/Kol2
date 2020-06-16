using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kolokwium.DTOs
{
    public class AddNewPlayerToTeamRequest
    {

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public int NumOnShirt { get; set; }
        public string Comment { get; set; }

    }
}
