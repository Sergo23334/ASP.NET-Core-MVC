using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FastShop.Data;
using FastShop.Data.Models;
using FastShop.Data.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace FastShop.Controllers
{
    public class HomeController : Controller
    {
		private readonly AppDbContext db;

		public HomeController(AppDbContext context)
		{
			db = context;
		}

        public IActionResult Index()
        {
			ViewBag.Title = "Главная";

			IEnumerable<Product> ReccomendProduct = db.Products.Where(p => p.IsFavorite).OrderByDescending(p => p.Id).Take(10);
			IEnumerable<Product> SaleProduct = db.Products.Where(p => p.IsSale).OrderByDescending(p => p.Id).Take(10);

			HomeVM vm = new HomeVM
			{
				_RecommendProduct = ReccomendProduct,
				_SaleProduct = SaleProduct
			};

			return View(vm);
        }

		public IActionResult Error()
		{
			return View();
		}
    }
}