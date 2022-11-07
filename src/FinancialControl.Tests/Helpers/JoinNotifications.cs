using System.Collections.Generic;
using System.Linq;
using Flunt.Notifications;

namespace FinancialControl.Tests;

public static class JoinNotifications
{
    public static string Join(this IEnumerable<Notification> notifications, string separator = ";")
    {
        return string.Join(separator, notifications.Select(x => $"{x.Key}: {x.Message}"));
    }
}