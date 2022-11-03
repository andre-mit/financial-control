using Flunt.Notifications;
using Flunt.Validations;

namespace FinancialControl.Domain.Entities;

public class Role : Entity
{
    public string Name { get; private set; }
    public string? Description { get; private set; }

    public List<User> Users { get; private set; }

    public Role(string name, string? description)
    {
        AddNotifications(new Contract<Notification>()
        .Requires()
        .IsNotNullOrWhiteSpace(name, "Nome", "Nome inválido"));
        Name = name;
        Description = description;

        Users = new List<User>();
    }

    public void AddUser(User user)
    {
        if(user.IsValid)
            Users.Add(user);
    }
}