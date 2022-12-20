const {assert} = require('chai');
const {PaymentPackage} = require('./PaymentPackage');

describe('Payment Package Class Tests', () => {

    describe('Tests for the name', () => {
        it('test the constructor', () => {
            let pp = new PaymentPackage('Name', 1000);

            assert.equal(pp.name, 'Name');
            assert.equal(pp.value, 1000);
            assert.equal(pp.VAT, 20);
            assert.equal(pp.active, true);
        });

        it('Should throw error when the new Name is a number', () => {
            assert.throws(() => new PaymentPackage(123, 123), 'Name must be a non-empty string');
        });

        it('Should throw error when the new Name is an array', () => {
            assert.throws(() => new PaymentPackage(['abv'], 123), 'Name must be a non-empty string');
        });

        it('Should throw error when the new Name is empty', () => {
            assert.throws(() => new PaymentPackage('', 123), 'Name must be a non-empty string');
        });

        it('Should return the new Name if the input is good', () => {
            assert.doesNotThrow(() => new PaymentPackage('abc', 123));
        });
    });

    describe('Tests for the value', () => {
        it('Should throw error when the new Value is a string', () => {
            assert.throws(() => new PaymentPackage('abc', 'abc'), 'Value must be a non-negative number');
        });

        it('Should throw error when the new Value is an array', () => {
            assert.throws(() => new PaymentPackage('abc', [123]), 'Value must be a non-negative number');
        });

        it('Should throw error when the new Value is negative', () => {
            assert.throws(() => new PaymentPackage('abc', -123), 'Value must be a non-negative number');
        });

        it('Should return the new Value if the input is good', () => {
            assert.doesNotThrow(() => new PaymentPackage('abc', 123));
        });

        it('Set value to null', () => {
            let pp = new PaymentPackage('Name', 100);
            assert.doesNotThrow(() => {
                pp.value = 0
            })
        });
    });

    describe('Tests for the VAT', () => {
        it('Should throw error when the new VAT is a string', () => {
            let pp = new PaymentPackage('abc', 123);
            assert.throws(() => pp.VAT = 'abc', 'VAT must be a non-negative number');
        });

        it('Should throw error when the new VAT is an array', () => {
            let pp = new PaymentPackage('abc', 123);
            assert.throws(() => pp.VAT = [123], 'VAT must be a non-negative number');
        });

        it('Should throw error when the new VAT is negative', () => {
            let pp = new PaymentPackage('abc', 123);
            assert.throws(() => pp.VAT = -123, 'VAT must be a non-negative number');
        });

        it('Should return the new VAT if the input is good', () => {
            let pp = new PaymentPackage('abc', 123);
            assert.doesNotThrow(() => pp.VAT = 123);
        });
    });

    describe('Tests for active bool', () => {
        it('Should throw error when the new Active is a string', () => {
            let pp = new PaymentPackage('abc', 123);
            assert.throws(() => pp.active = 'abc', 'Active status must be a boolean');
        });

        it('Should throw error when the new Active is an array', () => {
            let pp = new PaymentPackage('abc', 123);
            assert.throws(() => pp.active = [123], 'Active status must be a boolean');
        });

        it('Should throw error when the new Active is negative', () => {
            let pp = new PaymentPackage('abc', 123);
            assert.throws(() => pp.active = -123, 'Active status must be a boolean');
        });

        it('Should return the new Active if the input is good', () => {
            let pp = new PaymentPackage('abc', 123);
            assert(() => pp.active = true);
        });
    });

    describe('Tests for toString', () => {
        it('Should return a string as all the input is correct - 1', () => {
            let pp = new PaymentPackage('abc', 123);
            let output = [
                `Package: abc`,
                `- Value (excl. VAT): 123`,
                `- Value (VAT 20%): 147.6`
            ]
            assert.equal(pp.toString(), output.join('\n'));
        });

        it('Should return a string as all the input is correct - 2', () => {
            let pp = new PaymentPackage('abc', 123);
            pp.VAT = 30;
            let output = [
                `Package: abc`,
                `- Value (excl. VAT): 123`,
                `- Value (VAT 30%): 159.9`
            ]
            assert.equal(pp.toString(), output.join('\n'));
        });

        it('Should return a string as all the input is correct - 3', () => {
            let pp = new PaymentPackage('abc', 123);
            pp.active = false;
            let output = [
                `Package: abc (inactive)`,
                `- Value (excl. VAT): 123`,
                `- Value (VAT 20%): 147.6`
            ]
            assert.equal(pp.toString(), output.join('\n'));
        });

        it('Should return a string as all the input is correct - 4', () => {
            let pp = new PaymentPackage('abc', 123);
            pp.VAT = 30;
            pp.active = false;
            let output = [
                `Package: abc (inactive)`,
                `- Value (excl. VAT): 123`,
                `- Value (VAT 30%): 159.9`
            ]
            assert.equal(pp.toString(), output.join('\n'));
        });
    });
});