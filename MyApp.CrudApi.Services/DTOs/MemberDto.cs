namespace MyApp.CrudApi.Domain.DTOs
{
    public class MemberDto
    {
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public DateTime JoinDate { get; set; }
        public MembershipPlanDto MembershipPlan { get; set; }
    }
}
