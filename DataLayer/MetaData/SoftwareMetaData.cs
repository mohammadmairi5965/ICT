using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DataLayer
{
    class SoftwareMetaData
    {
        [Key]
        public int ID { get; set; }
        [Display(Name ="عنوان فعالیت")]
        [Required(AllowEmptyStrings =false,ErrorMessage =ErrorMessage.RequierdMsg)]
        public string Name { get; set; }

        [Display(Name = "نوع")]
        //[Required(AllowEmptyStrings = false, ErrorMessage = ErrorMessage.RequierdMsg)]
        public string Version { get; set; }

        [Display(Name = "توضیحات")]
      //  [Required(AllowEmptyStrings = false, ErrorMessage = ErrorMessage.RequierdMsg)]
        public string Type { get; set; }
    }

    [MetadataType(typeof(SoftwareMetaData))]
    public partial class Software { }
}
