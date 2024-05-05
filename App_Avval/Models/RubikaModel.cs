using System.ComponentModel.DataAnnotations.Schema;
using System.Net;

namespace App_Avval.Models
{
    public class RubikaModel
    {
        public RubikaModel()
        {
          //  posts = new List<RubikaPost>();
        }
        public int Id { get; set; }
        public string? ChannelId { get; set; }
        public string? Name { get; set; }
        public int MemberCount { get; set; } = 0;
        public string? Description { get; set; }
        public string? Description_Links { get; set; }
        //public List<RubikaPost> posts { get; set; }
        public string? Date { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime? VisitedDate { get; set; }
        public string? UserName { get; set; }
        public string? Type { get; set; }

        public int? TypeSotware { get;set; }

    }
    public class RubikaPost
    {
        public int Id { get; set; }        
        public string? ChannelId { get; set; }
        public string? MessageId { get; set; }
        public string? Description { get; set; }
        public string? Date { get; set; }
        public int ViewCount { get; set; } = 0;
        public string? HTML { get; set;}
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime? VisitedDate { get; set; }

    }
}
