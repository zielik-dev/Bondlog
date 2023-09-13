namespace Bondlog.Shared.Domain.Models
{
    public class UserSessionModel
    {
        public string? Username { get; set; }
        public string? Role { get; set; }
        public string? Token { get; set; }
        public string? ErrorMessage { get; set; }
        public bool Successful { get; set; }
    }
}