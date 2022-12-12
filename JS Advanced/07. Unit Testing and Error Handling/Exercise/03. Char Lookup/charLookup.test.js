const { assert } = require('chai');
const { lookupChar } = require('./charLookup');

describe('Char Lookup tests', () => {
    it('should return the char at the given index', () => {
        assert.equal(lookupChar('hello', 0), 'h');
        assert.equal(lookupChar('hello', 4), 'o');
    });

    it('should return undefined if first param not a string', () => {
        assert.equal(lookupChar([], 0), undefined);
        assert.equal(lookupChar({}, 0), undefined);
        assert.equal(lookupChar(5, 0), undefined);
    });

    it('should return undefined if second param is floating point', () => {
        assert.equal(lookupChar('hello', 1.1), undefined);
    });

    it('should return undefined if second param not a number', () => {
        assert.equal(lookupChar('hi', 'hi'), undefined);
        assert.equal(lookupChar('hi', []), undefined);
        assert.equal(lookupChar('hi', {}), undefined);
    });

    it('should return Incorect Index if index is out of bounds', () => {
        assert.equal(lookupChar('hi', -1), 'Incorrect index');
        assert.equal(lookupChar('hi', 2), 'Incorrect index');
    });
});