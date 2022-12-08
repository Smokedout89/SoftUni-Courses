const { assert } = require('chai');
const { sum } = require('./sum');

describe('Sum checker', () => {
    it('works with numbers array', () => {
        assert.equal(sum([1,2,3]), 6);
    });

    it('return zero with no numbers', () => {
        assert.equal(sum([]), 0);
    });
});