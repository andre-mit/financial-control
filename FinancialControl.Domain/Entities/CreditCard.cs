using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialControl.Domain.Entities
{
    public class CreditCard : Entity
    {
        public string Name { get; private set; }
        public byte PaymentDay { get; private set; }
        public byte CloseDay { get; private set; }

        public CreditCard(string name, byte paymentDay, byte closeDay)
        {
            Name = name;
            PaymentDay = paymentDay;
            CloseDay = closeDay;
        }
    }
}
