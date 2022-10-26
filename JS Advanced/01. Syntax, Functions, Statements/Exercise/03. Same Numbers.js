function sameNumbers(number) {
    let areSame = true;
    let sum = 0;
    let itterations = String(number);
    
    let firstDigit = itterations[0];

    for (let i = 0; i < itterations.length; i++) {
        if (firstDigit != itterations[i]){
            areSame = false;
        }

        sum += +itterations[i];
    }

    console.log(areSame);
    console.log(sum);
}

sameNumbers(2222222)
sameNumbers(1234)