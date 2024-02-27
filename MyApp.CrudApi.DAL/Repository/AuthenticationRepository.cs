using Microsoft.Extensions.Configuration;
using MyApp.CrudApi.Domain.IRepository;
using MyApp.CrudApi.Domain.Models;
using Newtonsoft.Json;

namespace MyApp.CrudApi.DAL.Repository
{
    public class AuthenticationRepository : IAuthenticationRepository
    {
        private readonly JsonSerializerSettings _options = new() { NullValueHandling = NullValueHandling.Ignore };
        private readonly IConfiguration _configuration;
        private readonly string _usersDataPath;

        public AuthenticationRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            var workingDirectory = Directory.GetCurrentDirectory();
            var basePath = Directory.GetParent(workingDirectory).FullName;
            _usersDataPath = basePath + _configuration["UsersData"];
        }

        public UserModel Login(UserModel user)
        {
            var reader = new StreamReader(_usersDataPath);
            var json = reader.ReadToEnd();
            reader.Close();
            var userList = JsonConvert.DeserializeObject<List<UserModel>>(json);
            return userList.FirstOrDefault(u => u.Username == user.Username && u.Password == user.Password);
        }

        public void RegisterNewUser(UserModel user)
        {
            var reader = new StreamReader(_usersDataPath);
            var json = reader.ReadToEnd();
            reader.Close();
            var userList = JsonConvert.DeserializeObject<List<UserModel>>(json);

            if (userList is not null)
            {
                user.Id = userList.Count + 1;
                userList.Add(user);
                var jsonString = JsonConvert.SerializeObject(userList, Formatting.Indented, _options);
                File.WriteAllText(_usersDataPath, jsonString);
            }
        }
    }
}
