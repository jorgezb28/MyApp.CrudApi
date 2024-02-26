namespace MyApp.CrudApi.Domain.Models
{
    public class MembershipPlanModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
    }
}