using SAS.v1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SAS.v1.ClasesNP
{
    public class AlumnoAsignaturaPreRequisitoNP
    {

      public PlanDeEstudio Asigantura { get; set; }

      public List<Alumno> Alumnos { get; set; }

        public AlumnoAsignaturaPreRequisitoNP()
        {

        }

    }
}