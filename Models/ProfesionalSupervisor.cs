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
    
    public partial class ProfesionalSupervisor
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ProfesionalSupervisor()
        {
            this.CampoClinicoAlumno = new HashSet<CampoClinicoAlumno>();
        }
    
        public int ProfesionalSupervisorId { get; set; }
        public int ValorSupervisor { get; set; }
        public string Observaciones { get; set; }
        public int PersonaPersonaId { get; set; }
    
        public virtual Persona Persona { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CampoClinicoAlumno> CampoClinicoAlumno { get; set; }
    }
}
