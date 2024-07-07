using InvoiceSystem.Enums;
using System;
using static InvoiceSystem.Enums.InvoiceStatus;

namespace InvoiceSystem.Models
{
    public class Invoice
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public DateTime DueDate { get; set; }
        public decimal PaidAmount { get; set; }
        public InvoiceStatus Status { get; set; }

        public bool IsOverdue => DateTime.Now > DueDate;
        public bool IsFullyPaid => PaidAmount >= Amount;

        public void MarkAsPaid()
        {
            Status = InvoiceStatus.Paid;
        }

        public void MarkAsVoid()
        {
            Status = InvoiceStatus.Void;
        }
    }
}