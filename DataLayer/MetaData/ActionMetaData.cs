
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
   public class ActionMetaData
    {
        [Key]
        public int ActionID { get; set; }

        [Display(Name = "عنوان کار")]
        [Required(AllowEmptyStrings = false, ErrorMessage = ErrorMessage.RequierdMsg)]
        [MaxLength(100, ErrorMessage = ErrorMessage.MaxLenghtMsg)]
        public string Title { get; set; }
    }
    [MetadataType(typeof(ActionMetaData))]
    public partial class Action
    {
    
    }
}
