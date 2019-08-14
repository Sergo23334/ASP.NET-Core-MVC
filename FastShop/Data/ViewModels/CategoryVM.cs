using FastShop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FastShop.Data.ViewModels
{
	public class CategoryVM
	{
		public IEnumerable<MainCategory> mc { get; set; }
		public IEnumerable<Category> c { get; set; }
		public IEnumerable<Subcategory> s { get; set; }
		public IEnumerable<Product> p { get; set; }
	}
}
