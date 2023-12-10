﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using config_server.Data;

#nullable disable

namespace config_server.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20231210001552_firstMigration")]
    partial class firstMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("config_server.Models.Config", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<float>("ClusterRadius")
                        .HasColumnType("real");

                    b.Property<int>("Duration")
                        .HasColumnType("int");

                    b.Property<bool>("GeoFencing")
                        .HasColumnType("bit");

                    b.Property<float>("LocationBuffer")
                        .HasColumnType("real");

                    b.Property<int>("MapSubType")
                        .HasColumnType("int");

                    b.Property<int>("MapType")
                        .HasColumnType("int");

                    b.Property<float>("TimeBuffer")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.ToTable("Config");
                });
#pragma warning restore 612, 618
        }
    }
}
