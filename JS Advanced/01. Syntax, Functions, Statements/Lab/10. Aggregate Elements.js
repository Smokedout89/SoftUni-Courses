function solve(elements) {
  aggregate(elements, 0, (a, b) => a + b);
  aggregate(elements, 0, (a, b) => a + 1 / b);
  aggregate(elements, ``, (a, b) => a + b);

  function aggregate(arr, initValue, func) {
    let value = initValue;

    for (let i = 0; i < arr.length; i++) {
      value = func(value, arr[i]);
    }

    console.log(value);
  }
}

solve([1, 2, 3]);
solve([2, 4, 8, 16]);
