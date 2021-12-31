using FinancialControl.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialControl.Domain.Repositories;

public interface IUserRepository
{
    Task<User> GetUserAsync(Guid id);
    Task<User> GetUserAsync(string email);
    Task SaveAsync(User user);
    Task DeleteAsync(Guid id);
    Task ChangeNameAsync(Guid id, string name);
    Task ChangeEmailAsync(Guid id, string email);
    Task ChangePasswordAsync(Guid id, string password);
    Task ChangePhoneAsync(Guid id, string phone);
    Task ConfirmEmailAsync(Guid id);
    Task ConfirmPhoneAsync(Guid id);
}