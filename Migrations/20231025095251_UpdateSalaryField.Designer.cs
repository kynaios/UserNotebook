﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using UserNotebook.Context;

#nullable disable

namespace UserNotebook.Migrations
{
    [DbContext(typeof(UserContext))]
    [Migration("20231025095251_UpdateSalaryField")]
    partial class UpdateSalaryField
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("UserNotebook.Models.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateOnly>("BirthDay")
                        .HasColumnType("date");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Sex")
                        .HasColumnType("integer");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasDiscriminator<string>("Discriminator").HasValue("User");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("UserNotebook.Models.Adult", b =>
                {
                    b.HasBaseType("UserNotebook.Models.User");

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("IsEmployed")
                        .HasColumnType("boolean");

                    b.Property<double>("Salary")
                        .HasColumnType("double precision");

                    b.HasDiscriminator().HasValue("Adult");
                });

            modelBuilder.Entity("UserNotebook.Models.Kid", b =>
                {
                    b.HasBaseType("UserNotebook.Models.User");

                    b.Property<double>("BagWeight")
                        .HasColumnType("double precision");

                    b.Property<string>("SchoolName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasDiscriminator().HasValue("Kid");
                });
#pragma warning restore 612, 618
        }
    }
}
