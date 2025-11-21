using VIRS.Domain.Core._CommentAgg.Entities;

namespace VIRS.Domain.Core.SystemAdminAgg.Entities
{
    public class SystemAdmin : BaseEntity
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
