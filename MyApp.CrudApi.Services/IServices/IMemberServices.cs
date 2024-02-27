using MyApp.CrudApi.Domain.DTOs;
using MyApp.CrudApi.Domain.Models;

namespace MyApp.CrudApi.Services.IServices
{
    public interface IMemberServices
    {
        List<MemberDto> GetAll();
        MemberDto GetById(int id);
        void Insert(MemberDto member);
        void Update(MemberDto member);
        void Delete(MemberDto member);
    }
}
