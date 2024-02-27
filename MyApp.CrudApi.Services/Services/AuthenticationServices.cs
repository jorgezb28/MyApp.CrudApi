using AutoMapper;
using MyApp.CrudApi.Domain.IRepository;
using MyApp.CrudApi.Domain.Models;
using MyApp.CrudApi.Services.DTOs;
using MyApp.CrudApi.Services.IServices;

namespace MyApp.CrudApi.Services.Services
{
    public class AuthenticationServices : IAuthenticationServices
    {
        private readonly IAuthenticationRepository _authenticationRepository;
        private readonly IMapper _mapper;

        public AuthenticationServices(IAuthenticationRepository authenticationRepository, IMapper mapper)
        {
            _authenticationRepository = authenticationRepository;
            _mapper = mapper;
        }

        public UserDto Login(LoginUserDto userDto)
        {
            if (userDto == null) throw new ArgumentNullException("user");

            var user = _mapper.Map<UserModel>(userDto);

            var userModel = _authenticationRepository.Login(user);

            return userModel != null ? _mapper.Map<UserDto>(userModel) : null;
        }

        public void RegisterNewUser(RegisterUserDto user)
        {
           if (user == null) throw new ArgumentNullException("user");

            var newUser = _mapper.Map<UserModel>(user);
            _authenticationRepository.RegisterNewUser(newUser);
        }
    }
}
