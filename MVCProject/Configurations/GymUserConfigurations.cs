using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MVCProject.Entities;

public class GymUserConfigurations<T> : IEntityTypeConfiguration<T> where T : GymUser
{
    public void Configure(EntityTypeBuilder<T> builder)
    {
        builder.Property(x => x.Name)
            .HasMaxLength(50);
        builder.Property(x => x.Phone)
            .HasMaxLength(11);
        builder.HasIndex(x => x.Email)
            .IsUnique();
        builder.HasIndex(x => x.Phone)
         .IsUnique();

        builder.ToTable(T =>
        {
            T.HasCheckConstraint("GymUserEmailCheck", "Email LIKE '_%@_%._%'");
            T.HasCheckConstraint(
                "GymUserPhoneCheck",
                "LEN(Phone) = 11 AND (Phone LIKE '011%' OR Phone LIKE '012%' OR Phone LIKE '015%' OR Phone LIKE '010%')"
            );
        });






        builder.ComplexProperty(x => x.Address);
        
           
        


    }
}

