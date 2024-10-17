using Atrai.Model.Core.Entity.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Atrai.Model.Core.Entity
{
    [Table("VGM")]
    public class VGMModel : BaseModel
    {
        [Display(Name = "VGA No")]
        public string? VGANo { get; set; }
        [Display(Name = "VGA Method")]
        public string? VGAMethod { get; set; }
        [Display(Name = "Container No")]
        public string? ContainerNo { get; set; }
        [Display(Name = "Container Type")]
        public string? ContainerType { get; set; }
        [Display(Name = "Contaner Size")]
        public string? ContainerSize { get; set; }
        [Display(Name = "Tare Weight")]
        public string? TareWeight { get; set; }
        [Display(Name = "Verified Gross Mass")]
        public string? VerifiedGrossMass { get; set; }
        [Display(Name = "Previously declared weight")]
        public string? PreviouslyDeclaredweight { get; set; }
        [Display(Name = "VGM weight by CPA")]

        public string? VGMWeightbyCPA { get; set; }
        [Display(Name = "Name of Shipper")]

        public string? NameofShipper { get; set; }
        [Display(Name = "Name of MLO/Shipping Agent")]

        public string? ShippingAgent { get; set; }
        [Display(Name = "VGM performed on behalf of the shipper by")]

        public string? VGMPerformedShipperBy { get; set; }
        [Display(Name = "Weight bridge registration no")]

        public string? WeightBridgeRegistrationNo { get; set; }
        [Display(Name = "Address of weigh bridge")]

        public string? AddressOfWeightBridge { get; set; }
        [Display(Name = "Issued by")]

        public string? IssuedBy { get; set; }

        [Display(Name = "Notes")]

        [DataType(DataType.MultilineText)]
        public string? Notes { get; set; }

    }
}
