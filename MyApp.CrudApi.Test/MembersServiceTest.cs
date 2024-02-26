using AutoFixture;
using FluentAssertions;
using FluentAssertions.Equivalency;
using Moq;
using MyApp.CrudApi.Domain.IRepository;
using MyApp.CrudApi.Domain.Models;
using MyApp.CrudApi.Services.Services;
using Newtonsoft.Json.Linq;
using System;

namespace MyApp.CrudApi.Test
{
    public class MembersServiceTest
    {
        private readonly MemberServices _memberService;
        private readonly Mock<IMembersRepository> _membersRepositoryMock;
        private readonly Fixture autoFixture;

        public MembersServiceTest()
        {
            _membersRepositoryMock = new Mock<IMembersRepository>();

            _memberService = new MemberServices(_membersRepositoryMock.Object);
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
        public void GetByIdl_ShouldThrowException_WhenIdIsNotVaid()
        {
            // Arrange
            var id = 0;

            // act
            Action action = () => _memberService.GetById(id);

            // assert
            action.Should().Throw<ArgumentNullException>();

        }

        [Fact]
        public void GetByIdl_ShouldReturnMember_WhenIdIsValid()
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
    }
}