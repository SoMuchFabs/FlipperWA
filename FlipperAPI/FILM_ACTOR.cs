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
    
    public partial class FILM_ACTOR
    {
        public decimal ID_FILM_ACTOR { get; set; }
        public decimal ID_FILM { get; set; }
        public decimal ID_ACTOR { get; set; }
    
        public virtual ACTORS ACTORS { get; set; }
        public virtual FILMS FILMS { get; set; }
    }
}
