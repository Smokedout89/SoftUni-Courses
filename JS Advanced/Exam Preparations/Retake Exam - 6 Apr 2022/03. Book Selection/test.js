const { assert } = require('chai');
const { bookSelection } = require('./03. Book selection');

describe("Tests for Book selection", function() {
    describe("isGenreSuitable tests", function() {
        it('should work as expected', function () {
            assert.equal(bookSelection.isGenreSuitable('Thriller', 13), `Those books are suitable`);
            assert.equal(bookSelection.isGenreSuitable('Horror', 13), `Those books are suitable`);
            assert.equal(bookSelection.isGenreSuitable('Comedy', 9), `Those books are suitable`);
            assert.equal(bookSelection.isGenreSuitable('Bumble', 3), `Those books are suitable`);
        });

        it('should throw for genres that require age', function () {
            assert.equal(bookSelection.isGenreSuitable('Thriller', 12), `Books with Thriller genre are not suitable for kids at 12 age`);
            assert.equal(bookSelection.isGenreSuitable('Horror', 12),`Books with Horror genre are not suitable for kids at 12 age` );
        });
    });

    describe("isItAffordable tests", function() {
        it('should work as expected', function () {
            assert.equal(bookSelection.isItAffordable(2,3), `Book bought. You have 1$ left`);
            assert.equal(bookSelection.isItAffordable(2,2), `Book bought. You have 0$ left`);
        });

        it('should print msg if there is not enough budget', function () {
            assert.equal(bookSelection.isItAffordable(2,1), `You don't have enough money`);
        });

        it('should print msg if argument is not a number', function () {
            assert.throw(() => bookSelection.isItAffordable('1', 2), 'Invalid input');
            assert.throw(() => bookSelection.isItAffordable(1, '2'), 'Invalid input');
            assert.throw(() => bookSelection.isItAffordable('1', '2'), 'Invalid input');
        });
    });

    describe("suitableTitles tests", function() {
        it('should work as expected', function () {
            assert.deepEqual(bookSelection.suitableTitles([{title: 'Chakalite',genre: 'Comedy'}],'Comedy'), ['Chakalite']);
        });

        it('should work as expected with more than 1 movie', function () {
            assert.deepEqual(bookSelection.suitableTitles([{title: 'Chakalite',genre: 'Comedy'}],'Comedy'), ['Chakalite']);
            assert.deepEqual(bookSelection.suitableTitles
            ([{title: 'Rush Hour',genre: 'Action'}
                , {title: 'Bad Boys', genre: 'Action'}]
                ,'Action'), ['Rush Hour', 'Bad Boys']);
        });

        it('should throw with invalid input', function () {
            assert.throws(() => bookSelection.suitableTitles('asd', 'Comedy'), 'Invalid input');
            assert.throws(() => bookSelection.suitableTitles([{title: 'asd', genre: 'Comedy'}], 9), 'Invalid input');
            assert.throws(() => bookSelection.suitableTitles([{title: 'asd', genre: 'Comedy'}], {}), 'Invalid input');
        });
    });
});