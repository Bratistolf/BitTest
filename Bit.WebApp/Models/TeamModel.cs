using System.ComponentModel.DataAnnotations;

namespace Bit.WebApp.Models
{
    public class TeamModel
    {
        public int TeamId { get; set; }
        [Display(Name = "Название команды")]
        public string TeamName { get; set; }
    }
}
