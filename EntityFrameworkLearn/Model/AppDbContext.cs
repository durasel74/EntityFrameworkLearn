using System;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkLearn.Model;

public class AppDbContext : DbContext
{
	public AppDbContext() { }

	public DbSet<City> Cities { get; set; }
	public DbSet<Country> Country { get; set; }
	public DbSet<Hotel> Hotels { get; set; }
	public DbSet<TourOperator> TourOperators { get; set; }
	public DbSet<User> Users { get; set; }
	public DbSet<AirFlight> AirFlights { get; set; }
	public DbSet<Tour> Tours { get; set; }
	public DbSet<User_Tour> Users_Tours { get; set; }

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.Entity<Tour>()
			.HasKey(t => new { t.name, t.date });
		modelBuilder.Entity<User_Tour>()
			.HasKey(t => new { t.userLogin, t.tourName, t.tourDate });
	}

	protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
	{
		optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;" +
			@"AttachDbFilename=|DataDirectory|\Recources\TourDB.mdf;Database=TourDB;" +
			@"User Id=User;Password=0000;");
	}
}
