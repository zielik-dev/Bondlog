namespace Bondlog.Server.Domain
{
    public class AuditableEntity
    {
        public int Id { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string? InactivatedBy { get; set; }
        public DateTime? InactivatedDate { get; set; }
        public int? StatusId { get; set; }  //0 off, 1 on
    }
}