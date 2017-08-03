'use strict'

module.exports = class Tote {
    constructor() {
        this.betPools = [{
            type: 'w',
            stakeFactor: 0.85
        }];

        this.poolsStakesPerRunner = {};
        this.poolsTotalStake = {};

        this.betPools.forEach(function (betPool) {
            this.poolsStakesPerRunner[betPool.type] = {};
            this.poolsTotalStake[betPool.type] = 0;
        }, this);
    }

    addBet(type, runner, stake) {
        if (!this.poolsStakesPerRunner[type].hasOwnProperty(runner)) {
            this.poolsStakesPerRunner[type][runner] = 0;
        }

        this.poolsStakesPerRunner[type][runner] = this.poolsStakesPerRunner[type][runner] + stake;
        this.poolsTotalStake[type] = this.poolsTotalStake[type] + stake;
    }

    totalStakeForType(type) {
        return this.poolsTotalStake[type];
    }

    totalStakeForRunner(type, runner) {
        return this.poolsStakesPerRunner[type][runner];
    }
}