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
                BinaryWriter fout = new BinaryWriter(new FileStream("binary.dat", FileMode.Create));
                double d = 0;
                int i = 1;
                while (i < 11)
                {
                    fout.Write(d);
                    d += 0.33;
                    d *= Math.Pow(-1, i);
                    i++;
                }
                fout.Close();
                i = 0;
                FileStream f = new FileStream("binary.dat", FileMode.Open);
                BinaryReader fin = new BinaryReader(f);
                try
                {
                    while (true)
                    {
                        d = fin.ReadDouble();     // чтение из файла вещественных чисел 
                        if (d < 0)
                        {
                            i++;
                        }
                    }
                }
                catch (EndOfStreamException e) { }
                fin.Close();
                f.Close();

                fout = new BinaryWriter(new FileStream("binary.dat", FileMode.Append));
                fout.Write(i);   // запись в конец файла количества отрицательных элементов
                fout.Close();
                Console.WriteLine("i= " + i);  //отладочная печать

                fin = new BinaryReader(new FileStream("binary.dat", FileMode.Open));
                for (int j = 0; j < 10; j++)   // печать содержащихся в файле вещественных чисел
                {
                    d = fin.ReadDouble();
                    Console.Write(d + " ");
                }
                i = fin.ReadInt32();   // считывание количества отрицательных элементов с конца файла
                Console.WriteLine();
                Console.WriteLine("negative = " + i);
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
