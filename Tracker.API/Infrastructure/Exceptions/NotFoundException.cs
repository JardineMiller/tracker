using System.Net;
using Tracker.API.Infrastructure.Exceptions.Models;

namespace Tracker.API.Infrastructure.Exceptions
{
    public class NotFoundException : HandledHttpResponseException
    {
        public NotFoundException(string name, int id) : base($"Could not find {name} with Id {id}")
        {
        }

        public NotFoundException(string name, string id) : base(
            $"Could not find {name} with Id {id}"
        )
        {
        }

        public override ExceptionHttpResponse CreateResponse()
        {
            return new ExceptionHttpResponse
            {
                StatusCode = HttpStatusCode.NotFound,
                ResultMessage = this.Message
            };
        }
    }
}