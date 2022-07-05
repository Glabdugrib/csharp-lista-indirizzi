using System.IO;

namespace csharp_lista_indirizzi
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Address> addresses = new List<Address>();

            string path = "C:\\Users\\Simone\\source\\repos\\csharp-lista-indirizzi\\addresses.csv";

            if (File.Exists(path))
            {
                // File creation
                StreamReader file = File.OpenText(path);

                uint lineCount = 0;

                // File read
                while (!file.EndOfStream)
                {
                    lineCount++;

                    try
                    {
                        string line = file.ReadLine();
                        string[] values = line.Split(',');

                        // Checks
                        if (values.Length > 6)
                        {
                            throw new Exception($"Too many values at line {lineCount}");
                        }

                        foreach(string value in values)
                        {
                            if(value == "")
                            {
                                throw new Exception($"Missing value at line {lineCount}");
                            }
                        }

                        // Creation of Addres obj and save
                        Address address = new Address(values[0], values[1], values[2], values[3], values[4], values[5]);
                        addresses.Add(address);
                    }
                    catch(Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }

                // Close file
                file.Close();
            }
            else
            {
                Console.WriteLine("File doesn't exist!");
            }


            // Stampa
            foreach(Address address in addresses)
            {
                if(address != addresses[0])
                {
                    address.ToString();
                }
                
            }
        }
    }
}

//