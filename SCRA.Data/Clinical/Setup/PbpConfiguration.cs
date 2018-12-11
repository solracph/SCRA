using SCRA.Data.Clinical.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace SCRA.Data.Clinical.Setup
{
    internal class PbpConfiguration : EntityTypeConfiguration<PbpEntity>
    {
        public PbpConfiguration()
        {
            ToTable("Pbp", "dbo")
                .HasKey(t => t.PbpId)
                .Property(t => t.PbpId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

             HasMany(p => p.Contracts)
                .WithMany(c => c.Pbp)
                .Map(cs =>
                {
                    cs.MapLeftKey("PBPId");
                    cs.MapRightKey("ContractId");
                    cs.ToTable("ContractPBP");
                });
        }

    }
}
