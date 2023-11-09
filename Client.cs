using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ATScompanySpace
{
    public class Client
    {
        private string login = "";
        private string password = "";
        private string id = "";
        private string name = "";
        private string address = "";
        private DateTime birthDate;
        private decimal debt = 0;
        private decimal overpayment = 0;

        [JsonIgnore]
        public List<Call> CallHistory { get; set; }

        [JsonIgnore]
        public List<Invoice> Invoices { get; set; }
        public string PhoneNumber { get; private set; }
        public static int NextClientId { get; private set; } = 1;
        public DateTime LastInvoiceDate { get; set; }

        public string Login { get; private set; }
        public string Password { get; private set; }
        public string Id
        {
            get { return id; }
            private set { id = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Address
        {
            get { return address; }
            set { address = value; }
        }

        public DateTime BirthDate
        {
            get { return birthDate; }
            set { birthDate = value; }
        }

        public decimal Debt
        {
            get
            {
                decimal unpaidInvoicesDebt = Invoices.Where(i => !i.IsPaid).Sum(i => i.Amount - i.PaidAmount);
                decimal overdueInterestDebt = Invoice.CalculateLateFee(Invoices);
                return unpaidInvoicesDebt + overdueInterestDebt;
            }
            set { debt = value; }
        }

        public decimal Overpayment
        {
            get { return overpayment; }
            set { overpayment = value; }
        }


        [JsonConstructor]
        public Client(string login, string password, string id, string name, string address, string phoneNumber, DateTime birthDate, decimal debt,
            decimal overpayment, DateTime lastInvoiceDate)
        {
            Login = login;
            Password = password;
            Id = id;
            Name = name;
            Address = address;
            PhoneNumber = phoneNumber;
            BirthDate = birthDate;
            Debt = debt;
            Overpayment = overpayment;
            CallHistory = new List<Call>();
            Invoices = new List<Invoice>();
            LastInvoiceDate = lastInvoiceDate;
            ATScompany.Instance.AddClient(this);

        }
        public Client()
        {
            Id = GenerateUniqueClientId();
            PhoneNumber = GeneratePhoneNumber(int.Parse(Id));
            LastInvoiceDate = DateTime.Today.AddDays(-1);

            Console.Write("Введите имя -> ");
            Name = Console.ReadLine();

            Console.Write("Введите адрес -> ");
            Address = Console.ReadLine();

            Console.Write("Введите дату рождения (гггг.мм.дд) -> ");
            BirthDate = Convert.ToDateTime(Console.ReadLine());

            Login = PhoneNumber;
            Console.WriteLine($"Ваш номер телефона {PhoneNumber} будет использован как логин");
            Console.Write("Придумайте пароль -> ");
            Password = Console.ReadLine();

            CallHistory = new List<Call>();
            Invoices = new List<Invoice>();
        }

        public Client(string name, string address, DateTime birthDate, string password)
        {
            Id = GenerateUniqueClientId();
            PhoneNumber = GeneratePhoneNumber(int.Parse(Id));
            LastInvoiceDate = DateTime.Today.AddDays(-1);

            Name = name;
            Address = address;
            BirthDate = birthDate;
            Login = PhoneNumber;
            Password = password;
            CallHistory = new List<Call>();
            Invoices = new List<Invoice>();
        }

        private string GenerateUniqueClientId()
        {
            string newClientId;

            do
            {
                newClientId = GenerateRandomClientId();
            }
            while (ClientIdExists(newClientId));

            return newClientId;
        }

        private string GenerateRandomClientId()
        {
            Random random = new Random();
            const string chars = "0123456789";
            return new string(Enumerable.Repeat(chars, 6).Select(s => s[random.Next(s.Length)]).ToArray());
        }

        private bool ClientIdExists(string clientId)
        {
            return ATScompany.Instance.Clients.Any(client => client.Id == clientId);
        }

        private string GeneratePhoneNumber(int clientId)
        {
            return $"8-0152-{clientId:D6}";
        }

        public override string ToString()
        {
            return $"Клиент: {Name}, \nТелефон: {PhoneNumber}, \nАдрес: {Address}, \nЗадолженность: {Debt:C}";
        }

        public void MakeCall(DateTime callDate, int duration, bool isIncoming, string clientId)
        {
            Call call = new Call(callDate, duration, isIncoming, clientId);

            this.CallHistory.Add(call);
            ATScompany.Instance.AddCall(call);
        }

        public string PrintClientInfo()
        {
            string clientInfo = "";
            clientInfo += $"\nИмя: {Name}\n";
            clientInfo += $"Адрес: {Address}\n";
            clientInfo += $"Дата рождения: {BirthDate.ToShortDateString()}\n";
            clientInfo += $"Номер телефона: {PhoneNumber}\n";
            clientInfo += $"Текущая задолженность: {Debt:C}\n";
            clientInfo += $"Пеня: {Invoice.CalculateLateFee(Invoices):C}";

            if (Overpayment > 0)
            {
                clientInfo += $"Переплата: {Overpayment:C}\n";
            }

            clientInfo += "\nИстория звонков:\n";
            foreach (var call in CallHistory)
            {
                string callType = call.IsIncoming ? "входящий" : "исходящий";
                clientInfo += $"{call.CallDate} {callType}, Длительность: {call.Duration}\n";
            }

            clientInfo += "\nСписок счетов:\n";
            foreach (var invoice in Invoices)
            {
                decimal amount = invoice.Amount - invoice.PaidAmount;
                clientInfo += $"{invoice.InvoiceDate}: {amount:C}\n";
            }

            return clientInfo;
        }

        //public void MyAccount()
        //{

        //}
        public string ReceiveInvoice()
        {
            StringBuilder invoiceInfo = new StringBuilder();

            bool unpaidInvoicesExist = Invoices.Any(i => !i.IsPaid);
            bool overdueInterestExists = Debt > 0;
            decimal lateFee = Invoice.CalculateLateFee(Invoices);

            if (unpaidInvoicesExist || overdueInterestExists)
            {
                invoiceInfo.AppendLine("\nУ вас есть финансовые обязательства:");

                if (unpaidInvoicesExist)
                {
                    invoiceInfo.AppendLine("Неоплаченные счета:");
                    foreach (var unpaidInvoice in Invoices.Where(i => !i.IsPaid))
                    {
                        invoiceInfo.AppendLine($"- Счет за {unpaidInvoice.InvoiceDate}, Сумма: {(unpaidInvoice.Amount - unpaidInvoice.PaidAmount):C}");
                    }
                }

                if (overdueInterestExists)
                {
                    invoiceInfo.AppendLine($"Задолженность по процентам просрочки оплаты: {lateFee:C}");
                }

                invoiceInfo.AppendLine($"Итого к оплате: {Debt}");
            }
            else
            {
                invoiceInfo.AppendLine("Ваши финансовые обязательства полностью погашены.");
            }

            return invoiceInfo.ToString();
        }


        public string PayInvoice(decimal payment)
        {
            StringBuilder pay = new StringBuilder();
            bool unpaidInvoicesExist = Invoices.Any(i => !i.IsPaid);
            decimal lateFee = Invoice.CalculateLateFee(Invoices);
            bool overdueInterestExists = lateFee > 0;

            decimal remainingPayment = payment;

            if (unpaidInvoicesExist || overdueInterestExists)
            {
                if (unpaidInvoicesExist)
                {
                    foreach (var unpaidInvoice in Invoices.Where(i => !i.IsPaid))
                    {
                        decimal invoiceAmount = unpaidInvoice.Amount - unpaidInvoice.PaidAmount;

                        if (remainingPayment >= invoiceAmount)
                        {
                            unpaidInvoice.IsPaid = true;
                            unpaidInvoice.PaidAmount = invoiceAmount;
                            remainingPayment -= invoiceAmount;
                        }
                        else
                        {
                            unpaidInvoice.PaidAmount += remainingPayment;
                            remainingPayment = 0;
                        }

                        if (remainingPayment <= 0)
                            break;
                    }
                }

                if (overdueInterestExists)
                {
                    if (remainingPayment >= lateFee)
                    {
                        Debt = 0;
                        remainingPayment -= lateFee;
                    }
                    else
                    {
                        Debt -= remainingPayment;
                        remainingPayment = 0;
                        pay.AppendLine($"Оставшаяся задолженность: {Debt}");
                    }
                }
                pay.AppendLine($"\nОплата в размере {payment} принята.");
            }
            else
            {
                pay.AppendLine("Все счета оплачены. Внесённая сумма сохранена как переплата.");
            }

            if (remainingPayment > 0)
            {
                Overpayment = remainingPayment;
            }
            return pay.ToString();
        }

        public string AddOverpayment(decimal amount)
        {
            Overpayment += amount;
            return $"Счёт пополнен на сумму {amount}";
        }
    }
}
