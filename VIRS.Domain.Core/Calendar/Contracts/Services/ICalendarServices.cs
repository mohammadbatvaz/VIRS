using System.Security.Cryptography.X509Certificates;

namespace VIRS.Domain.Core.Calendar.Contracts.Services
{
    public interface ICalendarServices
    {
        int ShamsiDayOfWeek(DateTime date);

        string ShamsiDayNameOfWeek(int dayNumber);

        string ShamsiMonthName(int monthNumber);

        string CompleteShamsiDate(DateTime date);
    }
}
