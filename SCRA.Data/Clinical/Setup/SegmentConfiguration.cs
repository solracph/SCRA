using SCRA.Data.Clinical.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace SCRA.Data.Clinical.Setup
{
    internal class SegmentConfiguration : EntityTypeConfiguration<SegmentEntity>
    {
        public SegmentConfiguration()
        {
            ToTable("Segment", "dbo")
                .HasKey(t => t.SegmentId)
                .Property(t => t.SegmentId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
        }
    }
}
