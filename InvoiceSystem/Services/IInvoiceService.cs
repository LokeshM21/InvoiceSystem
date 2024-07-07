using System.Collections.Generic;
using InvoiceSystem.Models;

namespace InvoiceSystem.Services
{
    public interface IInvoiceService
    {
        Invoice GetInvoice(int id);
        Invoice CreateInvoice(decimal amount, DateTime dueDate);
        IEnumerable<Invoice> GetAllInvoices();
        void MakePayment(Payment payment);
        void ProcessOverdueInvoices(decimal lateFee, int overdueDays);
    }
}