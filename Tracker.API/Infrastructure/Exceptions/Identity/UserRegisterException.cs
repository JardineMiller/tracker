using System.Collections.Generic;
using System.Net;
using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;
using Tracker.API.Infrastructure.Exceptions.Models;

namespace Tracker.API.Infrastructure.Exceptions.Identity
{
    public class UserRegisterException : HandledHttpResponseException
    {
        private readonly IEnumerable<IdentityError> _errors;

        public UserRegisterException(IEnumerable<IdentityError> errors)
        {
            this._errors = errors;
        }

        public override ExceptionHttpResponse CreateResponse()
        {
            return new ExceptionHttpResponse
            {
                StatusCode = HttpStatusCode.BadRequest,
                ResultMessage = JsonConvert.SerializeObject(this._errors)
            };
        }
    }
}