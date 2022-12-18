using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinancialControl.Core.Entities;
using Flunt.Notifications;
using Flunt.Validations;

namespace FinancialControl.Domain.Entities
{
    public class CreditCard : Entity
    {
        private readonly IList<CreditCardExpense> _expenses;

        public string Name { get; private set; }
        public byte PaymentDay { get; private set; }
        public byte CloseDay { get; private set; }

        public IReadOnlyCollection<CreditCardExpense> Expenses => _expenses.ToArray();

        public User? User { get; private set; }

        public CreditCard()
        {
            
        }

        public CreditCard(string name, byte paymentDay, byte closeDay, User user)
        {
            AddNotifications(new Contract<Notification>()
                .Requires()
                .IsNotNullOrWhiteSpace(name, "Nome", "Nome inválido")
                .IsBetween(paymentDay, 1, 31, "Pagamento", "Dia de pagamento inválido")
                .IsBetween(closeDay, 1, 31, "Fechamento", "Dia de fechamento inválido")
            );

            if (user.IsValid)
                User = user;

            Name = name;
            PaymentDay = paymentDay;
            CloseDay = closeDay;
            _expenses = new List<CreditCardExpense>();
        }
    }
}
