using System.Collections.Generic;
using FluentValidation.Results;
using Microsoft.Extensions.Logging;
using Moq;
using Newtonsoft.Json;
using Tracker.API.Infrastructure.Exceptions;
using Tracker.Tests.Helpers;
using Xunit;

namespace Tracker.Tests.API.Infrastructure.Exceptions;

public class ExceptionLoggerTests
{
    [Fact]
    public void Exception_Logger_Logs_For_NotFoundException()
    {
        // Arrange
        var loggerMock = new Mock<ILogger<ExceptionLogger>>();
        var sut = new ExceptionLogger(loggerMock.Object);
        var exception = new NotFoundException("entity", "id");

        // Act
        sut.LogException(exception);

        // Assert
        loggerMock.VerifyLogging(
            $"[{nameof(NotFoundException)}] occurred: [{exception.Message}]",
            LogLevel.Warning,
            Times.Once()
        );
    }

    [Fact]
    public void Exception_Logger_Logs_For_ValidationException()
    {
        // Arrange
        var loggerMock = new Mock<ILogger<ExceptionLogger>>();
        var sut = new ExceptionLogger(loggerMock.Object);
        var exception = new ValidationException(
            new List<ValidationFailure>
            {
                new("userId", "userId error message")
            }
        );

        // Act
        sut.LogException(exception);

        // Assert
        loggerMock.VerifyLogging(
            $"[{nameof(ValidationException)}] occurred: [{JsonConvert.SerializeObject(exception.Failures)}]",
            LogLevel.Warning,
            Times.Once()
        );
    }
}