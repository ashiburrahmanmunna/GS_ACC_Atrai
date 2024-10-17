using Atrai.Model.Core.Entity.Base;
using Atrai.Model.Core.Entity.Self;
using System;
using System.ComponentModel.DataAnnotations;

namespace Atrai.Model.Core.Entity
{
    public class NotificationSetting : BaseModel
    {

        [Required]
        public string? UserName { get; set; }
        [Required]
        public string? DeviceToken { get; set; }
    }
    public class NotificationMassage : SelfModel
    {
        public int NotificationSettingId { get; set; }
        public NotificationSetting NotificationSetting { get; set; }

        public string? Massage { get; set; }
        public string? Title { get; set; }
        public DateTime? ScheduleTime { get; set; }
        public Status Status { get; }
        public Status Priority { get; }
    }
    public enum Status
    {
        Pending,
        Sent,
        Urgent,
        Regular
    }
    public class NotificationDto
    {

        //[Required]
        //public string? Email { get; set; }
        [Required]
        public string? NewDeviceToken { get; set; }
        public string? OldDeviceToken { get; set; }
    }
}
