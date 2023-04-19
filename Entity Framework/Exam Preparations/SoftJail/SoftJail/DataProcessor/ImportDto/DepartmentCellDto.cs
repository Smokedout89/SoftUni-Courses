namespace SoftJail.DataProcessor.ImportDto
{
    using System.ComponentModel.DataAnnotations;

    using Common;
    using Newtonsoft.Json;

    public class DepartmentCellDto
    {
        [JsonProperty(nameof(CellNumber))]
        [Range(ValidationConstants.CellNumberMinValue, ValidationConstants.CellNumberMaxValue)]
        public int CellNumber { get; set; }

        [JsonProperty(nameof(HasWindow))]
        public bool HasWindow { get; set; }
    }
}