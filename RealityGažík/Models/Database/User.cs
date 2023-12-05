using System.ComponentModel.DataAnnotations.Schema;

namespace RealityGažík.Models.Database
{
    [Table("tbUsers")]

    public class User
    {
        public int id { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        [Column("tel")]
        public string telephone { get; set; }
        [Column("pfp")]
        public string? pfpRoute { get; set; }
    }
}
