using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

using GbDriver;

namespace GbDriver.Helpers
{
    class CSV_Data
    {
        public string? path, hldPath;

        public CSV_Data()
        {
            this.path = null;
        }
        public CSV_Data(string path)
        {
            this.path = path;
        }

        public CSV_Data ReadGbData()
        {      
            CSV_Data data = new CSV_Data( "../../../Test Data/gbUserData.csv");  
           
            return data;
        }


        public CSV_Data ReadDummyData()
        {      
            CSV_Data data = new CSV_Data( "../../../Test Data/dummyUserData.csv");  
           
            return data;
        }
        public List<string> Read()
        {
            List<string> testData = new List<string>();
            try
            {
                string[] lines = File.ReadAllLines(path);

                for (int i = 1; i < lines.Length; i++)
                {
                    testData.Add(lines[i]);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading CSV: {ex.Message}");
            }
            return testData;
        }
        public void Append(List<string> data)
        {
            try
            {
                File.AppendAllLines(path, data);
                Console.WriteLine("Data appended to CSV successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error appending to CSV: {ex.Message}");
            }
        }
        public void Write(List<string> data)
        {
            try
            {
                File.WriteAllLines(path, data);
                Console.WriteLine("Data written to CSV successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error writing to CSV: {ex.Message}");
            }
        }

        public bool IsHeaderPresent()
        {
            try
            {
                string[] lines = File.ReadAllLines(path);

                // Check if the file has at least one line
                if (lines.Length > 0)
                {
                    // Check if the first line contains the expected header
                    return lines[0].ToLower().Contains("name") && lines[0].ToLower().Contains("email") && lines[0].ToLower().Contains("password");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error checking header in CSV: {ex.Message}");
            }

            return false;
        }
        public void RemoveRecordByName(string name)
        {
            try
            {
                List<string> linesToKeep = new List<string>();
                string[] lines = File.ReadAllLines(path);

                // Add lines excluding the ones with the specified name
                for (int i = 1; i < lines.Length; i++)
                {
                    if (!lines[i].Contains(name))
                    {
                        linesToKeep.Add(lines[i]);
                    }
                }

                File.WriteAllLines(path, linesToKeep);
                Console.WriteLine($"Records with name '{name}' removed successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error removing record: {ex.Message}");
            }
        }
        public bool IsRecordPresent(string userData)
        {
            try
            {
                string[] lines = File.ReadAllLines(path);

                foreach (string line in lines)
                {
                    // Check if the line contains the given user data
                    if (line.Contains(userData))
                    {
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error checking record in CSV: {ex.Message}");
            }

            return false;
        }
    }
}
