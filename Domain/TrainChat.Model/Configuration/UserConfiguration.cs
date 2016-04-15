using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;

namespace TrainChat.Model.Configuration
{
    class UserConfiguration : EntityTypeConfiguration<UserEntity>
    {
        public UserConfiguration()
        {
            HasKey(t => t.Id);
            Property(t => t.Name).HasMaxLength(255).IsRequired().HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(new IndexAttribute("IX_NameUnique") { IsUnique = true, IsClustered = false }));
            Property(t => t.Login).HasMaxLength(25).IsRequired();
            Property(t => t.Password).HasMaxLength(150).IsRequired();
            Property(t => t.Role).IsRequired();
            HasMany(t => t.CreatedRooms).WithRequired(t => t.Creator).HasForeignKey(t => t.CreatorId).WillCascadeOnDelete(false);
            HasMany(t=> t.UserRoom).WithRequired(t=> t.User).HasForeignKey(t=> t.UserId).WillCascadeOnDelete(false);
        }
    }
}
