const { assert } = require('chai');
const { isOddOrEven } = require('./evenOrOdd');

describe('Even or Odd Tests', () => {
    it('Should return undefined with number', () => {
        assert.equal(isOddOrEven(5), undefined);
    });

    it('Should return undefined with array', () => {
        assert.equal(isOddOrEven([]), undefined);
    });

    it('Should return undefined with object', () => {
        assert.equal(isOddOrEven({}), undefined);
    });

    it('Should return even', () => {
        assert.equal(isOddOrEven('hell'), 'even');
    });

    it('Should return odd', () => {
        assert.equal(isOddOrEven('hello'), 'odd');
    });
});