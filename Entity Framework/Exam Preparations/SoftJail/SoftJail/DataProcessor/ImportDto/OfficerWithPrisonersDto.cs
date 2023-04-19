namespace SoftJail.DataProcessor.ImportDto
{
    using System.Xml.Serialization;
    using System.ComponentModel.DataAnnotations;

    using Common;

    [XmlType("Officer")]
    public class OfficerWithPrisonersDto
    {
        [Required]
        [XmlElement("Name")]
        [MinLength(ValidationConstants.OfficerFullNameMinLength)]
        [MaxLength(ValidationConstants.OfficerFullNameMaxLength)]
        public string FullName { get; set; }

        [XmlElement("Money")]
        [Range(typeof(decimal), ValidationConstants.NonNegativeDecimalMinValue, ValidationConstants.NonNegativeDecimalMaxValue)]
        public decimal Salary { get; set; }

        [Required]
        [XmlElement("Position")]
        public string Position { get; set; }

        [Required]
        [XmlElement("Weapon")]
        public string Weapon { get; set; }

        [XmlElement("DepartmentId")]
        public int DepartmentId { get; set; }

        [XmlArray("Prisoners")]
        public OfficerPrisonerDto[] Prisoners { get; set; }
    }
}