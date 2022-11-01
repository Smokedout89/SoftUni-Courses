function equalNeighbors(matrix) {
  let equals = 0;

  const isInside = (row, col) =>
    row >= 0 && row < matrix.length && col >= 0 && col < matrix[row].length;

  for (let row = 0; row < matrix.length; row++) {
    for (let col = 0; col < matrix[row].length; col++) {
      if (isInside(row + 1, col)) {
        if (matrix[row][col] === matrix[row + 1][col]) {
          equals++;
        }
      }
      if (isInside(row, col + 1)) {
        if (matrix[row][col] === matrix[row][col + 1]) {
          equals++;
        }
      }
    }
  }

  return equals;
}

equalNeighbors([
  ["2", "3", "4", "7", "0"],
  ["4", "0", "5", "3", "4"],
  ["2", "3", "5", "4", "2"],
  ["9", "8", "7", "5", "4"],
]);
equalNeighbors([
  ["test", "yes", "yo", "ho"],
  ["well", "done", "yo", "6"],
  ["not", "done", "yet", "5"],
]);
