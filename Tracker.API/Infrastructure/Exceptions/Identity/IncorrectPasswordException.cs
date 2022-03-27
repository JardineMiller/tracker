using System.Net;
using Tracker.API.Infrastructure.Exceptions.Models;

namespace Tracker.API.Infrastructure.Exceptions.Identity
{
    public class IncorrectPasswordException : HandledHttpResponseException
    {
        public IncorrectPasswordException(string message) : base(message)
        {
        }

        public override ExceptionHttpResponse CreateResponse()
        {
            return new ExceptionHttpResponse
            {
                StatusCode = HttpStatusCode.Unauthorized,
                ResultMessage = this.Message
            };
        }
    }
}