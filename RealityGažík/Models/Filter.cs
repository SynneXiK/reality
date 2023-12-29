using System.Text;
using System.Text.Json;

namespace RealityGažík.Models
{
    public class Filter
    {
        public int lowestPrice {  get; set; }
        public int highestPrice { get; set; }
        public string region { get; set; }
        public string apType {  get; set; }
        public int area { get; set; }
        public int count { get; set; }
        public char generalType { get; set; }

		public string ToJsonString()
		{
			return JsonSerializer.Serialize(this);
		}
	}

}
