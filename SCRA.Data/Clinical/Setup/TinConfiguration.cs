using SCRA.Data.Clinical.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace SCRA.Data.Clinical.Setup
{
    internal class TinConfiguration : EntityTypeConfiguration<TinEntity>
    {
        public TinConfiguration()
        {
            ToTable("TIN", "dbo")
                .HasKey(t => t.TinId)
                .Property(t => t.TinId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
        }
    }
}
