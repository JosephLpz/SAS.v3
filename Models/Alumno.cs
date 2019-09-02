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
    
    public partial class Alumno
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Alumno()
        {
            this.CampoClinicoAlumno = new HashSet<CampoClinicoAlumno>();
            this.AsignaturaAlumno = new HashSet<AsignaturaAlumno>();
            this.ImunizacionAlumno = new HashSet<InmunizacionAlumno>();
            this.CursoAlumno = new HashSet<CursoAlumno>();
        }
    
        public int AlumnoId { get; set; }
        public string Observaciones { get; set; }
        public int PersonaPersonaId { get; set; }
        public int CentroFormadorCentroFormadorId { get; set; }
    
        public virtual Persona Persona { get; set; }
        public virtual CentroFormador CentroFormador { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CampoClinicoAlumno> CampoClinicoAlumno { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AsignaturaAlumno> AsignaturaAlumno { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<InmunizacionAlumno> ImunizacionAlumno { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CursoAlumno> CursoAlumno { get; set; }


        public virtual string cursoNivel
        {

            get
            {
                int curso = -1;
                int NCurso;
                foreach(var item in CursoAlumno)
                {
                   NCurso = Int32.Parse(item.CursoNivel.NombreCurso.Substring(0, 1));

                    if (curso < NCurso)
                    {
                        curso = NCurso;
                    }
                }
                return curso +" "+"Año";
            }
        }
    }
}
