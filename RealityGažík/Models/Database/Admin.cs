using System.ComponentModel.DataAnnotations.Schema;

namespace RealityGažík.Models.Database
{
    [Table("tbAdmins")]

    public class Admin
    {
        public int id { get; set; }
        public string role { get; set; }
        public string username { get; set; }
        public string password { get; set; }
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
