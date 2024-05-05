﻿// <auto-generated />
using System;
using App_Avval.Models.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace App_Avval.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20231106064808_addtablelink_fieldType")]
    partial class addtablelink_fieldType
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("App_Avval.Models.RubikaLink", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ChannelId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Link")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Type")
                        .HasColumnType("int");

                    b.Property<DateTime?>("VisitedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("RubikaLinks");
                });

            modelBuilder.Entity("App_Avval.Models.RubikaModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ChannelId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Date")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description_Links")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MemberCount")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("VisitedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("RubikaModels");
                });

            modelBuilder.Entity("App_Avval.Models.RubikaPost", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ChannelId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Date")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HTML")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MessageId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("RubikaModelId")
                        .HasColumnType("int");

                    b.Property<int>("ViewCount")
                        .HasColumnType("int");

                    b.Property<DateTime?>("VisitedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("RubikaModelId");

                    b.ToTable("RubikaPosts");
                });

            modelBuilder.Entity("App_Avval.Models.RubikaPost", b =>
                {
                    b.HasOne("App_Avval.Models.RubikaModel", null)
                        .WithMany("posts")
                        .HasForeignKey("RubikaModelId");
                });

            modelBuilder.Entity("App_Avval.Models.RubikaModel", b =>
                {
                    b.Navigation("posts");
                });
#pragma warning restore 612, 618
        }
    }
}