namespace BusStation.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using static BusStation.Data.Common.DataConstants;

    public class Destination
    {
        public Destination()
        {
            Tickets = new List<Ticket>();
        }

        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        [MaxLength(DestNameMaxLength)]
        public string DestinationName { get; set; }

        [Required]
        [MaxLength(OriginMaxLength)]
        public string Origin { get; set; }

        [Required]
        [MaxLength(DateMaxLength)]
        public string Date { get; set; }

        [Required]
        [MaxLength(TimeMaxLength)]
        public string Time { get; set; }

        [Required]
        [MaxLength(PictureUrlMaxLength)]
        public string ImageUrl { get; set; }

        public ICollection<Ticket> Tickets { get; set; }
    }
}
