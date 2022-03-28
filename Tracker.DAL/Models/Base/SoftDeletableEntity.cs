using System;

namespace Tracker.DAL.Models.Base
{
    public interface ISoftDeletable
    {
        public bool IsDeleted { get; set; }
        public DateTimeOffset? DeletedOn { get; set; }
    }

    public class SoftDeletableEntity : AuditableEntity, ISoftDeletable
    {
        public bool IsDeleted { get; set; }
        public DateTimeOffset? DeletedOn { get; set; }
    }
}