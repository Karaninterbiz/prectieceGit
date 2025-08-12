using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialModule.Contracts.DTOs
{
    public class InvoiceDto
    {
        public Guid InvoiceId { get; set; }
        public string? GatewayInvoiceId { get; set; }
        public decimal? TotalAmount { get; set; }
        public string? InvoiceStatus { get; set; }
        public DateTime? InvoiceDueDate { get; set; }
        public string? BillingPlanName { get; set; }
        public Guid BusinessUnitId { get; set; }
        public string? BusinessUnitName { get; set; }
        public string? Description { get; set; }
        public DateTime BillingYear { get; set; }
        public string BillingPeriod { get; set; }
        public int BillingPeriodNumber { get; set; }
        public DateTime GenerationDateTime { get; set; }

    }
}
