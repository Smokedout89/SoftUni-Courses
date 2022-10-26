function calculatePrice(fruit, grams, pricePerKg) {
    let gramsToKg = grams / 1000;
    let totalPrice = pricePerKg * gramsToKg;

    console.log(`I need $${totalPrice.toFixed(2)} to buy ${gramsToKg.toFixed(2)} kilograms ${fruit}.`)
}

calculatePrice('orange', 2500, 1.80);
calculatePrice('apple', 1563, 2.35);