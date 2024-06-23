﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RentifyMVC.Data;

#nullable disable

namespace RentifyMVC.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240623214334_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("AgentUser", b =>
                {
                    b.Property<int>("AgentsagentID")
                        .HasColumnType("int");

                    b.Property<int>("UsersuserID")
                        .HasColumnType("int");

                    b.HasKey("AgentsagentID", "UsersuserID");

                    b.HasIndex("UsersuserID");

                    b.ToTable("AgentUser");
                });

            modelBuilder.Entity("Rentify.Models.Domains.Agent", b =>
                {
                    b.Property<int>("agentID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("agentID"));

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("firstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("lastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("officeAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("phoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("agentID");

                    b.ToTable("Agents");
                });

            modelBuilder.Entity("Rentify.Models.Domains.Property", b =>
                {
                    b.Property<int>("propertyID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("propertyID"));

                    b.Property<string>("address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("agentID")
                        .HasColumnType("int");

                    b.Property<string>("city")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("dateAvailable")
                        .HasColumnType("datetime2");

                    b.Property<string>("description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("numberOfBathrooms")
                        .HasColumnType("int");

                    b.Property<int>("numberOfRooms")
                        .HasColumnType("int");

                    b.Property<decimal>("price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<bool>("ssAvailable")
                        .HasColumnType("bit");

                    b.Property<string>("state")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("userID")
                        .HasColumnType("int");

                    b.Property<string>("zipCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("propertyID");

                    b.HasIndex("agentID");

                    b.HasIndex("userID");

                    b.ToTable("Properties");
                });

            modelBuilder.Entity("Rentify.Models.Domains.RentalApplication", b =>
                {
                    b.Property<int>("applicationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("applicationId"));

                    b.Property<DateTime>("applicationDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("moveInDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("notes")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("propertyID")
                        .HasColumnType("int");

                    b.Property<string>("status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("userID")
                        .HasColumnType("int");

                    b.HasKey("applicationId");

                    b.HasIndex("propertyID");

                    b.HasIndex("userID");

                    b.ToTable("RentalApplications");
                });

            modelBuilder.Entity("Rentify.Models.Domains.Review", b =>
                {
                    b.Property<int>("reviewID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("reviewID"));

                    b.Property<string>("comment")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("datePosted")
                        .HasColumnType("datetime2");

                    b.Property<int>("propertyID")
                        .HasColumnType("int");

                    b.Property<int>("rating")
                        .HasColumnType("int");

                    b.Property<int>("userID")
                        .HasColumnType("int");

                    b.HasKey("reviewID");

                    b.HasIndex("propertyID");

                    b.HasIndex("userID");

                    b.ToTable("Reviews");
                });

            modelBuilder.Entity("Rentify.Models.Domains.User", b =>
                {
                    b.Property<int>("userID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("userID"));

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte>("password")
                        .HasColumnType("tinyint");

                    b.Property<string>("phoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("userName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("userID");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("AgentUser", b =>
                {
                    b.HasOne("Rentify.Models.Domains.Agent", null)
                        .WithMany()
                        .HasForeignKey("AgentsagentID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Rentify.Models.Domains.User", null)
                        .WithMany()
                        .HasForeignKey("UsersuserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Rentify.Models.Domains.Property", b =>
                {
                    b.HasOne("Rentify.Models.Domains.Agent", "agent")
                        .WithMany("Properties")
                        .HasForeignKey("agentID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Rentify.Models.Domains.User", "user")
                        .WithMany("Properties")
                        .HasForeignKey("userID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("agent");

                    b.Navigation("user");
                });

            modelBuilder.Entity("Rentify.Models.Domains.RentalApplication", b =>
                {
                    b.HasOne("Rentify.Models.Domains.Property", "property")
                        .WithMany("RentalApplications")
                        .HasForeignKey("propertyID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Rentify.Models.Domains.User", "User")
                        .WithMany()
                        .HasForeignKey("userID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");

                    b.Navigation("property");
                });

            modelBuilder.Entity("Rentify.Models.Domains.Review", b =>
                {
                    b.HasOne("Rentify.Models.Domains.Property", "property")
                        .WithMany("Review")
                        .HasForeignKey("propertyID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Rentify.Models.Domains.User", "user")
                        .WithMany()
                        .HasForeignKey("userID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("property");

                    b.Navigation("user");
                });

            modelBuilder.Entity("Rentify.Models.Domains.Agent", b =>
                {
                    b.Navigation("Properties");
                });

            modelBuilder.Entity("Rentify.Models.Domains.Property", b =>
                {
                    b.Navigation("RentalApplications");

                    b.Navigation("Review");
                });

            modelBuilder.Entity("Rentify.Models.Domains.User", b =>
                {
                    b.Navigation("Properties");
                });
#pragma warning restore 612, 618
        }
    }
}
