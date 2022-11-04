using FinancialControl.Domain.Entities;
using FinancialControl.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialControl.Tests.Repositories
{
    internal class FakeCreditCardRepository : ICreditCardRepository
    {
        public List<CreditCard> CreditCards { get; private set; }

        public FakeCreditCardRepository()
        {
            CreditCards = new List<CreditCard>
            {
                new CreditCard("Master", 10, 1, new User("André", "contato@andre-mit.dev")),
                new CreditCard("Visa", 10, 1, new User("André", "contato@andre-mit.dev")),
                new CreditCard("Elo", 10, 1, new User("André", "contato@andre-mit.dev")),
            };
        }

        public Task AddExpenseAsync(Guid cardId, Guid userId, CreditCardExpense expense)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Guid id, Guid userId)
        {
            throw new NotImplementedException();
        }

        public Task<CreditCard> GetAsync(Guid id, Guid userId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<CreditCard>> GetAsync(Guid userId)
        {
            throw new NotImplementedException();
        }

        public Task RemoveExpenseAsync(Guid cardId, Guid userId, Guid expenseId)
        {
            throw new NotImplementedException();
        }

        public Task SaveAsync(CreditCard card)
        {
            throw new NotImplementedException();
        }
    }
}
