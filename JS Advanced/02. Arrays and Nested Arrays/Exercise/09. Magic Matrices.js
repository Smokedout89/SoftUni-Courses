function magicMatrix(matrix) {
  let isMagic = true;
  let colSum = 0;
  let sumNeeded = matrix[0].reduce((a, b) => a + b);

  for (let row = 0; row < matrix.length; row++) {
    let rowSum = matrix[row].reduce((a, b) => a + b);

    if (rowSum !== sumNeeded) {
      isMagic = false;
      break;
    }
  }

  for (let row = 0; row < matrix.length; row++) {
    for (let col = 0; col < matrix.length; col++) {
      colSum += matrix[row][col];
    }

    if (colSum !== sumNeeded) {
      isMagic = false;
      break;
    }

    colSum = 0;
  }

  isMagic ? console.log(`true`) : console.log(`false`);
}

magicMatrix([
  [4, 5, 6],
  [6, 5, 4],
  [5, 5, 5],
]);
magicMatrix([
  [11, 32, 45],
  [21, 0, 1],
  [21, 1, 1],
]);
magicMatrix([
  [1, 0, 0],
  [0, 0, 1],
  [0, 1, 0],
]);