﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PatientDbContext;

namespace PatientDbContext.Migrations
{
    [DbContext(typeof(PatientDb))]
    [Migration("20211013093018_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.11")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("PatientEntity.Medication", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("Problemid")
                        .HasColumnType("int");

                    b.Property<string>("description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("freq")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("Problemid");

                    b.ToTable("tblMedication");
                });

            modelBuilder.Entity("PatientEntity.Patient", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("tblPatient");
                });

            modelBuilder.Entity("PatientEntity.Problem", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("Patientid")
                        .HasColumnType("int");

                    b.Property<string>("description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("genetic")
                        .HasColumnType("bit");

                    b.HasKey("id");

                    b.HasIndex("Patientid");

                    b.ToTable("tblProblem");
                });

            modelBuilder.Entity("PatientEntity.Medication", b =>
                {
                    b.HasOne("PatientEntity.Problem", null)
                        .WithMany("medications")
                        .HasForeignKey("Problemid");
                });

            modelBuilder.Entity("PatientEntity.Problem", b =>
                {
                    b.HasOne("PatientEntity.Patient", null)
                        .WithMany("problems")
                        .HasForeignKey("Patientid");
                });

            modelBuilder.Entity("PatientEntity.Patient", b =>
                {
                    b.Navigation("problems");
                });

            modelBuilder.Entity("PatientEntity.Problem", b =>
                {
                    b.Navigation("medications");
                });
#pragma warning restore 612, 618
        }
    }
}
