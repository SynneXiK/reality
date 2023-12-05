using System.ComponentModel.DataAnnotations.Schema;

namespace RealityGažík.Models.Database
{
    [Table("tbValues")]

    public class Value
    {
        public int id {  get; set; }
        public int idLabel { get; set; }
        public int idOffer { get; set; }
        public string value { get; set; }
    }
}
