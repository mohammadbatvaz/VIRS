using System.ComponentModel;

namespace VIRS.Domain.Core.InspectionRequestAgg.Enums
{
    public enum InspectionStatusEnum
    {
        [Description("در انتظار بررسی")]
        Pending,

        [Description("تأیید شده")]
        Confirmed,

        [Description("رد شده")]
        Rejected
    }
}
