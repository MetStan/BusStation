namespace BusStation.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using static Data.Common.DataConstants;

    public class User
    {
        public User()
        {
            Id = Guid.NewGuid().ToString();
            Tickets = new List<Ticket>();
        }

        [Key]
        [Required]
        [MaxLength(GuidLength)]
        public string Id { get; set; }

        [Required]
        [MaxLength(UsernameMaxLength)]
        public string Username { get; set; }

        [Required]
        [MaxLength(EmailMaxLength)]
        public string Email { get; set; }

        [Required]
        [MaxLength(PasswordMaxLengthInDb)]
        public string Password { get; set; }

        public ICollection<Ticket> Tickets { get; set; }
    }
}
