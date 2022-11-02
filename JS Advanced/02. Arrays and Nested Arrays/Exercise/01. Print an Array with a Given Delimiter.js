function printArray(array, delimiter) {
    console.log(array.join(`${delimiter}`));
}

printArray(["One", "Two", "Three", "Four", "Five"], "-");
printArray(["How about no?", "I", "will", "not", "do", "it!"], "_");