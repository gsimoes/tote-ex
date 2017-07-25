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
            public void When_input_empty_or_null_returns_null()
            {
                var toteCommandParser = new ToteCommandParser();
                var command = toteCommandParser.Parse("");

                Assert.IsNull(command);

                command = toteCommandParser.Parse(null);

                Assert.IsNull(command);
            }

            [Test]
            public void When_bet_input_returns_bet_command()
            {
                var toteCommandParser = new ToteCommandParser();
                var command = toteCommandParser.Parse("bet:W:1:12");

                Assert.That(command is AddBetCommand);
            }

            [Test]
            public void When_result_input_returns_result_command()
            {
                var toteCommandParser = new ToteCommandParser();
                var command = toteCommandParser.Parse("result:1:2:3");

                Assert.That(command is ResultCommand);
            }
        }
    }
}