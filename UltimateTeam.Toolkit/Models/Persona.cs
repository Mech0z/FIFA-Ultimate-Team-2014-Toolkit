using System.Collections.Generic;

namespace UltimateTeam.Toolkit.Models
{
    public class Persona
    {
        public long PersonaId { get; set; }

        public string PersonaName { get; set; }

        public List<UserClub> UserClubList { get; set; }

        public bool ReturningUser { get; set; }
    }
}