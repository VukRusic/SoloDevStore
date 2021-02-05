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
    
    public partial class RegistrovanProizvod
    {
        public RegistrovanProizvod()
        {
            this.Recenzijas = new HashSet<Recenzija>();
        }
    
        public int Id { get; set; }
        public int IdDevelopera { get; set; }
        public string Naziv { get; set; }
        public string Zanr { get; set; }
        public int BrojIgraca { get; set; }
        public int PrepStarDoba { get; set; }
        public decimal Cena { get; set; }
        public Nullable<int> Procenat { get; set; }
        public string Opis { get; set; }
    
        public virtual Developer Developer { get; set; }
        public virtual ICollection<Recenzija> Recenzijas { get; set; }
    }
}
