using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DataLayer
{
    class UnitMetaData
    {
        [Key]
        public int ID { get; set; }

        [Display(Name = "عنوان")]
        [Required(AllowEmptyStrings = false, ErrorMessage = ErrorMessage.RequierdMsg)]
        public string Title { get; set; }
        [Display(Name = "تلفن")]
        [MaxLength(10,ErrorMessage =ErrorMessage.MaxLenghtMsg)]
        public string tel { get; set; }

    }
    [MetadataType(typeof(UnitMetaData))]
    public partial class Unit { }
}
