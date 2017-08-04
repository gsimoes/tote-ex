'use strict'

class Command {
    constructor() {

    }

    execute(tote) { }
}

class ErrorCommand extends Command {
    constructor() {
        super();
    }

    execute(tote) {
        console.log("Invalid command. Format is Bet:<product>:<selections>:<stake> or Result:<first>:<second>:<third>");
        console.log("Example \"Bet:W:1:5\" or \"Result:1:2:3\"");
        console.log("Product is W or P or E. When product is E, then selections should be in the format \"2,3\"");
    }
}

class BetCommand extends Command {
    constructor(type, runner, stake) {
        super();

        this.type = type;
        this.runner = runner;
        this.stake = stake;
    }

    execute(tote) {
        tote.addBet(this.type, this.runner, this.stake);
    }

    toString() {
        return `${this.type} | ${this.runner} | ${this.stake}`;
    }
}

class ResultCommand extends Command {
    constructor(first, second, third) {
        super();

        this.first = first;
        this.second = second;
        this.third = third;
    }

    execute(tote) {
       var betPools = tote.getResults(this.first, this.second, this.third);

       console.log(betPools);
    }

    toString() {
        return `${this.first} | ${this.second} | ${this.third}`;
    }
}

module.exports = { Command, ErrorCommand, BetCommand, ResultCommand }