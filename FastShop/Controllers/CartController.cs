using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using FastShop.Data;
using FastShop.Data.Models;
using FastShop.Classes;
using Newtonsoft.Json;

namespace FastShop.Controllers
{
    public class CartController : Controller
    {
		AppDbContext db;

		public CartController(AppDbContext context)
		{
			db = context;
		}

        public IActionResult Index()
        {
			IEnumerable<Product> Cart = HttpContext.Session.Get<IEnumerable<Product>>("Cart");

            return View(Cart);
        }

		[HttpPost]
		public void AddToCart(int id)
		{
			if (HttpContext.Session.Get<List<Product>>("Cart") == null)
			{
				List<Product> Cart = db.Products.Where(p => p.Id == id).ToList();

				HttpContext.Session.Set("Cart", Cart);
			}
			else
			{
				List<Product> Cart = HttpContext.Session.Get<List<Product>>("Cart");
				if (Cart.SingleOrDefault(p => p.Id == id) == null)
				{
					Product CartItem = db.Products.Single(p => p.Id == id);
					Cart.Add(CartItem);
					HttpContext.Session.Set("Cart", Cart);
				}
			}
		}
    }
}