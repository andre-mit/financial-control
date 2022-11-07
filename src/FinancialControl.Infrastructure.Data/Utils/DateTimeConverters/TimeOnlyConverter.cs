using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace FinancialControl.Infrastructure.Data.Utils.DateTimeConverters;

public class TimeOnlyConverter : ValueConverter<TimeOnly, TimeSpan>
{
    public TimeOnlyConverter() : base(
        timeOnly => timeOnly.ToTimeSpan(),
        timeSpan => TimeOnly.FromTimeSpan(timeSpan))
    {
    }
}