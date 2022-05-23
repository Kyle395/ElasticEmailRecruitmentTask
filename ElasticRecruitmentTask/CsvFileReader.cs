using System;
using System.Collections.Generic;
using Microsoft.VisualBasic.FileIO;

namespace ElasticRecruitmentTask
{
    class CsvFileReader
    {
        public string[] ReadCsvFile(string filePath)
        {
            if (filePath == null)
            {
                Console.WriteLine("An error occured while reading the file. \nAre you sure the file is in the correct format? \n" +
                    "For information on how to build the file, go to the website:\nhttps://help.elasticemail.com/en/articles/4966686-how-to-upload-your-contacts");
                Console.ReadKey();
                return null;
            }
            else
            {
                List<string> address = new List<string>();
                var parser = new TextFieldParser(filePath);
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(new string[] { ";" });
                while (!parser.EndOfData)
                {
                    string[] row = parser.ReadFields();
                    string[] column = row[0].Split(',');
                    address.Add(column[0]);
                }
                address.RemoveAt(0);
                return address.ToArray();
            }            
        }
    }
}
