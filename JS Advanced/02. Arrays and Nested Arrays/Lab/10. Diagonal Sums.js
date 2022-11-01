function diagonalSum(matrix) {
  let firstSum = 0;
  let secondSum = 0;
  let i = 0;

  for (const row of matrix) {
    let j = row.length - i - 1;

    firstSum += row[i++];
    secondSum += row[j];
  }

  console.log(firstSum + ` ` + secondSum);
}

diagonalSum([
  [20, 40],
  [10, 60],
]);
diagonalSum([
  [3, 5, 17],
  [-1, 7, 14],
  [1, -8, 89],
]);
