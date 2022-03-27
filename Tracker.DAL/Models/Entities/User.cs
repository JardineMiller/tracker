using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using Tracker.DAL.Models.Base;

namespace Tracker.DAL.Models.Entities
{
    public class User : IdentityUser, IAuditableEntity
    {
        public List<Task> Tasks { get; } = new();
        public List<RefreshToken> RefreshTokens { get; } = new();

        public DateTimeOffset CreatedOn { get; set; }
        public DateTimeOffset? ModifiedOn { get; set; }
    }
}