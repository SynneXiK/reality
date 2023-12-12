using System.ComponentModel.DataAnnotations.Schema;

namespace RealityGažík.Models.Database
{
    [Table("tbUsers")]

    public class User : LoginModel, UpdateModel
    {
        public int id { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string tel { get; set; }
        public string? pfp { get; set; }
        [NotMapped]
        public bool isAdmin { get; set; }
    }
}
