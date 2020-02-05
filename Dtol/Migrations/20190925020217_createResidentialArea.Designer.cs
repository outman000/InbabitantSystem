﻿// <auto-generated />
using System;
using Dtol;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Dtol.Migrations
{
    [DbContext(typeof(DtolContext))]
    [Migration("20190925020217_createResidentialArea")]
    partial class createResidentialArea
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Dtol.Dtol.ResidentialArea", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address");

                    b.Property<double>("BuiltUpArea");

                    b.Property<DateTime>("ConstructionTime");

                    b.Property<string>("Developers");

                    b.Property<string>("East");

                    b.Property<string>("Nanme");

                    b.Property<string>("North");

                    b.Property<int>("ParkingSpacesAbove");

                    b.Property<int>("ParkingSpacesBelow");

                    b.Property<string>("Property");

                    b.Property<string>("PropertyContacts");

                    b.Property<double>("PropertyFee");

                    b.Property<string>("South");

                    b.Property<int>("Telephone");

                    b.Property<string>("West");

                    b.HasKey("Id");

                    b.ToTable("residentialAreas");
                });
#pragma warning restore 612, 618
        }
    }
}
