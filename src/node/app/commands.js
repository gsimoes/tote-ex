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

module.exports = { Command, ErrorCommand }