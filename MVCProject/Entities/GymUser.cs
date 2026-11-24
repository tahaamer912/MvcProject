using MVCProject.Entities.Enums;

namespace MVCProject.Entities
{
    public class GymUser : BaseEntity
    {
        public String Name { get; set; } = default!;
        public String Email { get; set; } = default!;
        public String Phone { get; set; } = default!;
        public DateOnly DateOfBirth { get; set; }
        public Gender Gender { get; set; }
        public Address Address { get; set; } = default!;
    }
} 
 