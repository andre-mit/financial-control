using Flunt.Notifications;

namespace FinancialControl.Core.Entities;

public class Entity : Notifiable<Notification>
{
    public Guid Id { get; private set; }
    public DateTime CreatedAt { get; protected set; }
    public DateTime UpdatedAt { get; protected set; }

    protected Entity()
    {
        Id = Guid.NewGuid();
    }
}