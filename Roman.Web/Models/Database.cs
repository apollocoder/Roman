using Microsoft.EntityFrameworkCore;

namespace Roman.Web.Models;

public class Database(DbContextOptions<Database> options) : DbContext(options)
{
    protected override void OnModelCreating(ModelBuilder modelBuilder) {}
}
