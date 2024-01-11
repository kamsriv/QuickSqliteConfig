namespace quicktests
{
    using Moq;
    using Moq.EntityFrameworkCore;
    using Xunit;
    using Quickapp_del.DataModel;
    using Microsoft.EntityFrameworkCore;
    using Quickapp_del.Modal;
    using Quickapp_del.Controllers;
    [TestFixture]
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
            System.Diagnostics.Debugger.Launch();
        }

        [Fact]
        public void FirstTest()
        {
            Assert.Equal(1, 1.0);
        }

        [Fact]
        public async Task GetAllUsers_returnUsers()
        {
            //Arrange
            var userCtx = new Mock<DBConnect>();
            userCtx.Setup(c => c.People).ReturnsDbSet(GetFakeEmployeeList());
            userCtx.Setup(c => c.Addresses).ReturnsDbSet(GetFakeMailingAddresses());

            //Act
            WeatherForecastController ct = new(userCtx.Object);
            var people = ct.GetPeople();

            //Assert
            Assert.True(people.Any());
        }
        private static IEnumerable<Person> GetFakeEmployeeList()
        {
            return new List<Person>()
    {
        new Person
        {
            Id = 1,
            Name = "John Doe",
            Address = new MailingAddress(){ Id = 1, City = "Seattle", State = "CA"},
            Age = 10,
            EmailId = "john@example"
        },
        new Person
        {
            Id = 2,
            Name = "Mark Luther",
            EmailId = "M.L@gmail.com",
            Address = new MailingAddress() { Id=1, City = "Washington", State = "LA"},
            Age = 12
        }
    };
        }
        private static IEnumerable<MailingAddress> GetFakeMailingAddresses()
        {
            return new List<MailingAddress> { new MailingAddress { Id = 1, City = "Hyderabad", State = "Telangana", Country = "India", ZipCode = "501301" }};
        }
    }
}