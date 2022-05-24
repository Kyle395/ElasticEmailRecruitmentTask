using System;
using System.Collections.Generic;
using Microsoft.VisualBasic.FileIO;

namespace ElasticRecruitmentTask
{
    class CsvFileReader
    {
        MailValidation mailValidation;
        public CsvFileReader(){
            mailValidation = new MailValidation();
        }
        public string[] ReadCsvFile(string filePath)
        {
            if (filePath == null)
            {
                Console.WriteLine("An error occured while reading the file. \n" +
                    "Are you sure the file is in the correct format? \n" +
                    "For information on how to build the file, go to the website:\n" +
                    "https://help.elasticemail.com/en/articles/4966686-how-to-upload-your-contacts");
                Console.ReadKey();
                return null;
            }
            else
            {
                List<string> address = new List<string>();
                TextFieldParser parser = initializeParser(filePath);
                while (!parser.EndOfData)
                {
                    parseData(address, parser);
                }
                address.RemoveAt(0);
                if (mailValidation.ValidateRecipientEmail(address.ToArray())) return address.ToArray();
                return null;
            }
        }

        private static TextFieldParser initializeParser(string filePath)
        {
            var parser = new TextFieldParser(filePath);
            parser.TextFieldType = FieldType.Delimited;
            parser.SetDelimiters(new string[] { ";" });
            return parser;
        }

        private static void parseData(List<string> address, TextFieldParser parser)
        {
            string[] row = parser.ReadFields();
            string[] column = row[0].Split(',');
            address.Add(column[0]);
        }
    }
}
