using SAS.v1.ClasesNP;
using SAS.v1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SAS.v1.Services
{
    public class InstitucionServices
    {

        private ModeloContainer db = new ModeloContainer();

       public InstitucionNP BuscarCampoClinico(int? id)
       {
           InstitucionNP CampoC = new InstitucionNP();
           CampoC.CampoClinicos = db.NombreCampoClinicoSet.Where(c => c.InstitucionId == id).ToList();
           return CampoC;
       }
    }
}