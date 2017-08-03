var expect = require("chai").expect;
var Tote = require("../app/tote");

describe("tote", function () {
    describe("when adding win bet", function () {
        it("updates total stake and runner stake", function () {
            var tote = new Tote("a", "b");

            tote.addBet("w", "1", 4);

            expect(4).to.equal(tote.totalStakeForType("w"));
            expect(4).to.equal(tote.totalStakeForRunner("w", "1"));

            tote.addBet("w", "2", 10);

            expect(14).to.equal(tote.totalStakeForType("w"));
            expect(10).to.equal(tote.totalStakeForRunner("w", "2"));
        });
    });
});