﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace WebApplication1.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20241229030733_initial")]
    partial class initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("CustomerMovie", b =>
                {
                    b.Property<Guid>("customersId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("moviesId")
                        .HasColumnType("uuid");

                    b.HasKey("customersId", "moviesId");

                    b.HasIndex("moviesId");

                    b.ToTable("CustomerMovie");
                });

            modelBuilder.Entity("WebApplication1.Models.DomainModels.Customer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid?>("membershipTypeId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("membershipTypeId");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("WebApplication1.Models.DomainModels.Genre", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("GenreName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Genres");
                });

            modelBuilder.Entity("WebApplication1.Models.DomainModels.Memebershiptype", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<float>("DiscountRate")
                        .HasColumnType("real");

                    b.Property<int>("DurationInMonth")
                        .HasColumnType("integer");

                    b.Property<int>("SignUpFee")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("memebershipTypes");
                });

            modelBuilder.Entity("WebApplication1.Models.DomainModels.Movie", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid?>("genre_idId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("genre_idId");

                    b.ToTable("Movies");
                });

            modelBuilder.Entity("CustomerMovie", b =>
                {
                    b.HasOne("WebApplication1.Models.DomainModels.Customer", null)
                        .WithMany()
                        .HasForeignKey("customersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApplication1.Models.DomainModels.Movie", null)
                        .WithMany()
                        .HasForeignKey("moviesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("WebApplication1.Models.DomainModels.Customer", b =>
                {
                    b.HasOne("WebApplication1.Models.DomainModels.Memebershiptype", "membershipType")
                        .WithMany("customers")
                        .HasForeignKey("membershipTypeId");

                    b.Navigation("membershipType");
                });

            modelBuilder.Entity("WebApplication1.Models.DomainModels.Movie", b =>
                {
                    b.HasOne("WebApplication1.Models.DomainModels.Genre", "genre_id")
                        .WithMany("movies")
                        .HasForeignKey("genre_idId");

                    b.Navigation("genre_id");
                });

            modelBuilder.Entity("WebApplication1.Models.DomainModels.Genre", b =>
                {
                    b.Navigation("movies");
                });

            modelBuilder.Entity("WebApplication1.Models.DomainModels.Memebershiptype", b =>
                {
                    b.Navigation("customers");
                });
#pragma warning restore 612, 618
        }
    }
}
