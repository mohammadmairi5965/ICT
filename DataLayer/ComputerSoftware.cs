//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataLayer
{
    using System;
    using System.Collections.Generic;
    
    public partial class ComputerSoftware
    {
        public int ComputerSoftwareID { get; set; }
        public string ComputerID { get; set; }
        public int SoftwareID { get; set; }
    
        public virtual Computer Computer { get; set; }
        public virtual Software Software { get; set; }
    }
}
