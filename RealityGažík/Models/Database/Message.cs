using System.ComponentModel.DataAnnotations.Schema;

namespace RealityGažík.Models.Database
{
    [Table("tbMessages")]
    public class Message
    {
        public int id {  get; set; }
        public int idInquiry { get; set; }
        public int idUser { get; set; }
        public string text { get; set; }
        public DateTime time { get; set; }
    }
}
