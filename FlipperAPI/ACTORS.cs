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
    
    public partial class ACTORS
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ACTORS()
        {
            this.FILM_ACTOR = new HashSet<FILM_ACTOR>();
        }
    
        public decimal ID_ACTOR { get; set; }
        public string NAME { get; set; }
        public string SURNAME { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FILM_ACTOR> FILM_ACTOR { get; set; }
    }
}
