﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TopChoiceHardware.OrdersService.AccessData;

namespace TopChoiceHardware.OrdersService.AccessData.Migrations
{
    [DbContext(typeof(OrdenesContext))]
    [Migration("20210925153733_migracion1")]
    partial class migracion1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.10")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TopChoiceHardware.OrdersService.Domain.Entities.Factura", b =>
                {
                    b.Property<int>("InvoiceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int?>("OrdenId")
                        .HasColumnType("int");

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("InvoiceId");

                    b.HasIndex("OrdenId");

                    b.HasIndex("UserId");

                    b.ToTable("Factura");
                });

            modelBuilder.Entity("TopChoiceHardware.OrdersService.Domain.Entities.MetodoPago", b =>
                {
                    b.Property<int>("PaymentMethodId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("PaymentMethodId");

                    b.ToTable("MetodoPago");
                });

            modelBuilder.Entity("TopChoiceHardware.OrdersService.Domain.Entities.Orden", b =>
                {
                    b.Property<int>("OrdenId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AddressId")
                        .HasColumnType("int");

                    b.Property<int?>("OrdenProductoId")
                        .HasColumnType("int");

                    b.Property<int?>("OrdenProductoId1")
                        .HasColumnType("int");

                    b.Property<int>("PaymentMethodId")
                        .HasColumnType("int");

                    b.Property<int>("Total")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("OrdenId");

                    b.HasIndex("OrdenProductoId");

                    b.HasIndex("OrdenProductoId1");

                    b.HasIndex("PaymentMethodId");

                    b.ToTable("Orden");
                });

            modelBuilder.Entity("TopChoiceHardware.OrdersService.Domain.Entities.OrdenProducto", b =>
                {
                    b.Property<int>("OrdenProductoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("OrdenId")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.HasKey("OrdenProductoId");

                    b.ToTable("OrdenProducto");
                });

            modelBuilder.Entity("TopChoiceHardware.OrdersService.Domain.Entities.Factura", b =>
                {
                    b.HasOne("TopChoiceHardware.OrdersService.Domain.Entities.Orden", "Orden")
                        .WithMany()
                        .HasForeignKey("OrdenId");

                    b.HasOne("TopChoiceHardware.OrdersService.Domain.Entities.Orden", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Orden");

                    b.Navigation("User");
                });

            modelBuilder.Entity("TopChoiceHardware.OrdersService.Domain.Entities.Orden", b =>
                {
                    b.HasOne("TopChoiceHardware.OrdersService.Domain.Entities.OrdenProducto", null)
                        .WithMany("Ordenes")
                        .HasForeignKey("OrdenProductoId");

                    b.HasOne("TopChoiceHardware.OrdersService.Domain.Entities.OrdenProducto", null)
                        .WithMany("Productos")
                        .HasForeignKey("OrdenProductoId1");

                    b.HasOne("TopChoiceHardware.OrdersService.Domain.Entities.MetodoPago", "PaymentMethod")
                        .WithMany()
                        .HasForeignKey("PaymentMethodId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PaymentMethod");
                });

            modelBuilder.Entity("TopChoiceHardware.OrdersService.Domain.Entities.OrdenProducto", b =>
                {
                    b.Navigation("Ordenes");

                    b.Navigation("Productos");
                });
#pragma warning restore 612, 618
        }
    }
}
