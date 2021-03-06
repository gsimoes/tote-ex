﻿using System;
using NUnit.Framework;
using ToteChallenge.Domain;

namespace ToteChallenge.Tests
{
    [TestFixture]
    public class ToteFixture
    {
        [Test]
        public void When_add_win_bet_updates_tote_stake_and_runner_stake()
        {
            var tote = new Tote(new[]
            {
                new BetPool("w", 1),
            });

            tote.AddBet(type: "w", runner: "1", stake: 4);

            Assert.AreEqual(4, tote.TotalStakeForType("w"));
            Assert.AreEqual(4, tote.TotalStakeForRunner("w", "1"));

            tote.AddBet(type: "w", runner: "2", stake: 10);

            Assert.AreEqual(14, tote.TotalStakeForType("w"));
            Assert.AreEqual(10, tote.TotalStakeForRunner("w", "2"));
        }

        [Test]
        public void When_pool_does_not_exist_throws()
        {
            var tote = new Tote(new[]
            {
                    new BetPool("w", 1),
                });

            Assert.Throws<ArgumentException>(() => tote.AddBet(type: "p", runner: "1", stake: 4));
            Assert.Throws<ArgumentException>(() => tote.TotalStakeForType(type: "p"));
            Assert.Throws<ArgumentException>(() => tote.TotalStakeForRunner(type: "p", runner: "1"));
        }

        [Test]
        public void When_runner_does_not_exist_returns_0()
        {
            var tote = new Tote(new[]
            {
                new BetPool("w", 1),
            });

            Assert.AreEqual(0, tote.TotalStakeForRunner("w", "2"));
        }

        [Test]
        public void When_getting_results_should_calculate_using_stakes_factor()
        {
            var tote = new Tote(new[]
            {
                new BetPool("w", 0.88m),
            });

            tote.AddBet(type: "w", runner: "1", stake: 4);
            tote.AddBet(type: "w", runner: "2", stake: 10);

            var expectedRunner1 = Math.Round((4 + 10) * 0.88m / 4, 2);
            var expectedRunner2 = Math.Round((4 + 10) * 0.88m / 10, 2);

            Assert.AreEqual(expectedRunner1, tote.GetResult(type: "w", runner: "1"));
            Assert.AreEqual(expectedRunner2, tote.GetResult(type: "w", runner: "2"));
        }
    }
}