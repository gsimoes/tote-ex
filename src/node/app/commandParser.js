'use strict'

const Commands = require("./commands.js");

module.exports = class CommandParser {
    parse(input) {
        const betCommandRegex = /^bet\:(W|P|E)\:(\d{1,2}|\d{1,2}\,\d{1,2})\:(\d{1,6})/gi;
        const resultCommandRegex = /^result\:(\d{1,2})\:(\d{1,2})\:(\d{1,2})/gi;
        
        let match;

        if (typeof input !== 'string' || typeof input === 'undefined' || input == '') {
            return new Commands.ErrorCommand();
        }

        input = input.toLowerCase().trim();

        match = betCommandRegex.exec(input);
        if (match != null) {
            return new Commands.BetCommand(match[1], match[2], parseInt(match[3]));
        }

        match = resultCommandRegex.exec(input);
        if (match != null) {
            return new Commands.ResultCommand(match[1], match[2], match[3]);
        }

        return new Commands.ErrorCommand(); 
    }
}