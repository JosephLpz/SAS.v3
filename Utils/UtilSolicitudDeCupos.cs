using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SAS.v1.ClasesNP;
using SAS.v1.Models;

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

        public List<SolicitudDeCuposNP> GetSolicitudes(List<DataPoint> dataPoint)
        {
            SolicitudDeCuposNP solicitud = new SolicitudDeCuposNP();
            List<SolicitudDeCuposNP> solicitudes = new List<SolicitudDeCuposNP>();
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
            
            }
            return solicitudes;
        }
    }
}