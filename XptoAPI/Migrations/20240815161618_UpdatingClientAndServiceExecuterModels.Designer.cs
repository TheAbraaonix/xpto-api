﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using XptoAPI.Context;

#nullable disable

namespace XptoAPI.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240815161618_UpdatingClientAndServiceExecuterModels")]
    partial class UpdatingClientAndServiceExecuterModels
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("XptoAPI.Models.Client", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Cpf")
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("XptoAPI.Models.ServiceExecuter", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Cnpj")
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("serviceExecuters");
                });

            modelBuilder.Entity("XptoAPI.Models.ServiceOrder", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<Guid>("ClientId")
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("ServiceDate")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid>("ServiceExecuterId")
                        .HasColumnType("char(36)");

                    b.Property<int>("ServiceNumber")
                        .HasColumnType("int");

                    b.Property<string>("ServiceTitle")
                        .HasColumnType("longtext");

                    b.Property<double>("ServiceValue")
                        .HasColumnType("double");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.HasIndex("ServiceExecuterId");

                    b.ToTable("serviceOrders");
                });

            modelBuilder.Entity("XptoAPI.Models.ServiceOrder", b =>
                {
                    b.HasOne("XptoAPI.Models.Client", "Client")
                        .WithMany("ServiceOrders")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("XptoAPI.Models.ServiceExecuter", "ServiceExecuter")
                        .WithMany("ServiceOrders")
                        .HasForeignKey("ServiceExecuterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Client");

                    b.Navigation("ServiceExecuter");
                });

            modelBuilder.Entity("XptoAPI.Models.Client", b =>
                {
                    b.Navigation("ServiceOrders");
                });

            modelBuilder.Entity("XptoAPI.Models.ServiceExecuter", b =>
                {
                    b.Navigation("ServiceOrders");
                });
#pragma warning restore 612, 618
        }
    }
}
