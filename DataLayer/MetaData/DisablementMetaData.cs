using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    class DisablementMetaData
    {
        [Key]
        public int ID { get; set; }

        [Display(Name = "زمان اعلام")]
        [Required(AllowEmptyStrings = false, ErrorMessage = ErrorMessage.RequierdMsg)]
        public System.DateTime DateOfDisablement { get; set; }

        [Display(Name = "شماره کاربر")]
        [Required(AllowEmptyStrings = false, ErrorMessage = ErrorMessage.RequierdMsg)]
        public int userID { get; set; }
        [Display(Name = "شماره کامپیوتر")]
        [Required(AllowEmptyStrings = false, ErrorMessage = ErrorMessage.RequierdMsg)]
        public string ComputerID { get; set; }
        [Display(Name = "توضیح")]
        public string Descroption { get; set; }
        [Display(Name = "وضعیت")]
        public int Status { get; set; }

        [Display(Name = "شماره کاربر")]
        [Required(AllowEmptyStrings = false, ErrorMessage = ErrorMessage.RequierdMsg)]
        public Nullable<int> ICTUser { get; set; }
        [Display(Name = "اولویت")]
        [Required(AllowEmptyStrings = false, ErrorMessage = ErrorMessage.RequierdMsg)]
        public Nullable<int> Priority { get; set; }
    }
    [MetadataType(typeof(DisablementMetaData))]
    public partial class Disablement { }
}
