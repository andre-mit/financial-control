using FinancialControl.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FinancialControl.Domain.Queries
{
    public static class CreditCardQueries
    {
        public static Expression<Func<CreditCard, bool>> GetCreditCard(Guid id, Guid userId)
        {
            return x => x.Id == id && x.User.Id == userId;
        }

        public static Expression<Func<CreditCard, bool>> GetCreditCards(Guid userId)
        {
            return x => x.User.Id == userId;
        }
    }
}
