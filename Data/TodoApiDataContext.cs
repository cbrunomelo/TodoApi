using Microsoft.EntityFrameworkCore;
using TodoAPi.Data.Mappings;
using TodoAPi.Models;

namespace TodoAPi.Data;


public class TodoAPiDataContext : DbContext
{
    public DbSet<Todo> Todos { get; set; }

    public DbSet<User> Users { get; set; }

    public DbSet<UserRole> UsersRoles { get; set; }


    public DbSet<Role> Roles { get; set; }



    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlServer($"{Configuration.ConnectionString}");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new TodoMap());
        modelBuilder.ApplyConfiguration(new UserMap());
        modelBuilder.ApplyConfiguration(new UserRoleMap());
        modelBuilder.ApplyConfiguration(new RoleMap());





    }
}