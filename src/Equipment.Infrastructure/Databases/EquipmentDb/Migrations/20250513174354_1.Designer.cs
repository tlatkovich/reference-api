﻿// <auto-generated />
using System;
using System.Collections.Generic;
using Equipment.Infrastructure.Databases.EquipmentDb;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Equipment.Infrastructure.Databases.EquipmentDb.Migrations
{
    [DbContext(typeof(EquipmentDbContext))]
    [Migration("20250513174354_1")]
    partial class _1
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Equipment.Core.Domain.EquipmentAggregate.Attachment", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("EquipmentId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Make")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.ComplexProperty<Dictionary<string, object>>("EquipmentNumber", "Equipment.Core.Domain.EquipmentAggregate.Attachment.EquipmentNumber#EquipmentNumber", b1 =>
                        {
                            b1.IsRequired();

                            b1.Property<int>("Value")
                                .HasColumnType("int");
                        });

                    b.HasKey("Id");

                    b.HasIndex("EquipmentId");

                    b.ToTable("Attachments");
                });

            modelBuilder.Entity("Equipment.Core.Domain.EquipmentAggregate.Equipment", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("EquipmentNumber")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EquipmentNumber"), 10000000L);

                    b.Property<bool>("IsAttachment")
                        .HasColumnType("bit");

                    b.Property<string>("Make")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ModifiedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.ComplexProperty<Dictionary<string, object>>("SerialNumber", "Equipment.Core.Domain.EquipmentAggregate.Equipment.SerialNumber#SerialNumber", b1 =>
                        {
                            b1.IsRequired();

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");
                        });

                    b.HasKey("Id");

                    b.ToTable("Equipment");
                });

            modelBuilder.Entity("Equipment.Core.Domain.EquipmentAggregate.Attachment", b =>
                {
                    b.HasOne("Equipment.Core.Domain.EquipmentAggregate.Equipment", null)
                        .WithMany("Attachments")
                        .HasForeignKey("EquipmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Equipment.Core.Domain.EquipmentAggregate.Equipment", b =>
                {
                    b.Navigation("Attachments");
                });
#pragma warning restore 612, 618
        }
    }
}
