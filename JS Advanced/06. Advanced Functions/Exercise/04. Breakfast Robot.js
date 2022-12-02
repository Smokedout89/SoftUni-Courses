function solution() {
    let stock = {
        protein: 0,
        carbohydrate: 0,
        fat: 0,
        flavour: 0
    };

    const recipes = {
        apple: { carbohydrate: 1, flavour: 2 },
        lemonade: { carbohydrate: 10, flavour: 20 },
        burger: { carbohydrate: 5, fat: 7, flavour: 3 },
        eggs: { protein: 5, fat: 1, flavour: 1 },
        turkey: { protein: 10, carbohydrate: 10, fat: 10, flavour: 10 }
    };

    const commands = {
        restock,
        prepare,
        report
    };

    return manager;
    function manager(line) {
        const [command, param, qty] = line.split(' ');
        return commands[command](param, qty);
    };

    function restock(type, qty) {
        stock[type] += Number(qty);
        return 'Success';
    }

    function prepare(recipeAsStr, qty) {
        const recipe = Object.entries(recipes[recipeAsStr]);
        qty = Number(qty);

        recipe.forEach(ingredient => ingredient[1] *= qty);
        
        for (const [ingredient, requiredQty] of recipe) {
            if (stock[ingredient] < requiredQty) {
                return `Error: not enough ${ingredient} in stock`
            }
        }

        recipe.forEach(([ingredient, requiredQty]) => stock[ingredient] -= requiredQty);

        return 'Success';
    }

    function report() {
        return `protein=${stock.protein} carbohydrate=${stock.carbohydrate} fat=${stock.fat} flavour=${stock.flavour}`
    }
}

let manager = solution();
console.log(manager("restock flavour 50")); // Success 
console.log(manager("prepare lemonade 4")); // Error: not enough carbohydrate in stock 