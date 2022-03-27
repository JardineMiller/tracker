using System.Net;

namespace Tracker.API.Infrastructure.Exceptions.Models
{
    public class ExceptionHttpResponse
    {
        public string ResultMessage { get; set; }
        public HttpStatusCode StatusCode { get; set; }
    }
}