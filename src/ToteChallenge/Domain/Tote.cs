using System.Collections.Concurrent;
using System.Collections.Generic;

namespace ToteChallenge.Domain
{
    public class Tote
    {
        private readonly Dictionary<string, ConcurrentDictionary<string, int>> _poolsCounts = new Dictionary<string, ConcurrentDictionary<string, int>>();
        private readonly ConcurrentDictionary<string, decimal> _poolsTotals = new ConcurrentDictionary<string, decimal>();

        public Tote()
        {
            CreatePool("w"); // win
            CreatePool("p"); // place
            CreatePool("e"); // exacta
        }

        private void CreatePool(string type)
        {
            if (!_poolsCounts.ContainsKey(type))
            {
                _poolsCounts.Add(type, new ConcurrentDictionary<string, int>());
                _poolsTotals.AddOrUpdate(type, 0, (oldKey, oldValue) => 0);
            }
        }

        public void AddBet(string type, string runners, int stake)
        {
            if (!_poolsCounts.ContainsKey(type) || !_poolsTotals.ContainsKey(type))
            {
                return;
            }

            var poolCounts = _poolsCounts[type];
            poolCounts.AddOrUpdate(runners, 1, (key, current) => current + 1);

            _poolsTotals.AddOrUpdate(type, stake, (key, current) => current + stake);
        }

        public int TotalCountForRunner(string type, string runner)
        {
            if (!_poolsCounts.ContainsKey(type) || !_poolsCounts[type].ContainsKey(runner))
            {
                return 0;
            }

            return _poolsCounts[type][runner];
        }

        public decimal TotalStakeForType(string type)
        {
            if (!_poolsTotals.ContainsKey(type))
            {
                return 0;
            }

            return _poolsTotals[type];
        }
    }
}