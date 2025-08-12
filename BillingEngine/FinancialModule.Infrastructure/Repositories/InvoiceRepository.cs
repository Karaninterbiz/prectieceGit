using FinancialModule.Contracts.DTOs;
using FinancialModule.Contracts.Repositories;
using FinancialModule.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialModule.Infrastructure.Repositories
{
    public class InvoiceRepository : IInvoiceRepository
    {
        private readonly FinancialDbContext _context;

        public InvoiceRepository(FinancialDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<InvoiceDto>> GetAllInvoicesAsync()
        {
            return await _context.Invoices
                .Include(i => i.BillingPlan)
                .Include(i => i.BusinessUnit)
                .Select(i => new InvoiceDto
                {
                    InvoiceId = i.InvoiceId,
                    BusinessUnitId = i.BusinessUnitId ?? Guid.Empty,
                    GatewayInvoiceId = i.GatewayInvoiceId,
                    TotalAmount = i.TotalAmount,
                    InvoiceStatus = i.InvoiceStatus,
                    InvoiceDueDate = i.InvoiceDueDate,
                    BillingPlanName = i.BillingPlan != null ? i.BillingPlan.Name : null,
                    BusinessUnitName = i.BusinessUnit != null ? i.BusinessUnit.BusinessTypeName : null,
                    BillingPeriod = i.BillingPeriod,
                    BillingYear = i.PaymentDate ?? DateTime.Today,
                    BillingPeriodNumber = i.BillingPeriodNumber ?? 0,
                    GenerationDateTime = i.GeneratedDateTime ?? DateTime.UtcNow,
                    Description = i.Description
                })
                .ToListAsync();
        }

        public async Task<InvoiceDto?> GetInvoiceByIdAsync(Guid id)
        {
            return await _context.Invoices
                .Include(i => i.BillingPlan)
                .Include(i => i.BusinessUnit)
                .Where(i => i.InvoiceId == id)
                .Select(i => new InvoiceDto
                {
                    InvoiceId = i.InvoiceId,
                    BusinessUnitId = i.BusinessUnitId ?? Guid.Empty,
                    GatewayInvoiceId = i.GatewayInvoiceId,
                    TotalAmount = i.TotalAmount,
                    InvoiceStatus = i.InvoiceStatus,
                    InvoiceDueDate = i.InvoiceDueDate,
                    BillingPlanName = i.BillingPlan != null ? i.BillingPlan.Name : null,
                    BusinessUnitName = i.BusinessUnit != null ? i.BusinessUnit.BusinessTypeName : null,
                    BillingPeriod = i.BillingPeriod,
                    BillingYear = i.PaymentDate ?? DateTime.Today,
                    BillingPeriodNumber = i.BillingPeriodNumber ?? 0,
                    GenerationDateTime = i.GeneratedDateTime ?? DateTime.UtcNow,
                    Description = i.Description
                })
                .FirstOrDefaultAsync();
        }
    }
}
