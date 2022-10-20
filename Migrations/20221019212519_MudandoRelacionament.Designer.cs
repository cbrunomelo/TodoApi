﻿// <auto-generated />
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
    [Migration("20221019212519_MudandoRelacionament")]
    partial class MudandoRelacionament
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("TodoAPi.Models.Role", b =>
                {
                    b.Property<string>("Name")
                        .HasMaxLength(80)
                        .HasColumnType("NVARCHAR(80)")
                        .HasColumnName("Name");

                    b.HasKey("Name");

                    b.ToTable("Role", (string)null);
                });

            modelBuilder.Entity("TodoAPi.Models.Todo", b =>
                {
                    b.Property<string>("Title")
                        .HasMaxLength(30)
                        .HasColumnType("NVARCHAR(30)")
                        .HasColumnName("Title");

                    b.Property<string>("Email")
                        .HasColumnType("NVARCHAR(80)");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(60)
                        .HasColumnType("SMALLDATETIME")
                        .HasDefaultValue(new DateTime(2022, 10, 19, 21, 25, 19, 576, DateTimeKind.Utc).AddTicks(5915))
                        .HasColumnName("CreatedAt");

                    b.Property<bool>("Done")
                        .HasColumnType("BIT")
                        .HasColumnName("Done");

                    b.Property<DateTime>("LastUpdate")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(60)
                        .HasColumnType("SMALLDATETIME")
                        .HasDefaultValue(new DateTime(2022, 10, 19, 21, 25, 19, 576, DateTimeKind.Utc).AddTicks(6176))
                        .HasColumnName("LastUpdate");

                    b.HasKey("Title", "Email");

                    b.HasIndex("Email");

                    b.ToTable("Todo", (string)null);
                });

            modelBuilder.Entity("TodoAPi.Models.User", b =>
                {
                    b.Property<string>("Email")
                        .HasMaxLength(80)
                        .HasColumnType("NVARCHAR(80)")
                        .HasColumnName("Email");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("NVARCHAR(80)")
                        .HasColumnName("Name");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("VARCHAR(255)")
                        .HasColumnName("PasswordHash");

                    b.HasKey("Email");

                    b.ToTable("User", (string)null);
                });

            modelBuilder.Entity("TodoAPi.Models.UserRole", b =>
                {
                    b.Property<string>("RoleName")
                        .HasColumnType("NVARCHAR(80)");

                    b.Property<string>("UserEmail")
                        .HasColumnType("NVARCHAR(80)");

                    b.HasKey("RoleName", "UserEmail");

                    b.HasIndex("UserEmail");

                    b.ToTable("UserRole", (string)null);
                });

            modelBuilder.Entity("TodoAPi.Models.Todo", b =>
                {
                    b.HasOne("TodoAPi.Models.User", "User")
                        .WithMany("Todos")
                        .HasForeignKey("Email")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("TodoAPi.Models.UserRole", b =>
                {
                    b.HasOne("TodoAPi.Models.Role", "Role")
                        .WithMany("UserRoles")
                        .HasForeignKey("RoleName")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TodoAPi.Models.User", "User")
                        .WithMany("UserRoles")
                        .HasForeignKey("UserEmail")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");

                    b.Navigation("User");
                });

            modelBuilder.Entity("TodoAPi.Models.Role", b =>
                {
                    b.Navigation("UserRoles");
                });

            modelBuilder.Entity("TodoAPi.Models.User", b =>
                {
                    b.Navigation("Todos");

                    b.Navigation("UserRoles");
                });
#pragma warning restore 612, 618
        }
    }
}
