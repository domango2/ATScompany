using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ATScompanySpace
{
    public class Call
    {
        public DateTime CallDate { get; set; }
        public int Duration { get; set; }
        public bool IsIncoming { get; set; }
        public string ClientId { get; set; }
        public decimal Cost { get; set; }

        [JsonConstructor]
        public Call(DateTime callDate, int duration, bool isIncoming, string clientId, decimal cost)
        {
            CallDate = callDate;
            Duration = duration;
            IsIncoming = isIncoming;
            ClientId = clientId;
            Cost = cost;
            if (!IsDuplicateCall(this))
            {
                ATScompany.Instance.AddCall(this);
                Client existingClient = ATScompany.Instance.FindClientById(ClientId)!;
                existingClient.CallHistory.Add(this);
            }
        }

        private bool IsDuplicateCall(Call newCall)
        {
            foreach (var existingCall in ATScompany.Instance.Calls)
            {
                if (existingCall.CallDate == newCall.CallDate
                    && existingCall.Duration == newCall.Duration
                    && existingCall.ClientId == newCall.ClientId)
                {
                    return true;
                }
            }

            return false;
        }
        public Call(DateTime callDate, int duration, bool isIncoming, string clientId)
        {
            CallDate = callDate;
            Duration = duration;
            IsIncoming = isIncoming;
            ClientId = clientId;

            Cost = CalculateCallCost();
        }


        private decimal CalculateCallCost()
        {
            if (!IsIncoming)
            {
                double minutes = (double)Duration / 60.0;
                decimal cost = (decimal)(minutes * 0.10);
                return cost;
            }
            else
            {
                return 0.0m;
            }
        }


        public override string ToString()
        {
            string callType = IsIncoming ? "входящий" : "исходящий";
            return $"{CallDate:dd.MM.yyyy HH:mm:ss} - {callType} звонок для клиента {ATScompany.Instance.FindClientById(ClientId)!.Name}. " +
                $"\nПродолжительность: {Duration} сек. Стоимость: {Cost:C}";
        }
    }
}
