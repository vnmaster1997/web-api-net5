﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RestfulAPI.Data;

namespace RestfulAPI.Migrations
{
    [DbContext(typeof(MyDbContext))]
    [Migration("20220107075743_InitDB")]
    partial class InitDB
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.13")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("RestfulAPI.Data.Merchandise", b =>
                {
                    b.Property<Guid>("code")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte>("discount")
                        .HasColumnType("tinyint");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<double>("price")
                        .HasColumnType("float");

                    b.HasKey("code");

                    b.ToTable("Merchandise");
                });
#pragma warning restore 612, 618
        }
    }
}
