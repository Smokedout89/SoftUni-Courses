const { expect } = require('chai');
const { isSymmetric } = require('./symmetry');


describe('Symmetry Checker', () => {
    it('works with symmetric numeric array', () => {
        expect(isSymmetric([1, 2, 2, 1])).to.be.true;
    });

    it('retunt false for non-symmetric array', () => {
        expect(isSymmetric([1, 2, 3, 1])).to.be.false;
    });

    it('return false for non-array', () => {
        expect(isSymmetric(5)).to.be.false;
    });

    it('works with symmetric string array', () => {
        expect(isSymmetric(['a', 'b', 'b', 'a'])).to.be.true;
    });

    it('works with symmetric numeric odd array', () => {
        expect(isSymmetric([2, 3, 2])).to.be.true;
    });

    it('retunt false for string', () => {
        expect(isSymmetric('abba')).to.be.false;
    });

    it('retunt false for type missmatch', () => {
        expect(isSymmetric([1, 2, '1'])).to.be.false;
    });
});