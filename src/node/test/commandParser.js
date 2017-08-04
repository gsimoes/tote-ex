var chai = require("chai"),
    expect = chai.expect,
    assert = chai.assert;

var CommandParser = require("../app/commandParser.js"),
    Commands = require("../app/commands.js")

describe("command parser", function () {
    describe("when input invalid", function () {
        it("returns error command", function () {
            var commandParser = new CommandParser();
            var command = commandParser.parse(null);

            expect(command instanceof Commands.ErrorCommand).to.equal(true);
        });

        it("when bet input should return bet command", function () {
            const input = 'bet:W:1:12';

            var commandParser = new CommandParser();
            var command = commandParser.parse(input);

            expect(command instanceof Commands.BetCommand).to.equal(true);
            expect(command.toString()).to.equal("W | 1 | 12");
        });
    });
});