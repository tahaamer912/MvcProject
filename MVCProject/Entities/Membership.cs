using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;

namespace MVCProject.Entities
{
    public class Membership : BaseEntity
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public int MemberId { get; set; }
        public Member Member { get; set; } = default!;

        public int PlanId { get; set; }
        public Plan Plan { get; set; } = default!;

        [NotMapped]
        public String Status => StartDate > DateTime.Now ? "Upcoming" : 
                               EndDate < DateTime.Now ? "Active" : 
                               "Expired";





    }
}
