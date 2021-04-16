using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;

namespace Uitlezen_CSV
{
    public class CsvReader
    {
        const string delimeter = "\",\"";
        public static void readCsvBasicStreamReader()
        {
            StreamReader streamReader = new StreamReader($@"");
            while (!streamReader.EndOfStream)
            {
                string line = streamReader.ReadLine();
                string[] values = line.Split(delimeter);

                //todo
            }
            streamReader.Close();
            streamReader.Dispose();
        }
        public static void readCsvBestPracticeStreamReader()
        {
            using (StreamReader streamReader = new StreamReader(@""))
            {
                while (!streamReader.EndOfStream)
                {
                    string line = streamReader.ReadLine();
                    string[] values = line.Split(delimeter);

                    //todo
                }
            }
        }
        public static void readCsvWithoutStreamReader()
        {
            string[] lines = System.IO.File.ReadAllLines(@"");
            foreach (string line in lines)
            {
                string[] values = line.Split(delimeter);

                //todo
            }
        }
        public static void readCsvNoQuotes()
        {
            char[] quotes = { '\"', ' ' };
            using (StreamReader streamReader = new StreamReader(@""))
            {
                while (!streamReader.EndOfStream)
                {
                    string line = streamReader.ReadLine();
                    string[] values = line
                        .Split(delimeter)
                        .Select(s => s.Trim(quotes).Replace("\\\"", "\""))
                        .ToArray();

                    //todo
                }
            }
        }
        public static void readCsvToDataTable()
        {
            DataTable dataTable = new DataTable();
            char[] quotes = { '\"', ' ' };
            using (StreamReader streamReader = new StreamReader(@""))
            {
                string[] headers = streamReader.ReadLine().Split(delimeter).Select(s => s.Trim(quotes).Replace("\\\"", "\"")).ToArray();

                foreach (string header in headers)
                {
                    dataTable.Columns.Add(header);
                }
                while (!streamReader.EndOfStream)
                {
                    string line = streamReader.ReadLine();
                    string[] values = line
                        .Split(delimeter)
                        .Select(s => s.Trim(quotes).Replace("\\\"", "\""))
                        .ToArray();

                    DataRow row = dataTable.NewRow();
                    for (int i = 0; i < values.Length; i++)
                    {
                        row[i] = values[i];
                    }
                    dataTable.Rows.Add(row);
                }
            }
        }

    }
}
