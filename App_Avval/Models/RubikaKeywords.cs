using Azure.Core.Pipeline;

namespace App_Avval.Models
{
    public class RubikaKeywords
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public DateTime? VisitedDate { get; set; }
        public int? Count { get; set; }
        public int? Type { get; set; }
        public DateTime? VisitedDateEitaa { get; set; }
        public int? CountEitaa { get; set; }
    }
}
