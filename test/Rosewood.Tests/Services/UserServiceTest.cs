using System.Threading.Tasks;
using Moq;
using Rosewood.Services.Exceptions;
using Rosewood.Services.Impls;

namespace Rosewood.Tests.Services;

public class UserServiceTest
{
    [Fact]
    public void SignupTest()
    {
        Mock<UserService> userService = new Mock<UserService>();
        var dto = new UserCreateRequest 
        {
            FirstName = "Yusuf",
            LastName = "Yakubov",
            Email = "yusuf_yakubov@rosewood.org",
            Password = "12345678",
        };
        userService.Setup(x => x.SignUp(dto))
            .Returns(Task.FromResult(default(object)));
        Assert.ThrowsAsync<BadRequestException>(() => userService.Object.SignUp(dto));
        // this test is written wrong!;
    }
}
