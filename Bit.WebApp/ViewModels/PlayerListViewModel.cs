using System.Collections.Generic;

namespace Bit.WebApp.Models
{
    public class PlayerListViewModel
    {
        public IEnumerable<TeamModel> Teams { get; set; }
        public IEnumerable<PlayerModel> Players { get; set; }
    }
}
