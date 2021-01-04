using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
   public class ComputerHardwareViewModel
    {
        public string ComputerID { get; set; }

        public string HardwareTitle { get; set; }

        public string HardwareModel { get; set; }

        public bool Has { get; set; }
    }
}
