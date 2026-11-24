using MVCProject.Entities.Enums;

namespace MVCProject.Entities
{
    public class Trainer : GymUser
    {
        public DateTime HireDate { get; set; }
        public Specialties Specialties { get; set; }

        //Relationships
        public ICollection<Session> Sessions { get; set; } = default!;


    }

}
    


