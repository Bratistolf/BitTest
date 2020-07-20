using System.ComponentModel.DataAnnotations;

namespace Bit.WebApp.Models
{
    public class PlayerModel
    {
        public int? Id { get; set; }
        [Display(Name = "Имя")]
        public string Name { get; set; }
        [Display(Name = "Фамилия")]
        public string Surname { get; set; }
        [Display(Name = "Пол")]
        public string Gender { get; set; }
        [Display(Name = "Дата рождения")]
        public string Birthday { get; set; }
        [Display(Name = "Команда")]
        public int TeamId { get; set; }
        [Display(Name = "Страна")]
        public string Country { get; set; }
    }
}