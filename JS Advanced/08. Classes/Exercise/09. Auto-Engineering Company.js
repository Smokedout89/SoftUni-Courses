function carProducer(arr) {
    let cars = {};

    for (const car of arr) {
        let [brand, model, produced] = car.split(' | ');

        if (!cars[brand]) {
            cars[brand] = {};
        }

        if (!cars[brand][model]) {
            cars[brand][model] = 0;
        }

        cars[brand][model] += Number(produced);

    }

    for (const brand in cars) {
        console.log(brand);
        for (const [model, qty] of Object.entries(cars[brand])) {
            console.log(`###${model} -> ${qty}`);
        }
    }
}

carProducer(
    ['Audi | Q7 | 1000',
        'Audi | Q6 | 100',
        'BMW | X5 | 1000',
        'BMW | X6 | 100',
        'Citroen | C4 | 123',
        'Volga | GAZ-24 | 1000000',
        'Lada | Niva | 1000000',
        'Lada | Jigula | 1000000',
        'Citroen | C4 | 22',
        'Citroen | C5 | 10'])