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
    
    public partial class CursoAlumno
    {
        public int Id { get; set; }
        public int AlumnoAlumnoId { get; set; }
        public int CursoNivelId { get; set; }
    
        public virtual Alumno Alumno { get; set; }
        public virtual CursoNivel CursoNivel { get; set; }
    }
}
