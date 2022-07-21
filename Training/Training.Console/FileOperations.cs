using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Training
{
    public class FileOperations
    {
        private const string fileToRead = @"C:\Users\Seth Clossman\source\repos\DotNET-Full-Stack-Class-Notes\Training\Training.Console\FileToRead.txt";
        private const string fileToWrite = @"C:\Users\Seth Clossman\source\repos\DotNET-Full-Stack-Class-Notes\Training\Training.Console\FileToWrite.txt";
        private const string testCsv = @"C:\Users\Seth Clossman\source\repos\DotNET-Full-Stack-Class-Notes\Training\Training.Console\Test.csv";

        public void ReadFile()
        {
            //string allText = File.ReadAllText(fileToRead);

            //Console.WriteLine("All text: {0}", allText);

            //string[] allLines = File.ReadAllLines(fileToRead);

            //foreach (string line in allLines)
            //{
            //    Console.WriteLine(line);
            //    Console.WriteLine("-------------------------------------------------------");
            //}

            using (StreamReader reader = new StreamReader(fileToRead))
            {
                //string line;
                //while ((line = reader.ReadLine()) != null)
                //{
                //    Console.WriteLine(line);
                //}

                while (reader.Peek() > -1)
                {
                    
                    string eachLine = reader.ReadLine();
                    Console.WriteLine(eachLine);
                }
            }
        }

        public void WriteFile()
        {
            if (File.Exists(fileToWrite))
            {
                Console.WriteLine("The file exists, appending to it");
            } 
            else
            {
                Console.WriteLine("The file does not exist, creating and appending to the file");
            }

            using (StreamWriter writer = File.AppendText(fileToWrite))
            {
                writer.Write("This is a test. --- ");
                writer.WriteLine("This adds to the previous text.");
                writer.WriteLine("Writes another line to the file.");
                writer.WriteLine("The last line of text");
                writer.WriteLine("=======================");
            }

        }

        public IEnumerable<CSVData> ReadCSV()
        {
            List<CSVData> retList = new List<CSVData>();

            using (StreamReader reader = new StreamReader(testCsv))
            {
                reader.ReadLine();
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    string[] vals = line.Split(',');

                    retList.Add(
                        new CSVData(
                            Convert.ToInt32(vals[0]),
                            vals[1],
                            vals[2],
                            vals[3],
                            vals[4],
                            vals[5]
                            )
                        );
                }
            }
            return retList;
        }

    }
}
