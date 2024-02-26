using MyApp.CrudApi.Domain.Models;

namespace MyApp.CrudApi.Domain.IRepository
{
    public interface IMembershipPlansRepository
    {
        List<MembershipPlanModel> GetAll();
        void Update(MemberModel member);
    }
}