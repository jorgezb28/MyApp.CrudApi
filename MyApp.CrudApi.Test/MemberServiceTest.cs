using AutoFixture;
using AutoMapper;
using FluentAssertions;
using Moq;
using MyApp.CrudApi.Domain.DTOs;
using MyApp.CrudApi.Domain.IRepository;
using MyApp.CrudApi.Domain.Models;
using MyApp.CrudApi.Services.Mapping;
using MyApp.CrudApi.Services.Services;

namespace MyApp.CrudApi.Test
{
    public class MemberServiceTest
    {
        private readonly MemberServices _memberService;
        private readonly Mock<IMembersRepository> _membersRepositoryMock;
        private readonly IMapper _mapper;
        private readonly Fixture autoFixture;

        public MemberServiceTest()
        {
            _membersRepositoryMock = new Mock<IMembersRepository>();
            _mapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MapperProfile());
            }).CreateMapper();

            _memberService = new MemberServices(_membersRepositoryMock.Object,_mapper);
            autoFixture = new Fixture();
        }

        [Fact]
        public void GetAll_ShouldReturnMemnbers()
        {
            // Arrange
            var members = autoFixture.CreateMany<MemberModel>(3).ToList();
            _membersRepositoryMock.Setup(x => x.GetAll()).Returns(members);


            // Act
            var result = _memberService.GetAll();


            //Assert
            result.Should().BeEquivalentTo(members);
            
        }

        [Fact]
        public void GetByIdl_ShouldThrowException_WhenIdIsNotValid()
        {
            // Arrange
            var id = 0;

            // act
            Action action = () => _memberService.GetById(id);

            // assert
            action.Should().Throw<ArgumentNullException>();

        }

        [Fact]
        public void GetById_ShouldReturnMember_WhenIdIsValid()
        {
            // Arrange
            var id = 2;
            var member = autoFixture.Create<MemberModel>();
            member.Id = id;
            _membersRepositoryMock.Setup(x => x.GetById(id)).Returns(member);

            // act
           var result = _memberService.GetById(id);

            // assert
            result.Should().BeEquivalentTo(member);
        }

        [Fact]
        public void Insertl_ShouldThrowException_WhenIMemberdIsNotValid()
        {
            // Arrange
           

            // act
            Action action = () => _memberService.Insert(null);

            // assert
            action.Should().Throw<ArgumentNullException>();

        }

        [Fact]
        public void Insert_ShouldInsertMember()
        {
            // Arrange
            var memberDto = autoFixture.Create<MemberDto>();
            _membersRepositoryMock.Setup(x => x.Insert(It.IsAny<MemberModel>()));

            // act
            _memberService.Insert(memberDto);

            // assert
            _membersRepositoryMock.Verify(x => x.Insert(It.IsAny<MemberModel>()), Times.Once);
        }

        // TODO: Add missing tests
    }
}