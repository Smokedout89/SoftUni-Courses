const { assert } = require('chai');
const { flowerShop } = require('./flowerShop');

describe("Flower Shop Test", function() {
    describe("Calculate price tests", function() {
        it("Price should be calculated properly", function() {
            assert.equal(flowerShop.calcPriceOfFlowers('Orchid', 5, 10),
                `You need $50.00 to buy Orchid!`);
        });
        it("Price should throw with invalid params", function() {
            assert.throws(() => flowerShop.calcPriceOfFlowers(5, 5, 10), 'Invalid input!');
            assert.throws(() => flowerShop.calcPriceOfFlowers('Orchid', 1.1, 10), 'Invalid input!');
            assert.throws(() => flowerShop.calcPriceOfFlowers('Orchid', 1, 1.1), 'Invalid input!');
        });
    });

    describe("Check availability tests", function() {
        it("Checking for flower should work as intended", function() {
            assert.equal(flowerShop.checkFlowersAvailable('Orchid', ['Rose', 'Orchid']), `The Orchid are available!`);
            assert.equal(flowerShop.checkFlowersAvailable('Tulip', ['Rose', 'Orchid']), `The Tulip are sold! You need to purchase more!`);
        });
    });

    describe("Sell flowers tests", function() {
        it("Selling flower should work as intended", function() {
            assert.equal(flowerShop.sellFlowers(['Rose', 'Orchid', 'Tulip'], 0), `Orchid / Tulip`);
            assert.equal(flowerShop.sellFlowers(['Rose', 'Orchid', 'Tulip'], 2), `Rose / Orchid`);
        });
        it("Selling flower should throw with invalid params", function () {
            assert.throws(() => flowerShop.sellFlowers('dad', 1), 'Invalid input!');
            assert.throws(() => flowerShop.sellFlowers(['Rose', 'Orchid', 'Tulip'], 1.5), 'Invalid input!');
            assert.throws(() => flowerShop.sellFlowers(['Rose', 'Orchid', 'Tulip'], -1), 'Invalid input!');
            assert.throws(() => flowerShop.sellFlowers(['Rose', 'Orchid', 'Tulip'], 3), 'Invalid input!');
        });
    });
});