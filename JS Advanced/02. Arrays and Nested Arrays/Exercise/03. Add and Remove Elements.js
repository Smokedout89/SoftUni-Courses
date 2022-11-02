function addRemove(array) {
  let result = [];
  let number = 1;

  for (let i = 0; i < array.length; i++) {
    const element = array[i];

    if (element === `add`) {
      result.push(number);
    } else if (element === `remove`) {
      result.pop();
    }

    number++;
  }

  if (result.length === 0) {
    console.log(`Empty`);
  } else {
    console.log(result.join(`\n`));
  }
}

addRemove(["add", "add", "add", "add"]);
addRemove(["add", "add", "remove", "add", "add"]);
addRemove(["remove", "remove", "remove"]);