using Microsoft.EntityFrameworkCore;
using TestDito.Domain.Entities;

namespace TestDito.Infrastructure;

public class DatabaseContext(DbContextOptions<DatabaseContext> options) 
	: DbContext(options)
{
	public DbSet<User> Users { get; set; }
}
