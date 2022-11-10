function lowestPrices(arr) {
    let obj = {};

    for (const inputLine of arr) {
        const args = inputLine.split(' | ');
        const town = args[0];
        const product = args[1];
        const price = Number(args[2]);

        if (!obj.hasOwnProperty(product)) {
            obj[product] = { town, price };
        } else {
            if (price < obj[product].price) {
                obj[product] = { town, price };
            }
        }
    }

    let products = Object.keys(obj);

    for (const product of products) { 
        console.log(`${product} -> ${obj[product].price} (${obj[product].town})`);
    }
}

lowestPrices([
    'Sample Town | Sample Product | 1000',
    'Sample Town | Orange | 2',
    'Sample Town | Peach | 1',
    'Sofia | Orange | 3',
    'Sofia | Peach | 2',
    'New York | Sample Product | 1000.1',
    'New York | Burger | 10'
])