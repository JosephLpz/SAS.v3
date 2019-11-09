using SAS.v1.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace SAS.v1.ClasesNP
{
    public class AlumnoNP
    {
        public int PersonaId { get; set; }

        [DisplayName("Rut")]
        public string Rut { get; set; }
        [DisplayName("Dv")]
        public string Dv { get; set; }
        [DisplayName("Nombre")]
        public string Nombre { get; set; }
        [DisplayName("Apellido Paterno")]
        public string ApPaterno { get; set; }
        [DisplayName("Apellido Materno")]
        public string ApMaterno { get; set; }

        public int AlumnoId { get; set; }

        [DisplayName("Curso")]
        public string CursoNivel { get; set; }
        [DisplayName("Carrera")]
        public string Carrera { get; set; }
        [DisplayName("Inmunización")]
        public string Inmunizacion { get; set; }

        public bool check { get; set;}
    }

    public class AlumnosNP
    {
        public Alumno alumnos { get; set; }

        public bool check { get; set; }

    }
   
}