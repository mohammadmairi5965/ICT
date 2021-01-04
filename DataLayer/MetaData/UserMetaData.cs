using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class UserMetaData
    {
        [Key]
        public int userID { get; set; }
        [Display(Name = "عنوان نقش")]
        [Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
        public int RoleID { get; set; }
        [Display(Name = "نام کاربری")]
        [Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
        public string UserName { get; set; }
        [Display(Name = "رمز عبور")]
        [Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
        public string Password { get; set; }
        [Display(Name = "موبایل")]
        public string Mobile { get; set; }
        [Display(Name = "کد فعال سازی")]
        public string ActiveCode { get; set; }
        [Display(Name = "وضعیت فعال بودن")]
        public bool IsActive { get; set; }
        [Display(Name = "تاریخ ثبت")]
        public System.DateTime RegisterDate { get; set; }
        [Display(Name = "تصویر")]
        public string PersonalImage { get; set; }
        [Display(Name = "نام نمایشی")]
        [Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
        public string Name { get; set; }

        [Display(Name = "نام کاربری شبکه")]
        public string DomainUserName { get; set; }
    }

    [MetadataType(typeof(UserMetaData))]
    public partial class User
    {

    }
}
