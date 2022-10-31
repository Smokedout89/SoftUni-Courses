function smallestTwo(array) {
  const result = array.sort((a, b) => a - b).slice(0, 2);

  console.log(result.join(` `));
}

smallestTwo([30, 15, 50, 5]);
smallestTwo([3, 0, 10, 4, 7, 3]);
