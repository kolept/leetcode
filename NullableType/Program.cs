// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

NullableTest ntest = new NullableTest();

ntest.QuestionMustHave = "";

//https://www.youtube.com/watch?v=bXsOOpWavp4

Console.ReadLine();

public  class NullableTest 
{

    string notNull = "Hello";
    string? nullable = default;
    string questionMustHave = "Default";

    //give default value no Squiggly line ~~~~~~~ 
    public string QuestionMustHave 
    {
        get { return questionMustHave; }
        set { questionMustHave = value; }
    
    }

    //have default value with Squiggly line ~~~~~~~ 
    //how to turn on and off     <Nullable>enable</Nullable>  in project properties <-help ppl to spot run time nullable crahed
    public string MustHave { get; set; }

    public string? QuestionAnswerOptional { get; set; }


    public void dosomething() 
    {
        notNull = nullable!; // null forgiveness
    }

}