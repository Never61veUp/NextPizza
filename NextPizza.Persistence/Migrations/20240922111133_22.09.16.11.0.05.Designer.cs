﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NextPizza.Persistence;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace NextPizza.Persistence.Migrations
{
    [DbContext(typeof(NextPizzaDbContext))]
    [Migration("20240922111133_22.09.16.11.0.05")]
    partial class _22091611005
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("NextPizza.Persistence.Entities.DoughTypeEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int>("ThicknessInCm")
                        .HasColumnType("integer");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("DoughTypes");
                });

            modelBuilder.Entity("NextPizza.Persistence.Entities.ProductEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasMaxLength(13)
                        .HasColumnType("character varying(13)");

                    b.Property<bool>("IsNewProduct")
                        .HasColumnType("boolean");

                    b.Property<decimal>("Price")
                        .HasColumnType("numeric");

                    b.Property<string>("Title")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Products");

                    b.HasDiscriminator().HasValue("ProductEntity");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("NextPizza.Persistence.Entities.SizeEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int>("SizeInCm")
                        .HasColumnType("integer");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Sizes");
                });

            modelBuilder.Entity("NextPizza.Persistence.Entities.DrinkEntity", b =>
                {
                    b.HasBaseType("NextPizza.Persistence.Entities.ProductEntity");

                    b.Property<bool>("IsAlcoholic")
                        .HasColumnType("boolean");

                    b.Property<decimal>("VolumeInLiters")
                        .HasColumnType("numeric");

                    b.HasDiscriminator().HasValue("DrinkEntity");
                });

            modelBuilder.Entity("NextPizza.Persistence.Entities.PizzaEntity", b =>
                {
                    b.HasBaseType("NextPizza.Persistence.Entities.ProductEntity");

                    b.Property<Guid>("DoughTypeId")
                        .HasColumnType("uuid");

                    b.Property<bool>("IsVegan")
                        .HasColumnType("boolean");

                    b.Property<Guid>("SizeId")
                        .HasColumnType("uuid");

                    b.HasIndex("DoughTypeId");

                    b.HasIndex("SizeId");

                    b.HasDiscriminator().HasValue("PizzaEntity");
                });

            modelBuilder.Entity("NextPizza.Persistence.Entities.PizzaEntity", b =>
                {
                    b.HasOne("NextPizza.Persistence.Entities.DoughTypeEntity", "DoughType")
                        .WithMany()
                        .HasForeignKey("DoughTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("NextPizza.Persistence.Entities.SizeEntity", "SizeEntity")
                        .WithMany()
                        .HasForeignKey("SizeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DoughType");

                    b.Navigation("SizeEntity");
                });
#pragma warning restore 612, 618
        }
    }
}
