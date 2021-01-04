using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    class ComputerTypeMetaData
    {
        [Key]
        public int ID { get; set; }

        [Display(Name = "عنوان")]
        [Required(AllowEmptyStrings = false, ErrorMessage = ErrorMessage.RequierdMsg)]
        public string Title { get; set; }

        [Display(Name = "زیرواحد")]
        public Nullable<int> SubUnitID { get; set; }
    }
    [MetadataType(typeof(ComputerTypeMetaData))]
    public partial class ComputerType
    {}
}
