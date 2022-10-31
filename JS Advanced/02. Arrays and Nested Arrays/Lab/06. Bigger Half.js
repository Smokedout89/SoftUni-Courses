function biggerHalf(arr) {
  let half = 0;
  if (arr.length % 2 === 0) {
    half = arr.length / 2;
  } else {
    half = Math.floor(arr.length / 2);
  }

  let result = arr.sort((a, b) => a - b).slice(half, arr.length);

  return result;
}

biggerHalf([4, 7, 2, 5]);
biggerHalf([3, 19, 14, 7, 2, 19, 6]);
