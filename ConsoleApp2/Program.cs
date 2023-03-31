using System;
using System.IO;
namespace ConsoleApplication1
{
    class Program
    {
        static void Main()
        {
            try
            {
                BinaryWriter fout = new BinaryWriter(new FileStream("binary.txt", FileMode.Create));
                double d = 0;
                double min=0, max=0;
                int i = 1;
                while (i < 11)
                {
                    d = Convert.ToDouble(Console.ReadLine());
                    fout.Write(d);
                    i++;
                }
                fout.Close();
                i = 0;
                Console.WriteLine();
                FileStream f = new FileStream("binary.txt", FileMode.Open);
                BinaryReader fin = new BinaryReader(f);
                try
                {
                    while (true)
                    {
                        d = fin.ReadDouble();     // чтение из файла вещественных чисел 
                        i++;
                    }
                }
                catch (EndOfStreamException e) { }
                fin.Close();
                f.Close();

                fin = new BinaryReader(new FileStream("binary.txt", FileMode.Open));
                for (int j = 0; j < 10; j++)   // печать содержащихся в файле вещественных чисел
                {
                    
                    d = fin.ReadDouble();
                    if (j == 0)
                    {
                        max = d;
                        min = d;
                    }
                    Console.Write(d + " ");
                    if (d < min)
                        min = d;
                    if (d > max)
                        max = d;
                }
                Console.WriteLine();
                fin.Close();

                fout = new BinaryWriter(new FileStream("binary.txt", FileMode.Append));
                fout.Write(Math.Abs(max-min));
                fout.Close();
                Console.WriteLine();
                fin = new BinaryReader(new FileStream("binary.txt", FileMode.Open));
                while (true)
                    {
                        d = fin.ReadDouble();     // чтение из файла вещественных чисел 
                        Console.Write(d + " ");
                        i++;
                    }
                fin.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error end: " + e.Message);
                return;
            }
        }
    }
}
