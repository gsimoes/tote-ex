using NUnit.Framework;
using ToteChallenge.Domain;

namespace ToteChallenge.Tests
{
    [TestFixture]
    public class ToteFixture
    {
        public class AddBetTests : ToteFixture
        {
            [Test]
            public void When_add_win_bet_updates_tote_count_and_total_win()
            {
                var tote = new Tote();

                tote.AddBet(type: "w", runners: "1", stake: 4);

                Assert.That(tote.TotalCountForRunner("w", "1") == 1);
                Assert.That(tote.TotalStakeForType("w") == 4);
            }
        }
    }
}