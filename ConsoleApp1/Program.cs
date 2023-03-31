using System;
using System.IO;
namespace ConsoleApplication1
{
    class Program
    {
        static void Main()
        {
                BinaryWriter fout = new BinaryWriter(new FileStream("F.txt", FileMode.Create));
                double d = 0;
                int i = 1;
                Console.WriteLine("Введите темперратуру по мсяцам:");
                while (i < 13)
                {
                    d = Convert.ToDouble(Console.ReadLine());
                    fout.Write(d);
                    i++;
                }
                fout.Close();
                i = 0;
                Console.WriteLine();
                FileStream f = new FileStream("F.txt", FileMode.Open);
                BinaryReader fin = new BinaryReader(f);

                
                double s = 0;
                for (int j = 0; j < 10; j++)   // печать содержащихся в файле вещественных чисел
                {

                    d = fin.ReadDouble();
                    s += d;
                    
                }
                Console.WriteLine();
                fin.Close();
                Double sr = s / 12;
                Console.WriteLine("Средняя годовая температура: "+sr);
                FileStream f1 = new FileStream("F.txt", FileMode.Open);
                fout = new BinaryWriter(new FileStream("G.txt", FileMode.Create));
                BinaryReader fin1 = new BinaryReader(f1);
                for (int j = 0; j < 10; j++)   // печать содержащихся в файле вещественных чисел
                {

                    d = fin1.ReadDouble();
                    fout.Write(sr-d);

                }
                f1.Close();
                fout.Close();
                fin1.Close();
                Console.WriteLine();
                FileStream f2 = new FileStream("G.txt", FileMode.Open);
                BinaryReader fin2 = new BinaryReader(f2);
                for (int j = 0; j < 10; j++)   // печать содержащихся в файле вещественных чисел
                {

                    d = fin2.ReadDouble();
                    Console.WriteLine(Math.Round(d,2));

                }
        }
    }
}
