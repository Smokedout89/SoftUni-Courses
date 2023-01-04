const { assert } = require('chai');
const { rentCar } = require('./rentCar');

describe("Rent car tests", function() {
    describe("Search car tests", function() {
        it("Search for car works as intended", function() {
            assert.equal(rentCar.searchCar(['Audi', 'BMW'], 'BMW'), `There is 1 car of model BMW in the catalog!`);
            assert.equal(rentCar.searchCar(['BMW', 'Audi', 'BMW'], 'BMW'), `There is 2 car of model BMW in the catalog!`);
        });
        it("Search for car throws if car not found", function() {
            assert.throws(() => rentCar.searchCar(['Audi'], 'Mercedes'), 'There are no such models in the catalog!');
        });
        it("Search for car throws with invalid args", function() {
            assert.throws(() => rentCar.searchCar('Audi', 'Mercedes'), 'Invalid input!');
            assert.throws(() => rentCar.searchCar(1, 'Mercedes'), 'Invalid input!');
            assert.throws(() => rentCar.searchCar(['Audi'], 1), 'Invalid input!');
            assert.throws(() => rentCar.searchCar(['Audi'], []), 'Invalid input!');
        });
    });

    describe("Calculate price tests", function() {
        it("Calculate price should work as intended", function() {
            assert.equal(rentCar.calculatePriceOfCar('Toyota', 3), `You choose Toyota and it will cost $120!`);
        });
        it("Calculate price should throw if car is not available", function() {
            assert.throws(() => rentCar.calculatePriceOfCar('Honda', 3), 'No such model in the catalog!');
        });
        it("Calculate price should throw with invalid params", function() {
            assert.throws(() => rentCar.calculatePriceOfCar(2, 3), 'Invalid input!');
            assert.throws(() => rentCar.calculatePriceOfCar('Audi', '5'), 'Invalid input!');
            assert.throws(() => rentCar.calculatePriceOfCar(5, '5'), 'Invalid input!');
        });
    });

    describe("Check budget tests", function() {
        it("Check budget works as intended", function() {
            assert.equal(rentCar.checkBudget(30, 3, 90), `You rent a car!`);
            assert.equal(rentCar.checkBudget(30, 3, 89), 'You need a bigger budget!');
        });
        it("Check budget should throw with non integer param", function() {
            assert.throws(() => rentCar.checkBudget('30', 3, 90), 'Invalid input!');
            assert.throws(() => rentCar.checkBudget(30, '3', 90), 'Invalid input!');
            assert.throws(() => rentCar.checkBudget(30, 3, '90'), 'Invalid input!');

        });
    });
});