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
    
    public partial class CentroFormador
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CentroFormador()
        {
            this.Alumno = new HashSet<Alumno>();
        }
    
        public int CentroFormadorId { get; set; }
        public int CarreraCarreraId { get; set; }
        public int NombreCentroFormadorNombreCentroFormadorId { get; set; }
        public int AnioId { get; set; }
    
        public virtual Carrera Carrera { get; set; }
        public virtual NombreCentroFormador NombreCentroFormador { get; set; }
        public virtual Anio Anio { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Alumno> Alumno { get; set; }
    }
}
