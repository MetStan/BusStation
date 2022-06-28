namespace BusStation.Data.Common
{
    public class DataConstants
    {
        public const int GuidLength = 36;

        public const int UsernameMinLength = 5;
        public const int UsernameMaxLength = 20;

        public const int PasswordMinLength = 5;
        public const int PasswordMaxLength = 20;
        public const int PasswordMaxLengthInDb = 64;

        public const string UserEmailRegularExpression = @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
        public const int EmailMaxLength = 60;
        public const int EmailMinLength = 10;
        public const string InvalidEmailMessage = "Invalid e-mail!";

        public const int DestNameMinLength = 2;
        public const int DestNameMaxLength = 50;

        public const int OriginMinLength = 2;
        public const int OriginMaxLength = 50;

        public const int DateMaxLength = 30;
        public const int TimeMaxLength = 30;

        public const int PictureUrlMaxLength = 2048;

        public const int PriceMaxLength = 5;
    }
}
