using System;

namespace ToteChallenge.Domain
{
    public class BetPool
    {
        public string Type { get; }

        public decimal StakeFactor { get; }

        public BetPool(string type, decimal stakeFactor)
        {
            if (string.IsNullOrEmpty(type))
            {
                throw new ArgumentException(nameof(type));
            }

            Type = type;
            StakeFactor = stakeFactor;
        }
    }
}