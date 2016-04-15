using System.Data.Entity.ModelConfiguration;

namespace TrainChat.Model.Configuration
{
    internal class RoleConfiguration : EntityTypeConfiguration<RoleEntity>
    {
        public RoleConfiguration()
        {
            //HasKey(t => t.Id);
            //Property(t => t.Name).HasMaxLength(50).IsRequired();
            //Property(t => t.Description).HasMaxLength(255).IsRequired();

            //HasMany(t => t.Users).WithRequired(t => t.Role).HasForeignKey(t => t.Role).WillCascadeOnDelete(false);
        }
    }
}

