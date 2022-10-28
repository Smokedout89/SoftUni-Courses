function numberSequence(lenght, elementsToSum) {
  let result = new Array();
  result[0] = 1;

  for (let index = 1; index < lenght; index++) {
    let number = 0;
    let startIndex = index - elementsToSum;

    if (startIndex < 0) {
      startIndex = 0;
    }

    for (i = startIndex; i < index; i++) {
      if (isNaN(result[i])) {
        result[i] = 0;
      }
      number += +result[i];
    }

    result[index] = number;
  }

  return result;
}

console.log(numberSequence(6, 3));
console.log(numberSequence(8, 2));