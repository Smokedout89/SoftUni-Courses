const { assert } = require('chai');
const { companyAdministration } = require('./companyAdministration');

describe("Tests for Company Administration", function() {
    describe("Hiring employee tests", function() {
        it("Test with programmer and enough exp", function() {
            assert.equal(companyAdministration.hiringEmployee('John', 'Programmer', 3),
                `John was successfully hired for the position Programmer.`);
        });
        it("Test with programmer and not enough exp", function() {
            assert.equal(companyAdministration.hiringEmployee('John', 'Programmer', 2),
                `John is not approved for this position.`);
        });
        it("Test with different position", function() {
            assert.throw(() => companyAdministration.hiringEmployee('John', 'Engineer', 2),
                `We are not looking for workers for this position.`);
        });
    });

    describe("Calculate salary tests", function() {
        it("Test should return correct salary", function() {
            assert.equal(companyAdministration.calculateSalary(10), 150);
        });
        it("Test should return correct salary with the bonus", function() {
            assert.equal(companyAdministration.calculateSalary(170), 3550);
        });
        it("Test should throw with wrong input", function() {
            assert.throws(() => companyAdministration.calculateSalary('5'), `Invalid hours`);
            assert.throws(() => companyAdministration.calculateSalary('asd'), `Invalid hours`);
            assert.throws(() => companyAdministration.calculateSalary(-1), `Invalid hours`);
        });
    });

    describe("Fire employee tests", function() {
        it("Test should return string with remaining workers", function() {
            assert.equal(companyAdministration.firedEmployee(['Gosho', 'Tosho', 'Pesho'], 1),
                `Gosho, Pesho`);
        });
        it("Test should throw error if not passed an array", function() {
            assert.throws(() => companyAdministration.firedEmployee('asd', 2),
                `Invalid input`);
            assert.throws(() => companyAdministration.firedEmployee(5, 2),
                `Invalid input`);
            assert.throws(() => companyAdministration.firedEmployee({}, 2),
                `Invalid input`);
        });
        it("Test should throw error if passed invalid index", function() {
            assert.throws(() => companyAdministration.firedEmployee(['Gosho', 'Tosho'], 2),
                `Invalid input`);
            assert.throws(() => companyAdministration.firedEmployee(['Gosho', 'Tosho'], -1),
                `Invalid input`);
            assert.throws(() => companyAdministration.firedEmployee(['Gosho', 'Tosho'], '1'),
                `Invalid input`);
        });
    });
});