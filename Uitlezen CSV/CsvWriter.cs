
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Uitlezen_CSV
{
    class CsvWriter
    {
        public static void writeCsvNoStreamWriter()
        {
            string filepath = @"D:\DemoData.csv";
            StringBuilder output = new StringBuilder();
            output.AppendLine("1,2,3");
            output.AppendLine("4,5,6");

            File.WriteAllText(filepath, output.ToString());
            File.AppendAllText(filepath, output.ToString());
        }
        public static void writeCsvStreamWriter()
        {
            using (StreamWriter streamWriter = new StreamWriter(@"D:\DemoData.csv"))
            {
                streamWriter.WriteLine("1,2,3");
                streamWriter.WriteLine("4,5,6");
            }
        }
        public static void WriteTXTStreamWriter(string typeCode,string text)
        {
            DateTime date = DateTime.Now;
            using (StreamWriter streamWriter = new StreamWriter($@"D:\{typeCode} {date.ToString("dd MM yyyy HH mm ss")}.txt"))
            {
                streamWriter.WriteLine(text);
            }
        }
    }
}
