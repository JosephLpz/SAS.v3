//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SAS.v1.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class ContadorSituacion
    {
        public int Id { get; set; }
        public string Vigente { get; set; }
        public string RetiroTemporal { get; set; }
        public string RetiroDefinitivo { get; set; }
        public string EliminadoAcademica { get; set; }
        public string RetractoMatricula { get; set; }
        public string EiminadoNoMatricula { get; set; }
        public string Abandono { get; set; }
        public int AnioId { get; set; }
    
        public virtual Anio Anio { get; set; }
    }
}
