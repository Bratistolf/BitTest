using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Bit.WebApp.Models
{
    public class PlayerCreateEditViewModel
    {
        public PlayerModel Player { get; set; }
        public IEnumerable<TeamModel> Teams { get; set; }

        [Display(Name = "Создать новую команду?")]
        public bool IsNewTeam { get; set; }
        [Display(Name = "Название новой команды")]
        public string NewTeamName { get; set; }
    }
}
