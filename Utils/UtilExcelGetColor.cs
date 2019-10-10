using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Spire.Xls;
using Spire.Xls.Collections;

namespace SAS.v1.Utils
{
    public class UtilExcelGetColor
    {

        Workbook workbook = new Workbook();
        //Trae el color de la celda dependiendo de un rango, especificamente necesito solo una celda
        //asi que el rango es el mismo, primero abre el archivo con FileName y el metodo LoadFromFile
        //Luego trae todas las hojas de el archivo xls y busca la hoja ingresada por el usuario en NombreHoja
        public int[] getColorCell(string FileName, string rango,string NombreHoja)
        {
            int[] value = new int[4];

            
            workbook.LoadFromFile(FileName);     
            var results = GetAllWorksheets(FileName);
            foreach (Worksheet item in results)
            {
                if (item.Name.ToString()==NombreHoja)
                {
                    Worksheet worksheet = workbook.Worksheets[item.Index];
                    var color = worksheet.Range[rango + ":" + rango].Style.Color;

                    value[0] = color.A;
                    value[1] = color.R;
                    value[2] = color.G;
                    value[3] = color.B;
                   
                   
                }
            }

            //Worksheet worksheet = workbook.Worksheets[2];
            //var color = worksheet.Range["R9:R9"].Style.Color;
            //var color = worksheet.Range[rango+":"+rango].Style.Color;
            
            return value;

        }
        //trae el numero de columnas de la tabla
        public int getCountColumn(string FileName)
        {
            workbook.LoadFromFile(FileName);
         int value= workbook.ActiveSheet.Columns.Count();

            return value;
        }
        public int getRows(string FileName)
        {
            workbook.LoadFromFile(FileName);
            int value = workbook.ActiveSheet.Rows.Count();
            return value;
        }
        public static WorksheetsCollection GetAllWorksheets(string fileName)
        { 
    //Initialize a new Workboook object

    Workbook workbook = new Workbook();

    //Load the document

    workbook.LoadFromFile(fileName);


    //Get all worksheets

    WorksheetsCollection worksheets = workbook.Worksheets;

    return worksheets;

        }

        
    }
}