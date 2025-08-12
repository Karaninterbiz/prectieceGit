using FinancialModule.Contracts.DTOs;
using FinancialModule.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace BillingEngine.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoicesController : ControllerBase
    {
        private readonly InvoiceService _invoiceService;

        public InvoicesController(InvoiceService invoiceService)
        {
            _invoiceService = invoiceService;
        }

        /// <summary>
        /// Get all invoices
        /// </summary>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<InvoiceDto>), 200)]
        public async Task<IActionResult> GetAll()
        {
            var invoices = await _invoiceService.GetAllInvoicesAsync();
            return Ok(invoices);
        }

        /// <summary>
        /// Get invoice by ID
        /// </summary>
        [HttpGet("{id:guid}")]
        [ProducesResponseType(typeof(InvoiceDto), 200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetById(Guid id)
        {
            var invoice = await _invoiceService.GetInvoiceByIdAsync(id);
            if (invoice == null)
                return NotFound();

            return Ok(invoice);
        }
    }
}
