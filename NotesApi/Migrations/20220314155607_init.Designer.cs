﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NotesApi.Contexts;

#nullable disable

namespace NotesApi.Migrations
{
    [DbContext(typeof(NotesDbContext))]
    [Migration("20220314155607_init")]
    partial class init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("NotesApi.Models.Database.Note", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ApprovedById")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CreatedById")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsApproved")
                        .HasColumnType("bit");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ApprovedById");

                    b.HasIndex("CreatedById");

                    b.ToTable("Notes");
                });

            modelBuilder.Entity("NotesApi.Models.Database.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasDiscriminator<int>("Role").IsComplete(false);
                });

            modelBuilder.Entity("NotesApi.Models.Database.Admin", b =>
                {
                    b.HasBaseType("NotesApi.Models.Database.User");

                    b.HasDiscriminator().HasValue(0);
                });

            modelBuilder.Entity("NotesApi.Models.Database.StandardUser", b =>
                {
                    b.HasBaseType("NotesApi.Models.Database.User");

                    b.Property<string>("SupervisorId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasIndex("SupervisorId");

                    b.HasDiscriminator().HasValue(2);
                });

            modelBuilder.Entity("NotesApi.Models.Database.SuperUser", b =>
                {
                    b.HasBaseType("NotesApi.Models.Database.User");

                    b.HasDiscriminator().HasValue(1);
                });

            modelBuilder.Entity("NotesApi.Models.Database.Note", b =>
                {
                    b.HasOne("NotesApi.Models.Database.SuperUser", "ApprovedBy")
                        .WithMany("ApprovedNotes")
                        .HasForeignKey("ApprovedById")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("NotesApi.Models.Database.User", "CreatedBy")
                        .WithMany("Notes")
                        .HasForeignKey("CreatedById")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("ApprovedBy");

                    b.Navigation("CreatedBy");
                });

            modelBuilder.Entity("NotesApi.Models.Database.StandardUser", b =>
                {
                    b.HasOne("NotesApi.Models.Database.SuperUser", "Supervisor")
                        .WithMany("Employees")
                        .HasForeignKey("SupervisorId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Supervisor");
                });

            modelBuilder.Entity("NotesApi.Models.Database.User", b =>
                {
                    b.Navigation("Notes");
                });

            modelBuilder.Entity("NotesApi.Models.Database.SuperUser", b =>
                {
                    b.Navigation("ApprovedNotes");

                    b.Navigation("Employees");
                });
#pragma warning restore 612, 618
        }
    }
}
