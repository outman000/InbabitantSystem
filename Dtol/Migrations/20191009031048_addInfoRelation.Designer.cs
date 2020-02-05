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
    [Migration("20191009031048_addInfoRelation")]
    partial class addInfoRelation
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Dtol.Dtol.Building", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("AreaId");

                    b.Property<Guid?>("AreaInfoId");

                    b.Property<string>("BuildingNature");

                    b.Property<int?>("BuildingNo");

                    b.Property<DateTime?>("CheckinTime");

                    b.Property<DateTime?>("ConstructionTime");

                    b.Property<int?>("ElevatorCount");

                    b.Property<int?>("FloorCount");

                    b.Property<int?>("HouseCount");

                    b.Property<string>("Name");

                    b.Property<string>("Status");

                    b.Property<int?>("UndergroundCount");

                    b.Property<int?>("UnitNo");

                    b.HasKey("Id");

                    b.HasIndex("AreaInfoId");

                    b.ToTable("building");
                });

            modelBuilder.Entity("Dtol.Dtol.HouseInfo", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Area");

                    b.Property<int?>("BuildingNo");

                    b.Property<string>("HouseHolder");

                    b.Property<string>("HouseHolderIdNo");

                    b.Property<string>("HouseNo");

                    b.Property<string>("Status");

                    b.Property<int?>("UnitNo");

                    b.HasKey("Id");

                    b.ToTable("houseInfo");
                });

            modelBuilder.Entity("Dtol.Dtol.InfoRelationShip", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("HouseInfoId");

                    b.Property<Guid?>("ResidentInfoId");

                    b.HasKey("Id");

                    b.HasIndex("HouseInfoId");

                    b.HasIndex("ResidentInfoId");

                    b.ToTable("infoRelationShip");
                });

            modelBuilder.Entity("Dtol.Dtol.ResidentIdentity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("FormId");

                    b.Property<string>("IdentityName");

                    b.Property<string>("Status");

                    b.HasKey("Id");

                    b.ToTable("residentIdentity");
                });

            modelBuilder.Entity("Dtol.Dtol.ResidentInfo", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address");

                    b.Property<string>("Company");

                    b.Property<string>("Education");

                    b.Property<string>("Gender");

                    b.Property<Guid?>("HouseHolderId");

                    b.Property<string>("IdNumber");

                    b.Property<string>("Job");

                    b.Property<string>("Married");

                    b.Property<string>("Minority");

                    b.Property<string>("Name");

                    b.Property<string>("Phone");

                    b.Property<string>("PhotoId");

                    b.Property<string>("Politics");

                    b.Property<string>("Register");

                    b.Property<string>("RelationWithHousehold");

                    b.Property<string>("ReligiousBelief");

                    b.Property<string>("Status");

                    b.HasKey("Id");

                    b.ToTable("residentInfo");
                });

            modelBuilder.Entity("Dtol.Dtol.ResidentRelationShip", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("ResidentIdentityId");

                    b.Property<Guid?>("ResidentInfoId");

                    b.HasKey("Id");

                    b.HasIndex("ResidentIdentityId");

                    b.HasIndex("ResidentInfoId");

                    b.ToTable("residentRelationShip");
                });

            modelBuilder.Entity("Dtol.Dtol.ResidentialArea", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address");

                    b.Property<double?>("BuiltUpArea");

                    b.Property<DateTime?>("ConstructionTime");

                    b.Property<string>("Developers");

                    b.Property<string>("East");

                    b.Property<string>("Name");

                    b.Property<string>("North");

                    b.Property<int?>("ParkingSpacesAbove");

                    b.Property<int?>("ParkingSpacesBelow");

                    b.Property<string>("Property");

                    b.Property<string>("PropertyContacts");

                    b.Property<double?>("PropertyFee");

                    b.Property<string>("South");

                    b.Property<string>("Status");

                    b.Property<int?>("Telephone");

                    b.Property<string>("West");

                    b.HasKey("Id");

                    b.ToTable("residentialAreas");
                });

            modelBuilder.Entity("Dtol.Dtol.Building", b =>
                {
                    b.HasOne("Dtol.Dtol.ResidentialArea", "AreaInfo")
                        .WithMany()
                        .HasForeignKey("AreaInfoId");
                });

            modelBuilder.Entity("Dtol.Dtol.InfoRelationShip", b =>
                {
                    b.HasOne("Dtol.Dtol.HouseInfo", "HouseInfo")
                        .WithMany()
                        .HasForeignKey("HouseInfoId");

                    b.HasOne("Dtol.Dtol.ResidentInfo", "ResidentInfo")
                        .WithMany()
                        .HasForeignKey("ResidentInfoId");
                });

            modelBuilder.Entity("Dtol.Dtol.ResidentRelationShip", b =>
                {
                    b.HasOne("Dtol.Dtol.ResidentIdentity", "ResidentIdentity")
                        .WithMany()
                        .HasForeignKey("ResidentIdentityId");

                    b.HasOne("Dtol.Dtol.ResidentInfo", "ResidentInfo")
                        .WithMany()
                        .HasForeignKey("ResidentInfoId");
                });
#pragma warning restore 612, 618
        }
    }
}
