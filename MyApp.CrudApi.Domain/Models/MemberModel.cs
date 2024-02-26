namespace MyApp.CrudApi.Domain.Models
{
    public class MemberModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public DateTime JoinDate { get; set; }
        public MembershipPlanModel MembershipPlan { get; set; }
    }
}
