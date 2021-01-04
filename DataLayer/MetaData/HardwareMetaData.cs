using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    class HardwareMetaData
    {
        [Key]
        public int ID { get; set; }
        [Display(Name = "مدل")]
        [Required(AllowEmptyStrings = false, ErrorMessage = ErrorMessage.RequierdMsg)]
        public string Name { get; set; }
        [Display(Name = "نوع")]
        [Required(AllowEmptyStrings = false, ErrorMessage = ErrorMessage.RequierdMsg)]
        public int Type { get; set; }
    }
    [MetadataType(typeof(HardwareMetaData))]
    public partial class Hardware { }
}
