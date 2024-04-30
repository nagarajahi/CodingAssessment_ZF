using CodingAssessment.Middleware;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Moq;
using System.Net;

namespace CodingAssessmentUnitTest.Middleware
{
    public class ExceptionMiddlewareTests
    {
        [Fact]
        public async Task Invoke_NoException_CallsNextMiddleware()
        {
            // Arrange
            var nextCalled = false;
            var context = new DefaultHttpContext();
            var middleware = new ExceptionMiddleware((innerHttpContext) =>
            {
                nextCalled = true;
                return Task.CompletedTask;
            }, Mock.Of<ILogger<ExceptionMiddleware>>());

            // Act
            await middleware.Invoke(context);

            // Assert
            Assert.True(nextCalled);
            Assert.Equal((int)HttpStatusCode.OK, context.Response.StatusCode);
        }

        [Fact]
        public async Task Invoke_Exception_LogsErrorAndReturnsInternalServerError()
        {
            // Arrange
            var exceptionMessage = "Test exception message";
            var context = new DefaultHttpContext();
            var responseBodyStream = new MemoryStream();
            context.Response.Body = responseBodyStream;

            var middleware = new ExceptionMiddleware((innerHttpContext) =>
            {
                throw new Exception(exceptionMessage);
            }, Mock.Of<ILogger<ExceptionMiddleware>>());

            // Act
            await middleware.Invoke(context);

            // Reset the position of the response body stream
            responseBodyStream.Seek(0, SeekOrigin.Begin);

            var responseContent = await new StreamReader(responseBodyStream).ReadToEndAsync();

            // Assert
            Assert.Equal(exceptionMessage, responseContent);
        }
    }


}
