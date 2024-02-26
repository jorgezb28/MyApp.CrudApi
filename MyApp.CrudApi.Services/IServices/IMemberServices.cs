using MyApp.CrudApi.Domain.Models;

namespace MyApp.CrudApi.Services.IServices
{
    public interface IMemberServices
    {
        List<MemberModel> GetAll();
        MemberModel GetById(int id);
        void Insert(MemberModel member);
        void Update(MemberModel member);
        void Delete(MemberModel member);
    }
}
