using System;
using NUnit.Framework;
using ToteChallenge.Domain;

namespace ToteChallenge.Tests
{
    [TestFixture]
    public class AddBetCommandFixture
    {
        [Test]
        public void When_invalid_params_throw_exception()
        {
            var command = new AddBetCommand();

            Assert.Throws<ArgumentException>(() => command.Execute(null));

            command.Type = "w";
            command.Stake = -1;
            command.Runner = "1";

            Assert.Throws<ArgumentException>(() => command.Execute(null));
        }
    }
}