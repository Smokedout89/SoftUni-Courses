class Restaurant {
    constructor(budgetMoney) {
        this.budgetMoney = budgetMoney;
        this.menu = {};
        this.stockProducts = {};
        this.history = [];
    }

    loadProducts(arr) {
        for (const line of arr) {
            let [name, quantity, price] = line.split(' ');

            price = Number(price);
            quantity = Number(quantity);

            if (price <= this.budgetMoney) {
                if (this.stockProducts.hasOwnProperty(name)) {
                    this.stockProducts[name] += quantity;
                } else {
                    this.stockProducts[name] = quantity;
                }

                this.budgetMoney -= price;
                this.history.push(`Successfully loaded ${quantity} ${name}`);
            } else {
                this.history.push(`There was not enough money to load ${quantity} ${name}`);
            }
        }

        return this.history.join('\n');
    }

    addToMenu(meal, products, price) {
        if (this.menu.hasOwnProperty(meal)) {
            return `The ${meal} is already in the our menu, try something different.`;
        } else {
            this.menu[meal] = {
                products,
                price
            };
        }

        let meals = Object.keys(this.menu).length;

        if (meals === 1) {
            return `Great idea! Now with the ${meal} we have 1 meal in the menu, other ideas?`;
        } else {
            return `Great idea! Now with the ${meal} we have ${meals} meals in the menu, other ideas?`;
        }
    }

    showTheMenu() {
        if (Object.keys(this.menu).length === 0) {
            return "Our menu is not ready yet, please come later...";
        }

        let result = [];

        for (const [meal, value] of Object.entries(this.menu)) {
            result.push(`${meal} - $ ${value.price}`);
        }

        return result.join('\n');
    }

    makeTheOrder(meal) {
        if (!this.menu.hasOwnProperty(meal)) {
            return `There is not ${meal} yet in our menu, do you want to order something else?`;
        }

        let canPrepare = true;
        let products = this.menu[meal].products;

        for (const product of products) {
            const [name, quantity] = product.split(' ');
            if (!this.stockProducts[name] || this.stockProducts[name] < Number(quantity)) {
                canPrepare =  false;
                break;
            }
        }

        if (!canPrepare) {
            return `For the time being, we cannot complete your order (${meal}), we are very sorry...`;
        } else {
            for (const product of products) {
                const [name, quantity] = product.split(' ');
                this.stockProducts[name] -= Number(quantity);
            }

            this.budgetMoney += Number(this.menu[meal].price);
            return `Your order (${meal}) will be completed in the next 30 minutes and will cost you ${this.menu[meal].price}.`;
        }
    }
}