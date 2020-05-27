﻿// <auto-generated />
using System;
using DotNet.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DotNet.DataAccess.Migrations
{
    [DbContext(typeof(DotNetContext))]
    partial class DotNetContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DotNet.Models.Character", b =>
                {
                    b.Property<int>("CharacterId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CharacterName");

                    b.Property<int?>("GameId");

                    b.HasKey("CharacterId");

                    b.HasIndex("GameId");

                    b.ToTable("Characters");
                });

            modelBuilder.Entity("DotNet.Models.Developer", b =>
                {
                    b.Property<int>("DeveloperId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DeveloperName");

                    b.HasKey("DeveloperId");

                    b.ToTable("Developers");
                });

            modelBuilder.Entity("DotNet.Models.Game", b =>
                {
                    b.Property<int>("GameId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("GameSeries");

                    b.Property<string>("GameSubtitle");

                    b.Property<string>("GameTitle");

                    b.Property<float>("HoursToComplete");

                    b.HasKey("GameId");

                    b.ToTable("Games");
                });

            modelBuilder.Entity("DotNet.Models.Publisher", b =>
                {
                    b.Property<int>("PublisherId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("PublisherName");

                    b.HasKey("PublisherId");

                    b.ToTable("Publishers");
                });

            modelBuilder.Entity("DotNet.Models.VideoGame", b =>
                {
                    b.Property<int>("GameId");

                    b.Property<int>("PublisherId");

                    b.Property<int>("DeveloperId");

                    b.Property<int>("CharacterId");

                    b.HasKey("GameId", "PublisherId", "DeveloperId", "CharacterId");

                    b.HasAlternateKey("CharacterId", "DeveloperId", "GameId", "PublisherId");

                    b.HasIndex("DeveloperId");

                    b.HasIndex("PublisherId");

                    b.ToTable("VideoGames");
                });

            modelBuilder.Entity("DotNet.Models.Character", b =>
                {
                    b.HasOne("DotNet.Models.Game")
                        .WithMany("CharacterCast")
                        .HasForeignKey("GameId");
                });

            modelBuilder.Entity("DotNet.Models.VideoGame", b =>
                {
                    b.HasOne("DotNet.Models.Character", "Character")
                        .WithMany()
                        .HasForeignKey("CharacterId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("DotNet.Models.Developer", "Developer")
                        .WithMany("DevelopedGames")
                        .HasForeignKey("DeveloperId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("DotNet.Models.Game", "Game")
                        .WithMany()
                        .HasForeignKey("GameId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("DotNet.Models.Publisher", "Publisher")
                        .WithMany("PublishedGames")
                        .HasForeignKey("PublisherId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
