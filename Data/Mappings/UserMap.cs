using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TodoAPi.Models;

namespace TodoAPi.Data.Mappings;

public class UserMap : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {

        builder.ToTable("User");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
        .ValueGeneratedOnAdd()
        .UseIdentityColumn();

        builder.Property(x => x.Name)
        .IsRequired()
        .HasColumnName("Name")
        .HasColumnType("NVARCHAR")
        .HasMaxLength(80);


        builder.HasMany(x => x.Todos)
        .WithOne(x => x.User)
        .OnDelete(DeleteBehavior.Cascade);

    }
}

