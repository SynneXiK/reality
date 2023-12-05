using System.ComponentModel.DataAnnotations.Schema;

namespace RealityGažík.Models.Database
{
    [Table("tbLabels")]

    public class Label
    {
        public int id { get; set; }
        public string label { get; set; }
    }
}
