﻿// <auto-generated />
using System;
using Lubes.DBContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Lubes.Migrations
{
    [DbContext(typeof(ApplicationDBContext))]
    partial class ApplicationDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Lubes.Models.Add_item", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Category_id")
                        .HasColumnType("int");

                    b.Property<string>("DateTime")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Item_name")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<float>("Item_price")
                        .HasColumnType("real");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.ToTable("Add_item");
                });

            modelBuilder.Entity("Lubes.Models.Item_category", b =>
                {
                    b.Property<int>("IDT")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Category_name")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("ImageURL")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Item_categoryIDT")
                        .HasColumnType("int");

                    b.HasKey("IDT");

                    b.HasIndex("Item_categoryIDT");

                    b.ToTable("Items_category");
                });

            modelBuilder.Entity("Lubes.Models.Roles", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Role_id")
                        .HasColumnType("int");

                    b.Property<string>("Role_name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("Lubes.Models.Stock_summary", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<float>("Cash_made")
                        .HasColumnType("real");

                    b.Property<string>("Category_name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IDT")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageURL")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Item_name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("Item_price")
                        .HasColumnType("real");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<string>("User_id")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("item_sold")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.ToTable("Stock_summary");
                });

            modelBuilder.Entity("Lubes.Models.Submited_stock", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<float>("Cash_made")
                        .HasColumnType("real");

                    b.Property<string>("DateTime")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("User_id")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("item_id")
                        .HasColumnType("int");

                    b.Property<int>("item_sold")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.ToTable("Submited_stock");
                });

            modelBuilder.Entity("Lubes.Models.Users", b =>
                {
                    b.Property<int>("National_id")
                        .HasColumnType("int");

                    b.Property<string>("Full_name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("strRole")
                        .HasColumnType("int");

                    b.HasKey("National_id");

                    b.ToTable("c_Users");
                });

            modelBuilder.Entity("Lubes.Models.Item_category", b =>
                {
                    b.HasOne("Lubes.Models.Item_category", null)
                        .WithMany("item_Categories")
                        .HasForeignKey("Item_categoryIDT");
                });
#pragma warning restore 612, 618
        }
    }
}
