using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
  public class ComputerhardwareMetaData
    {
        [Key]
        public int ComputerHardwareID { get; set; }
        [Display(Name = "کد تجهیز")]
        [Required(AllowEmptyStrings = false, ErrorMessage = ErrorMessage.RequierdMsg)]
        public string ComputerID { get; set; }
        [Display(Name = "مدل سخت افزار")]
        [Required(AllowEmptyStrings = false, ErrorMessage = ErrorMessage.RequierdMsg)]
        public int HardwareID { get; set; }
        [Display(Name = "کد اموالی")]
        public string AmvalCode { get; set; }
        [Display(Name = "سریال")]
        public string Serial { get; set; }
        public virtual Computer Computer { get; set; }
        public virtual Hardware Hardware { get; set; }
    }
    [MetadataType(typeof(ComputerhardwareMetaData))]
    public partial class ComputerHardware
    {

    }
}
