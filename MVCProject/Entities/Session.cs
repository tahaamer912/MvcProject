namespace MVCProject.Entities
{
    public class Session : BaseEntity
    {
        public String Description { get; set; } = default!;
        public int Capacity { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }


        //Relationships
        public int TrainerId { get; set; }
        public Trainer Trainer { get; set; } = default!;








    }
}
