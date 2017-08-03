using System;

namespace ToteChallenge.Domain
{
    public class ErrorCommand : Command
    {
        public override void Execute(Tote context)
        {
            Console.WriteLine("Invalid command. Format is Bet:<product>:<selections>:<stake> or Result:<first>:<second>:<third>");
            Console.WriteLine("Example \"Bet:W:1:5\" or \"Result:1:2:3\"");
            Console.WriteLine("Product is W or P or E. When product is E, then selections should be in the format \"2,3\"");
        }
    }
}