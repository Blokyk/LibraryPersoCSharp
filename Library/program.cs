using System.Collections.Generic;
using Library.Collections;
using Library.Math;
using Library.Image.Filtering;
using Library.Image;
using System;

public class Program
{
    static void Main(string[] args)
    {        
        System.Drawing.Bitmap bitmap = new System.Drawing.Bitmap(@"C:\Users\Christophe\Desktop\result.png");
        System.IO.StreamWriter txtWriter = new System.IO.StreamWriter(@"C:\Users\Christophe\dump.txt");
        txtWriter.AutoFlush = true;
        Console.WriteLine("Starting...");
        int radacan = 65;
        Console.WriteLine("The squareroot of {0} is ~" + Library.Math.Math.Sqrt(radacan) + " and the System.Math.Sqrt of {0} is " + System.Math.Sqrt(radacan), radacan);
        Filter filter = new Filter(FilterShape.Horizontal);
        float[,,] scale = bitmap.ToIntArrayAsFactor();
        Console.WriteLine("Scalation finished");

        ExConsole.WaitUntil();

        float[,,] filtered = filter.Apply(scale);

        int[,] r, g, b = new int[filtered.GetLength(0), filtered.GetLength(1)];

        r = g = b;

        for (int x = 0; x < filtered.GetLength(0); x++)
        {
            for (int y = 0; y < filtered.GetLength(1); y++)
            {
                r[x, y] = (int)filtered[x, y, 0];
                g[x, y] = (int)filtered[x, y, 1];
                b[x, y] = (int)filtered[x, y, 2];
            }
        }

        //Console.WriteLine(tmp[2, 2, 1]);
        ExConsole.WaitUntil();
    }
}