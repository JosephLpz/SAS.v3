using SAS.v1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SAS.v1.ClasesNP
{
    public class DataPointAlumno
    {
        public DataPointAlumno(DataPoint dataPoint, List<Alumno> alumno )
        {
            this.dataPoint = dataPoint;
            this.alumno = alumno;
        }

        public DataPointAlumno()
        {
       
        }
        public DataPoint dataPoint { get; set; }
        public List<Alumno> alumno { get; set; }
    }
}