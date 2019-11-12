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
    
    public partial class ProyeccionDeCupo
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ProyeccionDeCupo()
        {
            this.ProyeccionAlumno = new HashSet<ProyeccionAlumno>();
        }
    
        public int Id { get; set; }
        public int AsignaturaId { get; set; }
        public int CarreraCarreraId { get; set; }
        public int AnioId { get; set; }
        public string CuposProyectados { get; set; }
        public string CuposRestantes { get; set; }
    
        public virtual Asignatura Asignatura { get; set; }
        public virtual Carrera Carrera { get; set; }
        public virtual Anio Anio { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProyeccionAlumno> ProyeccionAlumno { get; set; }
    }
}