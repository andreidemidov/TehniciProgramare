﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TP_PROJECT_FreeLancePlatform_Api.Helpers;

namespace TP_PROJECT_FreeLancePlatform_Api.Migrations
{
    [DbContext(typeof(FreeLancePlatformContext))]
    partial class UserModelContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TP_PROJECT_FreeLancePlatform_Api.Model.UserModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("EmailAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.Property<int?>("JobId")
                        .HasColumnType("int");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("nvarchar(9)");

                    b.HasKey("Id");

                    b.HasIndex("JobId");

                    b.ToTable("UserModels");
                });

            modelBuilder.Entity("tp_project_freelance_platform_api.Entities.Applicant", b =>
                {
                    b.Property<int>("JobID")
                        .HasColumnType("int");

                    b.Property<int>("UserModelID")
                        .HasColumnType("int");

                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.HasKey("JobID", "UserModelID");

                    b.HasIndex("UserModelID");

                    b.ToTable("Applicant");
                });

            modelBuilder.Entity("tp_project_freelance_platform_api.Entities.Job", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("AddedDate")
                        .HasColumnType("datetime");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Department")
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("EmployeerId")
                        .HasColumnType("int");

                    b.Property<string>("ForeignLanguage")
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Industry")
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Level")
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Occupation")
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("Salary")
                        .HasColumnType("int");

                    b.Property<string>("Study")
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("EmployeerId");

                    b.ToTable("Job");
                });

            modelBuilder.Entity("tp_project_freelance_platform_api.Entities.UserDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("County")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("PersonalDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Position")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("SelectedFile")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SelectedFileName")
                        .IsRequired()
                        .HasColumnType("nvarchar(200)");

                    b.Property<int>("UserModelId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserModelId")
                        .IsUnique();

                    b.ToTable("UserDetail");
                });

            modelBuilder.Entity("TP_PROJECT_FreeLancePlatform_Api.Model.UserModel", b =>
                {
                    b.HasOne("tp_project_freelance_platform_api.Entities.Job", null)
                        .WithMany("Users")
                        .HasForeignKey("JobId");
                });

            modelBuilder.Entity("tp_project_freelance_platform_api.Entities.Applicant", b =>
                {
                    b.HasOne("tp_project_freelance_platform_api.Entities.Job", "Job")
                        .WithMany("Participants")
                        .HasForeignKey("JobID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("TP_PROJECT_FreeLancePlatform_Api.Model.UserModel", "UserModel")
                        .WithMany("Participants")
                        .HasForeignKey("UserModelID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("tp_project_freelance_platform_api.Entities.Job", b =>
                {
                    b.HasOne("TP_PROJECT_FreeLancePlatform_Api.Model.UserModel", "User")
                        .WithMany("Jobs")
                        .HasForeignKey("EmployeerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("tp_project_freelance_platform_api.Entities.UserDetail", b =>
                {
                    b.HasOne("TP_PROJECT_FreeLancePlatform_Api.Model.UserModel", "UserModel")
                        .WithOne("UserDetail")
                        .HasForeignKey("tp_project_freelance_platform_api.Entities.UserDetail", "UserModelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
