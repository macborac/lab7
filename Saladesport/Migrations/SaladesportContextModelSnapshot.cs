﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Saladesport.Models;

#nullable disable

namespace Saladesport.Migrations
{
    [DbContext(typeof(SaladesportContext))]
    partial class SaladesportContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Saladesport.Models.Abonament", b =>
                {
                    b.Property<int>("AbonamentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AbonamentId"));

                    b.Property<int>("Durata")
                        .HasColumnType("int");

                    b.Property<int>("EquipmentID")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.HasKey("AbonamentId");

                    b.HasIndex("EquipmentID");

                    b.ToTable("Abonament", (string)null);
                });

            modelBuilder.Entity("Saladesport.Models.Equipment", b =>
                {
                    b.Property<int>("EquipmentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EquipmentId"));

                    b.Property<string>("ExerciseName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Number")
                        .HasColumnType("int");

                    b.Property<int>("Vizitator")
                        .HasColumnType("int");

                    b.Property<int?>("VizitatorsVisitatorId")
                        .HasColumnType("int");

                    b.HasKey("EquipmentId");

                    b.HasIndex("VizitatorsVisitatorId");

                    b.ToTable("Equipment", (string)null);
                });

            modelBuilder.Entity("Saladesport.Models.Filiale", b =>
                {
                    b.Property<int>("FilialeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FilialeId"));

                    b.Property<string>("Locatia")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("FilialeId");

                    b.ToTable("Filiale", (string)null);
                });

            modelBuilder.Entity("Saladesport.Models.Snacks", b =>
                {
                    b.Property<int>("SnacksId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SnacksId"));

                    b.Property<int>("Durata")
                        .HasColumnType("int");

                    b.Property<int>("FilialeID")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SnacksPrice")
                        .HasColumnType("int");

                    b.HasKey("SnacksId");

                    b.HasIndex("FilialeID");

                    b.ToTable("Snacks", (string)null);
                });

            modelBuilder.Entity("Saladesport.Models.Visitator", b =>
                {
                    b.Property<int>("VisitatorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("VisitatorId"));

                    b.Property<int>("AbonamentID")
                        .HasColumnType("int");

                    b.Property<string>("AbonamentName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("BirthDay")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("GettingDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Mail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SecondName")
                        .HasColumnType("int");

                    b.Property<int?>("VisitatorId1")
                        .HasColumnType("int");

                    b.HasKey("VisitatorId");

                    b.HasIndex("AbonamentID");

                    b.HasIndex("VisitatorId1");

                    b.ToTable("Visitator", (string)null);
                });

            modelBuilder.Entity("Saladesport.Models.Abonament", b =>
                {
                    b.HasOne("Saladesport.Models.Equipment", "Equipment")
                        .WithMany("Abonament")
                        .HasForeignKey("EquipmentID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Equipment");
                });

            modelBuilder.Entity("Saladesport.Models.Equipment", b =>
                {
                    b.HasOne("Saladesport.Models.Visitator", "Vizitators")
                        .WithMany()
                        .HasForeignKey("VizitatorsVisitatorId");

                    b.Navigation("Vizitators");
                });

            modelBuilder.Entity("Saladesport.Models.Snacks", b =>
                {
                    b.HasOne("Saladesport.Models.Filiale", "Filiales")
                        .WithMany("Snackses")
                        .HasForeignKey("FilialeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Filiales");
                });

            modelBuilder.Entity("Saladesport.Models.Visitator", b =>
                {
                    b.HasOne("Saladesport.Models.Abonament", "Abonament")
                        .WithMany("Vizitators")
                        .HasForeignKey("AbonamentID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Saladesport.Models.Visitator", null)
                        .WithMany("Visitators")
                        .HasForeignKey("VisitatorId1");

                    b.Navigation("Abonament");
                });

            modelBuilder.Entity("Saladesport.Models.Abonament", b =>
                {
                    b.Navigation("Vizitators");
                });

            modelBuilder.Entity("Saladesport.Models.Equipment", b =>
                {
                    b.Navigation("Abonament");
                });

            modelBuilder.Entity("Saladesport.Models.Filiale", b =>
                {
                    b.Navigation("Snackses");
                });

            modelBuilder.Entity("Saladesport.Models.Visitator", b =>
                {
                    b.Navigation("Visitators");
                });
#pragma warning restore 612, 618
        }
    }
}
