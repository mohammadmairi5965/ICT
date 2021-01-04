using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DataLayer
{
    class OutputDetailMetaData
    {
        [Key]
        public int OutputDetailID { get; set; }
        [Display(Name ="کد کالا")]
        [Required(AllowEmptyStrings =false,ErrorMessage =ErrorMessage.RequierdMsg)]
        public int HardwareID { get; set; }
        [Display(Name = "تعداد")]
        [Required(AllowEmptyStrings = false, ErrorMessage = ErrorMessage.RequierdMsg)]
        public int Tedad { get; set; }

        [Display(Name = "کد فاکتور")]
        [Required(AllowEmptyStrings = false, ErrorMessage = ErrorMessage.RequierdMsg)]
        public int OutputID { get; set; }
    }
    [MetadataType(typeof(OutputDetailMetaData))]
    public partial class OutputDetail { }
}
