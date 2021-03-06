﻿using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;

namespace ToteChallenge.Domain
{
    public class Tote
    {
        private readonly IDictionary<string, BetPool> _betPools;

        private readonly Dictionary<string, ConcurrentDictionary<string, decimal>> _poolsStakesPerRunner = new Dictionary<string, ConcurrentDictionary<string, decimal>>();
        private readonly ConcurrentDictionary<string, decimal> _poolsTotalStake = new ConcurrentDictionary<string, decimal>();

        public bool Open { get; private set; }

        public Tote(IEnumerable<BetPool> betPools)
        {
            _betPools = betPools
                .ToDictionary(betPool => betPool.Type);

            Open = true;

            InitialisePools();
        }

        private void InitialisePools()
        {
            foreach (var betPool in _betPools)
            {
                _poolsStakesPerRunner.Add(betPool.Value.Type.ToLower(), new ConcurrentDictionary<string, decimal>());
                _poolsTotalStake.AddOrUpdate(betPool.Value.Type, 0, (oldKey, oldValue) => 0);
            }
        }

        public void AddBet(string type, string runner, decimal stake)
        {
            if (!_betPools.ContainsKey(type))
            {
                throw new ArgumentException("Bet pool does not exist.");
            }

            var runnerStakes = _poolsStakesPerRunner[type];
            runnerStakes.AddOrUpdate(runner, stake, (key, current) => current + stake);

            _poolsTotalStake.AddOrUpdate(type, stake, (key, current) => Math.Round(current + stake));
        }

        public decimal TotalStakeForType(string type)
        {
            if (!_betPools.ContainsKey(type))
            {
                throw new ArgumentException("Bet pool does not exist.");
            }

            return _poolsTotalStake[type];
        }

        public decimal TotalStakeForRunner(string type, string runner)
        {
            if (!_betPools.ContainsKey(type))
            {
                throw new ArgumentException("Bet pool does not exist.");
            }

            return _poolsStakesPerRunner[type].ContainsKey(runner)
                ? _poolsStakesPerRunner[type][runner]
                : 0;
        }

        public decimal GetResult(string type, string runner)
        {
            if (!_betPools.ContainsKey(type))
            {
                throw new ArgumentException("Bet pool does not exist.");
            }

            var betPool = _betPools[type];
            var totalStakeForRunner = TotalStakeForRunner(type, runner);

            if (totalStakeForRunner == 0)
            {
                return 0;
            }

            return Math.Round(TotalStakeForType(type) * betPool.StakeFactor / totalStakeForRunner, 2);
        }

        public void CloseTote()
        {
            Open = false;
        }
    }
}