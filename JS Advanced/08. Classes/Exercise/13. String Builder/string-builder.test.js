const { assert } = require('chai');
const { StringBuilder } = require('./string-builder');

describe('StringBuilder Test', () => {
    describe('constructor tests', () => {
        it('should initialize with empty array if undefined is passed', () => {
            let sb = new StringBuilder(undefined);
            assert.equal(sb.toString(), '');
        });

        it('should throw error if passed non string', () => {
           assert.throws(() => new StringBuilder(1.23), TypeError);
           assert.throws(() => new StringBuilder(null), TypeError);
        });

        it('should initialize array when passed valid string', () => {
            let sb1 = new StringBuilder('abc');
            let sb2 = new StringBuilder('test');
            assert.equal(sb1.toString(), 'abc');
            assert.equal(sb2.toString(), 'test');
        });
    });

    describe('append tests', () => {
        it('should throw when passed non-string', () => {
            let sb = new StringBuilder();
            assert.throws(() => sb.append(true), TypeError);
            let sb2 = new StringBuilder('abc')
            assert.throws(() => sb2.append(123), TypeError);
        });

        it('should append strings correctly', () => {
            let sb = new StringBuilder('asd');
            assert.equal(sb.toString(),'asd');

            sb.append('123');
            assert.equal(sb.toString(),'asd123');
            sb.append('dsa');
            assert.equal(sb.toString(),'asd123dsa');
        });

        it('should append only chars with a string', () => {
            let sb = new StringBuilder('asd');
            sb.append('123');
            sb.append('456');
            assert.equal(sb.toString(), 'asd123456');
            sb.remove(3,3);
            assert.equal(sb.toString(), 'asd456');
        });
    });

    describe('prepend tests', () => {
        it('should throw when passed non-string', () => {
            let sb = new StringBuilder();
            assert.throws(() => sb.prepend(true), TypeError);
            assert.throws(() => sb.prepend(123), TypeError);
        });

        it('should prepend strings correctly', () => {
            let sb = new StringBuilder('asd');
            sb.prepend('123');
            assert.equal(sb.toString(), '123asd');
            sb.prepend('dsa');
            assert.equal(sb.toString(), 'dsa123asd');
        });

        it('should prepend chars at correct index', () => {
            let sb = new StringBuilder('asd');
            sb.prepend('123');
            sb.prepend('456');
            assert.equal(sb.toString(), '456123asd');
            sb.remove(3,3);
            assert.equal(sb.toString(), '456asd');
        });
    });

    describe('insertAt tests', () => {
        it('should throw when passed non-string', () => {
            let sb = new StringBuilder();
            assert.throws(() => sb.insertAt(true, 1), TypeError);
            let sb2 = new StringBuilder('abc')
            assert.throws(() => sb2.insertAt(123, 1), TypeError);
        });

        it('should insert at given index', () => {
            let sb = new StringBuilder('lama');
            sb.insertAt('ma', 2);
            assert.equal(sb.toString(), 'lamama');
            sb.insertAt('ta', 6);
            assert.equal(sb.toString(), 'lamamata');
        });

        it('should insert chars at correct index', () => {
            let sb = new StringBuilder('lama');
            sb.insertAt('ma', 2);
            sb.insertAt('ma', 2);
            assert.equal(sb.toString(), 'lamamama');
            sb.remove(2,2);
            assert.equal(sb.toString(), 'lamama');
        });
    });

    describe('remove tests', () => {
        it('should remove chars at correct index', () => {
            let sb = new StringBuilder('lamama');
            sb.remove(2,2);
            assert.equal(sb.toString(), 'lama');
            sb.remove(0,2);
            assert.equal(sb.toString(), 'ma');
        });
    });

    describe('toString tests', () => {
        it('should return correct string', () => {
            let sb = new StringBuilder();
            let sb2 = new StringBuilder('lama');

            assert.equal(sb.toString(), '');
            assert.equal(sb2.toString(), 'lama');
        });
    });
});