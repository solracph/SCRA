using SCRA.Data.Clinical.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace SCRA.Data.Clinical.Setup
{
    internal class RuleConfiguration : EntityTypeConfiguration<RuleEntity>
    {
        public RuleConfiguration()
        {
            ToTable("Rule", "dbo")
                .HasKey(t => t.RuleId)
                .Property(t => t.RuleId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            HasMany(p => p.Segments)
                .WithMany(c => c.Rules)
                .Map(cs =>
                {
                    cs.MapLeftKey("RuleId");
                    cs.MapRightKey("SegmentId");
                    cs.ToTable("RuleSegment");
                });

            HasMany(p => p.Contracts)
                .WithMany(c => c.Rules)
                .Map(cs =>
                {
                    cs.MapLeftKey("RuleId");
                    cs.MapRightKey("ContractId");
                    cs.ToTable("RuleContract");
                });

            HasMany(p => p.Pbp)
               .WithMany(c => c.Rules)
               .Map(cs =>
               {
                   cs.MapLeftKey("RuleId");
                   cs.MapRightKey("PbpId");
                   cs.ToTable("RulePBP");
               });

             HasMany(p => p.Tin)
               .WithMany(c => c.Rules)
               .Map(cs =>
               {
                   cs.MapLeftKey("RuleId");
                   cs.MapRightKey("TinId");
                   cs.ToTable("RuleTIN");
               });

            HasMany(p => p.Measures)
                .WithMany(c => c.Rules)
                .Map(cs =>
                {
                    cs.MapLeftKey("RuleId");
                    cs.MapRightKey("MeasureId");
                    cs.ToTable("RuleMeasure");
                });

           HasMany(p => p.Applications)
                .WithMany(c => c.Rules)
                .Map(cs =>
                {
                    cs.MapLeftKey("RuleId");
                    cs.MapRightKey("ApplicationId");
                    cs.ToTable("RuleApplication");
                });
        }
    }
}
