using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MVCProject.Entities;

    public class PlanConfigurations : IEntityTypeConfiguration<Plan>
{
    public void Configure(EntityTypeBuilder<Plan> builder)
    {
        builder.Property(x => x.CreatedAt)
            .HasDefaultValueSql("GETDATE()");
        builder.ToTable(T =>
        {
            T.HasCheckConstraint("PlanDurationCheck", "DurationDays  between 1 and 365");
        });
    }
    
    
}
