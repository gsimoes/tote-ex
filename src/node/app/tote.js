'use strict'

module.exports = class Tote {
    constructor(betPools) {
        this.poolsStakesPerRunner = {};
        this.poolsTotalStake = {};
        this.betPools = {};

        betPools.forEach(function (betPool) {
            this.poolsStakesPerRunner[betPool.type] = {};
            this.poolsTotalStake[betPool.type] = 0;
            this.betPools[betPool.type] = betPool;
        }, this);
    }

    addBet(type, runner, stake) {
        if (typeof this.betPools[type] === 'undefined') {
            throw new Error("Bet pool does not exist");
        }

        if (!this.poolsStakesPerRunner[type].hasOwnProperty(runner)) {
            this.poolsStakesPerRunner[type][runner] = 0;
        }

        this.poolsStakesPerRunner[type][runner] = this.poolsStakesPerRunner[type][runner] + stake;
        this.poolsTotalStake[type] = this.poolsTotalStake[type] + stake;
    }

    totalStakeForType(type) {
        if (typeof this.betPools[type] === 'undefined') {
            throw new Error("Bet pool does not exist");
        }

        return this.poolsTotalStake[type];
    }

    totalStakeForRunner(type, runner) {
        if (typeof this.betPools[type] === 'undefined') {
            throw new Error("Bet pool does not exist");
        }

        return this.poolsStakesPerRunner[type][runner] || 0;
    }

    getResult(type, runner) {
        if (typeof this.betPools[type] === 'undefined') {
            throw new Error("Bet pool does not exist");
        }

        var betPool = this.betPools[type];
        var stakeForRunner = this.totalStakeForRunner(type, runner);

        if (stakeForRunner == 0) {
            return 0;
        }

        return Number((this.totalStakeForType(type) * betPool.stakeFactor / stakeForRunner).toFixed(2));
    }

    getResults(first, second, third) {
        var $this = this;

        var result = {
            first: first,
            second: second,
            third: third
        };

        var results = [];

        Object.keys(this.betPools).forEach(function(key,index) {
            var betPool = $this.betPools[key];
            betPool.results = [];

            betPool.results = betPool
                .resultsFor
                .map(function (position) {
                    return $this.getResult(betPool.type, position(result));
                });
            
            results.push(betPool);
        });

        return results;
    }
}