using System;
using Flunt.Notifications;

namespace FinancialControl.Domain.Entities;

public abstract class Entity : Notifiable<Notification>
{
    public Guid Id { get; private set; }

    protected Entity()
    {
        Id = Guid.NewGuid();
    }
}
