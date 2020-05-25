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

            modelBuilder.Entity("DotNet.Models.Actor", b =>
                {
                    b.Property<int>("ActorId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ActorName");

                    b.HasKey("ActorId");

                    b.ToTable("Actors");
                });

            modelBuilder.Entity("DotNet.Models.Character", b =>
                {
                    b.Property<int>("CharacterId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ActorId");

                    b.Property<string>("CharacterName");

                    b.Property<int?>("GameId");

                    b.HasKey("CharacterId");

                    b.HasIndex("ActorId");

                    b.HasIndex("GameId");

                    b.ToTable("Characters");
                });

            modelBuilder.Entity("DotNet.Models.Developer", b =>
                {
                    b.Property<int>("CompanyId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("DeveloperId");

                    b.HasKey("CompanyId");

                    b.ToTable("Developers");
                });

            modelBuilder.Entity("DotNet.Models.Game", b =>
                {
                    b.Property<int>("GameId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BoxArtImage");

                    b.Property<int?>("DeveloperId");

                    b.Property<float>("EstimatedTtc");

                    b.Property<string>("GameSeries");

                    b.Property<string>("GameSubtitle");

                    b.Property<string>("GameTitle");

                    b.Property<int?>("PublisherId");

                    b.Property<DateTime>("ReleaseDate");

                    b.HasKey("GameId");

                    b.HasIndex("DeveloperId");

                    b.HasIndex("PublisherId");

                    b.ToTable("Games");
                });

            modelBuilder.Entity("DotNet.Models.Publisher", b =>
                {
                    b.Property<int>("CompanyId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("PublisherId");

                    b.HasKey("CompanyId");

                    b.ToTable("Publishers");
                });

            modelBuilder.Entity("DotNet.Models.VideoGame", b =>
                {
                    b.Property<int>("GameId");

                    b.Property<int>("PublisherId");

                    b.Property<int>("DeveloperId");

                    b.Property<int>("CharacterId");

                    b.Property<int>("ActorId");

                    b.HasKey("GameId", "PublisherId", "DeveloperId", "CharacterId", "ActorId");

                    b.HasAlternateKey("ActorId", "CharacterId", "DeveloperId", "GameId", "PublisherId");

                    b.HasIndex("CharacterId");

                    b.HasIndex("DeveloperId");

                    b.HasIndex("PublisherId");

                    b.ToTable("VideoGames");
                });

            modelBuilder.Entity("DotNet.Models.Character", b =>
                {
                    b.HasOne("DotNet.Models.Actor", "Actor")
                        .WithMany("Plays")
                        .HasForeignKey("ActorId");

                    b.HasOne("DotNet.Models.Game")
                        .WithMany("Cast")
                        .HasForeignKey("GameId");
                });

            modelBuilder.Entity("DotNet.Models.Game", b =>
                {
                    b.HasOne("DotNet.Models.Developer", "Developer")
                        .WithMany()
                        .HasForeignKey("DeveloperId");

                    b.HasOne("DotNet.Models.Publisher", "Publisher")
                        .WithMany()
                        .HasForeignKey("PublisherId");
                });

            modelBuilder.Entity("DotNet.Models.VideoGame", b =>
                {
                    b.HasOne("DotNet.Models.Actor", "Actor")
                        .WithMany()
                        .HasForeignKey("ActorId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("DotNet.Models.Character", "Character")
                        .WithMany("Appearances")
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
