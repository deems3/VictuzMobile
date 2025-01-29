﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using VictuzMobile.DatabaseConfig;

#nullable disable

namespace VictuzMobile.DatabaseConfig.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20250129151024_AddRegistrationDate")]
    partial class AddRegistrationDate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "9.0.1");

            modelBuilder.Entity("DatabaseConfig.Models.Suggestion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CategoryId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("ImageURL")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("LocationId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("MaxRegistrations")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("OrganiserId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("LocationId");

                    b.HasIndex("OrganiserId");

                    b.ToTable("Suggestions");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryId = 3,
                            Description = "Leer hoe jij je eigen netwerk kunt beveiligen",
                            EndDate = new DateTime(2026, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ImageURL = "cybersecurity.jpg",
                            LocationId = 1,
                            MaxRegistrations = 10,
                            Name = "Cybersecurity",
                            OrganiserId = 2,
                            StartDate = new DateTime(2026, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 2,
                            CategoryId = 4,
                            Description = "Programmeer je eigen robot",
                            EndDate = new DateTime(2026, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ImageURL = "robot_suggestion.jpg",
                            LocationId = 1,
                            MaxRegistrations = 6,
                            Name = "Robots programmeren",
                            OrganiserId = 1,
                            StartDate = new DateTime(2026, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("SuggestionUser", b =>
                {
                    b.Property<int>("LikedByUsersId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("LikedSuggestionsId")
                        .HasColumnType("INTEGER");

                    b.HasKey("LikedByUsersId", "LikedSuggestionsId");

                    b.HasIndex("LikedSuggestionsId");

                    b.ToTable("SuggestionLikes", (string)null);
                });

            modelBuilder.Entity("VictuzMobile.DatabaseConfig.Models.Activity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CategoryId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("ImageURL")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("LocationId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("MaxRegistrations")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("OrganiserId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("LocationId");

                    b.HasIndex("OrganiserId");

                    b.ToTable("Activities");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryId = 1,
                            Description = "Kom voetballen",
                            EndDate = new DateTime(2026, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ImageURL = "https://cdn.pixabay.com/photo/2014/10/14/20/24/ball-488718_640.jpg",
                            LocationId = 1,
                            MaxRegistrations = 22,
                            Name = "Voetbal Toernooi",
                            OrganiserId = 2,
                            StartDate = new DateTime(2026, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 2,
                            CategoryId = 2,
                            Description = "Leer hoe jij je eigen AI kunt maken",
                            EndDate = new DateTime(2026, 4, 3, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ImageURL = "https://img.freepik.com/free-photo/ai-human-technology-background_1409-5588.jpg",
                            LocationId = 1,
                            MaxRegistrations = 6,
                            Name = "Omgaan met AI",
                            OrganiserId = 1,
                            StartDate = new DateTime(2026, 4, 3, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 3,
                            CategoryId = 3,
                            Description = "Klei je eigen technische tool",
                            EndDate = new DateTime(2026, 5, 3, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ImageURL = "https://cdn.pixabay.com/photo/2016/03/27/17/10/pottery-1283146_1280.jpg",
                            LocationId = 1,
                            MaxRegistrations = 10,
                            Name = "Kleien",
                            OrganiserId = 3,
                            StartDate = new DateTime(2026, 5, 3, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("VictuzMobile.DatabaseConfig.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Sport"
                        },
                        new
                        {
                            Id = 2,
                            Name = "AI"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Workshop"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Programmeren"
                        });
                });

            modelBuilder.Entity("VictuzMobile.DatabaseConfig.Models.Location", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("CustomText")
                        .HasColumnType("TEXT");

                    b.Property<string>("Housenumber")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("PostalCode")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Province")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Locations");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            City = "Heerlen",
                            Country = "Nederland",
                            Housenumber = "300",
                            PostalCode = "6419 DJ",
                            Province = "Limburg",
                            Street = "Nieuw Eyckholt"
                        });
                });

            modelBuilder.Entity("VictuzMobile.DatabaseConfig.Models.Registration", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ActivityId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("RegistrationDate")
                        .HasColumnType("TEXT");

                    b.Property<int?>("SuggestionId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("ActivityId");

                    b.HasIndex("SuggestionId");

                    b.HasIndex("UserId");

                    b.ToTable("Registrations");
                });

            modelBuilder.Entity("VictuzMobile.DatabaseConfig.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("DisplayName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<bool>("Limited")
                        .HasColumnType("INTEGER");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Role")
                        .HasColumnType("INTEGER");

                    b.Property<int>("StudentNumber")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DisplayName = "Demi",
                            Email = "demi@example.com",
                            Limited = false,
                            PasswordHash = "$2a$11$C/eNd9h0Ju/wRySYCJCyp.t.qh3pZzD0aEhUyNmc1murYt/G9J3Xq",
                            PhoneNumber = "123456789",
                            Role = 1,
                            StudentNumber = 1234567,
                            Username = "demi"
                        },
                        new
                        {
                            Id = 2,
                            DisplayName = "Mees",
                            Email = "mees@example.com",
                            Limited = false,
                            PasswordHash = "$2a$11$C/eNd9h0Ju/wRySYCJCyp.t.qh3pZzD0aEhUyNmc1murYt/G9J3Xq",
                            PhoneNumber = "123456789",
                            Role = 1,
                            StudentNumber = 2345678,
                            Username = "mees"
                        },
                        new
                        {
                            Id = 3,
                            DisplayName = "Bas",
                            Email = "bas@example.com",
                            Limited = false,
                            PasswordHash = "$2a$11$C/eNd9h0Ju/wRySYCJCyp.t.qh3pZzD0aEhUyNmc1murYt/G9J3Xq",
                            PhoneNumber = "123456789",
                            Role = 1,
                            StudentNumber = 3456789,
                            Username = "bas"
                        },
                        new
                        {
                            Id = 4,
                            DisplayName = "Finn",
                            Email = "finn@example.com",
                            Limited = false,
                            PasswordHash = "$2a$11$C/eNd9h0Ju/wRySYCJCyp.t.qh3pZzD0aEhUyNmc1murYt/G9J3Xq",
                            PhoneNumber = "123456789",
                            Role = 1,
                            StudentNumber = 4567890,
                            Username = "finn"
                        },
                        new
                        {
                            Id = 5,
                            DisplayName = "User",
                            Email = "user@example.com",
                            Limited = false,
                            PasswordHash = "$2a$11$C/eNd9h0Ju/wRySYCJCyp.t.qh3pZzD0aEhUyNmc1murYt/G9J3Xq",
                            PhoneNumber = "123456789",
                            Role = 1,
                            StudentNumber = 8971627,
                            Username = "user"
                        },
                        new
                        {
                            Id = 6,
                            DisplayName = "Admin",
                            Email = "admin@example.com",
                            Limited = false,
                            PasswordHash = "$2a$11$C/eNd9h0Ju/wRySYCJCyp.t.qh3pZzD0aEhUyNmc1murYt/G9J3Xq",
                            PhoneNumber = "123456789",
                            Role = 0,
                            StudentNumber = 7176123,
                            Username = "admin"
                        });
                });

            modelBuilder.Entity("DatabaseConfig.Models.Suggestion", b =>
                {
                    b.HasOne("VictuzMobile.DatabaseConfig.Models.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("VictuzMobile.DatabaseConfig.Models.Location", "Location")
                        .WithMany()
                        .HasForeignKey("LocationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("VictuzMobile.DatabaseConfig.Models.User", "Organiser")
                        .WithMany()
                        .HasForeignKey("OrganiserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Location");

                    b.Navigation("Organiser");
                });

            modelBuilder.Entity("SuggestionUser", b =>
                {
                    b.HasOne("VictuzMobile.DatabaseConfig.Models.User", null)
                        .WithMany()
                        .HasForeignKey("LikedByUsersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DatabaseConfig.Models.Suggestion", null)
                        .WithMany()
                        .HasForeignKey("LikedSuggestionsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("VictuzMobile.DatabaseConfig.Models.Activity", b =>
                {
                    b.HasOne("VictuzMobile.DatabaseConfig.Models.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("VictuzMobile.DatabaseConfig.Models.Location", "Location")
                        .WithMany()
                        .HasForeignKey("LocationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("VictuzMobile.DatabaseConfig.Models.User", "Organiser")
                        .WithMany()
                        .HasForeignKey("OrganiserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Location");

                    b.Navigation("Organiser");
                });

            modelBuilder.Entity("VictuzMobile.DatabaseConfig.Models.Registration", b =>
                {
                    b.HasOne("VictuzMobile.DatabaseConfig.Models.Activity", "Activity")
                        .WithMany("Registration")
                        .HasForeignKey("ActivityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DatabaseConfig.Models.Suggestion", null)
                        .WithMany("Registration")
                        .HasForeignKey("SuggestionId");

                    b.HasOne("VictuzMobile.DatabaseConfig.Models.User", "User")
                        .WithMany("Registrations")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Activity");

                    b.Navigation("User");
                });

            modelBuilder.Entity("DatabaseConfig.Models.Suggestion", b =>
                {
                    b.Navigation("Registration");
                });

            modelBuilder.Entity("VictuzMobile.DatabaseConfig.Models.Activity", b =>
                {
                    b.Navigation("Registration");
                });

            modelBuilder.Entity("VictuzMobile.DatabaseConfig.Models.User", b =>
                {
                    b.Navigation("Registrations");
                });
#pragma warning restore 612, 618
        }
    }
}
