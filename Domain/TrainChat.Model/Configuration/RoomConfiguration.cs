using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;

namespace TrainChat.Model.Configuration
{
    class RoomConfiguration : EntityTypeConfiguration<RoomEntity>
    {
        public RoomConfiguration()
        {
            HasKey(t => t.Id);
            Property(t => t.Name).HasMaxLength(255).IsRequired().HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(new IndexAttribute("IX_NameUnique") { IsUnique = true, IsClustered = false }));
            Property(t => t.IsPrivate).IsRequired();

            HasMany(t => t.RoomUser).WithRequired(t => t.Room).HasForeignKey(t=>t.RoomId).WillCascadeOnDelete(false);
        }
    }
}
