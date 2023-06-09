﻿// <auto-generated />
using System;
using DAL.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace JTO_DAL.Migrations
{
    [DbContext(typeof(JTOContext))]
    [Migration("20230609114735_IsActiveAttribute")]
    partial class IsActiveAttribute
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("JTO_MODELS.AgeCategory", b =>
                {
                    b.Property<int>("AgeCategoryID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AgeCategoryID"), 1L, 1);

                    b.Property<bool?>("IsActive")
                        .HasColumnType("bit");

                    b.Property<int?>("MaxAge")
                        .HasColumnType("int");

                    b.Property<int?>("MinAge")
                        .HasColumnType("int");

                    b.HasKey("AgeCategoryID");

                    b.ToTable("AgeCategories");
                });

            modelBuilder.Entity("JTO_MODELS.Destination", b =>
                {
                    b.Property<int>("DestinationID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DestinationID"), 1L, 1);

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Zip")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DestinationID");

                    b.ToTable("Destinations");
                });

            modelBuilder.Entity("JTO_MODELS.GroupTour", b =>
                {
                    b.Property<int>("GroupTourID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("GroupTourID"), 1L, 1);

                    b.Property<int?>("AgeCategoryID")
                        .HasColumnType("int");

                    b.Property<decimal>("Budget")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("DestinationID")
                        .HasColumnType("int");

                    b.Property<DateTime>("Enddate")
                        .HasColumnType("datetime2");

                    b.Property<int>("MaxParticipants")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("ResponsibleID")
                        .HasColumnType("int");

                    b.Property<DateTime>("Startdate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("ThemeID")
                        .HasColumnType("int");

                    b.HasKey("GroupTourID");

                    b.HasIndex("AgeCategoryID");

                    b.HasIndex("DestinationID");

                    b.HasIndex("ResponsibleID");

                    b.HasIndex("ThemeID");

                    b.ToTable("GroupTours");
                });

            modelBuilder.Entity("JTO_MODELS.Participant", b =>
                {
                    b.Property<int>("ParticipantID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ParticipantID"), 1L, 1);

                    b.Property<int>("GroupTourID")
                        .HasColumnType("int");

                    b.Property<int>("PersonID")
                        .HasColumnType("int");

                    b.Property<int>("RoleID")
                        .HasColumnType("int");

                    b.HasKey("ParticipantID");

                    b.HasIndex("GroupTourID");

                    b.HasIndex("PersonID");

                    b.HasIndex("RoleID");

                    b.ToTable("Participants");
                });

            modelBuilder.Entity("JTO_MODELS.Person", b =>
                {
                    b.Property<int>("PersonID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PersonID"), 1L, 1);

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("CourseResponsible")
                        .HasColumnType("bit");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("GroupTourResponsible")
                        .HasColumnType("bit");

                    b.Property<bool>("MemberHealthInsurance")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Sex")
                        .HasColumnType("bit");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Zip")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("medicalSheet")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PersonID");

                    b.ToTable("Persons");
                });

            modelBuilder.Entity("JTO_MODELS.Role", b =>
                {
                    b.Property<int>("RoleID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RoleID"), 1L, 1);

                    b.Property<bool?>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RoleID");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("JTO_MODELS.Theme", b =>
                {
                    b.Property<int>("ThemeID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ThemeID"), 1L, 1);

                    b.Property<bool?>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ThemeID");

                    b.ToTable("Themes");
                });

            modelBuilder.Entity("JTO_Models.Trainee", b =>
                {
                    b.Property<int>("TraineeID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TraineeID"), 1L, 1);

                    b.Property<bool>("FinishedTraining")
                        .HasColumnType("bit");

                    b.Property<int>("PersonID")
                        .HasColumnType("int");

                    b.Property<int>("RoleID")
                        .HasColumnType("int");

                    b.Property<int>("TrainingID")
                        .HasColumnType("int");

                    b.HasKey("TraineeID");

                    b.HasIndex("PersonID");

                    b.HasIndex("RoleID");

                    b.HasIndex("TrainingID");

                    b.ToTable("Trainees");
                });

            modelBuilder.Entity("JTO_MODELS.Training", b =>
                {
                    b.Property<int>("TrainingID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TrainingID"), 1L, 1);

                    b.Property<DateTime?>("Date")
                        .IsRequired()
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TrainingID");

                    b.ToTable("Trainings");
                });

            modelBuilder.Entity("JTO_Models.User", b =>
                {
                    b.Property<int>("UserID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserID"), 1L, 1);

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserID");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("JTO_MODELS.GroupTour", b =>
                {
                    b.HasOne("JTO_MODELS.AgeCategory", "AgeCategory")
                        .WithMany("GroupTours")
                        .HasForeignKey("AgeCategoryID");

                    b.HasOne("JTO_MODELS.Destination", "Destination")
                        .WithMany("GroupTours")
                        .HasForeignKey("DestinationID");

                    b.HasOne("JTO_MODELS.Person", "Responsible")
                        .WithMany()
                        .HasForeignKey("ResponsibleID");

                    b.HasOne("JTO_MODELS.Theme", "Theme")
                        .WithMany("GroupTours")
                        .HasForeignKey("ThemeID");

                    b.Navigation("AgeCategory");

                    b.Navigation("Destination");

                    b.Navigation("Responsible");

                    b.Navigation("Theme");
                });

            modelBuilder.Entity("JTO_MODELS.Participant", b =>
                {
                    b.HasOne("JTO_MODELS.GroupTour", "GroupTour")
                        .WithMany("Participants")
                        .HasForeignKey("GroupTourID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("JTO_MODELS.Person", "Person")
                        .WithMany("Participants")
                        .HasForeignKey("PersonID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("JTO_MODELS.Role", "Role")
                        .WithMany("Participants")
                        .HasForeignKey("RoleID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("GroupTour");

                    b.Navigation("Person");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("JTO_Models.Trainee", b =>
                {
                    b.HasOne("JTO_MODELS.Person", "Person")
                        .WithMany("Trainees")
                        .HasForeignKey("PersonID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("JTO_MODELS.Role", "Role")
                        .WithMany("Trainees")
                        .HasForeignKey("RoleID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("JTO_MODELS.Training", "Training")
                        .WithMany("Trainees")
                        .HasForeignKey("TrainingID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Person");

                    b.Navigation("Role");

                    b.Navigation("Training");
                });

            modelBuilder.Entity("JTO_MODELS.AgeCategory", b =>
                {
                    b.Navigation("GroupTours");
                });

            modelBuilder.Entity("JTO_MODELS.Destination", b =>
                {
                    b.Navigation("GroupTours");
                });

            modelBuilder.Entity("JTO_MODELS.GroupTour", b =>
                {
                    b.Navigation("Participants");
                });

            modelBuilder.Entity("JTO_MODELS.Person", b =>
                {
                    b.Navigation("Participants");

                    b.Navigation("Trainees");
                });

            modelBuilder.Entity("JTO_MODELS.Role", b =>
                {
                    b.Navigation("Participants");

                    b.Navigation("Trainees");
                });

            modelBuilder.Entity("JTO_MODELS.Theme", b =>
                {
                    b.Navigation("GroupTours");
                });

            modelBuilder.Entity("JTO_MODELS.Training", b =>
                {
                    b.Navigation("Trainees");
                });
#pragma warning restore 612, 618
        }
    }
}
