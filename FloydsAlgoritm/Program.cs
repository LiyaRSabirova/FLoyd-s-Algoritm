using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FloydsAlgoritm
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var cntFiles = 90;
            var minFile = 10;
            Vizov(minFile, cntFiles);
            Stopwatch m = new Stopwatch();
            for (int i = 0; i < cntFiles-minFile; i++)
            {
                var pp = (minFile+i).ToString() + ".txt";
                var mass = Sch(pp);
                m.Start();
                var cntIt = FloydWarshall(mass, minFile + i);
                m.Stop();
                Console.WriteLine($"{i+1}   {(minFile+i)*(minFile+i)}  {m.Elapsed}    {cntIt}");
                m.Reset();
            }
            Console.ReadKey();
        }
        static int FloydWarshall(int[,] matrix, int sz)
        {
            int cnt = 0;
            for (var k = 0; k < sz; ++k)
            {
                for (var i = 0; i < sz; ++i)
                {

                    for (var j = 0; j < sz; ++j)
                    {
                        var distance = matrix[i, k] + matrix[k, j];
                        if (matrix[i, j] > distance)
                        {
                            matrix[i, j] = distance;
                        }
                        cnt++;
                    }
                }
            }
            return cnt;
        }
        static int[,] Sch(string path)
        {
            StreamReader streamReader = new StreamReader(path);
            var cntV = int.Parse(streamReader.ReadLine());
            var matr = new int[cntV, cntV];
            for (var i = 0; i < cntV; i++)
            {
                for (var j = 0; j < cntV; j++)
                {
                    matr[i, j] = int.Parse(streamReader.ReadLine());
                }
            }
            return matr;
        }
        static void GenerationMassiv(int size, string path)
        {
            StreamWriter stringWriter = new StreamWriter(path, true);
            Random r = new Random();
            stringWriter.WriteLine(Math.Sqrt(size));
            for (var i = 1; i <= size; i++)
            {
                stringWriter.WriteLine($"{r.Next(5000,7000)} ");
            }
            stringWriter.Close();
        }
        static void Vizov(int cntvmin, int cntvmax)
        {
            var vv = cntvmin;
            var cntverchin = cntvmin;
            while (vv <= cntvmax)
            {
                var v = vv * vv;
                var pp = cntverchin.ToString() + ".txt";
                GenerationMassiv(v, pp);
                vv += 1;
                cntverchin += 1;
            }
        }
    }
}
