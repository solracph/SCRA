using SCRA.Common.Utilities;
using SCRA.Data.Clinical.Entities;
using SCRA.Data.Clinical.Setup;
using System.Data.Entity;

namespace SCRA.Data.Common.Models
{
    public class DatabaseContext : DbContext
    {
       /* public DatabaseContext() : base(Settings.SCRAConnectionString)
        {
            Database.SetInitializer<DatabaseContext>(null);
        }*/

        public DatabaseContext(string connString) : base(connString)
        {
            Database.SetInitializer<DatabaseContext>(null);
        }


        public IDbSet<ApplicationEntity> Applications { get; set; }
        public IDbSet<ContractEntity> Contracts { get; set; }
        public IDbSet<MeasureEntity> Measures { get; set; }
        public IDbSet<PbpEntity> PbpsList { get; set; }
        public IDbSet<RuleEntity> Rules { get; set; }
        public IDbSet<SegmentEntity> Segments { get; set; }
        public IDbSet<TinEntity> TinList { get; set; }
        public IDbSet<UserEntity> Users { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new ApplicationConfiguration());
            modelBuilder.Configurations.Add(new ContractConfiguration());
            modelBuilder.Configurations.Add(new MeasureConfiguration());
            modelBuilder.Configurations.Add(new PbpConfiguration());
            modelBuilder.Configurations.Add(new RuleConfiguration());
            modelBuilder.Configurations.Add(new SegmentConfiguration());
            modelBuilder.Configurations.Add(new TinConfiguration());
            modelBuilder.Configurations.Add(new UserConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}