using SCRA.Data.Clinical.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace SCRA.Data.Clinical.Setup
{
    internal class ContractConfiguration : EntityTypeConfiguration<ContractEntity>
    {
        public ContractConfiguration()
        {
            ToTable("Contract", "dbo")
                .HasKey(t => t.ContractId)
                .Property(t => t.ContractId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

           
        }
    }
}
