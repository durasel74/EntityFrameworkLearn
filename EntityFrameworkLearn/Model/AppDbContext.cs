using System;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkLearn.Model;

public class AppDbContext : DbContext
{
	public DbSet<Cities> Cities { get; set; }

	public AppDbContext()
	{
		// Database.EnsureCreated();
	}

	protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
	{
		optionsBuilder.UseSqlServer(@"Server=(LocalDb)\MSSQLLocalDB;" +
			@"AttachDbFilename=|DataDirectory|\Recources\TourDB.mdf;Database=TourDB;" +
			"Trusted_Connection=True;");
	}
}
