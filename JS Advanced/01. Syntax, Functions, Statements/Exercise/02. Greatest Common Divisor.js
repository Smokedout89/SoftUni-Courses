function GCD(num1, num2) {
    if (num2 == 0) {
        return num1;
    }

    return GCD(num2, num1 % num2)
}

console.log(GCD(15, 5))
console.log(GCD(2154, 458))