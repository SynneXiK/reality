using System.ComponentModel.DataAnnotations.Schema;

namespace RealityGažík.Models.Database
{
    [Table("tbImages")]

    public class Image
    {
        public string id {  get; set; }
        public int idOffer { get; set; }
        public string fileExtension { get; set; }
        public bool main { get; set; }
    }
}
