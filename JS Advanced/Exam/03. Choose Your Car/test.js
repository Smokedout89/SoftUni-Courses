const {assert} = require('chai');
const {chooseYourCar} = require('./chooseYourCar');

describe("Choose your car tests", function () {
    describe("Choose type tests", function () {
        it("Choosing car should work as expected", function () {
            assert.equal(chooseYourCar.choosingType('Sedan', 'Green', 2010), `This Green Sedan meets the requirements, that you have.`);
            assert.equal(chooseYourCar.choosingType('Sedan', 'Green', 2009), `This Sedan is too old for you, especially with that Green color.`);
        });
        it("Choosing car should throw if not a Sedan", function () {
            assert.throws(() => chooseYourCar.choosingType('Coupe', 'Green', 2010), `This type of car is not what you are looking for.`);
        });
        it("Choosing car should throw with invalid year", function () {
            assert.throws(() => chooseYourCar.choosingType('Sedan', 'Green', 1899), `Invalid Year!`);
            assert.throws(() => chooseYourCar.choosingType('Sedan', 'Green', 2023), `Invalid Year!`);
        });
    });

    describe("Brand name tests", function () {
        it("Brand function should work as expected", function () {
            assert.equal(chooseYourCar.brandName(['Mercedes', 'Audi', 'VW'], 0), 'Audi, VW');
        });

        it("Brand function should throw with invalid params", function () {
            assert.throws(() => chooseYourCar.brandName('asd', 0), "Invalid Information!");
            assert.throws(() => chooseYourCar.brandName(['Mercedes', 'Audi', 'VW'], 'asd'), "Invalid Information!");
            assert.throws(() => chooseYourCar.brandName(['Mercedes', 'Audi', 'VW'], -1), "Invalid Information!");
            assert.throws(() => chooseYourCar.brandName(['Mercedes', 'Audi', 'VW'], 3), "Invalid Information!");
        });
    });

    describe("Fuel consumption tests", function () {
        it("Fuel consumption should work as expected", function () {
            assert.equal(chooseYourCar.carFuelConsumption(100, 10), `The car burns too much fuel - 10.00 liters!`);
            assert.equal(chooseYourCar.carFuelConsumption(100, 6), `The car is efficient enough, it burns 6.00 liters/100 km.`);
            assert.equal(chooseYourCar.carFuelConsumption(100, 7), `The car is efficient enough, it burns 7.00 liters/100 km.`);
        });
        it("Fuel consumption should throw with invalid params", function () {
            assert.throws(() => chooseYourCar.carFuelConsumption('a', 1), "Invalid Information!");
            assert.throws(() => chooseYourCar.carFuelConsumption(1, 'a'), "Invalid Information!");
            assert.throws(() => chooseYourCar.carFuelConsumption(10, 0), "Invalid Information!");
            assert.throws(() => chooseYourCar.carFuelConsumption(0, 10), "Invalid Information!");
        });
    });
});
