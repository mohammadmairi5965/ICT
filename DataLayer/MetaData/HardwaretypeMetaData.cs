using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    class HardwareTypeMetaData
    {
        [Key]
        public int HardwareTypeID { get; set; }
        [Display(Name = "عنوان سخت افزار")]
        [Required(AllowEmptyStrings = false, ErrorMessage = ErrorMessage.RequierdMsg)]
        public string Name { get; set; }
        [Display(Name = "زیر واحد")]
        [Required(AllowEmptyStrings = false, ErrorMessage = ErrorMessage.RequierdMsg)]
        public string SubArea { get; set; }
    }

    [MetadataType(typeof(HardwareTypeMetaData))]
    public partial class HardwareType
    {

    }
}
