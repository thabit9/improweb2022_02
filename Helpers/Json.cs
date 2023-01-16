using System;
using System.Data;
using System.Text;

namespace improweb2022_02.Helpers
{
    public class json
    {
        public struct jsonData
        {
            public bool Success;
            public string html;
            public string RedirectURL;
        }

        public struct jsonProductData
        {
            public bool Success;
            public string productData;
            public string filterData;
        }

        public static string jsonOut(jsonData jl)
        {
            StringBuilder sbOut = new StringBuilder();
            sbOut.Append("{");
            sbOut.Append(string.Format(@"""success"":""{0}"", ", jl.Success.ToString().ToLower()));
            sbOut.Append(string.Format(@"""html"":""{0}"", ", fixJSONText(jl.html)));
            sbOut.Append(string.Format(@"""url"":""{0}"" ", fixJSONText(jl.RedirectURL)));
            sbOut.Append("}");
            return sbOut.ToString();
        }

        public static string jsonProductOut(jsonProductData jp)
        {
            StringBuilder sbOut = new StringBuilder();
            sbOut.Append("{");
            sbOut.Append(string.Format(@"""success"":""{0}"", ""phtml"":""{1}"", ""fhtml"":""{2}"" ", 
                jp.Success.ToString().ToLower(), fixJSONText(jp.productData), fixJSONText(jp.filterData)));
            sbOut.Append("}");
            return sbOut.ToString();
        }

        public static string fixJSONText(string strIn)
        {
            StringBuilder sbOut = new StringBuilder();
            if (string.IsNullOrEmpty(strIn))
                sbOut.Append("");
            else
                sbOut.Append(strIn);
            sbOut.Replace("\\", "\\\\");
            sbOut.Replace(@"""", @"\""");
            sbOut.Replace(@"�", @"\""");
            sbOut.Replace("\r", "");
            sbOut.Replace("\n", "\\n");
            return sbOut.ToString();
        }

        public static string decodeJasonText(string strIn)
        {
            StringBuilder sbOut = new StringBuilder();
            if(string.IsNullOrEmpty(strIn))
                sbOut.Append("");
            else
                sbOut.Append(strIn);
            sbOut.Replace(@"\/",@"/");
            sbOut.Replace(@"\""", @"""");
            return sbOut.ToString();
        }
    }
}
