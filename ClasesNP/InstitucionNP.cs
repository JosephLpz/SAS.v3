
using SAS.v1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
namespace SAS.v1.ClasesNP
{
    public class InstitucionNP
    {
        public Institucion Institucion { get; set; }

        public List<NombreCampoClinico> CampoClinicos { get; set; }

    }
}