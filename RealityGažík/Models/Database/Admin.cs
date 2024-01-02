using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RealityGažík.Models.Database
{
    [Table("tbAdmins")]

    public class Admin
    {
        public int id { get; set; }
        public string role { get; set; }
        [Required(ErrorMessage = "Username is required.")]
        public string username { get; set; }
        [Required(ErrorMessage = "Password is required.")]
        public string password { get; set; }
        [Required(ErrorMessage = "Name is required.")]
        public string name { get; set; }
        public string email { get; set; }
        public string tel { get; set; }
        public string pfp { get; set; }
    }

    public static class Roles
    {
        public static string user = "user";
        public static string broker = "broker";
        public static string admin = "admin";
    }
}
