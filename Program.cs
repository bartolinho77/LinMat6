using System;


namespace LinMat6
{
    class Program
    {
        static void Main()
        {
            RecursiveDescentPredictiveParser parser = new RecursiveDescentPredictiveParser();
            Console.WriteLine("Enter expression:");
            string expression = Console.ReadLine();
            Console.WriteLine("Result: " + parser.Parse(expression));
        }
    }
}
