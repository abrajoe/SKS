//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SKS
{
    using System;
    using System.Collections.Generic;
    
    public partial class MesswertTyp
    {
        public MesswertTyp()
        {
            this.Messwerts = new HashSet<Messwert>();
        }
    
        public int MesswertTypID { get; set; }
        public long Minimum { get; set; }
        public long Maximum { get; set; }
        public string Einheit { get; set; }
    
        public virtual ICollection<Messwert> Messwerts { get; set; }
    }
}