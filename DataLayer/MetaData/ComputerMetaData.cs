using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
   public class ComputerMetaData
    {
        [Key]
        [Display(Name = "شماره تجهیز")]
        [Required(AllowEmptyStrings = false, ErrorMessage = ErrorMessage.RequierdMsg)]
        [MaxLength(5, ErrorMessage = ErrorMessage.MaxLenghtMsg)]
        string Computer_ID { get; set; }

        [Display(Name = "واحد")]
        [Required(AllowEmptyStrings = false, ErrorMessage = ErrorMessage.RequierdMsg)]
        public int unit { get; set; }
        [Display(Name = "نوع")]
        [Required(AllowEmptyStrings = false, ErrorMessage = ErrorMessage.RequierdMsg)]
        public int TypeOfComputer { get; set; }

        [Display(Name = "کد اموالی")]
        public string AmvalCode { get; set; }
        [Display(Name = "سریال")]
        public string Serial { get; set; }

    }
    [MetadataType(typeof(ComputerMetaData))]
    public partial class Computer { }
}
