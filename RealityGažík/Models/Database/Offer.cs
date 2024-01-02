using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RealityGažík.Models.Database
{
    [Table("tbOffers")]

    public class Offer
    {
        public int id { get; set; }
        public int idBroker { get; set; }
        [Required(ErrorMessage = "Name is required.")]
        public string name { get; set; }
        [Required(ErrorMessage = "Price is required.")]
        public int price { get; set; }
        [Required(ErrorMessage = "Location is required.")]
        public string location {  get; set; }
        [Required(ErrorMessage = "Area is required.")]
        public int area {  get; set; }
        public string description { get; set; }
        [Required(ErrorMessage = "Category is required.")]
        public int idCategory { get; set; }
        
    }
}
