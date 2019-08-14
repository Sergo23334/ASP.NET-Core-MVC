using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FastShop.Data.Models
{
	public class Product
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Desc { get; set; }
		public string Img { get; set; }
		public string Video { get; set; }
		public ushort Price { get; set; }
		public string Manufacturer { get; set; }
		public bool IsFavorite { get; set; }
		public bool IsSale { get; set; }
		public ushort OldPrice { get; set; }
		public string Tags { get; set; }
		public int Count { get; set; }
		public int MainCatId { get; set; }
		public int CatId { get; set; }
		public int SubcatId { get; set; }

	}
}
