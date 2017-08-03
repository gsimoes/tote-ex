var chai = require("chai"),
    expect = chai.expect,
    assert = chai.assert;

var Tote = require("../app/tote");

describe("tote", function () {
    describe("when adding win bet", function () {
        it("throws error if pool does not exist", function () {
            var tote = new Tote([{
                type: 'w',
                stakeFactor: 0.85
            }]);

            assert.throws(() => { tote.addBet("p", "1", 4); }, Error, "Bet pool does not exist");
        });
        
        it("updates total stake and runner stake", function () {
            var tote = new Tote([{
                type: 'w',
                stakeFactor: 0.85
            }]);

            tote.addBet("w", "1", 4);

            expect(4).to.equal(tote.totalStakeForType("w"));
            expect(4).to.equal(tote.totalStakeForRunner("w", "1"));

            tote.addBet("w", "2", 10);

            expect(14).to.equal(tote.totalStakeForType("w"));
            expect(10).to.equal(tote.totalStakeForRunner("w", "2"));
        });
    });

    describe("when retrieving stakes", function () {
        it("throws error if pool does not exist", function () {
            var tote = new Tote([{
                type: 'w',
                stakeFactor: 0.85
            }]);

            assert.throws(() => { tote.totalStakeForType("p"); }, Error, "Bet pool does not exist");
            assert.throws(() => { tote.totalStakeForRunner("p", "2"); }, Error, "Bet pool does not exist");
        });
    });
});