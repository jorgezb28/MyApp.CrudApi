using MyApp.CrudApi.Domain.Models;
using MyApp.CrudApi.Domain.IRepository;
using MyApp.CrudApi.Services.IServices;

namespace MyApp.CrudApi.Services.Services
{
    public class MemberServices : IMemberServices
    {
        private readonly IMembersRepository _membersRepository;

        public MemberServices(IMembersRepository membersRepository)
        {
            _membersRepository = membersRepository;
        }


        public List<MemberModel> GetAll()
        {
            var members = _membersRepository.GetAll();
            return members;
        }

        public MemberModel GetById(int id)
        {
            if(id <= 0) throw new ArgumentNullException("id");

            var member = _membersRepository.GetById(id);
            return member;
        }

        public void Insert(MemberModel member)
        {
            if (member is null) throw new ArgumentNullException("member");

            _membersRepository.Insert(member);
        }

        public void Update(MemberModel member)
        {
            if (member is null) throw new ArgumentNullException("member");

            _membersRepository.Update(member);
        }

        public void Delete(MemberModel member)
        {
            if (member is null) throw new ArgumentNullException("member");

            _membersRepository.Delete(member);
        }
    }
}
