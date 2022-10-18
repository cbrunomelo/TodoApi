using Microsoft.EntityFrameworkCore;
using TodoAPi.Data.Mappings;
using TodoAPi.Models;

namespace TodoAPi.Data;


public class TodoAPiDataContext : DbContext
{
    public DbSet<Todo> Todos { get; set; }

    public DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlServer("Server=localhost,1433;Database=TodoApi;User ID=sa;Password=1q2w3e4r@#$");


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new TodoMap());
        modelBuilder.ApplyConfiguration(new UserMap());



    }
}