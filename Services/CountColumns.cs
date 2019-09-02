using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SAS.v1.Services
{
    public class CountColumns
    {
        //Algoritmo que identifica cada una de las cabeceras de las columnas de un archivo xls
        //
        public List<string> GetHeadColumn(int NumeroDeColumnas)
        {
            List<string> value= new List<string>();
            int Ascii = 65;
            int AsciiContigua = 65;
            char letraContigua=' ';
            for (int i=1; i <= NumeroDeColumnas; i++)
            {

                char letra = (char)Ascii;
                if (Ascii==91)
                {
                    letraContigua = (char)AsciiContigua;
                    Ascii = 65;
                   letra = (char)Ascii;

                    AsciiContigua++;
                }
                if (letraContigua==' ')
                {
                    value.Add(letra.ToString());
                }else
                {
                value.Add(string.Concat(letraContigua.ToString(),letra.ToString()));
            
                }
                Ascii++;

            }


            return value;

        }
    }
}