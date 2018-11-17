using SAS.v1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SAS.v1.ClasesNP
{
    public class DocenteGuiaCamposClinicos
    {

        public ProfesionalDocenteGuia profesional  { get;set ; }
      
        public List<CampoClinicoAlumno> listaCamposClinicos { get; set; }
    }
}