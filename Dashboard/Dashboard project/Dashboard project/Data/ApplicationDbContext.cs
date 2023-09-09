using Dashboard_project.Models;
using Microsoft.EntityFrameworkCore;

namespace Dashboard_project.Data
{
	public class ApplicationDbContext :DbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
		{
		
		}
			public DbSet<Product> Products { get; set; }
		    public DbSet<ProductDetails> ProductDetails { get; set; }
		    public DbSet<Invoice> Invoice { get; set; }
		    public DbSet<customer> Customer { get; set; }
        public DbSet<carts> carts { get; set; }


    }
}

