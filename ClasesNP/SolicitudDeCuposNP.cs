using SAS.v1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SAS.v1.ClasesNP
{
    public class SolicitudDeCuposNP
    {
        public DataPoint Solicitud { get; set; }

        public List<SolicitudDeCupo> solicitudes { get; set; }
    }
}