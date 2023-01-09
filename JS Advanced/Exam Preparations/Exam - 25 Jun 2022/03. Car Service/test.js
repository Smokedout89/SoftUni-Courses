const { assert } = require('chai');
const { carService } = require('./03. Car Service_Resources');

describe("Tests for Car Service", function() {
    describe("It is expensive method tests", function() {
        it("Default happy path behavior test", function() {
            assert.equal(carService.isItExpensive('Turbo'), `The overall price will be a bit cheaper`);
            assert.equal(carService.isItExpensive('Tire change'), `The overall price will be a bit cheaper`);
        });

        it("Default expensive path behavior test", function() {
            assert.equal(carService.isItExpensive('Engine'), `The issue with the car is more severe and it will cost more money`);
            assert.equal(carService.isItExpensive('Transmission'), `The issue with the car is more severe and it will cost more money`);
        });
    });

    describe("Discount method tests", function() {
        it("Behavior without enough parts for discount test", function() {
            assert.equal(carService.discount(2, 100), `You cannot apply a discount`);
            assert.equal(carService.discount(1, 1000), `You cannot apply a discount`);
        });
        it("Behavior with enough parts for discount test", function() {
            assert.equal(carService.discount(3, 1000), `Discount applied! You saved 150$`);
            assert.equal(carService.discount(7, 1000), `Discount applied! You saved 150$`);
            assert.equal(carService.discount(9, 1000), `Discount applied! You saved 300$`);
        });
        it("Behavior when one of the params is not a number", function() {
            assert.throws(() => carService.discount('asd', 7), `Invalid input`);
            assert.throws(() => carService.discount(7, 'asd'), `Invalid input`);
            assert.throws(() => carService.discount('dsa', 'asd'), `Invalid input`);
        });
    });

    describe("Parts to buy method tests", function() {
        it("Behavior with valid data", function() {
            assert.equal(carService.partsToBuy([], []), 0);
            assert.equal(carService.partsToBuy
            ([{part: 'Turbo', price: 100}, {part: 'Braking disks', price: 50}], ['Turbo']), 100);
            assert.equal(carService.partsToBuy
            ([{part: 'Turbo', price: 100}, {part: 'Braking disks', price: 50}], ['Turbo', 'Braking disks']), 150);
        });
        it("Behavior with invalid arguments", function() {
            assert.throws(() => carService.partsToBuy({}, []), `Invalid input`);
            assert.throws(() => carService.partsToBuy([], {}), `Invalid input`);
            assert.throws(() => carService.partsToBuy('asd', 'dsa'), `Invalid input`);
        });
    });
});