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
    
    public partial class Disablement
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Disablement()
        {
            this.service = new HashSet<service>();
        }
    
        public int ID { get; set; }
        public System.DateTime DateOfDisablement { get; set; }
        public int userID { get; set; }
        public string ComputerID { get; set; }
        public string Descroption { get; set; }
        public int Status { get; set; }
        public Nullable<int> ICTUser { get; set; }
        public Nullable<int> Priority { get; set; }
    
        public virtual Computer Computer { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<service> service { get; set; }
        public virtual User User { get; set; }
        public virtual User User1 { get; set; }
    }
}
