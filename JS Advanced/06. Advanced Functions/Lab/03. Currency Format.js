function createFormatter(separator, symbol, symbolFirst, formatter) {
    return (value) => formatter(separator, symbol, symbolFirst, value);
    
    function currencyFormatter(separator, symbol, symbolFirst, value) {
        let result = Math.trunc(value) + separator;
        result += value.toFixed(2).substr(-2, 2);
        if (symbolFirst) return symbol + ' ' + result;
        else return result + ' ' + symbol;
    }
}


let dollarFormatter = createFormatter(',', '$', true, currencyFormatter);
console.log(dollarFormatter(5345));   // $ 5345,00
console.log(dollarFormatter(3.1429)); // $ 3,14
console.log(dollarFormatter(2.709));  // $ 2,71

let poundFormatter = createFormatter('.', '£', false, currencyFormatter)
console.log(poundFormatter(5345));
console.log(poundFormatter(3.1429))
console.log(poundFormatter(2.709));