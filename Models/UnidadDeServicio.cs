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
    
    public partial class UnidadDeServicio
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public UnidadDeServicio()
        {
            this.CampoClinicoAlumno = new HashSet<CampoClinicoAlumno>();
        }
    
        public int UnidadDeServicioId { get; set; }
        public int NombreUnidadDeServicioId { get; set; }
        public int CampoClinicoId { get; set; }
    
        public virtual NombreUnidadDeServicio NombreUnidadDeServicio { get; set; }
        public virtual CampoClinico CampoClinico { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CampoClinicoAlumno> CampoClinicoAlumno { get; set; }
    }
}
