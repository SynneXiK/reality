using System.ComponentModel.DataAnnotations.Schema;

namespace RealityGažík.Models.Database
{
    [Table("tbOffers")]

    public class Offer
    {
        public int id { get; set; }
        public int idBroker { get; set; }
        public string name { get; set; }
        public int price { get; set; }
        public string location {  get; set; }
        public int area {  get; set; }
        public string description { get; set; }
        public int idCategory { get; set; }
        
    }
}
