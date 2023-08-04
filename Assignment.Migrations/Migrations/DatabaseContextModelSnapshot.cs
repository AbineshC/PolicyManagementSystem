﻿// <auto-generated />
using System;
using Assignment.Migrations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Assignment.Migrations.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    partial class DatabaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.0");

            modelBuilder.Entity("Assignment.Contracts.Data.Entities.App", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("AddedOn")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Developer")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Price")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("App");
                });

            modelBuilder.Entity("Assignment.Contracts.Data.Entities.ApprovalHistory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ApprovalStatus")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("ApprovedBy")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("ApprovedDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Comments")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("EntityID")
                        .HasColumnType("INTEGER");

                    b.Property<string>("EntityType")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsApproval")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("ApprovalHistory");
                });

            modelBuilder.Entity("Assignment.Contracts.Data.Entities.Claim", b =>
                {
                    b.Property<int>("ClaimID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("ApprovalStatus")
                        .HasColumnType("INTEGER");

                    b.Property<float?>("ClaimAmount")
                        .IsRequired()
                        .HasColumnType("REAL");

                    b.Property<DateTime>("ClaimDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("ClaimDescription")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("ClaimReason")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsActive")
                        .HasColumnType("INTEGER");

                    b.Property<int>("PolicyID")
                        .HasColumnType("INTEGER");

                    b.Property<string>("StatusOfClaim")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("ClaimID");

                    b.HasIndex("PolicyID");

                    b.ToTable("Claims");
                });

            modelBuilder.Entity("Assignment.Contracts.Data.Entities.Policy", b =>
                {
                    b.Property<int>("PolicyID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("AssetValue")
                        .HasColumnType("TEXT");

                    b.Property<float?>("Coverage")
                        .HasColumnType("REAL");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Duration")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("HouseAddress")
                        .HasColumnType("TEXT");

                    b.Property<float>("InsuredAmount")
                        .HasColumnType("REAL");

                    b.Property<int>("InsurerHolderAge")
                        .HasColumnType("INTEGER");

                    b.Property<string>("InsurerName")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsDraft")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Model")
                        .HasColumnType("TEXT");

                    b.Property<int>("PolicyTypeId")
                        .HasColumnType("INTEGER");

                    b.Property<float>("Premium")
                        .HasColumnType("REAL");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("TEXT");

                    b.Property<bool>("Status")
                        .HasColumnType("INTEGER");

                    b.Property<string>("StatusOfPolicy")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("TEXT");

                    b.Property<string>("VehicleNumber")
                        .HasColumnType("TEXT");

                    b.HasKey("PolicyID");

                    b.ToTable("PolicyInformation");
                });

            modelBuilder.Entity("Assignment.Contracts.Data.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("AddedOn")
                        .HasColumnType("TEXT");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("User");
                });

            modelBuilder.Entity("Policy_Management_System_API.PolicyType", b =>
                {
                    b.Property<int>("PolicyTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsActive")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Policytype")
                        .HasColumnType("INTEGER");

                    b.HasKey("PolicyTypeId");

                    b.ToTable("PolicyTypeenum");
                });

            modelBuilder.Entity("Assignment.Contracts.Data.Entities.Claim", b =>
                {
                    b.HasOne("Assignment.Contracts.Data.Entities.Policy", "Policy")
                        .WithMany("Claims")
                        .HasForeignKey("PolicyID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Policy");
                });

            modelBuilder.Entity("Assignment.Contracts.Data.Entities.Policy", b =>
                {
                    b.Navigation("Claims");
                });
#pragma warning restore 612, 618
        }
    }
}