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
    
    public partial class Anio
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Anio()
        {
            this.CampoClinicoAlumno = new HashSet<CampoClinicoAlumno>();
            this.PlanDeEstudio = new HashSet<PlanDeEstudio>();
            this.ProyeccionDeCupo = new HashSet<ProyeccionDeCupo>();
        }
    
        public int Id { get; set; }
        public string Ano { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CampoClinicoAlumno> CampoClinicoAlumno { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PlanDeEstudio> PlanDeEstudio { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProyeccionDeCupo> ProyeccionDeCupo { get; set; }
    }
}
