function increasingSubset(array) {
  let result = [];
  let biggest = Number.NEGATIVE_INFINITY;

  for (const element of array) {
    if (element >= biggest) {
      biggest = element;
      result.push(element);
    }
  }

  return result;
}

increasingSubset([1, 3, 8, 4, 10, 12, 3, 2, 24]);
increasingSubset([1, 2, 3, 4]);
increasingSubset([20, 3, 2, 15, 6, 1]);