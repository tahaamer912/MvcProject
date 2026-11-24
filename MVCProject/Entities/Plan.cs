namespace MVCProject.Entities
{
    public class Plan : BaseEntity
    {
        public String Name { get; set; } = default!;
        public String Description { get; set; } = default!;
        public decimal Price { get; set; }
        public int DurationDays { get; set; }
        public bool  IsActive { get; set; }

        //Relationships
        public ICollection<Membership> PlanSubscriptions { get; set; } = default!;





    }
}
