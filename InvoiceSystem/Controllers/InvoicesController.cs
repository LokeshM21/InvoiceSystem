using Microsoft.AspNetCore.Mvc;
using InvoiceSystem.Models;
using InvoiceSystem.Services;

namespace InvoiceSystem.Controllers
{
  
    [ApiController]
    [Route("api/[controller]")]
    public class InvoicesController : ControllerBase
    {
        private readonly IInvoiceService _invoiceService;

        public InvoicesController(IInvoiceService invoiceService)
        {
            _invoiceService = invoiceService;
        }

        [HttpGet("{id}")]
        public IActionResult GetInvoice(int id)
        {
            var invoice = _invoiceService.GetInvoice(id);
            if (invoice == null)
            {
                return NotFound();
            }
            return Ok(invoice);
        }

        [HttpPost]
        public IActionResult CreateInvoice([FromBody] decimal amount, [FromBody] DateTime dueDate)
        {
            var invoice = _invoiceService.CreateInvoice(amount, dueDate);
            return CreatedAtAction(nameof(GetInvoice), new { id = invoice.Id }, invoice);
        }

     

        [HttpGet]
        public IActionResult GetAllInvoices()
        {
            var invoices = _invoiceService.GetAllInvoices();
            return Ok(invoices);
        }

        [HttpPost("{id}/payments")]
        public IActionResult MakePayment(int id, [FromBody] decimal amount)
        {
            var payment = new Payment { InvoiceId = id, Amount = amount };
            _invoiceService.MakePayment(payment);
            return Ok("Payment successful");
        }

        [HttpPost("process-overdue")]
        public IActionResult ProcessOverdueInvoices([FromBody] decimal lateFee, [FromBody] int overdueDays)
        {
            _invoiceService.ProcessOverdueInvoices(lateFee, overdueDays);
            return Ok("Overdue invoices processed");
        }
    }
}