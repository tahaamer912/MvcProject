namespace MVCProject.Entities
{
    public class Member :GymUser 
    {
      
        public String? Photo { get; set; }

        //Relationships
        public ICollection<Membership> MemberSubscriptions { get; set; } = default!;


    }
}
 
