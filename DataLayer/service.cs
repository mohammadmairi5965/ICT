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
    
    public partial class service
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public service()
        {
            this.ServiceImage = new HashSet<ServiceImage>();
        }
    
        public int ID { get; set; }
        public System.DateTime dateOfService { get; set; }
        public string Computer_ID { get; set; }
        public int SoftwareID { get; set; }
        public int Action { get; set; }
        public Nullable<int> DisablementID { get; set; }
        public int ICTUser { get; set; }
        public Nullable<int> PeriodicVisitsID { get; set; }
        public int TypeOfServices { get; set; }
    
        public virtual Action Action1 { get; set; }
        public virtual Computer Computer { get; set; }
        public virtual Disablement Disablement { get; set; }
        public virtual PeriodicVisits PeriodicVisits { get; set; }
        public virtual User User { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ServiceImage> ServiceImage { get; set; }
        public virtual Software Software { get; set; }
        public virtual TypeOFService TypeOFService { get; set; }
    }
}
