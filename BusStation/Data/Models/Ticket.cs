namespace BusStation.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using static BusStation.Data.Common.DataConstants;

    public class Ticket
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(PriceMaxLength)]
        public decimal Price { get; set; }

        [MaxLength(GuidLength)]
        [ForeignKey(nameof(UserId))]
        public string UserId { get; set; }
        public User User { get; set; }

        [MaxLength(GuidLength)]
        [ForeignKey(nameof(DestinationId))]
        public int DestinationId { get; set; }
        public Destination Destination { get; set; }
    }
}

