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
    
    public partial class CampoClinico
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CampoClinico()
        {
            this.UnidadDeServicio = new HashSet<UnidadDeServicio>();
        }
    
        public int Id { get; set; }
        public int NombreCampoClinicoId { get; set; }
        public int InstitucionId { get; set; }
    
        public virtual NombreCampoClinico NombreCampoClinico { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UnidadDeServicio> UnidadDeServicio { get; set; }
        public virtual Institucion Institucion { get; set; }
    }
}
