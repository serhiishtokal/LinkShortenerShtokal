﻿// <auto-generated />
using System;
using LinkShortenerShtokal.Infrastructure.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace LinkShortenerShtokal.Infrastructure.EF.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    partial class ApplicationContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("LinkShortenerShtokal.Core.Domain.RedirectRequest", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("RemoteIpAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("ShortenedUrlId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("ShortenedUrlId");

                    b.ToTable("RedirectRequests");
                });

            modelBuilder.Entity("LinkShortenerShtokal.Core.Domain.ShortenedUrl", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int>("NumberOfUsages")
                        .HasColumnType("int");

                    b.Property<string>("OriginalUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UrlAlias")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("UrlId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UrlId"), 1L, 1);

                    b.HasKey("Id");

                    b.HasAlternateKey("UrlId");

                    b.HasIndex("UrlAlias")
                        .IsUnique()
                        .HasFilter("[UrlAlias] IS NOT NULL");

                    b.ToTable("Urls");
                });

            modelBuilder.Entity("LinkShortenerShtokal.Core.Domain.RedirectRequest", b =>
                {
                    b.HasOne("LinkShortenerShtokal.Core.Domain.ShortenedUrl", "ShortenedUrl")
                        .WithMany()
                        .HasForeignKey("ShortenedUrlId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ShortenedUrl");
                });
#pragma warning restore 612, 618
        }
    }
}
