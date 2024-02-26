using MyApp.CrudApi.Domain.Models;

namespace MyApp.CrudApi.Domain.IRepository
{
    public interface IMembersRepository
    {
        List<MemberModel> GetAll();
        MemberModel GetById(int id);
        void Insert(MemberModel member);
        void Update(MemberModel member);
        void Delete(MemberModel member);
    }
}
