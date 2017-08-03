using System;
using ToteChallenge.Domain;

namespace ToteChallenge
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var tote = new Tote(new[]
            {
                new BetPool("w", 0.85m),
                new BetPool("p", 0.88m / 3),
                new BetPool("e", 0.82m),
            });

            var toteCommandHandler = new CommandHandler(new CommandParser(), tote);

            while (tote.Open)
            {
                Console.Write("Next command: ");

                var input = Console.ReadLine().Trim();
                toteCommandHandler.Execute(input);
            }

            Console.ReadLine();
        }
    }
}