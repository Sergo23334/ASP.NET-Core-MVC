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
    public class CatalogController : Controller
    {
		private AppDbContext db;

		public CatalogController(AppDbContext context)
		{
			db = context;
		}

		public IActionResult Index()
		{
			ViewBag.Title = "Каталог";

			IEnumerable<Product> AllProd = db.Products.OrderByDescending(p => p.Id);

			return View(AllProd);
		}

        public IActionResult Search(string q)
		{
			ViewBag.Title = $"Поиск \"{q}\"";

			IEnumerable<Product> res = db.Products.Where(p => p.Name.Contains(q) || p.Tags.Contains(q)).OrderByDescending(p => p.Id);

			return View(res);
		}

		[Route("/Catalog/Item/{id}")]
		public IActionResult Item(int id)
		{
			Product item = db.Products.Single(p => p.Id == id);

			ViewBag.Title = item.Name;

			return View(item);
		}

		[Route("/Catalog/Category/{par1?}/{par2?}/{par3?}")]
		public IActionResult Category(string par1, string par2, string par3)
		{
			CategoryVM vm = new CategoryVM();

			if (!string.IsNullOrEmpty(par3))
			{
				int mcId = db.MainCategories.Single(m => m.EngName.Equals(par1)).Id;
				int cId = db.Categories.Single(c => c.ParentCatId == mcId && c.EngName.Equals(par2)).Id;
				int sId = db.Subcategories.Single(s => s.ParentCatId == cId && s.EngName.Equals(par3)).Id;

				vm.p = db.Products.Where(p => p.MainCatId == mcId && p.CatId == cId && p.SubcatId == sId).OrderByDescending(p => p.Id);

				return View(vm);
			}

			if (!string.IsNullOrEmpty(par2))
			{
				int mcId = db.MainCategories.Single(m => m.EngName.Equals(par1)).Id;
				int cId = db.Categories.Single(c => c.ParentCatId == mcId && c.EngName.Equals(par2)).Id;

				vm.s = db.Subcategories.Where(s => s.ParentCatId == cId).OrderByDescending(p => p.Id);

				if(vm.s.FirstOrDefault() == null)
				{
					vm.p = db.Products.Where(p => p.MainCatId == mcId && p.CatId == cId).OrderByDescending(p => p.Id);
				}

				return View(vm);
			}

			if (!string.IsNullOrEmpty(par1))
			{
				int mcId = db.MainCategories.Single(m => m.EngName.Equals(par1)).Id;

				vm.c = db.Categories.Where(c => c.ParentCatId == mcId).OrderByDescending(p => p.Id);

				if (vm.c.FirstOrDefault() == null)
				{
					vm.p = db.Products.Where(p => p.MainCatId == mcId).OrderByDescending(p => p.Id);
				}

				return View(vm);
			}

			if (string.IsNullOrEmpty(par1))
			{
				vm.mc = db.MainCategories.OrderByDescending(m => m.Id);
				return View(vm);
			}

			return View();
		}
	}
}