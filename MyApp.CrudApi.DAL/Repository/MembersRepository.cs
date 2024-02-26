using Microsoft.Extensions.Configuration;
using MyApp.CrudApi.Domain.IRepository;
using MyApp.CrudApi.Domain.Models;
using Newtonsoft.Json;

namespace MyApp.CrudApi.DAL.Repository
{
    public class MembersRepository : IMembersRepository
    {
        private readonly JsonSerializerSettings _options
        = new() { NullValueHandling = NullValueHandling.Ignore };
        private readonly IConfiguration _configuration;
        private readonly string _membersDataPath;

        public MembersRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            var basePath = Environment.CurrentDirectory;
            _membersDataPath = basePath + _configuration["MembersData"];
        }

        public void Delete(MemberModel member)
        {
            var reader = new StreamReader(_membersDataPath);
            var json = reader.ReadToEnd();
            reader.Close();
            var memberList = JsonConvert.DeserializeObject<List<MemberModel>>(json);

            if (memberList is not null)
            {
                var memberToDelete = memberList.FirstOrDefault(m => m.Id == member.Id);
                if (memberToDelete is not null)
                {
                    var index = memberList.IndexOf(memberToDelete);

                    if (index != -1)
                    {
                        memberList.Remove(memberToDelete);
                        var jsonString = JsonConvert.SerializeObject(memberList, Formatting.Indented, _options);
                        File.WriteAllText(_membersDataPath, jsonString);
                    }
                }
            }
        }

        public List<MemberModel> GetAll()
        {
            var reader = new StreamReader(_membersDataPath);
            var json = reader.ReadToEnd();
            reader.Close();
            return JsonConvert.DeserializeObject<List<MemberModel>>(json);
        }

        public MemberModel GetById(int id)
        {
            var reader = new StreamReader(_membersDataPath);
            var json = reader.ReadToEnd();
            reader.Close();
            var memberList = JsonConvert.DeserializeObject<List<MemberModel>>(json);
            return memberList.FirstOrDefault(m => m.Id == id);
        }

        public void Insert(MemberModel member)
        {
            var reader = new StreamReader(_membersDataPath);
            var json = reader.ReadToEnd();
            reader.Close();
            var memberList = JsonConvert.DeserializeObject<List<MemberModel>>(json);

            if (memberList is not null)
            {
                memberList.Add(member);
                var jsonString = JsonConvert.SerializeObject(memberList, Formatting.Indented, _options);
                File.WriteAllText(_membersDataPath, jsonString);
            }
        }

        public void Update(MemberModel member)
        {
            var reader = new StreamReader(_membersDataPath);
            var json = reader.ReadToEnd();
            reader.Close();
            var memberList = JsonConvert.DeserializeObject<List<MemberModel>>(json);

            if (memberList is not null)
            {
                var memberToEdit = memberList.FirstOrDefault(m => m.Id == member.Id);
                if (memberToEdit is not null)
                {
                    var index = memberList.IndexOf(memberToEdit);

                    if (index != -1)
                    {
                        memberList[index] = member;
                        var jsonString = JsonConvert.SerializeObject(memberList, Formatting.Indented, _options);
                        File.WriteAllText(_membersDataPath, jsonString);
                    } 
                }
            }
        }
    }
}
