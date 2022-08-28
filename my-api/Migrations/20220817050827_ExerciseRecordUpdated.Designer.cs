﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Repository;

#nullable disable

namespace my_api.Migrations
{
    [DbContext(typeof(RepositoryContext))]
    [Migration("20220817050827_ExerciseRecordUpdated")]
    partial class ExerciseRecordUpdated
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Entities.Models.Exercise", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MuscularGroupId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("MuscularGroupId");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Exercises");

                    b.HasData(
                        new
                        {
                            Id = 10,
                            ImageUrl = "",
                            MuscularGroupId = 1,
                            Name = "Arnold Press"
                        });
                });

            modelBuilder.Entity("Entities.Models.MuscularGroup", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("MuscularGroups");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Shoulders"
                        });
                });

            modelBuilder.Entity("Entities.Models.Exercise", b =>
                {
                    b.HasOne("Entities.Models.MuscularGroup", "MuscularGroup")
                        .WithMany("Exercises")
                        .HasForeignKey("MuscularGroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MuscularGroup");
                });

            modelBuilder.Entity("Entities.Models.MuscularGroup", b =>
                {
                    b.Navigation("Exercises");
                });
#pragma warning restore 612, 618
        }
    }
}
