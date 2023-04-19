namespace SoftJail.Common
{
    public class ValidationConstants
    {
        // Decimal
        public const string NonNegativeDecimalMinValue = "0";
        public const string NonNegativeDecimalMaxValue = "79228162514264337593543950335";

        // Prisoner
        public const int PrisonerFullNameMinLength = 3;
        public const int PrisonerFullNameMaxLength = 20;
        public const int PrisonerAgeMinValue = 18;
        public const int PrisonerAgeMaxValue = 65;
        public const string PrisonerNicknameRegex = @"^(The\s)([A-Z][a-z]*)$";

        // Officer
        public const int OfficerFullNameMinLength = 3;
        public const int OfficerFullNameMaxLength = 30;

        // Department
        public const int DepartmentNameMinLength = 3;
        public const int DepartmentNameMaxLength = 25;

        // Cell
        public const int CellNumberMinValue = 1;
        public const int CellNumberMaxValue = 1000;

        // Mail
        public const string MailAddressRegex = @"^([A-Za-z\s0-9]+?)(\sstr\.)$";
    }
}