using System;

namespace Bit.Api.Domain.Models
{
    public class PlayerViewDto
    {
        public int PlayerId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Gender { get; set; }
        public string Birthday { get; set; }
        public string TeamId { get; set; }
        public string Country { get; set; }
    }
}
