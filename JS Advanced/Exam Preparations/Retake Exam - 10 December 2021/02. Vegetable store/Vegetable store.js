class VegetableStore {
    constructor(owner, location) {
        this.owner = owner;
        this.location = location;
        this.availableProducts = [];
    }

    loadingVegetables(vegetables) {
        for (const vegetable of vegetables) {
            let [type, quantity, price] = vegetable.split(' ');
            quantity = Number(quantity);
            price = Number(price);

            let product = this.availableProducts.find(v => v.type === type);

            if (product === undefined) {
                this.availableProducts.push({type, quantity, price});
            } else {
                product.quantity += quantity;

                if (price > product.price) {
                    product.price = price;
                }
            }
        }

        const prodTypes = this.availableProducts.map(t => t.type);
        return `Successfully added ${prodTypes.join(', ')}`;
    }

    buyingVegetables(selectedProducts) {
        let totalPrice = 0;

        for (const selectedProduct of selectedProducts) {
            let [type, quantity] = selectedProduct.split(' ');
            quantity = Number(quantity);

            let product = this.availableProducts.find(p => p.type === type);

            if (product === undefined) {
                throw new Error(`${type} is not available in the store, your current bill is $${totalPrice.toFixed(2)}.`);
            }

            if (quantity > product.quantity) {
                throw new Error(`The quantity ${quantity} for the vegetable ${type} is not available in the store, your current bill is $${totalPrice.toFixed(2)}.`);
            }

            totalPrice += quantity * product.price;
            product.quantity -= quantity;
        }

        return `Great choice! You must pay the following amount $${totalPrice.toFixed(2)}.`
    }

    rottingVegetable(type, quantity) {
        let product = this.availableProducts.find(v => v.type === type);

        if (product === undefined) {
            throw new Error(`${type} is not available in the store.`);
        }

        if (quantity > product.quantity) {
            product.quantity = 0;
            return `The entire quantity of the ${type} has been removed.`;
        } else {
            product.quantity -= quantity;
            return `Some quantity of the ${type} has been removed.`
        }
    }

    revision() {
        const vegRow = this.availableProducts
                .sort((a, b) => a.price - b.price)
                .map(v => `${v.type}-${v.quantity}-$${v.price}`)
                .join('\n');

        return [
           `Available vegetables:`,
            vegRow,
            `The owner of the store is ${this.owner}, and the location is ${this.location}.`
        ].join('\n')
    }
}