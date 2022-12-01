function argumentInfo() {
    let input = Array.from(arguments);
    let types = {};

    for (const str of input) {
        const type = typeof str;
        console.log(`${type}: ${str}`)

        if (types[type] === undefined) {
            types[type] = 0;
        }

        types[type]++;
    }

    const result = Object.entries(types).sort((a,b) => b[1] - a[1]);

    for (const [type, count] of result) {
        console.log(`${type} = ${count}`);
    }
}

argumentInfo('cat', 42, function () { console.log('Hello world!'); })
argumentInfo({ name: 'bob' }, 3.333, 9.999)