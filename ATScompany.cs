using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using System.ComponentModel;

namespace ATScompanySpace
{
    public class ATScompany 
    {
        public static ATScompany Instance { get; } = new ATScompany();
        public List<Client> Clients { get; set; }

        public List<Call> Calls { get; set; }

        public List<Invoice> Invoices { get; set; }

        private ATScompany()
        {
            Clients = new List<Client>();
            Calls = new List<Call>();
            Invoices = new List<Invoice>();
        }

        public void AddClient(Client client)
        {
            Clients.Add(client);
        }

        public void AddCall(Call call)
        {
            Calls.Add(call);
        }

        public void AddInvoice(Invoice invoice)

        {
            Invoices.Add(invoice);
        }

        public void SendInvoice()
        {
            DateTime currentDate = DateTime.Now;

            foreach (var client in Clients)
            {
                var callsAfterLastInvoice = client.CallHistory
                    .Where(call => call.CallDate > client.LastInvoiceDate)
                    .ToList();

                if (callsAfterLastInvoice.Count > 0)
                {
                    decimal callCost = callsAfterLastInvoice.Sum(call => call.Cost);

                    if (callCost == (decimal)0.0) continue;
                    Invoice invoice = new Invoice(currentDate, currentDate.AddDays(10), callCost, client.Id);

                    client.Invoices.Add(invoice);
                    Invoices.Add(invoice);

                    client.LastInvoiceDate = currentDate;
                }
            }
        }



        public string PrintAllClients()
        {
            StringBuilder text = new StringBuilder();
            text.AppendLine("Список клиентов:\n\n");
            foreach (var client in Clients)
            {
                text.AppendLine(client.ToString());
                text.AppendLine();
            }
            return text.ToString();
        }

        public string PrintAllCalls()
        {
            StringBuilder text = new StringBuilder();
            text.AppendLine("Список звонков:\n\n");
            foreach (var call in Calls)
            {
                text.AppendLine(call.ToString());
                text.AppendLine();
            }
            return text.ToString();
        }

        public string PrintAllInvoices()
        {
            StringBuilder text = new StringBuilder();
            text.AppendLine("Список счетов:\n\n");
            foreach (var invoice in Invoices)
            {
                text.AppendLine(invoice.ToString());
                text.AppendLine();
            }
            return text.ToString();
        }

        public Client? FindClientById(string clientId)
        {
            return Clients.FirstOrDefault(client => client.Id == clientId);
        }

        public Client? FindClientByPhoneNumber(string number)
        {
            return Clients.FirstOrDefault(client => client.PhoneNumber == number);
        }

        public Client? FindClient(string inputLogin, string inputPassword)
        {
            return Clients.FirstOrDefault(client => (client.Login == inputLogin && client.Password == inputPassword));
        }

        public Client Authorization(string inputLogin, string inputPassword)
        {
            Client client1 = FindClient(inputLogin, inputPassword);
            //client1.PrintClientInfo();
            return client1!;
        }

        public void SaveAll()
        {
            string dataClients = "dataClients.json";
            string dataCalls = "dataCalls.json";
            string dataInvoices = "dataInvoices.json";

            JsonSerializerOptions options = new JsonSerializerOptions();
            options.WriteIndented = true;

            var jsonClients = JsonSerializer.Serialize(Clients, options);
            var jsonCalls = JsonSerializer.Serialize(Calls, options);
            var jsonInvoices = JsonSerializer.Serialize(Invoices, options);

            File.WriteAllText(dataClients, jsonClients);
            File.WriteAllText(dataCalls, jsonCalls);
            File.WriteAllText(dataInvoices, jsonInvoices);

            Console.WriteLine("\nДанные сохранены.");
        }


        public void LoadAll()
        {
            Clients.Clear();
            Calls.Clear();
            Invoices.Clear();
            string dataClients = "dataClients.json";
            string dataCalls = "dataCalls.json";
            string dataInvoices = "dataInvoices.json";

            if (File.Exists(dataClients))
            {
                var jsonClients = File.ReadAllText(dataClients);
                var deserializedClients = JsonSerializer.Deserialize<List<Client>>(jsonClients);
                if (deserializedClients != null)
                {
                    if (File.Exists(dataCalls))
                    {
                        var jsonCalls = File.ReadAllText(dataCalls);
                        var deserializedCalls = JsonSerializer.Deserialize<List<Call>>(jsonCalls);
                    }

                    if (File.Exists(dataInvoices))
                    {
                        var jsonInvoices = File.ReadAllText(dataInvoices);
                        var deserializedInvoices = JsonSerializer.Deserialize<List<Invoice>>(jsonInvoices);
                    }
                }
            }
        }
    }
}
