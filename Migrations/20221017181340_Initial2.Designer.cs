// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TodoAPi.Data;

#nullable disable

namespace todo_api.Migrations
{
    [DbContext(typeof(TodoAPiDataContext))]
    [Migration("20221017181340_Initial2")]
    partial class Initial2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("TodoAPi.Models.Todo", b =>
                {
                    b.Property<string>("Title")
                        .HasMaxLength(30)
                        .HasColumnType("NVARCHAR(30)")
                        .HasColumnName("Title");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(60)
                        .HasColumnType("DATETIME")
                        .HasDefaultValue(new DateTime(2022, 10, 17, 18, 13, 40, 656, DateTimeKind.Utc).AddTicks(9994))
                        .HasColumnName("CreatedAt");

                    b.Property<bool>("Done")
                        .HasColumnType("BIT")
                        .HasColumnName("Done");

                    b.Property<DateTime>("LastUpdate")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(60)
                        .HasColumnType("DATETIME")
                        .HasDefaultValue(new DateTime(2022, 10, 17, 18, 13, 40, 657, DateTimeKind.Utc).AddTicks(235))
                        .HasColumnName("LastUpdate");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Title");

                    b.HasIndex("UserId");

                    b.ToTable("Todo", (string)null);
                });

            modelBuilder.Entity("TodoAPi.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("NVARCHAR(80)")
                        .HasColumnName("Name");

                    b.HasKey("Id");

                    b.ToTable("User", (string)null);
                });

            modelBuilder.Entity("TodoAPi.Models.Todo", b =>
                {
                    b.HasOne("TodoAPi.Models.User", "User")
                        .WithMany("Todos")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("TodoAPi.Models.User", b =>
                {
                    b.Navigation("Todos");
                });
#pragma warning restore 612, 618
        }
    }
}
