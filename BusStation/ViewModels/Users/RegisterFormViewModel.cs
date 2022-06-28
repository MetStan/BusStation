namespace BusStation.ViewModels.Users
{
    using System.ComponentModel.DataAnnotations;
    using static Data.Common.DataConstants;

    public class RegisterFormViewModel
    {

        [StringLength(UsernameMaxLength, MinimumLength = UsernameMinLength, ErrorMessage = "{0} must be between {2} and {1} characters.")]
        public string Username { get; init; }

        [Required]
        [StringLength(EmailMaxLength, MinimumLength = EmailMinLength, ErrorMessage = "{0} must be between {2} and {1} characters.")]
        [EmailAddress(ErrorMessage = InvalidEmailMessage)]
        [RegularExpression(UserEmailRegularExpression, ErrorMessage = InvalidEmailMessage)]
        public string Email { get; init; }

        [Required]
        [StringLength(PasswordMaxLength, MinimumLength = PasswordMinLength, ErrorMessage = "{0} must be between {2} and {1} characters.")]
        public string Password { get; init; }

        [Compare(nameof(Password), ErrorMessage = "Password and ConfirmPassword must be equal.")]
        public string ConfirmPassword { get; init; }
    }
}
