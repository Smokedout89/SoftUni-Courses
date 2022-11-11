function jansNotation(arr) {
    let numbers = [];

    for (const input of arr) {
        if (typeof input === `number`) {
            numbers.push(Number(input));
        } else {
            if (numbers.length < 2) {
                return `Error: not enough operands!`;
            }

            let secondNum = numbers.pop();
            let firstNum = numbers.pop();

            switch (input) {
                case `+`:
                    numbers.push(firstNum + secondNum);
                    break;
                case `-`:
                    numbers.push(firstNum - secondNum);
                    break;
                case `*`:
                    numbers.push(firstNum * secondNum);
                    break;
                case `/`:
                    numbers.push(firstNum / secondNum);
                    break;
            }
        }
    }

    return numbers.length > 1 ? `Error: too many operands!` : numbers[0];
}

console.log(jansNotation([3, 4, '+']))
console.log(jansNotation([5, 3, 4, '*', '-']))
console.log(jansNotation([7, 33, 8, '-']))
console.log(jansNotation([15, '/']))