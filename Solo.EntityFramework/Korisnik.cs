//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Solo.EntityFramework
{
    using System;
    using System.Collections.Generic;
    
    public partial class Korisnik
    {
        public Korisnik()
        {
            this.EvidencijaProdajes = new HashSet<EvidencijaProdaje>();
            this.Recenzijas = new HashSet<Recenzija>();
        }
    
        public int Id { get; set; }
        public string RacunID { get; set; }
    
        public virtual ICollection<EvidencijaProdaje> EvidencijaProdajes { get; set; }
        public virtual Nalog Nalog { get; set; }
        public virtual Racun Racun { get; set; }
        public virtual ICollection<Recenzija> Recenzijas { get; set; }
    }
}
