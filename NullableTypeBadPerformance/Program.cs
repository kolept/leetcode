// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
NullableTest test = new NullableTest();

test.NoneNullableParameter(2,2);

test.LoopNullableParameter(2,2); //nullable type is bad in performance for loop 

//

Console.ReadLine();




public class NullableTest
{

    int? x;
    int? y;

    public void LoopNullableParameter (int? x, int? y)
    {
        var watch = System.Diagnostics.Stopwatch.StartNew();

        int? a = 0;
        // the code that you want to measure comes here

        for (int b=0;b<100;b++) 
        {
            a += x * y; //cannot be hoisted by JIT , hoist raise (something) by means of ropes and pulleys.
        }


        watch.Stop();
        var elapsedMs = watch.ElapsedTicks;
        Console.WriteLine($"LoopNullableParameter {elapsedMs}" );
    }


    public void NoneNullableParameter(int x, int y)
    {
        var watch = System.Diagnostics.Stopwatch.StartNew();
        int a = 0;

        for (int b = 0; b < 100; b++)
        {
            a += x * y;

            //can be hoist by JIT
            
        }

        // the code that you want to measure comes here
        watch.Stop();
        var elapsedMs = watch.ElapsedTicks;

        Console.WriteLine($"NoneNullableParameter {elapsedMs}");


    }
}