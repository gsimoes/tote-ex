'use strict'

module.exports = class Tote {
    constructor(betPools) {
        this.poolsStakesPerRunner = {};
        this.poolsTotalStake = {};
        this.betPools = betPools;

        betPools.forEach(function (betPool) {
            this.poolsStakesPerRunner[betPool.type] = {};
            this.poolsTotalStake[betPool.type] = 0;
        }, this);
    }

    addBet(type, runner, stake) {
        if (typeof this.poolsStakesPerRunner[type] === 'undefined' || typeof this.poolsTotalStake[type] === 'undefined') {
            throw new Error("Bet pool does not exist");
        }

        if (!this.poolsStakesPerRunner[type].hasOwnProperty(runner)) {
            this.poolsStakesPerRunner[type][runner] = 0;
        }

        this.poolsStakesPerRunner[type][runner] = this.poolsStakesPerRunner[type][runner] + stake;
        this.poolsTotalStake[type] = this.poolsTotalStake[type] + stake;
    }

    totalStakeForType(type) {
        if (typeof this.poolsStakesPerRunner[type] === 'undefined' || typeof this.poolsTotalStake[type] === 'undefined') {
            throw new Error("Bet pool does not exist");
        }

        return this.poolsTotalStake[type];
    }

    totalStakeForRunner(type, runner) {
        if (typeof this.poolsStakesPerRunner[type] === 'undefined' || typeof this.poolsTotalStake[type] === 'undefined') {
            throw new Error("Bet pool does not exist");
        }
        
        return this.poolsStakesPerRunner[type][runner];
    }
}