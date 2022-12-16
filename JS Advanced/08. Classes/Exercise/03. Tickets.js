function tickets(arr, criteria) {
    class Ticket {
        constructor(destination, price, status) {
            this.destination = destination;
            this.price = Number(price);
            this.status = status;
        }
    }

    let tickets = [];

    for (const line of arr) {
        let [destination, price, status] = line.split('|');
        tickets.push(new Ticket(destination,price, status));
    }

    tickets.sort((a,b) => {
        if (criteria === 'destination') {
            return a.destination.localeCompare(b.destination);
        } else if (criteria === 'price') {
            return a.price - b.price;
        } else if (criteria === 'status') {
            return a.status.localeCompare(b.status);
        }
    })


    return tickets;
}

console.log(tickets([
    'Philadelphia|94.20|available',
    'New York City|95.99|available',
    'New York City|95.99|sold',
    'Boston|126.20|departed'],
    'destination'
));

console.log(tickets([
    'Philadelphia|94.20|available',
    'New York City|95.99|available',
    'New York City|95.99|sold',
    'Boston|126.20|departed'],
    'status'
));