var chai = require("chai"),
    expect = chai.expect,
    assert = chai.assert;

var CommandParser = require("../app/commandParser.js"),
    Commands = require("../app/commands.js");

describe("command parser", function () {
    describe("when input invalid", function () {
        it("returns error command", function () {
            var commandParser = new CommandParser();

            var command1 = commandParser.parse(null);
            expect(command1 instanceof Commands.ErrorCommand).to.equal(true);

            var command2 = commandParser.parse("some:comand");            
            expect(command2 instanceof Commands.ErrorCommand).to.equal(true);
        });

        it("when bet input should return bet command", function () {
            const input = 'bet:W:1:12';

            var commandParser = new CommandParser();
            var command = commandParser.parse(input);

            expect(command instanceof Commands.BetCommand).to.equal(true);
            expect(command.toString()).to.equal("w | 1 | 12");
        });

        it("when result input should return result command", function () {
            const input = 'result:1:2:3';

            var commandParser = new CommandParser();
            var command = commandParser.parse(input);

            expect(command instanceof Commands.ResultCommand).to.equal(true);
            expect(command.toString()).to.equal("1 | 2 | 3");
        });
    });
});