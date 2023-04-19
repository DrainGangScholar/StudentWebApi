﻿// <auto-generated />
using System;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infrastructure.Data.Migrations
{
    [DbContext(typeof(SWAContext))]
    [Migration("20230418182019_TEST")]
    partial class TEST
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.5");

            modelBuilder.Entity("Core.Entities.Kurs", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Ime")
                        .HasColumnType("TEXT");

                    b.Property<string>("Opis")
                        .HasColumnType("TEXT");

                    b.Property<string>("Sifra")
                        .HasColumnType("TEXT");

                    b.HasKey("ID");

                    b.ToTable("Kursevi");
                });

            modelBuilder.Entity("Core.Entities.Student", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Adresa")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DatumRodjenja")
                        .HasColumnType("TEXT");

                    b.Property<string>("Drzava")
                        .HasColumnType("TEXT");

                    b.Property<string>("Grad")
                        .HasColumnType("TEXT");

                    b.Property<string>("Ime")
                        .HasColumnType("TEXT");

                    b.Property<bool>("Pol")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Prezime")
                        .HasColumnType("TEXT");

                    b.HasKey("ID");

                    b.ToTable("Studenti");
                });

            modelBuilder.Entity("Core.Entities.StudentKurs", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("KursID")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Ocena")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("StudentID")
                        .HasColumnType("INTEGER");

                    b.HasKey("ID");

                    b.HasIndex("KursID");

                    b.HasIndex("StudentID");

                    b.ToTable("PohadjaniKursevi");
                });

            modelBuilder.Entity("Core.Entities.StudentKurs", b =>
                {
                    b.HasOne("Core.Entities.Kurs", "Kurs")
                        .WithMany("PohadjaniKursevi")
                        .HasForeignKey("KursID");

                    b.HasOne("Core.Entities.Student", "Student")
                        .WithMany("PohadjaniKursevi")
                        .HasForeignKey("StudentID");

                    b.Navigation("Kurs");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("Core.Entities.Kurs", b =>
                {
                    b.Navigation("PohadjaniKursevi");
                });

            modelBuilder.Entity("Core.Entities.Student", b =>
                {
                    b.Navigation("PohadjaniKursevi");
                });
#pragma warning restore 612, 618
        }
    }
}
