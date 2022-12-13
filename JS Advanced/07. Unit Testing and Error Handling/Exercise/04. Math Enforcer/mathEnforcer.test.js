const { assert } = require('chai');
const { mathEnforcer } = require('./mathEnforcer');

describe('Math Enforcer Test', () => {
    describe('Add Five Test', function () {
        it('should return undefind for non-number input', () => {
            assert.equal(mathEnforcer.addFive('test'), undefined);
        });

        it('should return correct for positive integer', () => {
            assert.equal(mathEnforcer.addFive(5), 10);
        });

        it('should return correct for negative integer', () => {
            assert.equal(mathEnforcer.addFive(-5), 0);
        });

        it('should return correct for floating point number', () => {
            assert.closeTo(mathEnforcer.addFive(2.5), 7.5, 0.1);
        });
    });

    describe('Subtract Ten Test', function () {
        it('should return undefind for non-number input', () => {
            assert.equal(mathEnforcer.subtractTen('test'), undefined);
        });

        it('should return correct for positive integer', () => {
            assert.equal(mathEnforcer.subtractTen(20), 10);
        });

        it('should return correct for negative integer', () => {
            assert.equal(mathEnforcer.subtractTen(-5), -15);
        });

        it('should return correct for floating point number', () => {
            assert.closeTo(mathEnforcer.subtractTen(12.5), 2.5, 0.1);
        });
    });

    describe('Sum Test', function () {
        it('should return undefind for invalid first param', () => {
            assert.equal(mathEnforcer.sum('1', 1), undefined);
        });

        it('should return undefind for invalid second param', () => {
            assert.equal(mathEnforcer.sum(1, '1'), undefined);
        });

        it('should return correct for integer number', () => {
            assert.equal(mathEnforcer.sum(10, 2), 12);
        });

        it('should return correct for floating point number', () => {
            assert.closeTo(mathEnforcer.sum(12.3, 5.6), 17.9, 0.1);
        });
    });
});