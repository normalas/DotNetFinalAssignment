﻿// <auto-generated />
using DotNet.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DotNet.DataAccess.Migrations
{
    [DbContext(typeof(DotNetContext))]
    [Migration("20200528080059_HugeModelChangeMaybeRemove")]
    partial class HugeModelChangeMaybeRemove
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DotNet.Models.VideoGame", b =>
                {
                    b.Property<int>("GameId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CharacterName");

                    b.Property<string>("DeveloperName");

                    b.Property<string>("GameSubtitle");

                    b.Property<string>("GameTitle");

                    b.Property<string>("PublisherName");

                    b.HasKey("GameId");

                    b.ToTable("VideoGames");
                });
#pragma warning restore 612, 618
        }
    }
}
