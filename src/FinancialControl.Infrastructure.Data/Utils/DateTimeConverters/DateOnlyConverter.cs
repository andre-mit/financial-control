using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace FinancialControl.Infrastructure.Data.Utils.DateTimeConverters;

public class DateOnlyConverter : ValueConverter<DateOnly, DateTime>
{
    public DateOnlyConverter() : base(
        dateOnly => dateOnly.ToDateTime(TimeOnly.MinValue),
        dateTime => DateOnly.FromDateTime(dateTime))
    {
    }
}