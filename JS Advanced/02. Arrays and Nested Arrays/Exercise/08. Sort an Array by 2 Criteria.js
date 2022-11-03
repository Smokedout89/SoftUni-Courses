function sortArray(array) {
  array.sort((a, b) => a.length - b.length || a.localeCompare(b));
  for (const element of array) {
    console.log(element);
  }
}

sortArray(["alpha", "beta", "gamma"]);
sortArray(["Isacc", "Theodor", "Jack", "Harrison", "George"]);
sortArray(["test", "Deny", "omen", "Default"]);