using Flunt.Notifications;
using Flunt.Validations;

namespace FinancialControl.Domain.Entities;

public class Role : Entity
{
    public string Name { get; set; }
    public string? Description { get; set; }

    public Role(string name, string? description)
    {
        AddNotifications(new Contract<Notification>()
        .Requires()
        .IsNotNullOrWhiteSpace(name, "Nome", "Nome inválido"));
        Name = name;
        Description = description;
    }
}