//------------------------------------------------------------------------------
// <auto-generated>
//     Codice generato da un modello.
//
//     Le modifiche manuali a questo file potrebbero causare un comportamento imprevisto dell'applicazione.
//     Se il codice viene rigenerato, le modifiche manuali al file verranno sovrascritte.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FlipperAPI
{
    using System;
    using System.Collections.Generic;
    
    public partial class SEATS
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SEATS()
        {
            this.RESERVATIONS = new HashSet<RESERVATIONS>();
        }
    
        public decimal ID_SEAT { get; set; }
        public string CODE { get; set; }
        public decimal ID_THEATER { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RESERVATIONS> RESERVATIONS { get; set; }
        public virtual THEATERS THEATERS { get; set; }
    }
}