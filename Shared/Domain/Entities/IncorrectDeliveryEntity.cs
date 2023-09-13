using Bondlog.Server.Domain;

namespace Bondlog.Shared.Domain.Entities
{
    public class IncorrectDeliveryEntity : AuditableEntity
    {
        public string? TransactionReference { get; set; }
        public string? Contract { get; set; }
        public string? Site { get; set; }
        public string? Department { get; set; }
        public string? DeliveryReference { get; set; }
        public string? PurchaseOrderReference { get; set; }
        public string? Type { get; set; }
        public string? Supplier { get; set; }
        public string? ExpectedSku { get; set; }
        public string? ExpectedQty { get; set; }
        public string? ReceivedSku { get; set; }
        public string? ReceivedQty { get; set;}
        public string? Escalation { get; set; }
        public string? PlannerName { get; set; }
        public string? Details { get; set; }
        public string? WorkAround { get; set;}
        public string? CurrentAction { get; set; }
    }
}