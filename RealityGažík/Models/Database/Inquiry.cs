using System.ComponentModel.DataAnnotations.Schema;

namespace RealityGažík.Models.Database
{
    [Table("tbInquiries")]

    public class Inquiry
    {
        public int id { get; set; }
        public int idOwner { get; set; }
        public int idSender { get; set; }
        public int idOffer { get; set; }
        public bool isActive { get; set; }
        public string name { get; set; }
        public string tel { get; set; }
        public string email { get; set; }
        [NotMapped]
        public string text { get; set; }
    }
}
