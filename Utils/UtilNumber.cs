using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SAS.v1.Utils
{
    public class UtilNumber
    {
        public bool IsNumeric(string input)
        {
            int test;
            return int.TryParse(input, out test);
        }
    }
}