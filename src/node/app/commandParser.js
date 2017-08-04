'use strict'

const Commands = require("./commands.js");

module.exports = class CommandParser {
    parse(input) {
        if (typeof input !== 'string' || typeof input === 'undefined' || input == '') {
            return new Commands.ErrorCommand();
        }
    }
}