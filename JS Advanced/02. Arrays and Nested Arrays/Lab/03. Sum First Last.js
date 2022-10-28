function firstLastSum(array) {
  let a = Number(array[0]);
  let b = Number(array[array.length - 1]);

  return a + b;
}

firstLastSum(["20", "30", "40"]);
firstLastSum(["5", "10"]);