namespace BusStation.ViewModels.Destinations
{
    using System.ComponentModel.DataAnnotations;
    using static Data.Common.DataConstants;

    public class DestinationFormViewModel
    {
        [Required]
        [StringLength(DestNameMaxLength, MinimumLength = DestNameMinLength, ErrorMessage = "{0} must be between {2} and {1} characters.")]
        public string DestinationName { get; set; }

        [Required]
        [StringLength(OriginMaxLength, MinimumLength = OriginMinLength, ErrorMessage = "{0} must be between {2} and {1} characters.")]
        public string Origin { get; set; }

        [Required]
        [MaxLength(60)]
        public string Date { get; set; }

        [Required]
        [Url]
        [MaxLength(PictureUrlMaxLength)]
        public string ImageUrl { get; set; }
    }
}
