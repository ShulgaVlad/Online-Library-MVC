﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OnlineLibrary.Data;

#nullable disable

namespace OnlineLibrary.Migrations
{
    [DbContext(typeof(OnlineLibraryDbContext))]
    partial class OnlineLibraryDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("OnlineLibrary.Models.Admin", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("WislistId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("WislistId");

                    b.ToTable("Admin");
                });

            modelBuilder.Entity("OnlineLibrary.Models.Book", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<string>("author")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("book_genre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("book_name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("number_of_views")
                        .HasColumnType("int");

                    b.Property<float?>("rating")
                        .IsRequired()
                        .HasColumnType("real");

                    b.Property<string>("short_dicription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Books");
                });

            modelBuilder.Entity("OnlineLibrary.Models.HistoryOfReadBooks", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<int?>("BookId")
                        .HasColumnType("int");

                    b.Property<int?>("ReaderId")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("BookId");

                    b.HasIndex("ReaderId");

                    b.ToTable("HistoryOfReadBooks");
                });

            modelBuilder.Entity("OnlineLibrary.Models.RegisteredReader", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<string>("e_mail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("faculty")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("first_name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("phone_number")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<string>("specialty")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("surname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("RegisteredReaders");
                });

            modelBuilder.Entity("OnlineLibrary.Models.Wishlist", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<int>("BookId")
                        .HasColumnType("int");

                    b.Property<string>("ItemName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.Property<int>("ReaderId")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("BookId");

                    b.HasIndex("ReaderId");

                    b.ToTable("Wishlists");
                });

            modelBuilder.Entity("OnlineLibrary.Models.Admin", b =>
                {
                    b.HasOne("OnlineLibrary.Models.Wishlist", "Wishlist")
                        .WithMany()
                        .HasForeignKey("WislistId");

                    b.Navigation("Wishlist");
                });

            modelBuilder.Entity("OnlineLibrary.Models.HistoryOfReadBooks", b =>
                {
                    b.HasOne("OnlineLibrary.Models.Book", "Books")
                        .WithMany()
                        .HasForeignKey("BookId");

                    b.HasOne("OnlineLibrary.Models.RegisteredReader", "RegisteredReaders")
                        .WithMany()
                        .HasForeignKey("ReaderId");

                    b.Navigation("Books");

                    b.Navigation("RegisteredReaders");
                });

            modelBuilder.Entity("OnlineLibrary.Models.Wishlist", b =>
                {
                    b.HasOne("OnlineLibrary.Models.Book", "Book")
                        .WithMany()
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OnlineLibrary.Models.RegisteredReader", "RegisteredReaders")
                        .WithMany()
                        .HasForeignKey("ReaderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Book");

                    b.Navigation("RegisteredReaders");
                });
#pragma warning restore 612, 618
        }
    }
}
