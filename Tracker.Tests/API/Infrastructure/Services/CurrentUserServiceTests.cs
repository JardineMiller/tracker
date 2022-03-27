using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Moq;
using Shouldly;
using Tracker.API.Infrastructure.Services;
using Xunit;

namespace Tracker.Tests.API.Infrastructure.Services;

public class CurrentUserServiceTests
{
    private readonly ICurrentUserService _currentUserService;

    public CurrentUserServiceTests()
    {
        var mockHttpContextAccessor = new Mock<IHttpContextAccessor>();
        var context = new DefaultHttpContext
        {
            User = new ClaimsPrincipal(
                new ClaimsIdentity(
                    new Claim[]
                    {
                        new(ClaimTypes.Name, "Mock User"),
                        new(ClaimTypes.NameIdentifier, "0001")
                    },
                    "mock"
                )
            )
        };

        mockHttpContextAccessor.Setup(contextAccessor => contextAccessor.HttpContext)
            .Returns(context);

        this._currentUserService = new CurrentUserService(mockHttpContextAccessor.Object);
    }

    [Fact]
    public void Returns_UserId()
    {
        // Act
        var result = this._currentUserService.GetId();

        // Assert
        result.ShouldBe("0001");
    }

    [Fact]
    public void Returns_User_Name()
    {
        // Act
        var result = this._currentUserService.GetUserName();

        // Assert
        result.ShouldBe("Mock User");
    }

    [Fact]
    public void Returns_IsAuthenticated()
    {
        // Act
        var result = this._currentUserService.IsAuthenticated();

        // Assert
        result.ShouldBe(true);
    }

    [Fact]
    public void Returns_IsNotAuthenticated()
    {
        // Arrange
        var mockHttpContextAccessor = new Mock<IHttpContextAccessor>();
        var context = new DefaultHttpContext();

        mockHttpContextAccessor.Setup(contextAccessor => contextAccessor.HttpContext)
            .Returns(context);

        var currentUserService = new CurrentUserService(mockHttpContextAccessor.Object);

        // Act
        var result = currentUserService.IsAuthenticated();

        // Assert
        result.ShouldBe(false);
    }
}