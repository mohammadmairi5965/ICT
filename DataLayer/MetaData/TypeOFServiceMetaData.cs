using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DataLayer
{
    class TypeOFServiceMetaData
    {
        [Key]
        public int ID { get; set; }

        [Display(Name = "عنوان سرویس")]
        [Required(AllowEmptyStrings = false, ErrorMessage = ErrorMessage.RequierdMsg)]
        public string Title { get; set; }
    }
    [MetadataType(typeof(TypeOFServiceMetaData))]
    public partial class TypeOFService { }
}
