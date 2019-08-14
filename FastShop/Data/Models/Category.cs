using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FastShop.Data.Models
{
	public class Category
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string EngName { get; set; }
		public string Img { get; set; }
		public int ParentCatId { get; set; }
	}
}
