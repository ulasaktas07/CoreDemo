using Microsoft.EntityFrameworkCore;

namespace BlogApiDemo.DataAccessLayer
{
	public class Context:DbContext
	{
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer("Server=MELYAT;Database=CoreBlogApiDb;User Id=sa;Password=1;");

		}
		public DbSet<Employee> Employees { get; set; }
	}
}
