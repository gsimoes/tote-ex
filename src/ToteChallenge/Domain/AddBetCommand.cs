using System;

namespace ToteChallenge.Domain
{
    public class AddBetCommand : Command
    {
        public string Type { get; set; }

        public string Runner { get; set; }

        public decimal Stake { get; set; }

        public override void Execute(Tote context)
        {
            if (string.IsNullOrEmpty(Type))
            {
                throw new ArgumentException(nameof(Type));
            }

            if (string.IsNullOrEmpty(Runner))
            {
                throw new ArgumentException(nameof(Runner));
            }

            if (Stake <= 0)
            {
                Console.WriteLine("Invalid stake. Should be higher than 0.");

                return;
            }

            context.AddBet(Type, Runner, Stake);
        }
    }
}