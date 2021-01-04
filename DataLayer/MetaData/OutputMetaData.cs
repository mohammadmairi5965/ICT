using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    class OutputMetaData
    {
        [Key]
       
        public int OutputID { get; set; }
        [Display(Name ="شماره کاربر ")]
        [Required(AllowEmptyStrings = false, ErrorMessage = ErrorMessage.RequierdMsg)]
        public int UserID { get; set; }

        [Display(Name = "توضیح")]
        public string Description { get; set; }

        [Display(Name = "تاریخ ")]
        [Required(AllowEmptyStrings =false,ErrorMessage =ErrorMessage.RequierdMsg)]
        public System.DateTime InputDate { get; set; }
    }
    [MetadataType(typeof(OutputMetaData))]
    public partial class Output { }
}
