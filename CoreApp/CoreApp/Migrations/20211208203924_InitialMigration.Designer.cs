﻿// <auto-generated />
using System;
using CoreApp.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace CoreApp.Migrations
{
    [DbContext(typeof(CoreAppDbContext))]
    [Migration("20211208203924_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("CoreApp.Data.Models.Project", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<int>("SectionId")
                        .HasColumnType("integer");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.HasKey("Id");

                    b.HasIndex("SectionId")
                        .IsUnique();

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("CoreApp.Data.Models.ProjectParticipant", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("ProjectId")
                        .HasColumnType("integer");

                    b.Property<int>("StudentId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("ProjectId");

                    b.HasIndex("StudentId");

                    b.ToTable("ProjectParticipants");
                });

            modelBuilder.Entity("CoreApp.Data.Models.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<int?>("StudentId")
                        .HasColumnType("integer");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.HasKey("Id");

                    b.HasIndex("StudentId");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("CoreApp.Data.Models.Section", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.HasKey("Id");

                    b.ToTable("Sections");
                });

            modelBuilder.Entity("CoreApp.Data.Models.Student", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("DiscordName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.Property<string>("Indeks")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.Property<int>("RoleId")
                        .HasColumnType("integer");

                    b.Property<string>("StudiesTag")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("YearOfStudies")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("CoreApp.Data.Models.Project", b =>
                {
                    b.HasOne("CoreApp.Data.Models.Section", "Section")
                        .WithOne("Project")
                        .HasForeignKey("CoreApp.Data.Models.Project", "SectionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Section");
                });

            modelBuilder.Entity("CoreApp.Data.Models.ProjectParticipant", b =>
                {
                    b.HasOne("CoreApp.Data.Models.Project", "Project")
                        .WithMany("ProjectParticipant")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CoreApp.Data.Models.Student", "Student")
                        .WithMany("ProjectParticipant")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Project");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("CoreApp.Data.Models.Role", b =>
                {
                    b.HasOne("CoreApp.Data.Models.Student", null)
                        .WithMany("Role")
                        .HasForeignKey("StudentId");
                });

            modelBuilder.Entity("CoreApp.Data.Models.Project", b =>
                {
                    b.Navigation("ProjectParticipant");
                });

            modelBuilder.Entity("CoreApp.Data.Models.Section", b =>
                {
                    b.Navigation("Project");
                });

            modelBuilder.Entity("CoreApp.Data.Models.Student", b =>
                {
                    b.Navigation("ProjectParticipant");

                    b.Navigation("Role");
                });
#pragma warning restore 612, 618
        }
    }
}
