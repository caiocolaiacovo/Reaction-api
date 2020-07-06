﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Reaction_api.Infra.Data;

namespace Reaction_api.Infra.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Reaction_api.Domain.Comment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("MomentId");

                    b.Property<string>("Text");

                    b.Property<int?>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("MomentId");

                    b.HasIndex("UserId");

                    b.ToTable("Comment");
                });

            modelBuilder.Entity("Reaction_api.Domain.Moment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("Description");

                    b.Property<string>("Picture");

                    b.Property<int>("Reactions");

                    b.Property<int?>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Moment");
                });

            modelBuilder.Entity("Reaction_api.Domain.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Avatar");

                    b.Property<string>("Name");

                    b.Property<string>("Profile");

                    b.HasKey("Id");

                    b.ToTable("User");
                });

            modelBuilder.Entity("Reaction_api.Domain.Comment", b =>
                {
                    b.HasOne("Reaction_api.Domain.Moment")
                        .WithMany("Comments")
                        .HasForeignKey("MomentId");

                    b.HasOne("Reaction_api.Domain.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Reaction_api.Domain.Moment", b =>
                {
                    b.HasOne("Reaction_api.Domain.User", "User")
                        .WithMany("Moments")
                        .HasForeignKey("UserId");
                });
#pragma warning restore 612, 618
        }
    }
}