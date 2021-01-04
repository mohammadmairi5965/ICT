using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
  public class RoleMetadata
    {
        [Key]
        public int RoleID { get; set; }
        [Display(Name ="عنوان نقش")]
        //  [Required(ErrorMessage ="لطفا {0} را وارد نمایید")]
        [Required(AllowEmptyStrings = false, ErrorMessage = ErrorMessage.RequierdMsg)]
        public string RoleTitle { get; set; }
        [Display(Name = "عنوان سیستمی نقش")]
        [Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
        public string RoleName { get; set; }
    }
    [MetadataType(typeof(RoleMetadata))]
    public partial class Role
    {

    }
}
