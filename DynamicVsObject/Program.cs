// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

DynamicVsObject test = new DynamicVsObject();

test.LoopDynamic(2, 2);

test.LoopObject(2, 2); //nullable type is bad in performance for loop 

Console.ReadLine();

public class DynamicVsObject
{



    public void LoopDynamic(dynamic x, dynamic y)
    {
        var watch = System.Diagnostics.Stopwatch.StartNew();

        int? a = 0;
        // the code that you want to measure comes here

        for (int b = 0; b < 100; b++)
        {
            a += x * y; //cannot be hoisted by JIT , hoist raise (something) by means of ropes and pulleys.
        }


        watch.Stop();
        var elapsedMs = watch.ElapsedTicks;
        Console.WriteLine($"LoopDynamic {elapsedMs}");
    }


    public void LoopObject(object x, object y)
    {
        var watch = System.Diagnostics.Stopwatch.StartNew();
        int a = 0;

        for (int b = 0; b < 100; b++)
        {
            a +=  Convert.ToInt32(x)  * Convert.ToInt32(y); //825 ticks                       
            //a += (int)x * (int)y; //160 ticks

            a += (int)x * (int)y; //160 ticks

            //can be hoist by JIT

        }

        // the code that you want to measure comes here
        watch.Stop();
        var elapsedMs = watch.ElapsedTicks;

        Console.WriteLine($"LoopObject {elapsedMs}");


    }
}