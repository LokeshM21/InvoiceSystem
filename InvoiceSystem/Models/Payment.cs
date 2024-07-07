using System;

namespace InvoiceSystem.Models
{
    public class Payment
    {
        public int InvoiceId { get; set; }
        public decimal Amount { get; set; }
    }
}