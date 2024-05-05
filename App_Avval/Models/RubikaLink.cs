namespace App_Avval.Models
{
    public class RubikaLink
    {
        public int Id { get; set; }
        public string? ChannelId { get; set; }
        public int? Type { get; set; }
        public string? Link { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime? VisitedDate { get; set; }

    }
}
