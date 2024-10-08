﻿// <auto-generated />
using System;
using DnDBeyondAPI;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Data.Migrations
{
    [DbContext(typeof(DnDContext))]
    [Migration("20240929095945_Initial Migration")]
    partial class InitialMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.17")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CharacterItem", b =>
                {
                    b.Property<Guid>("CharactersId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ItemsId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("CharactersId", "ItemsId");

                    b.HasIndex("ItemsId");

                    b.ToTable("CharacterItem");
                });

            modelBuilder.Entity("Data.Entities.Defense", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CharacterId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Defenses")
                        .HasColumnType("int");

                    b.Property<int>("TypeOfDamage")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CharacterId");

                    b.ToTable("Defense", (string)null);
                });

            modelBuilder.Entity("Data.Model.Entities.Class", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CharacterId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("HitDice")
                        .HasColumnType("int");

                    b.Property<int>("Level")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("Id");

                    b.HasIndex("CharacterId");

                    b.ToTable("Class", (string)null);
                });

            modelBuilder.Entity("Data.Model.Entities.Item", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ModifierId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("Id");

                    b.HasIndex("ModifierId");

                    b.ToTable("Item", (string)null);
                });

            modelBuilder.Entity("Data.Model.Entities.Modifier", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AffectedObject")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AffectedValue")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<short>("Value")
                        .HasMaxLength(2)
                        .HasColumnType("smallint");

                    b.HasKey("Id");

                    b.ToTable("Modifier");
                });

            modelBuilder.Entity("Data.Model.Entities.Stats", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<byte>("Charisma")
                        .HasMaxLength(2)
                        .HasColumnType("tinyint");

                    b.Property<byte>("Constitution")
                        .HasMaxLength(2)
                        .HasColumnType("tinyint");

                    b.Property<byte>("Dexterity")
                        .HasMaxLength(2)
                        .HasColumnType("tinyint");

                    b.Property<byte>("Intelligence")
                        .HasMaxLength(2)
                        .HasColumnType("tinyint");

                    b.Property<byte>("Strenght")
                        .HasMaxLength(2)
                        .HasColumnType("tinyint");

                    b.Property<byte>("Wisdom")
                        .HasMaxLength(2)
                        .HasColumnType("tinyint");

                    b.HasKey("Id");

                    b.ToTable("Stats", (string)null);
                });

            modelBuilder.Entity("DnDBeyondAPI.Models.Character", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("ActualHitPoints")
                        .HasColumnType("int");

                    b.Property<int>("Level")
                        .HasColumnType("int");

                    b.Property<int>("MaxHitPoints")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<Guid>("StatsId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("TemporaryHitPoints")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("StatsId");

                    b.ToTable("Character", (string)null);
                });

            modelBuilder.Entity("CharacterItem", b =>
                {
                    b.HasOne("DnDBeyondAPI.Models.Character", null)
                        .WithMany()
                        .HasForeignKey("CharactersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Data.Model.Entities.Item", null)
                        .WithMany()
                        .HasForeignKey("ItemsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Data.Entities.Defense", b =>
                {
                    b.HasOne("DnDBeyondAPI.Models.Character", null)
                        .WithMany("Defenses")
                        .HasForeignKey("CharacterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Data.Model.Entities.Class", b =>
                {
                    b.HasOne("DnDBeyondAPI.Models.Character", null)
                        .WithMany("Classes")
                        .HasForeignKey("CharacterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Data.Model.Entities.Item", b =>
                {
                    b.HasOne("Data.Model.Entities.Modifier", "Modifier")
                        .WithMany()
                        .HasForeignKey("ModifierId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Modifier");
                });

            modelBuilder.Entity("DnDBeyondAPI.Models.Character", b =>
                {
                    b.HasOne("Data.Model.Entities.Stats", "Stats")
                        .WithMany()
                        .HasForeignKey("StatsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Stats");
                });

            modelBuilder.Entity("DnDBeyondAPI.Models.Character", b =>
                {
                    b.Navigation("Classes");

                    b.Navigation("Defenses");
                });
#pragma warning restore 612, 618
        }
    }
}
