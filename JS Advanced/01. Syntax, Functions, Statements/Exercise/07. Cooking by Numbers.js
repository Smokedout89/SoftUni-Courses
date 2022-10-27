function solve(numToParse, op1, op2, op3, op4, op5) {
    let number = Number(numToParse);
    let arr = [op1, op2, op3, op4, op5];

    for (let index = 0; index < arr.length; index++) {
        switch (arr[index]) {
            case `chop`: number /= 2; break;
            case `dice`: number = Math.sqrt(number); break;
            case `spice`: number += 1; break;
            case `bake`: number *= 3; break;
            case `fillet`: number *= 0.8; break;
        }    

        console.log(number);
    }
}

solve('32', 'chop', 'chop', 'chop', 'chop', 'chop')
solve('9', 'dice', 'spice', 'chop', 'bake', 'fillet')