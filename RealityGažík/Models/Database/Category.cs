using System.ComponentModel.DataAnnotations.Schema;

namespace RealityGažík.Models.Database
{
	[Table("tbCategories")]
	public class Category
	{
		public int id { get; set; }
		public string name { get; set; }
        public string imgRoute { get; set; }

        [NotMapped]
		public int count { get; set; }

    }
}
