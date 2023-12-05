using System.ComponentModel.DataAnnotations.Schema;

namespace RealityGažík.Models.Database
{
    [Table("tbImages")]

    public class Image
    {
        public int id {  get; set; }
        public int idOffer { get; set; }
        public string path { get; set; }
    }
}
