class LibraryCollection {
    constructor(capacity) {
        this.capacity = capacity;
        this.books = [];
    }

    addBook(bookName, bookAuthor) {
        if (this.capacity === this.books.length) {
            throw new Error("Not enough space in the collection.");
        } else {
            this.books.push({
                bookName,
                bookAuthor,
                payed: false
            });

            return `The ${bookName}, with an author ${bookAuthor}, collect.`;
        }
    }

    payBook(bookName) {
        const currentB = this.books.find(b => b.bookName === bookName);

        if (currentB === undefined) {
            throw new Error(`${bookName} is not in the collection.`);
        }

        if (currentB.payed) {
            throw new Error(`${bookName} has already been paid.`);
        } else {
            currentB.payed = true;
            return `${bookName} has been successfully paid.`;
        }
    }

    removeBook(bookName) {
        const bookIndex = this.books.findIndex(b => b.bookName === bookName);

        if (bookIndex === -1) {
            throw new Error("The book, you're looking for, is not found.");
        }

        const currentB = this.books[bookIndex];

        if (!currentB.payed) {
            throw new Error(`${bookName} need to be paid before removing from the collection.`);
        } else {
            this.books.splice(bookIndex);
            return `${bookName} remove from the collection.`;
        }
    }

    getStatistics(bookAuthor) {
        if (bookAuthor === undefined) {
            const booksAsStr = this.books.sort((a, b) => a.bookName.localeCompare(b.bookName));
            const booksToPrint = booksAsStr
                .map(b => `${b.bookName} == ${b.bookAuthor} - ${b.payed ? 'Has Paid' : 'Not Paid'}.`)
                .join('\n');

            return [
                `The book collection has ${this.capacity - this.books.length} empty spots left.`,
                booksToPrint
            ].join('\n');
        } else {
            const author = this.books.some(b => b.bookAuthor === bookAuthor);

            if (author === false) {
                throw new Error(`${bookAuthor} is not in the collection.`);
            } else {
                let books = [];

                for (const book of this.books) {
                    if (book.bookAuthor === bookAuthor) {
                        books.push(book);
                    }
                }

                return books.map(b => `${b.bookName} == ${b.bookAuthor} - ${b.payed ? 'Has Paid' : 'Not Paid'}.`)
                    .join('\n');
            }
        }
    }
}