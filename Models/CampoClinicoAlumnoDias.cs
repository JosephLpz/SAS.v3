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
    
    public partial class CampoClinicoAlumnoDias
    {
        public int Id { get; set; }
        public int DiasDiasId { get; set; }
        public int CampoClinicoAlumnoId { get; set; }
    
        public virtual Dias Dias { get; set; }
        public virtual CampoClinicoAlumno CampoClinicoAlumno { get; set; }
    }
}
