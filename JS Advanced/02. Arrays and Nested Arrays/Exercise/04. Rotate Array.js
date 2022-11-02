function rotateArray(array, n) {
  for (let i = 0; i < n; i++) {
    const temp = array.pop();
    array.unshift(temp);
  }

  console.log(array.join(` `));
}

rotateArray(["1", "2", "3", "4"], 2);
rotateArray(["Banana", "Orange", "Coconut", "Apple"], 15);