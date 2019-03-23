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
            Institucion InstitucionEntity = db.Institucions.Find(id);
            CampoC.Institucion = new Institucion();
            CampoC.Institucion.NombreInstitucion = InstitucionEntity.NombreInstitucion;

            CampoC.CampoClinicos = db.CampoClinicos.Where(c => c.InstitucionId == id).ToList();
            return CampoC;
        }
    }
}