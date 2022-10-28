function evenPosElement(arr) {
  let result = new Array();

  for (let index = 0; index < arr.length; index++) {
    const element = arr[index];

    if (index % 2 === 0) {
      result.push(element);
    }
  }

  console.log(result.join(` `));
}

evenPosElement(["20", "30", "40", "50", "60"]);
evenPosElement(["5", "10"]);