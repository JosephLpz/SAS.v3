using SAS.v1.ClasesNP;
using SAS.v1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SAS.v1.Services
{
    public class UnidadDeServicioServices
    {
        ModeloContainer db = new ModeloContainer();

        //public UnidadServicioNP BuscarUnidadServicio(int? id)
        //{
        //    UnidadServicioNP unidadServicio = new UnidadServicioNP();
        //    CampoClinico campo = new CampoClinico();
        //    campo = db.CampoClinicos.Find(id);
        //    unidadServicio.Campo = new CampoClinico();
        //    unidadServicio.Campo.NombreCampoClinico = new NombreCampoClinico();
        //    unidadServicio.Campo.NombreCampoClinico.NombreCampo = campo.NombreCampoClinico.NombreCampo;

        //    unidadServicio.UnidadServicio = db.UnidadDeServicios.Where(u => u.CampoClinicoId == id).ToList();

        //    return  unidadServicio;
        //}
        //public UnidadDeServicioAlumnosNP BuscarAlumnosPorUnidadServicio(int id)
        //{
        //    UnidadDeServicioAlumnosNP UnidadAlumnos = new UnidadDeServicioAlumnosNP();
        //    UnidadDeServicio unidad = new UnidadDeServicio();
        //    unidad = db.UnidadDeServicios.Find(id);
        //    UnidadAlumnos.unidad = new UnidadDeServicio();
        //    UnidadAlumnos.unidad.NombreUnidadDeServicio = unidad.NombreUnidadDeServicio;
        //    UnidadAlumnos.CamposAlumnos = new List<CampoClinicoAlumno>();

        //    UnidadAlumnos.CamposAlumnos = db.CampoClinicoAlumnos.Where(a => a.UnidadDeServicioUnidadDeServicioId == id).ToList();

        //    return UnidadAlumnos;

        //}
    }
}