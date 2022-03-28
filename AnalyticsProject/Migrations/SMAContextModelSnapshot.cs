﻿// <auto-generated />
using System;
using AnalyticsProject.DataModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AnalyticsProject.Migrations
{
    [DbContext(typeof(SMAContext))]
    partial class SMAContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.10")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AnalyticsProject.DataModels.Event", b =>
                {
                    b.Property<Guid>("EventId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset>("DateFrom")
                        .HasColumnType("datetimeoffset");

                    b.Property<DateTimeOffset>("DateTo")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Hashtag")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EventId");

                    b.ToTable("Events");
                });

            modelBuilder.Entity("AnalyticsProject.DataModels.FacebookDb", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset>("DatePosted")
                        .HasColumnType("datetimeoffset");

                    b.Property<int>("comments")
                        .HasColumnType("int");

                    b.Property<string>("content")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("likes")
                        .HasColumnType("int");

                    b.Property<int>("retweets")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("FacebookDbs");
                });

            modelBuilder.Entity("AnalyticsProject.DataModels.HomePage", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("HomePages");
                });

            modelBuilder.Entity("AnalyticsProject.DataModels.LinkedInDb", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset>("DatePosted")
                        .HasColumnType("datetimeoffset");

                    b.Property<int>("comments")
                        .HasColumnType("int");

                    b.Property<string>("content")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("likes")
                        .HasColumnType("int");

                    b.Property<int>("retweets")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("LinkedInDbs");
                });

            modelBuilder.Entity("AnalyticsProject.DataModels.SummaryInformation", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("CountOfPosts")
                        .HasColumnType("int");

                    b.Property<DateTimeOffset>("DateFrom")
                        .HasColumnType("datetimeoffset");

                    b.Property<DateTimeOffset>("DateTo")
                        .HasColumnType("datetimeoffset");

                    b.Property<Guid?>("EventId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Platform")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("averageComments")
                        .HasColumnType("int");

                    b.Property<int>("averageLikes")
                        .HasColumnType("int");

                    b.Property<int>("averageRetweets")
                        .HasColumnType("int");

                    b.Property<string>("eventName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("followerIncrease")
                        .HasColumnType("int");

                    b.Property<int>("totalComments")
                        .HasColumnType("int");

                    b.Property<int>("totalFollowers")
                        .HasColumnType("int");

                    b.Property<int>("totalLikes")
                        .HasColumnType("int");

                    b.Property<int>("totalRetweets")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EventId");

                    b.ToTable("SummaryInformations");
                });

            modelBuilder.Entity("AnalyticsProject.DataModels.TwitterMLDb", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("likes")
                        .HasColumnType("int");

                    b.Property<string>("platform")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("postContent")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset>("postDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("postTime")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("retweets")
                        .HasColumnType("int");

                    b.Property<string>("user")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("TwitterMLDbs");
                });

            modelBuilder.Entity("AnalyticsProject.DataModels.Users", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PhoneNumber")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("AnalyticsProject.DataModels.SummaryInformation", b =>
                {
                    b.HasOne("AnalyticsProject.DataModels.Event", null)
                        .WithMany("SummaryInformations")
                        .HasForeignKey("EventId");
                });

            modelBuilder.Entity("AnalyticsProject.DataModels.Event", b =>
                {
                    b.Navigation("SummaryInformations");
                });
#pragma warning restore 612, 618
        }
    }
}
