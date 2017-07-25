using NUnit.Framework;
using ToteChallenge.Domain;

namespace ToteChallenge.Tests
{
    [TestFixture]
    public class ToteCommandParserFixture
    {
        public class ParseTests : ToteCommandParserFixture
        {
            [Test]
            public void When_input_empty_or_null_returns_error_command()
            {
                var parser = new ToteCommandParser();
                var command = parser.Parse("");

                Assert.That(command is ErrorCommand);
            }

            [Test]
            public void When_bet_input_returns_bet_command()
            {
                var parser = new ToteCommandParser();
                var command = parser.Parse("bet:W:1:12") as AddBetCommand;

                Assert.NotNull(command);

                Assert.That(command.Type == "w");
                Assert.That(command.Runner == "1");
                Assert.That(command.Stake == 12);
            }

            [Test]
            public void When_result_input_returns_result_command()
            {
                var parser = new ToteCommandParser();
                var command = parser.Parse("result:1:2:3");

                Assert.That(command is ResultCommand);
            }

            [Test]
            public void When_parse_fail_returns_error_command()
            {
                var parser = new ToteCommandParser();
                var command = parser.Parse("someother:1:2:3");

                Assert.That(command is ErrorCommand);
            }
        }
    }
}