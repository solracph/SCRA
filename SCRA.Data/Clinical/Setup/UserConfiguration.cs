using SCRA.Data.Clinical.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace SCRA.Data.Clinical.Setup
{
    internal class UserConfiguration : EntityTypeConfiguration<UserEntity>
    {
        public UserConfiguration()
        {
            ToTable("User", "dbo")
                .HasKey(t => t.UserId)
                .Property(t => t.UserId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            HasMany(p => p.Applications)
               .WithMany(c => c.Users)
               .Map(cs =>
               {
                   cs.MapLeftKey("UserId");
                   cs.MapRightKey("ApplicationId");
                   cs.ToTable("UserApplication");
               });

            HasMany(p => p.Rules)
              .WithMany(c => c.Users)
              .Map(cs =>
              {
                  cs.MapLeftKey("UserId");
                  cs.MapRightKey("RuleId");
                  cs.ToTable("UserRule");
              });
        }
    }
}
