using System.ComponentModel.DataAnnotations;

namespace Bondlog.Shared.Domain.Entities
{
    public class AspNetUserRolesEntity
    {
        public string? UserId { get; set; }
        public string? RoleId { get; set; }

    }
}
