class CarDealership {
    constructor(name) {
        this.name = name;
        this.availableCars = [];
        this.soldCars = [];
        this.totalIncome = 0;
    }

    addCar(model, horsepower, price, mileage) {
        if (model === '' || !Number.isInteger(horsepower) || horsepower < 0 || price < 0 || mileage < 0) {
            throw new Error("Invalid input!");
        }

        this.availableCars.push({
            model,
            horsepower,
            price,
            mileage
        });

        return `New car added: ${model} - ${horsepower} HP - ${mileage.toFixed(2)} km - ${price.toFixed(2)}$`;
    }

    sellCar(model, desiredMileage) {
        let carIndex = this.availableCars.findIndex(m => m.model === model);

        if (carIndex === -1) {
            throw new Error(`${model} was not found!`);
        }

        let car = this.availableCars[carIndex];
        let price = 0;

        if (car.mileage <= desiredMileage) {
            price = car.price;
        } else if (car.mileage - desiredMileage <= 40000) {
            price = car.price * 0.95;
        } else {
            price = car.price * 0.9;
        }

        this.soldCars.push({
            model,
            horsepower: car.horsepower,
            soldPrice: price.toFixed(2)
        });

        this.availableCars.splice(carIndex, 1);
        this.totalIncome += price;
        return `${model} was sold for ${price.toFixed(2)}$`;
    }

    currentCar() {
        if (this.availableCars.length === 0) {
            return "There are no available cars";
        }

        const carsAsRow =
            this.availableCars.map
            (c => `---${c.model} - ${c.horsepower} HP - ${c.mileage.toFixed(2)} km - ${c.price.toFixed(2)}$`);
        const carsToPrint = carsAsRow.join('\n');

        return [
            `-Available cars:`,
            carsToPrint
        ].join('\n')
    }

    salesReport(criteria) {
        let sortedCars;

        if (criteria === "horsepower") {
            sortedCars = this.soldCars.sort((a, b) => b.horsepower - a.horsepower);
        } else if (criteria === "model") {
            sortedCars = this.soldCars.sort((a, b) => a.model.localeCompare(b.model));
        } else {
            throw new Error("Invalid criteria!");
        }

        const sortedStr =
            sortedCars.map(c => `---${c.model} - ${c.horsepower} HP - ${c.soldPrice}$`);
        const sortedPrint = sortedStr.join('\n');

        return [
            `-${this.name} has a total income of ${this.totalIncome.toFixed(2)}$`,
            `-${this.soldCars.length} cars sold:`,
            sortedPrint
        ].join('\n')
    }
}