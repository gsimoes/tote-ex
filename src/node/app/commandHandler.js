'use strict'

module.exports = class CommandHandler {
    constructor(parser, tote){
        this.parser = parser;
        this.tote = tote;
    }

    handle(input) {
        var command = this.parser.parse(input);
        command.execute(this.tote);
    }
}