using SCRA.Data.Clinical.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace SCRA.Data.Clinical.Setup
{
    internal class MeasureConfiguration : EntityTypeConfiguration<MeasureEntity>
    {
        public MeasureConfiguration()
        {
            ToTable("Measure", "dbo")
                .HasKey(t => t.MeasureId)
                .Property(t => t.MeasureId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
        }
    }
}
