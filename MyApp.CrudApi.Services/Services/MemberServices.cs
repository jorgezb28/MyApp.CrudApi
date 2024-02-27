using MyApp.CrudApi.Domain.Models;
using MyApp.CrudApi.Domain.IRepository;
using MyApp.CrudApi.Services.IServices;
using AutoMapper;
using MyApp.CrudApi.Domain.DTOs;
using AutoMapper.Execution;

namespace MyApp.CrudApi.Services.Services
{
    public class MemberServices : IMemberServices
    {
        private readonly IMembersRepository _membersRepository;
        private readonly IMapper _mapper;

        public MemberServices(IMembersRepository membersRepository, IMapper mapper)
        {
            _membersRepository = membersRepository;
            _mapper = mapper;
        }


        public List<MemberDto> GetAll()
        {
            var members = _membersRepository.GetAll();
            var membersDto = _mapper.Map<List<MemberDto>>(members);
            return membersDto;
        }

        public MemberDto GetById(int id)
        {
            if(id <= 0) throw new ArgumentNullException("id");

            var member = _membersRepository.GetById(id);
            var memberDto = _mapper.Map<MemberDto>(member);
            return memberDto;
        }

        public void Insert(MemberDto memberDto)
        {
            if (memberDto is null) throw new ArgumentNullException("member");

            var member = _mapper.Map<MemberModel>(memberDto);
            _membersRepository.Insert(member);
        }

        public void Update(MemberDto memberDto)
        {
            if (memberDto is null) throw new ArgumentNullException("member");

            var member = _mapper.Map<MemberModel>(memberDto);
            _membersRepository.Update(member);
        }

        public void Delete(MemberDto memberDto)
        {
            if (memberDto is null) throw new ArgumentNullException("member");

            var member = _mapper.Map<MemberModel>(memberDto);
            _membersRepository.Delete(member);
        }
    }
}
