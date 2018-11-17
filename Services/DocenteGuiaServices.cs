using SAS.v1.ClasesNP;
using SAS.v1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SAS.v1.Services
{
    public class DocenteGuiaServices
    {
        private ModeloContainer db = new ModeloContainer();
        public DocenteGuiaCamposClinicos BuscarCamposDocente (int? id)
        {
            DocenteGuiaCamposClinicos DocenteCampos = new DocenteGuiaCamposClinicos();
            ProfesionalDocenteGuia DocenteGuia = db.ProfesionalDocenteGuias.Find(id);

            DocenteCampos.profesional = new ProfesionalDocenteGuia();
            DocenteCampos.profesional.Persona = new Persona();
            DocenteCampos.profesional.DocenciaHospitalaria = new DocenciaHospitalaria();
            DocenteCampos.profesional.Inmunizacion = new Inmunizacion();
            DocenteCampos.profesional.Persona.Rut = DocenteGuia.Persona.Rut;
            DocenteCampos.profesional.Persona.Dv = DocenteGuia.Persona.Dv;
            DocenteCampos.profesional.Persona.Nombre = DocenteGuia.Persona.Nombre;
            DocenteCampos.profesional.Persona.ApPaterno = DocenteGuia.Persona.ApPaterno;
            DocenteCampos.profesional.Persona.ApMaterno = DocenteGuia.Persona.ApMaterno;
            DocenteCampos.profesional.Profesion = DocenteGuia.Profesion;
            DocenteCampos.profesional.NumeroSuperintendencia = DocenteGuia.NumeroSuperintendencia;
            DocenteCampos.profesional.Telefono = DocenteGuia.Telefono;
            DocenteCampos.profesional.Correo = DocenteGuia.Correo;
            DocenteCampos.profesional.ValorDocente = DocenteGuia.ValorDocente;
            DocenteCampos.profesional.DocenciaHospitalaria.NombreDocenciaHospitalaria = DocenteGuia.DocenciaHospitalaria.NombreDocenciaHospitalaria;
            DocenteCampos.profesional.Inmunizacion.NombreInmunizacion = DocenteGuia.Inmunizacion.NombreInmunizacion;

            DocenteCampos.listaCamposClinicos = (from d in db.CampoClinicoAlumnos where d.ProfesionalDocenteGuiaProfesionalDocenteGuiaId == id select d).ToList();

            return DocenteCampos;
        }
    }
}