namespace Theatre.Common
{
    public class ValidationConstants
    {
        // Theatre
        public const int TheatreNameMinLength = 4;
        public const int TheatreNameMaxLength = 30;
        public const string TheatreMinNumberOfHalls = "1";
        public const string TheatreMaxNumberOfHalls = "10";
        public const int TheatreDirectorMinLength = 4;
        public const int TheatreDirectorMaxLength = 30;

        // Play
        public const int PlayTitleMinLength = 4;
        public const int PlayTitleMaxLength = 50;
        public const int PlayDescriptionMaxValue = 700;
        public const int PlayScreenwriterMinValue = 4;
        public const int PlayScreenwriterMaxValue = 30;

        // Cast
        public const int CastFullNameMinLength = 4;
        public const int CastFullNameMaxLength = 30;
        public const string CastPhoneNumberRegex = @"^(\+44)-(\d{2})-(\d{3})-(\d{4})$";

        // Ticket
        public const string TicketRowNumberMinLength = "1";
        public const string TicketRowNumberMaxLength = "10";
    }
}