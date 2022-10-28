function numbers(array) {
  let result = [];

  for (let i = 0; i < array.length; i++) {
    if (array[i] < 0) {
      result.unshift(array[i]);
    } else {
      result.push(array[i]);
    }
  }

  console.log(result.join("\n"));
}

numbers([7, -2, 8, 9,]);
numbers([3, -2, 0, -1]);