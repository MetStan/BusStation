namespace BusStation.ViewModels.Tickets
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using static BusStation.Data.Common.DataConstants;

    public class TicketFormViewModel
    {
        public string UserId { get; init; }

        public int DestinationId { get; init; }

        [Required]
        [MaxLength(PriceMaxLength)]
        [Range(typeof(decimal), "0", "79228162514264337593543950335")]
        public string Price { get; init; }

        [Required]
        [Range(1, 10)]
        public int TicketsCount { get; init; }
    }
}
