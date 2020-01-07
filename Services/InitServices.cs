using SAS.v1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace SAS.v1.Services
{
    public class InitServices
    {
        private ModeloContainer db = new ModeloContainer();
        public void CrearAnios()
        {
            var anios = db.Anios.ToList();
            int anioStart;
            if (anios.Count == 0)
            {
                for (anioStart = 1980; anioStart <= 2050; anioStart++)
                {
                    Anio anio = new Anio();
                    anio.Ano = anioStart.ToString();

                    db.Anios.Add(anio);
                    db.SaveChanges();
                }
            }
        }

        public bool CheckForInternetConnection()
        {
            try
            {
                using (var client = new WebClient())
                using (client.OpenRead("http://google.com/generate_204"))
                    return true;
            }
            catch
            {
                return false;
            }
        }

    }
}