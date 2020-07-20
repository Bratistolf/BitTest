using System;

namespace Bit.Api.Domain.Models
{
    public class PlayerUpdateDto
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Gender { get; set; }
        public string Birthday { get; set; }
        public int TeamId { get; set; }
        public string Country { get; set; }
    }
}
