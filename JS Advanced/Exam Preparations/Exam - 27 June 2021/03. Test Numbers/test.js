const { assert } = require('chai');
const { testNumbers } = require('./testNumbers');

describe("Test Numbers", function() {
    describe("Sum numbers tests", function() {
        it("Should sum numbers correctly", function() {
            assert.equal(testNumbers.sumNumbers(1, 2), '3.00');
        });

        it("Should return undefined when not a num", function() {
            assert.equal(testNumbers.sumNumbers('1', 2), undefined);
            assert.equal(testNumbers.sumNumbers(1, '2'), undefined);
        });
    });

    describe("Numbers checker tests", function() {
        it("Should return if num is odd or even", function() {
            assert.equal(testNumbers.numberChecker(1), 'The number is odd!');
            assert.equal(testNumbers.numberChecker(2), 'The number is even!');
        });

        it("Should throw error if nan", function() {
            assert.throws(() => testNumbers.numberChecker('asd'),'The input is not a number!');
        });
    });

    describe("Average sum tests", function() {
        it("Should return average sum", function() {
            assert.equal(testNumbers.averageSumArray([1, 2, 3]), 2);
        });
    });
});