function sortingNumbers(array) {
  let result = [];
  let n = array.length;
  array = array.sort((a, b) => a - b);

  for (let i = 0; i < n; i++) {
    let current;
    if (i % 2 === 0) {
      current = array.shift();
      result[i] = current;
    } else {
      current = array.pop();
      result[i] = current;
    }
  }

  return result;
}

sortingNumbers([1, 65, 3, 52, 48, 63, 31, -3, 18, 56]);
