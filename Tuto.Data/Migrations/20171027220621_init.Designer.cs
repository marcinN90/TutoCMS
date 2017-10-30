﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;
using Tuto.Data;

namespace Tuto.Data.Migrations
{
    [DbContext(typeof(TutoContext))]
    [Migration("20171027220621_init")]
    partial class init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("dbo")
                .HasAnnotation("ProductVersion", "2.0.0-rtm-26452")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Tuto.Data.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<string>("ShortSeoDescription");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.ToTable("Category");
                });

            modelBuilder.Entity("Tuto.Data.Models.Entry", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CategoryId");

                    b.Property<string>("Content");

                    b.Property<DateTime>("LastRevisionAt");

                    b.Property<string>("SeoDescription");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("EntryPart");
                });

            modelBuilder.Entity("Tuto.Data.Models.HomePageSettings", b =>
                {
                    b.Property<string>("Title")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Descritpion");

                    b.Property<string>("SeoDescription");

                    b.HasKey("Title");

                    b.ToTable("HomePageSettings");
                });

            modelBuilder.Entity("Tuto.Data.Models.Link", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("LinkTitle");

                    b.Property<string>("UrlAddress");

                    b.HasKey("Id");

                    b.ToTable("Link");
                });

            modelBuilder.Entity("Tuto.Data.Models.WebsiteDetails", b =>
                {
                    b.Property<string>("Title")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("OwnerEmail");

                    b.HasKey("Title");

                    b.ToTable("WebsiteDetails");
                });

            modelBuilder.Entity("Tuto.Data.Models.Entry", b =>
                {
                    b.HasOne("Tuto.Data.Models.Category", "Category")
                        .WithMany("Entries")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
