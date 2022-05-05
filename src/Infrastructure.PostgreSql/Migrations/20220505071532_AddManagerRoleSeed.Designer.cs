﻿// <auto-generated />
using System;
using Infrastructure.PostgreSql;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Infrastructure.PostgreSql.Migrations
{
    [DbContext(typeof(PostgreSqlCoreDb))]
    [Migration("20220505071532_AddManagerRoleSeed")]
    partial class AddManagerRoleSeed
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Domain.Role", b =>
                {
                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<int[]>("Permissions")
                        .IsRequired()
                        .HasColumnType("integer[]");

                    b.HasKey("Name");

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            Name = "root",
                            Permissions = new[] { 0, 1, 2, 3 }
                        },
                        new
                        {
                            Name = "manager",
                            Permissions = new[] { 0, 1, 2, 3 }
                        },
                        new
                        {
                            Name = "guest",
                            Permissions = new[] { 2, 3 }
                        });
                });

            modelBuilder.Entity("Domain.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("RoleName")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("RoleName");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Domain.User", b =>
                {
                    b.HasOne("Domain.Role", "Role")
                        .WithMany()
                        .HasForeignKey("RoleName");

                    b.Navigation("Role");
                });
#pragma warning restore 612, 618
        }
    }
}
