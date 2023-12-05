using System.ComponentModel.DataAnnotations.Schema;

namespace RealityGažík.Models.Database
{
    [Table("tbFavorites")]

    public class Favorite
    {
        public int id { get; set; }
        public int idUser { get; set; }
        public int idOffer { get; set; }
    }
}
