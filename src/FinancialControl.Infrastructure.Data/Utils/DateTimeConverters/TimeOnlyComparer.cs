using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace FinancialControl.Infrastructure.Data.Utils.DateTimeConverters;

public class TimeOnlyComparer : ValueComparer<TimeOnly>
{
    public TimeOnlyComparer() : base(
        (t1, t2) => t1.Ticks == t2.Ticks,
        t => t.GetHashCode())
    {
    }
}