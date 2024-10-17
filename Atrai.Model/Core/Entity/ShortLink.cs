using Atrai.Model.Core.Entity.Base;
using Atrai.Model.Core.Entity.Self;
using Microsoft.AspNetCore.WebUtilities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Atrai.Model.Core.Entity
{
    [Table("ShortLink")]
    public class ShortLinkModel : BaseModel
    {
        public string? GetUrlChunk()
        {
            return WebEncoders.Base64UrlEncode(BitConverter.GetBytes(Id));
        }

        public static int GetId(string urlChunk)
        {
            return BitConverter.ToInt32(WebEncoders.Base64UrlDecode(urlChunk));
        }

        //public int Id { get; set; }
        //[NotMapped]
        //public int UrlHitCount { get; set; }



        [Display(Name = "Name")]
        [Required]
        [StringLength(40, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 4)]
        public string? Name { get; set; }

        [Display(Name = "Orginal URL")]
        public string? Url { get; set; }

        public virtual ICollection<ShortLinkHitModel> ShortLinkHitList { get; set; }

    }


    [Table("ShortLinkHit")]
    public class ShortLinkHitModel : SelfModel
    {
        [ForeignKey("ShortLinkInfo")]
        public int ShortLinkId { get; set; }
        [Display(Name = "Short Link Info")]
        public virtual ShortLinkModel ShortLinkInfo { get; set; }


        [StringLength(300)]
        [Display(Name = "Web Link")]
        public string? WebLink { get; set; }
        [Display(Name = "Full Info")]
        public string? LongString { get; set; }
        [Display(Name = "IP Address")]

        [StringLength(50)]
        public string? IPAddress { get; set; }
        [Display(Name = "Device Type")]
        [StringLength(50)]
        public string? DeviceType { get; set; }
        [Display(Name = "Platform")]
        [StringLength(128)]
        public string? Platform { get; set; }
        [Display(Name = "Web Browser")]
        [StringLength(128)]
        public string? WebBrowserName { get; set; }
        [StringLength(128)]
        public string? Latitude { get; set; }
        [StringLength(128)]
        public string? Longitude { get; set; }

    }



}
