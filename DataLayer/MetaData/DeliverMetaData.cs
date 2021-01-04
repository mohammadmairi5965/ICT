using System;
using System.ComponentModel.DataAnnotations;

namespace DataLayer
{
    class DeliverMetaData
    {
        [Key]
        public int id { get; set; }


        [Display(Name = "کد کامپیوتر")]
        [Required(AllowEmptyStrings = false, ErrorMessage = ErrorMessage.RequierdMsg)]
        public string ComputerID { get; set; }
        [Display(Name = "کد کاربر")]
        [Required(AllowEmptyStrings = false, ErrorMessage = ErrorMessage.RequierdMsg)]
        public int UserID { get; set; }

        [Display(Name = "نام کامپیوتر")]
        public string ComputerName { get; set; }
        [Display(Name = "تاریخ تحویل")]
        [Required(AllowEmptyStrings = false, ErrorMessage = ErrorMessage.RequierdMsg)]
        public System.DateTime DeliveryDate { get; set; }
        [Display(Name = "تاریخ بازگشت")]
        public Nullable<System.DateTime> ReturnDate { get; set; }
    }
    [MetadataType(typeof(DeliverMetaData))]
    public partial class Deliver
    {

    }
}
