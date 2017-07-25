using System.Collections.Generic;
using NUnit.Framework;
using ToteChallenge.Domain;

namespace ToteChallenge.Tests
{
    [TestFixture]
    public class AcceptanceFixture
    {
        private readonly List<string> _commands = new List<string>
        {
            "Bet:W:1:3",
            "Bet:W:2:4",
            "Bet:W:3:5",
            "Bet:W:4:5",
            "Bet:W:1:16",
            "Bet:W:2:8",
            "Bet:W:3:22",
            "Bet:W:4:57",
            "Bet:W:1:42",
            "Bet:W:2:98",
            "Bet:W:3:63",
            "Bet:W:4:15",
            "Bet:P:1:31",
            "Bet:P:2:89",
            "Bet:P:3:28",
            "Bet:P:4:72",
            "Bet:P:1:40",
            "Bet:P:2:16",
            "Bet:P:3:82",
            "Bet:P:4:52",
            "Bet:P:1:18",
            "Bet:P:2:74",
            "Bet:P:3:39",
            "Bet:P:4:105",
            "Bet:E:1,2:13",
            "Bet:E:2,3:98",
            "Bet:E:1,3:82",
            "Bet:E:3,2:27",
            "Bet:E:1,2:5" ,
            "Bet:E:2,3:61",
            "Bet:E:1,3:28",
            "Bet:E:3,2:25",
            "Bet:E:1,2:81",
            "Bet:E:2,3:47",
            "Bet:E:1,3:93",
            "Bet:E:3,2:51",
        };

        [Test]
        public void Run_acceptance_test()
        {
            var tote = new Tote(new[]
            {
                new BetPool("w", 0.85m),
                new BetPool("p", 0.88m / 3),
                new BetPool("e", 0.82m),
            });

            var toteCommandHandler = new CommandHandler(new CommandParser(), tote);

            _commands.ForEach(toteCommandHandler.Execute);

            Assert.AreEqual(2.61m, tote.GetResult("w", "2"));
            Assert.AreEqual(1.06m, tote.GetResult("p", "2"));
            Assert.AreEqual(1.27m, tote.GetResult("p", "3"));
            Assert.AreEqual(2.13m, tote.GetResult("p", "1"));
            Assert.AreEqual(2.43m, tote.GetResult("e", "2,3"));
        }
    }
}