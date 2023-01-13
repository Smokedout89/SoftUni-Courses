const { assert } = require('chai');
const { cinema } = require('./cinema');

describe("Cinema Tests", function() {
    describe("Show Movie Tests", function() {
        it("Should show available movies", function() {
            assert.equal(cinema.showMovies(['Scary Movie', 'How High']), `Scary Movie, How High`);
        });
        it("Should return msg if no movies available", function() {
            assert.equal(cinema.showMovies([]), 'There are currently no movies to show.');
        });
    });

    describe("Ticket Price Tests", function() {
        it("Should return correct ticket price", function() {
            assert.equal(cinema.ticketPrice('Premiere'), `12.00`);
            assert.equal(cinema.ticketPrice('Normal'), `7.50`);
            assert.equal(cinema.ticketPrice('Discount'), `5.50`);
        });
        it("Should throw if invalid param provided", function() {
            assert.throws(() => cinema.ticketPrice('asd'),'Invalid projection type.');
            assert.throws(() => cinema.ticketPrice(5),'Invalid projection type.');
        });
    });

    describe("Swap Seats Tests", function() {
        it("Should return message for successful swap", function() {
            assert.equal(cinema.swapSeatsInHall(1, 20), "Successful change of seats in the hall.");
        });
        it("Should return message for unsuccessful swap", function() {
            assert.equal(cinema.swapSeatsInHall(1.1, 2), "Unsuccessful change of seats in the hall.");
            assert.equal(cinema.swapSeatsInHall(1, 2.1), "Unsuccessful change of seats in the hall.");
            assert.equal(cinema.swapSeatsInHall(0, 2), "Unsuccessful change of seats in the hall.");
            assert.equal(cinema.swapSeatsInHall(2, 0), "Unsuccessful change of seats in the hall.");
            assert.equal(cinema.swapSeatsInHall(21, 1), "Unsuccessful change of seats in the hall.");
            assert.equal(cinema.swapSeatsInHall(1, 21), "Unsuccessful change of seats in the hall.");
            assert.equal(cinema.swapSeatsInHall(1, 1), "Unsuccessful change of seats in the hall.");
        });
    });
});
