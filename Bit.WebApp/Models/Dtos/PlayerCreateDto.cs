using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bit.WebApp.Models.Dtos
{
    public class PlayerCreateDto
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Gender { get; set; }
        public string Birthday { get; set; }
        public int TeamId { get; set; }
        public string Country { get; set; }
    }
}
