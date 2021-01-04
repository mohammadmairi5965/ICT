using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DataLayer
{
    class WareHouseMetaData
    {
        [Key]
        public int WarehouseID { get; set; }

        [Display(Name ="کد کالا")]
        [Required(AllowEmptyStrings = false, ErrorMessage = ErrorMessage.RequierdMsg)]
        public int HardwareID { get; set; }

        [Display(Name = "تعداد")]
        [Required(AllowEmptyStrings = false, ErrorMessage = ErrorMessage.RequierdMsg)]
        public int Tedad { get; set; }
    }
    [MetadataType(typeof(WareHouseMetaData))]
    public partial class WareHouse { }
}
