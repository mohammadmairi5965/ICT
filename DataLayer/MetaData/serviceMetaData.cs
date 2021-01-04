using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DataLayer
{
    class serviceMetaData
    {
        [Key]
        public int ID { get; set; }

        [Display(Name ="تاریخ")]
        [Required(AllowEmptyStrings =false,ErrorMessage =ErrorMessage.RequierdMsg)]
        public System.DateTime dateOfService { get; set; }

        [Display(Name = "کد تجهیز")]
        [Required(AllowEmptyStrings = false, ErrorMessage = ErrorMessage.RequierdMsg)]
        public string Computer_ID { get; set; }

        [Display(Name = "فعالیت")]
        [Required(AllowEmptyStrings = false, ErrorMessage = ErrorMessage.RequierdMsg)]
        public int SoftwareID { get; set; }
        [Display(Name = "نوع فعالیت")]
        public int Action { get; set; }
        [Display(Name = "کد خرابی")]
        public Nullable<int> DisablementID { get; set; }

        [Display(Name = "کاربر فناوری اطلاعات")]
        [Required(AllowEmptyStrings = false, ErrorMessage = ErrorMessage.RequierdMsg)]
        public int ICTUser { get; set; }

        [Display(Name = "کد بازدید دوره ای")]
        public Nullable<int> PeriodicVisitsID { get; set; }

        [Display(Name = "نحوه انجام سرویس")]
        [Required(AllowEmptyStrings = false, ErrorMessage = ErrorMessage.RequierdMsg)]
        public int TypeOfServices { get; set; }
    }
    [MetadataType(typeof(serviceMetaData))]
    public partial class service { }
}
