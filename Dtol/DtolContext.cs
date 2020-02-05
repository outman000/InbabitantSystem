using Dtol.Dtol;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dtol
{
    public class DtolContext:DbContext
    {

        public DtolContext()
        {
        }

        public DtolContext(DbContextOptions<DtolContext> options)
            : base(options)
        {
        }
        public DbSet<ResidentialArea>  residentialAreas { get; set; }
        public DbSet<Building> building { get; set; }
        public DbSet<ResidentInfo> residentInfo { get; set; }
        public DbSet<ResidentIdentity> residentIdentity { get; set; }
        public DbSet<HouseInfo> houseInfo { get; set; }
        public DbSet<ResidentRelationShip> residentRelationShip { get; set; }
        public DbSet<InfoRelationShip> infoRelationShip { get; set; }
        public DbSet<Activity> activity { get; set; }
        public DbSet<FileUpload> fileUpload { get; set; }
        public DbSet<Inform> inform { get; set; }
        public DbSet<InformAndResident> informAndResident { get; set; }

        public DbSet<UserInfo> userInfo { get; set; }
        public DbSet<PartyInfo> partyInfo { get; set; }

        public DbSet<City> cities { get; set; }
        public DbSet<Political> politicals { get; set; }
        public DbSet<Nation> nations { get; set; }
    }
}
