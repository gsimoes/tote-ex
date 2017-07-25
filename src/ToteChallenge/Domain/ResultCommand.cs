using System;

namespace ToteChallenge.Domain
{
    public class ResultCommand : Command
    {
        public int First { get; set; }

        public int Second { get; set; }

        public int Third { get; set; }

        public override void Execute(Tote context)
        {
            Console.WriteLine($"Win:{First}:${context.GetResult("w", First.ToString())}");
            Console.WriteLine($"Place:{First}:${context.GetResult("p", First.ToString())}");
            Console.WriteLine($"Place:{Second}:${context.GetResult("p", Second.ToString())}");
            Console.WriteLine($"Place:{Third}:${context.GetResult("p", Third.ToString())}");
            Console.WriteLine($"Exacta:{First},{Second}:${context.GetResult("e", $"{First},{Second}")}");
        }
    }
}