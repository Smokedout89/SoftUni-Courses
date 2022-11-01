function biggestElement(matrix) {
  let biggest = matrix[0][0];

  for (const row of matrix) {
    if (Math.max(...row) > biggest) {
      biggest = Math.max(...row);
    }
  }

  return biggest;
}

biggestElement([
  [20, 50, 10],
  [8, 33, 145],
]);
biggestElement([
  [3, 5, 7, 12],
  [-1, 4, 33, 2],
  [8, 3, 0, 4],
]);