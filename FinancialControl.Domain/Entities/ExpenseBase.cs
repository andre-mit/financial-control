using Flunt.Notifications;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialControl.Domain.Entities;

public abstract class ExpenseBase : Entity
{
    public string Name { get; private set; }
    public string? Description { get; private set; }
    public decimal Value { get; private set; }
    public DateTime Date { get; private set; }

    public ExpenseBase(string name, string? description, decimal value, DateTime date)
    {
        AddNotifications(new Contract<Notification>()
            .Requires()
            .IsNotNullOrWhiteSpace(name, "Nome", "Nome inválido")
        );

        Name = name;
        Description = description;
        Value = value;
        Date = date;
    }
}