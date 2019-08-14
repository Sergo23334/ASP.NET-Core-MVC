using FastShop.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FastShop.Data.ViewModels;

namespace FastShop.Data
{
	public class AppDbContext : IdentityDbContext<User>
	{
		public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
		{
			Database.EnsureCreated();
		}

		public DbSet<MainCategory> MainCategories { get; set; }
		public DbSet<Category> Categories { get; set; }
		public DbSet<Subcategory> Subcategories { get; set; }
		public DbSet<Product> Products { get; set; }
	}
}
