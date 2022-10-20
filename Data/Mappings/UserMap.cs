using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TodoAPi.Models;

namespace TodoAPi.Data.Mappings;

public class UserMap : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {

        builder.ToTable("User");

        builder.HasKey(x => x.Email);

        builder.Property(x => x.Email).IsRequired()
         .HasColumnName("Email")
         .HasColumnType("NVARCHAR")
         .HasMaxLength(80);

        builder.Property(x => x.Name)
        .IsRequired()
        .HasColumnName("Name")
        .HasColumnType("NVARCHAR")
        .HasMaxLength(80);


        builder.HasMany(x => x.Todos)
        .WithOne(x => x.User)
        .OnDelete(DeleteBehavior.Cascade);


        builder.Property(x => x.PasswordHash).IsRequired()
         .HasColumnName("PasswordHash")
         .HasColumnType("VARCHAR")
         .HasMaxLength(255);


        builder
            .HasMany(x => x.UserRoles)
            .WithOne(x => x.User);
           
    }
}

