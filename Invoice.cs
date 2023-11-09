using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ATScompanySpace
{
    public class Invoice
    {
        bool isPaid;

        public DateTime InvoiceDate { get; set; } // Дата выставления счета
        public DateTime DueDate { get; set; } // Дата, до которой необходимо оплатить счет
        public decimal Amount { get; set; }
        public bool IsPaid
        {
            get { return (Amount - PaidAmount == 0); }
            set { isPaid = value; }
        }
        public decimal PaidAmount { get; set; }
        public string ClientId { get; set; }

        [JsonConstructor]
        public Invoice(DateTime invoiceDate, DateTime dueDate, decimal amount, decimal paidAmount, bool isPaid, string clientId)
        {
            InvoiceDate = invoiceDate;
            DueDate = dueDate;
            Amount = amount;
            PaidAmount = paidAmount;
            IsPaid = isPaid;
            ClientId = clientId;

            if (!IsDuplicateInvoice(this))
            {
                ATScompany.Instance.AddInvoice(this);
                Client existingClient = ATScompany.Instance.FindClientById(ClientId)!;
                existingClient.Invoices.Add(this);
            }
        }
        private bool IsDuplicateInvoice(Invoice newCall)
        {
            foreach (var existingInvoice in ATScompany.Instance.Invoices)
            {
                if (existingInvoice.ClientId == this.ClientId)
                {
                    return true;
                }
            }
            return false;
        }
        public Invoice(DateTime invoiceDate, DateTime dueDate, decimal amount, string clientId)
        {
            InvoiceDate = invoiceDate;
            DueDate = dueDate;
            Amount = amount;
            ClientId = clientId;
            IsPaid = false;
            PaidAmount = 0;


            Client? existingClient = ATScompany.Instance.FindClientById(ClientId);

            if (existingClient != null)
            {
                if (existingClient.Overpayment > 0)
                {
                    decimal remainingPayment = amount - existingClient.Overpayment;
                    if (remainingPayment <= 0)
                    {
                        IsPaid = true;
                        PaidAmount = amount;
                        existingClient.Overpayment -= amount;
                    }
                    else
                    {
                        IsPaid = false;
                        PaidAmount = 0;
                    }
                }
            }
            else
            {
                Console.WriteLine("Клиент с указанным идентификатором не найден");
            }
        }

        public override string ToString()
        {
            return $"Счет клиента {ClientId} от {InvoiceDate:dd.MM.yyyy} на сумму {(Amount - PaidAmount):C} {(IsPaid ? "оплачен" : "не оплачен")}";
        }

        public static decimal CalculateLateFee(List<Invoice> Invoices)
        {
            decimal lateFee = 0;
            foreach (Invoice invoice in Invoices)
            {
                if (!invoice.IsPaid && DateTime.Now > invoice.DueDate)
                {
                    TimeSpan overdueDays = DateTime.Now - invoice.DueDate;
                    lateFee += invoice.Amount * (decimal)(overdueDays.TotalDays * 0.01);
                }
            }
            return lateFee;
        }
    }
}
