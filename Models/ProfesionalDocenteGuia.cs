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
    
    public partial class ProfesionalDocenteGuia
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ProfesionalDocenteGuia()
        {
            this.CampoClinicoAlumno = new HashSet<CampoClinicoAlumno>();
        }
    
        public int ProfesionalDocenteGuiaId { get; set; }
        public string Profesion { get; set; }
        public long NumeroSuperintendencia { get; set; }
        public long Telefono { get; set; }
        public string Correo { get; set; }
        public string CumpleDatos { get; set; }
        public long ValorDocente { get; set; }
        public int PersonaPersonaId { get; set; }
        public int DocenciaHospitalariaDocenciaHospitalariaId { get; set; }
        public int InmunizacionInmunizacionId { get; set; }
    
        public virtual Persona Persona { get; set; }
        public virtual DocenciaHospitalaria DocenciaHospitalaria { get; set; }
        public virtual Inmunizacion Inmunizacion { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CampoClinicoAlumno> CampoClinicoAlumno { get; set; }
    }
}
