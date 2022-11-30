function solve(arr) {
    let result = {
        list: [],

        add(text) {
            this.list.push(text);
        },
        remove(text) {
            this.list = this.list.filter(t => t !== text);
        },
        print() {
            console.log(this.list.join(','));
        }
    };

    for (const line of arr) {
        let [command, text] = line.split(' ');

        switch (command) {
            case 'add': result.add(text); break;
            case 'remove': result.remove(text); break;
            case 'print': result.print(); break;
        }
    }
}

solve(['add hello', 'add again', 'remove hello', 'add again', 'print']);
solve(['add pesho', 'add george', 'add peter', 'remove peter', 'print']);