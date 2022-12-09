const { assert } = require('chai');
const { createCalculator } = require('./addSubtract');

describe('Add/Subtract Calculator Checker', () => {
    let calc;

    beforeEach(function () {
        calc = createCalculator();
    })

    it('calculator works', () => {
        calc.add(2);
        calc.subtract(1);

        assert.equal(calc.get(), 1);
    });

    it('calculator should return object', () => {
        assert.isObject(calc);
    });

    it('calculator should return number', () => {
        calc.add(5);
        assert.isNumber(calc.get());
    });

    it('calculator should return Nan with a string', () => {
        calc.add('word');
        assert.isNaN(calc.get());
    });

    it('calculator should have add, subtract, get properties', () => {
        assert.isTrue(calc.hasOwnProperty('add'));
        assert.isTrue(calc.hasOwnProperty('subtract'));
        assert.isTrue(calc.hasOwnProperty('get'));
        assert.isFalse(calc.hasOwnProperty('value'));
    });

    it('calculator should work with parsed numbers', () => {
        calc.add('2');
        calc.subtract('1')

        assert.equal(calc.get(), 1);
    });

    it('calculator should work withoud add', () => {
        calc.subtract('1')

        assert.equal(calc.get(), -1);
    });

    it('calculator should not be able to change value', () => {
        calc.add(3);
        calc.value = 5;

        assert.equal(calc.get(), 3);
    });
});