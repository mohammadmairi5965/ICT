using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DataLayer
{
    class PeriodicVisitsMetaData
    {
        [Key]
        public int ID { get; set; }
        [Display(Name ="تاریخ شروع")]
        [Required(AllowEmptyStrings =false,ErrorMessage =ErrorMessage.RequierdMsg)]
        public System.DateTime StartDate { get; set; }
        [Display(Name = "عنوان")]
        [Required(AllowEmptyStrings = false, ErrorMessage = ErrorMessage.RequierdMsg)]
        public string Title { get; set; }

        [Display(Name = "توضیح")]
        public string Description { get; set; }
    }

    [MetadataType(typeof(PeriodicVisitsMetaData))]
    public partial class PeriodicVisits { }
}
