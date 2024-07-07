using System.Collections.Generic;
using System.Linq;
using InvoiceSystem.Models;
using InvoiceSystem.Enums;

namespace InvoiceSystem.Services
{
    public class InvoiceService : IInvoiceService
    {
        private List<Invoice> _invoices = new List<Invoice>();

        public Invoice CreateInvoice(decimal amount, DateTime dueDate)
        {
            var invoice = new Invoice
            {
                Id = _invoices.Count + 1,
                Amount = amount,
                DueDate = dueDate,
                Status = InvoiceStatus.Pending
            };
            _invoices.Add(invoice);
            return invoice;
        }

        public IEnumerable<Invoice> GetAllInvoices()
        {
            return _invoices;
        }

        public void MakePayment(Payment payment)
        {
            var invoice = _invoices.FirstOrDefault(i => i.Id == payment.InvoiceId);
            if (invoice != null)
            {
                invoice.PaidAmount += payment.Amount;
                if (invoice.IsFullyPaid)
                {
                    invoice.MarkAsPaid();
                }
            }
        }

        public Invoice GetInvoice(int id)
        {
            var invoice = (from i in _invoices
                           where i.Id == id
                           select i).FirstOrDefault();
            return invoice;
        }

        public void ProcessOverdueInvoices(decimal lateFee, int overdueDays)
        {
            foreach (var invoice in _invoices)
            {
                if (invoice.IsOverdue)
                {
                    if (invoice.PaidAmount > 0)
                    {
                        var remainingAmount = invoice.Amount - invoice.PaidAmount;
                        var newInvoice = CreateInvoice(remainingAmount + lateFee, invoice.DueDate.AddDays(overdueDays));
                        invoice.MarkAsPaid();
                    }
                    else
                    {
                        var newInvoice = CreateInvoice(invoice.Amount + lateFee, invoice.DueDate.AddDays(overdueDays));
                        invoice.MarkAsVoid();
                    }
                }
            }
        }
    }
}