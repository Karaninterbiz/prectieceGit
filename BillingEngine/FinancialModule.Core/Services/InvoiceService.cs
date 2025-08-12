using FinancialModule.Contracts.DTOs;
using FinancialModule.Contracts.Repositories;

namespace FinancialModule.Core.Services
{
    public class InvoiceService
    {
        private readonly IInvoiceRepository _invoiceRepository;

        public InvoiceService(IInvoiceRepository invoiceRepository)
        {
            _invoiceRepository = invoiceRepository;
        }

        public async Task<IEnumerable<InvoiceDto>> GetAllInvoicesAsync()
        {
            return await _invoiceRepository.GetAllInvoicesAsync();
        }

        public async Task<InvoiceDto?> GetInvoiceByIdAsync(Guid id)
        {
            return await _invoiceRepository.GetInvoiceByIdAsync(id);
        }
    }
}
