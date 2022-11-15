function colorize() {
    let elements = document.querySelectorAll('tr:nth-of-type(even)');
    
    for (const element of elements) {
        element.style.backgroundColor = 'teal';
    }
}