using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    class InputDetailMetaData
    {
        [Key]
        public int InputDetailID { get; set; }
        [Display(Name = "شماره فاکتور")]
        [Required(AllowEmptyStrings = false, ErrorMessage = ErrorMessage.RequierdMsg)]
        public int InputID { get; set; }
        [Display(Name = "کد کالا")]
        [Required(AllowEmptyStrings = false, ErrorMessage = ErrorMessage.RequierdMsg)]
        public int HardwareID { get; set; }
        [Display(Name = "تعداد")]
        [Required(AllowEmptyStrings = false, ErrorMessage = ErrorMessage.RequierdMsg)]
        public int Tedad { get; set; }
    }

    [MetadataType(typeof(InputDetailMetaData))]
    public partial class InputDetail { }
}
