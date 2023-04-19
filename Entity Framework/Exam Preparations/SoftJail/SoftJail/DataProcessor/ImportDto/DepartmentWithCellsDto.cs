namespace SoftJail.DataProcessor.ImportDto
{
    using System.ComponentModel.DataAnnotations;

    using Newtonsoft.Json;

    using Common;

    public class DepartmentWithCellsDto
    {
        [Required]
        [JsonProperty(nameof(Name))]
        [MinLength(ValidationConstants.DepartmentNameMinLength)]
        [MaxLength(ValidationConstants.DepartmentNameMaxLength)]
        public string Name { get; set; }

        [JsonProperty(nameof(Cells))]
        public DepartmentCellDto[] Cells { get; set; }
    }
}