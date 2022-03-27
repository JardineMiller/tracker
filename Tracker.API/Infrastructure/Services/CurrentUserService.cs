using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Tracker.API.Infrastructure.Extensions;

namespace Tracker.API.Infrastructure.Services
{
    public interface ICurrentUserService
    {
    }

    public class CurrentUserService : ICurrentUserService
    {
        private readonly ClaimsPrincipal _user;

        public CurrentUserService(IHttpContextAccessor httpContextAccessor)
        {
            this._user = httpContextAccessor.HttpContext?.User;
        }

        public bool IsAuthenticated()
        {
            return this._user?.Identity?.IsAuthenticated ?? false;
        }

        public string GetUserName()
        {
            return this._user?.Identity?.Name;
        }

        public string GetId()
        {
            return this._user?.GetUsername();
        }
    }
}