using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using System;
using System.Linq;

namespace WebPedigree.Utiles
{
    public class UtilExcel
    {
        SpreadsheetDocument document = null;
        WorkbookPart wbPart = null;
        Sheet theSheet = null;

        public bool init(string fileName, string sheetName)
        {
            // Open the spreadsheet document for read-only access.
            document = SpreadsheetDocument.Open(fileName, false);
            if (document == null) return false;
            // Retrieve a reference to the workbook part.
            wbPart = document.WorkbookPart;

            // Find the sheet with the supplied name, and then use that 
            // Sheet object to retrieve a reference to the first worksheet.
            theSheet = wbPart.Workbook.Descendants<Sheet>().Where(s => s.Name == sheetName).FirstOrDefault();

            // Throw an exception if there is no sheet.
            if (theSheet == null)
            {
                throw new ArgumentException("sheetName");
            }
            return true;
        }

        // Retrieve the value of a cell, given a file name, sheet name, 
        // and address name.
        public string getCellValue(string addressName)
        {
            // Retrieve a reference to the worksheet part.
            WorksheetPart wsPart = (WorksheetPart)(wbPart.GetPartById(theSheet.Id));

            string value = null;

            // Use its Worksheet property to get a reference to the cell 
            // whose address matches the address you supplied.
            Cell theCell = wsPart.Worksheet.Descendants<Cell>().
                Where(c => c.CellReference == addressName).FirstOrDefault();

            // If the cell does not exist, return an empty string.
            if (theCell != null)
            {
                value = theCell.InnerText;

                // If the cell represents an integer number, you are done. 
                // For dates, this code returns the serialized value that 
                // represents the date. The code handles strings and 
                // Booleans individually. For shared strings, the code 
                // looks up the corresponding value in the shared string 
                // table. For Booleans, the code converts the value into 
                // the words TRUE or FALSE.
                if (theCell.DataType != null)
                {
                    switch (theCell.DataType.Value)
                    {
                        case CellValues.SharedString:

                            // For shared strings, look up the value in the
                            // shared strings table.
                            var stringTable =
                                wbPart.GetPartsOfType<SharedStringTablePart>()
                                .FirstOrDefault();

                            // If the shared string table is missing, something 
                            // is wrong. Return the index that is in
                            // the cell. Otherwise, look up the correct text in 
                            // the table.
                            if (stringTable != null)
                            {
                                value =
                                    stringTable.SharedStringTable
                                    .ElementAt(int.Parse(value)).InnerText;
                            }
                            break;

                        case CellValues.Boolean:
                            switch (value)
                            {
                                case "0":
                                    value = "FALSE";
                                    break;
                                default:
                                    value = "TRUE";
                                    break;
                            }
                            break;
                        }
                    }
                }
            return value;
        }

        internal string getCellValue(string v, int fila)
        {
            throw new NotImplementedException();
        }

        public void close()
        {
            document = null;
            wbPart = null;
            theSheet = null;
        }
    }
}