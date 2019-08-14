using FastShop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FastShop.Data.ViewModels
{
	public class HomeVM
	{
		public IEnumerable<Product> _RecommendProduct { get; set; }
		public IEnumerable<Product> _SaleProduct { get; set; }
	}
}
