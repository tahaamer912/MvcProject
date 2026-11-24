using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MVCProject.Entities;
public class MemberConfigurations: GymUserConfigurations<Member>, IEntityTypeConfiguration<Member>
{
    public new void Configure(EntityTypeBuilder<Member> builder)
    {
       
        builder.Property(x => x.CreatedAt)
            .HasDefaultValueSql("GETDATE()")
            .HasColumnName("JoinAt"); 
        base.Configure(builder);
       


          
    }

    }


