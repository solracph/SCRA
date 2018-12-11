using SCRA.Data.Clinical.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace SCRA.Data.Clinical.Setup
{
    internal class ApplicationConfiguration : EntityTypeConfiguration<ApplicationEntity>
    {
        public ApplicationConfiguration()
        {
            ToTable("Application", "dbo")
                .HasKey(t => t.ApplicationId)
                .Property(t => t.ApplicationId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
        }
    }
}
