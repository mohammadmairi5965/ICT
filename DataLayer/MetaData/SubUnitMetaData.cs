using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DataLayer
{
    class SubUnitMetaData
    {
        [Key]
        public int ID { get; set; }
        [Display(Name = "عنوان زیر واحد")]
        [Required(AllowEmptyStrings = false, ErrorMessage = ErrorMessage.RequierdMsg)]
        [MaxLength(100, ErrorMessage = ErrorMessage.MaxLenghtMsg)]
        public string Title { get; set; }
    }
    [MetadataType(typeof(SubUnitMetaData))]
    public partial class SubUnit
    {

    }
}
