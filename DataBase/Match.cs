//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataBase
{
    using System;
    using System.Collections.Generic;
    
    public partial class Match
    {
        public int Id { get; set; }
        public string Date { get; set; }
        public string Guest { get; set; }
        public string Host { get; set; }
        public string Result { get; set; }
        public int ArenaId { get; set; }
    
        public virtual Arena Arena { get; set; }
    }
}
