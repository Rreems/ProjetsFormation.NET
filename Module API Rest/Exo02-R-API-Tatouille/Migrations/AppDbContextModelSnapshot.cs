﻿// <auto-generated />
using System;
using Exo02_R_API_Tatouille.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Exo02_R_API_Tatouille.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Exo02_R_API_Tatouille.Models.Ingredient", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("id");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(800)
                        .HasColumnType("nvarchar(800)")
                        .HasColumnName("description");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("name");

                    b.Property<string>("RatatouilleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RatatouilleId");

                    b.ToTable("ingredient");
                });

            modelBuilder.Entity("Exo02_R_API_Tatouille.Models.Ratatouille", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("id");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(800)
                        .HasColumnType("nvarchar(800)")
                        .HasColumnName("description");

                    b.Property<bool>("IsSpicy")
                        .HasColumnType("bit")
                        .HasColumnName("est_piquante");

                    b.Property<bool>("IsVeggie")
                        .HasColumnType("bit")
                        .HasColumnName("est_vegetarienne");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("name");

                    b.Property<decimal>("Price")
                        .HasPrecision(14, 2)
                        .HasColumnType("decimal(14,2)")
                        .HasColumnName("prix");

                    b.HasKey("Id");

                    b.ToTable("ratatouille");
                });

            modelBuilder.Entity("Exo02_R_API_Tatouille.Models.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("id");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("created_at");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("created_by");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("email");

                    b.Property<string>("FirstName")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)")
                        .HasColumnName("first_name");

                    b.Property<string>("LastName")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)")
                        .HasColumnName("last_name");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("password");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("role");

                    b.HasKey("Id");

                    b.ToTable("users");
                });

            modelBuilder.Entity("Exo02_R_API_Tatouille.Models.Ingredient", b =>
                {
                    b.HasOne("Exo02_R_API_Tatouille.Models.Ratatouille", null)
                        .WithMany("Reservations")
                        .HasForeignKey("RatatouilleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Exo02_R_API_Tatouille.Models.Ratatouille", b =>
                {
                    b.Navigation("Reservations");
                });
#pragma warning restore 612, 618
        }
    }
}
