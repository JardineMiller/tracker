using System.Net;
using Tracker.API.Infrastructure.Exceptions.Models;

namespace Tracker.API.Infrastructure.Exceptions.Identity
{
    public class ExpiredTokenException : HandledHttpResponseException
    {
        public ExpiredTokenException(string message) : base(message)
        {
        }

        public override ExceptionHttpResponse CreateResponse()
        {
            return new ExceptionHttpResponse
            {
                StatusCode = HttpStatusCode.Unauthorized,
                ResultMessage = "Your login has expired. Please sign in again."
            };
        }
    }
}