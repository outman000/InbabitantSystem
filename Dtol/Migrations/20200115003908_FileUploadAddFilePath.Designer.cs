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
    [Migration("20200115003908_FileUploadAddFilePath")]
    partial class FileUploadAddFilePath
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Dtol.Dtol.Activity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ActivityForm");

                    b.Property<string>("ActivityRecord");

                    b.Property<DateTime?>("AddTime");

                    b.Property<int?>("BeneficiaryNumber");

                    b.Property<string>("Place");

                    b.Property<string>("Recorder");

                    b.Property<DateTime?>("StartTime");

                    b.Property<string>("Status");

                    b.Property<string>("TargetPeople");

                    b.Property<string>("Theme");

                    b.Property<string>("Title");

                    b.Property<int?>("participantsNumber");

                    b.HasKey("Id");

                    b.ToTable("activity");
                });

            modelBuilder.Entity("Dtol.Dtol.Building", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime?>("AddTime");

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

            modelBuilder.Entity("Dtol.Dtol.City", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("Code");

                    b.Property<Guid?>("FormId");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("cities");
                });

            modelBuilder.Entity("Dtol.Dtol.FileUpload", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("AddTime");

                    b.Property<string>("FileName");

                    b.Property<string>("FilePath");

                    b.Property<Guid?>("FormId");

                    b.Property<string>("PhysicsName");

                    b.Property<string>("Status");

                    b.HasKey("Id");

                    b.ToTable("fileUpload");
                });

            modelBuilder.Entity("Dtol.Dtol.HouseInfo", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime?>("AddTime");

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

                    b.Property<string>("RelationWithHousehold");

                    b.Property<Guid?>("ResidentInfoId");

                    b.HasKey("Id");

                    b.HasIndex("HouseInfoId");

                    b.HasIndex("ResidentInfoId")
                        .IsUnique()
                        .HasFilter("[ResidentInfoId] IS NOT NULL");

                    b.ToTable("infoRelationShip");
                });

            modelBuilder.Entity("Dtol.Dtol.Inform", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime?>("AddTime");

                    b.Property<string>("Address");

                    b.Property<string>("Content");

                    b.Property<string>("InformTitle");

                    b.Property<string>("PhoneNumber");

                    b.Property<DateTime?>("SendTime");

                    b.Property<string>("Sender");

                    b.Property<string>("Status");

                    b.Property<DateTime?>("Time");

                    b.HasKey("Id");

                    b.ToTable("inform");
                });

            modelBuilder.Entity("Dtol.Dtol.InformAndResident", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("InformId");

                    b.Property<Guid?>("residentInfoId");

                    b.HasKey("Id");

                    b.HasIndex("InformId");

                    b.HasIndex("residentInfoId");

                    b.ToTable("informAndResident");
                });

            modelBuilder.Entity("Dtol.Dtol.Nation", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<int>("code");

                    b.HasKey("Id");

                    b.ToTable("nations");
                });

            modelBuilder.Entity("Dtol.Dtol.PartyInfo", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Comment");

                    b.Property<string>("IdNumber");

                    b.Property<DateTime?>("JoinPartyTime");

                    b.Property<string>("PartyJob");

                    b.Property<Guid?>("ResidentId");

                    b.HasKey("Id");

                    b.ToTable("partyInfo");
                });

            modelBuilder.Entity("Dtol.Dtol.Political", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<int>("code");

                    b.HasKey("Id");

                    b.ToTable("politicals");
                });

            modelBuilder.Entity("Dtol.Dtol.ResidentIdentity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("AddTime");

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

                    b.Property<DateTime?>("AddTime");

                    b.Property<string>("Address");

                    b.Property<string>("City");

                    b.Property<string>("Company");

                    b.Property<string>("County");

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

                    b.Property<string>("Province");

                    b.Property<string>("Register");

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

                    b.HasIndex("ResidentInfoId")
                        .IsUnique()
                        .HasFilter("[ResidentInfoId] IS NOT NULL");

                    b.ToTable("residentRelationShip");
                });

            modelBuilder.Entity("Dtol.Dtol.ResidentialArea", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime?>("AddTime");

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

            modelBuilder.Entity("Dtol.Dtol.UserInfo", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime?>("AddTime");

                    b.Property<string>("PassWord");

                    b.Property<string>("Status");

                    b.Property<string>("UserName");

                    b.HasKey("Id");

                    b.ToTable("userInfo");
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
                        .WithOne("InfoRelationShips")
                        .HasForeignKey("Dtol.Dtol.InfoRelationShip", "ResidentInfoId");
                });

            modelBuilder.Entity("Dtol.Dtol.InformAndResident", b =>
                {
                    b.HasOne("Dtol.Dtol.Inform", "Inform")
                        .WithMany()
                        .HasForeignKey("InformId");

                    b.HasOne("Dtol.Dtol.ResidentInfo", "residentInfo")
                        .WithMany()
                        .HasForeignKey("residentInfoId");
                });

            modelBuilder.Entity("Dtol.Dtol.ResidentRelationShip", b =>
                {
                    b.HasOne("Dtol.Dtol.ResidentIdentity", "ResidentIdentity")
                        .WithMany()
                        .HasForeignKey("ResidentIdentityId");

                    b.HasOne("Dtol.Dtol.ResidentInfo", "ResidentInfo")
                        .WithOne("ResidentRelationShips")
                        .HasForeignKey("Dtol.Dtol.ResidentRelationShip", "ResidentInfoId");
                });
#pragma warning restore 612, 618
        }
    }
}
