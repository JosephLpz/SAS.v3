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
    
    public partial class CampoClinicoAlumno
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CampoClinicoAlumno()
        {
            this.CampoClinicoAlumnoDias = new HashSet<CampoClinicoAlumnoDias>();
        }
    
        public int Id { get; set; }
        public int AlumnoAlumnoId { get; set; }
        public int ProfesionalSupervidorProfesionalSupervisorId { get; set; }
        public int UnidadDeServicioUnidadDeServicioId { get; set; }
        public int PeriodoPeriodoId { get; set; }
        public int AsignaturaId { get; set; }
        public int SemestreId { get; set; }
        public int AnioId { get; set; }
        public int ProfesionalDocenteGuiaProfesionalDocenteGuiaId { get; set; }
        public int InstitucionId { get; set; }
        public int NombreCampoClinicoId { get; set; }
    
        public virtual Alumno Alumno { get; set; }
        //public virtual ProfesionalSupervisor ProfesionalSupervidor { get; set; }
        public virtual Periodo Periodo { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CampoClinicoAlumnoDias> CampoClinicoAlumnoDias { get; set; }
        public virtual Asignatura Asignatura { get; set; }
        public virtual Semestre Semestre { get; set; }
        public virtual Anio Anio { get; set; }
        public virtual ProfesionalDocenteGuia ProfesionalDocenteGuia { get; set; }
        public virtual NombreCampoClinico NombreCampoClinico { get; set; }
        public virtual string Dias
        {
            get
            {
                string dia = "";
                foreach (var item in CampoClinicoAlumnoDias)
                {
                    dia = (dia + string.Format("{0}", item.Dias.Dia) + "-");
                }
                dia = dia.TrimEnd('-');
                return dia;
            }
        }
    }
}
