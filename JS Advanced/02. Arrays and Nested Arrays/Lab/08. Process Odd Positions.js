function oddPositions(arr) {
  //const odd = arr.filter((x, i) => i % 2);
  //const doubled = odd.map(x => x * 2);
  //
  //doubled.reverse();
  //
  //console.log(doubled.join(` `));

  console.log(arr
    .filter((x, i) => i % 2)
    .map(x => x * 2)
    .reverse()
    .join(` `));
}

oddPositions([10, 15, 20, 25]);
oddPositions([3, 0, 10, 4, 7, 3]);