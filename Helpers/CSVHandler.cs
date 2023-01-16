using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace improweb2022_02.Helpers
{
    public class CSVHandler
    {
        public static string GetCSV(DataTable dt)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                DataColumn dc = dt.Columns[i];
                sb.Append(dc.ColumnName);
                if (i != dt.Columns.Count - 1)
                    sb.Append(",");
            }
            sb.AppendLine();
            foreach (DataRow r in dt.Rows)
            {
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    DataColumn dc = dt.Columns[i];
                    sb.Append("\"" + r[dc.ColumnName].ToString().Replace("\"", "\"\"") + "\"");
                    if (i != dt.Columns.Count - 1)
                        sb.Append(",");
                }
                sb.AppendLine();
            }
            return sb.ToString();
        }

        private static string ReadLine(string text, out int currentPos, int startPos)
        {
            StringBuilder line = new StringBuilder();
            currentPos = startPos;
            bool inQuote = false;

            for (; currentPos < text.Length; currentPos++)
            {
                line.Append(text[currentPos]);
                if (currentPos < text.Length - 1 && text[currentPos] == '\n' && !inQuote)
                {
                    currentPos++;
                    return line.ToString();
                }
                else if (text[currentPos] == '\"')
                {
                    if (currentPos < text.Length - 1 && text[currentPos + 1] == '\"')
                    {
                        currentPos++;
                        line.Append(text[currentPos]);
                    }
                    else
                        inQuote = !inQuote;
                }
            }
            return line.ToString();
        }

        public static DataTable GetDataTable(string csv)
        {
            DataTable dt = new DataTable();
            List<string> values = new List<string>();

            int currentPos = 0, totalCount = 0, successCount = 0;
            //ReadLine(allText, out currentPos, currentPos);//Skip the header

            bool isHeader = true;
            while (currentPos < csv.Length)
            {
                string line = ReadLine(csv, out currentPos, currentPos);

                line = line.TrimEnd(new char[] { '\n', '\r' });

                bool inQuote = false;
                values.Clear();
                StringBuilder temp = new StringBuilder();
                for (int i = 0; i < line.Length; i++)
                {
                    if (line[i] == '"')
                    {
                        if (i + 1 < line.Length && line[i + 1] == '"')
                        {
                            temp.Append('"');
                            i++;
                        }
                        else
                        {
                            inQuote = !inQuote;
                        }
                    }
                    else if (line[i] == ',' && !inQuote)
                    {
                        values.Add(temp.ToString());
                        temp = new StringBuilder();
                    }
                    else
                        temp.Append(line[i]);
                }
                values.Add(temp.ToString());

                if (isHeader)
                {
                    isHeader = false;
                    foreach (string s in values)
                        dt.Columns.Add(s);
                }
                else
                {
                    int missingCols = dt.Columns.Count - values.Count;
                    if (missingCols < 0)
                        throw new Exception("Too many columns at " + (totalCount));
                    for (int i = 0; i < missingCols; i++) //If number of columns is too low, pad with blank cols.
                        values.Add("");
                    dt.Rows.Add(values.ToArray());
                    successCount++;
                }
                totalCount++;
            }

            return dt;
        }
    
    }
}