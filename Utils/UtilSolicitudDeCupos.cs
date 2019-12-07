using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SAS.v1.ClasesNP;
using SAS.v1.Models;
using SAS.v1.Services;

namespace SAS.v1.Utils
{
    public class UtilSolicitudDeCupos
    {
        public int GetMayorNumeroDeCupos(List<DataPoint> data)
        {
            int numMayor=-1;
            foreach(var item in data)
            {
                if (item.Y > numMayor)
                {
                    numMayor = (int) item.Y;
                }
            }
            return numMayor;
        }

        public List<SolicitudDeCuposNP> GetSolicitudes(int index, List<SolicitudDeCuposNP> solicitudes, SolicitudDeCuposNP solicitud, List<DataPoint> dataPoint, SolicitudDeCupo solicitudCupo)
        {
            if (solicitudes.Count == 0)
            {
                foreach (var item in dataPoint)
                {
                    solicitud = new SolicitudDeCuposNP();
                    solicitud.Solicitud = new DataPoint();
                    solicitud.Solicitud.Label = item.Label;
                    solicitud.Solicitud.Y = item.Y;
                    solicitud.solicitudes = new List<SolicitudDeCupo>();
                    
                    solicitudes.Add(solicitud);
                }

            }else
            {
                for(int i = 0; i < dataPoint.Count; i++)
                {
                    solicitudes[i].Solicitud.Label = dataPoint[i].Label;
                    solicitudes[i].Solicitud.Y = dataPoint[i].Y;
                }
            }
            solicitudes[index].solicitudes.Add(solicitudCupo);
            return solicitudes;
        }

        public List<ProyeccionDeCupo> GetProyecciones(int[] Proyeccion)
        {
           
            List<ProyeccionDeCupo> Proyecciones = new List<ProyeccionDeCupo>();
            IngresoServices ingreso = new IngresoServices();
            foreach(var item in Proyeccion)
            {
                Proyecciones.Add(ingreso.ProyeccionFindById(item));
            }
            //if (solicitudes.Count == 0)
            //{
            //    foreach (var item in dataPoint)
            //    {
            //        solicitud = new SolicitudDeCuposNP();
            //        solicitud.Solicitud = new DataPoint();
            //        solicitud.Solicitud.Label = item.Label;
            //        solicitud.Solicitud.Y = item.Y;
            //        solicitud.solicitudes = new List<SolicitudDeCupo>();

            //        solicitudes.Add(solicitud);
            //    }
            
            //}
            return Proyecciones;
        }
    }
}