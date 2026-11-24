using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MVCProject.Entities;

namespace MVCProject.Configurations
{
    public class SessionConfigurations: IEntityTypeConfiguration<Session>
    {
        public void Configure(EntityTypeBuilder<Session> builder)
        {
            builder.Property(x => x.CreatedAt)
                .HasDefaultValueSql("GETDATE()");


             builder.ToTable(T =>
             {
                 T.HasCheckConstraint("SessionCapacityCostraing", "Capacity between 1 and 25");
                 T.HasCheckConstraint("SessionEndAfterStartDate  ", "EndDate > StartDate");
             });

            builder.HasOne(x => x.Trainer)
                .WithMany(x => x.Sessions)
                .OnDelete(DeleteBehavior.Restrict);






        }
    }
}
