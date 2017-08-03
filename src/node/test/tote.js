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

            expect(tote.totalStakeForType("w")).to.equal(4);
            expect(tote.totalStakeForRunner("w", "1")).to.equal(4);

            tote.addBet("w", "2", 10);

            expect(tote.totalStakeForType("w")).to.equal(14);
            expect(tote.totalStakeForRunner("w", "2")).to.equal(10);
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

        it("when runner does not exist returns 0", function () {
            var tote = new Tote([{
                type: 'w',
                stakeFactor: 0.85
            }]);

            expect(tote.totalStakeForRunner("w", "1")).to.equal(0);
        });
    });

    describe("when retrieving result", function () {
        it("calculates using the stakes factor", function () {
            var tote = new Tote([{
                type: 'w',
                stakeFactor: 0.88
            }]);

            tote.addBet("w", "1", 4);
            tote.addBet("w", "2", 10);

            var expectedRunner1 = Number(((4 + 10) * 0.88 / 4).toFixed(2));
            var expectedRunner2 = Number(((4 + 10) * 0.88 / 10).toFixed(2));

            expect(tote.getResult("w", "1")).to.equal(expectedRunner1);
            expect(tote.getResult("w", "2")).to.equal(expectedRunner2);
        });
    });
});