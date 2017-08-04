'use strict'

const Commands = require("./commands.js");

module.exports = class CommandParser {
    parse(input) {
        const betCommandRegex = /^bet\:(W|P|E)\:(\d{1,2})\:(\d{1,6})/gi;
        let match;

        if (typeof input !== 'string' || typeof input === 'undefined' || input == '') {
            return new Commands.ErrorCommand();
        }

        match = betCommandRegex.exec(input);
        if (match != null) {
            return new Commands.BetCommand(match[1], match[2], match[3]);
        }
    }
}