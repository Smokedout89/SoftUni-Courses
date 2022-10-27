function uppercase(string){
    string = string.toUpperCase();
    let regex = /[A-Za-z0-9]+/g;
    let words = string.match(regex);

    console.log(words.join(', '));
}

uppercase('Hi, how are you?');
uppercase('hello');