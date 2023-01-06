const { assert } = require('chai');
const { library } = require('./library');

describe("Library Tests", function() {
    describe("Calculate price tests", function() {
        it("Calculating price should work properly", function() {
            assert.equal(library.calcPriceOfBook('Knigata', 2000), `Price of Knigata is 20.00`);
        });
        it("Calculating price should apply discount", function() {
            assert.equal(library.calcPriceOfBook('Knigata', 1980), `Price of Knigata is 10.00`);
        });
        it("Calculating price should throw with invalid params", function() {
            assert.throws(() => library.calcPriceOfBook(1, 2000), "Invalid input");
            assert.throws(() => library.calcPriceOfBook('Knigata', 'a'), "Invalid input");
        });
    });

    describe("Find book tests", function() {
        it("Finding book should work properly", function() {
            assert.equal(library.findBook(['Knigata', 'C# Coding'], 'Knigata'), "We found the book you want.");
        });
        it("Finding book should return msg if book not found", function() {
            assert.equal(library.findBook(['Knigata', 'C# Coding'], 'Paolo Coelho'), "The book you are looking for is not here!");
        });
        it("Finding book should throw with no books in arr", function() {
            assert.throws(() => library.findBook([], 'Paolo'), "No books currently available");
        });
    });

    describe("Arrange books tests", function() {
        it("Arranging books should work properly", function() {
            assert.equal(library.arrangeTheBooks(40), "Great job, the books are arranged.");
            assert.equal(library.arrangeTheBooks(41), "Insufficient space, more shelves need to be purchased.");
        });
        it("Arranging books should throw with invalid params", function() {
            assert.throws(() => library.arrangeTheBooks(-1), "Invalid input");
            assert.throws(() => library.arrangeTheBooks(4.20), "Invalid input");
        });
    });
});