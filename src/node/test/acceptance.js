var chai = require("chai"),
    expect = chai.expect,
    assert = chai.assert;

var CommandParser = require("../app/commandParser.js"),
    Commands = require("../app/commands.js"),
    Tote = require("../app/tote");
CommandHandler = require("../app/commandHandler");

describe("acceptance", function () {
    it("should pass", function () {
        var inputs = [
            "Bet:W:1:3",
            "Bet:W:2:4",
            "Bet:W:3:5",
            "Bet:W:4:5",
            "Bet:W:1:16",
            "Bet:W:2:8",
            "Bet:W:3:22",
            "Bet:W:4:57",
            "Bet:W:1:42",
            "Bet:W:2:98",
            "Bet:W:3:63",
            "Bet:W:4:15",
            "Bet:P:1:31",
            "Bet:P:2:89",
            "Bet:P:3:28",
            "Bet:P:4:72",
            "Bet:P:1:40",
            "Bet:P:2:16",
            "Bet:P:3:82",
            "Bet:P:4:52",
            "Bet:P:1:18",
            "Bet:P:2:74",
            "Bet:P:3:39",
            "Bet:P:4:105",
            "Bet:E:1,2:13",
            "Bet:E:2,3:98",
            "Bet:E:1,3:82",
            "Bet:E:3,2:27",
            "Bet:E:1,2:5",
            "Bet:E:2,3:61",
            "Bet:E:1,3:28",
            "Bet:E:3,2:25",
            "Bet:E:1,2:81",
            "Bet:E:2,3:47",
            "Bet:E:1,3:93",
            "Bet:E:3,2:51",
        ];

        var tote = new Tote([
            {
                type: 'w',
                stakeFactor: 0.85,
                resultsFor: [ (result) => result.first]
            },
            {
                type: 'p',
                stakeFactor: 0.88 / 3,
                resultsFor: [(result) => result.first, (result) =>result.second, (result) => result.third]
            },
            {
                type: 'e',
                stakeFactor: 0.82,
                resultsFor: [(result) =>`${result.first},${result.second}`]
            }]);

        var toteCommandHandler = new CommandHandler(new CommandParser(), tote);
        inputs.forEach(function(input){
            toteCommandHandler.handle(input);
        });

        expect(tote.getResult("w", "2")).to.equal(2.61);
        expect(tote.getResult("p", "2")).to.equal(1.06);
        expect(tote.getResult("p", "3")).to.equal(1.27);
        expect(tote.getResult("p", "1")).to.equal(2.13);
        expect(tote.getResult("e", "2,3")).to.equal(2.43);

       console.log(tote.getResults("2", "3", "1"));
    });
});