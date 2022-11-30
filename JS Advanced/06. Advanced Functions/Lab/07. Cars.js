function solve(input) {
    let obj = {};

    for (const type of input) {
        let args = type.split(' ');
        let [command, name, key, value] = args;

        if (command === 'create' && args.length === 2) {
            createObj(name);
        } else if (command === 'create' && args.length > 2) {
            createObjWithParent(name, value);
        } else if (command === 'set') {
            obj[name][key] = value;
        } else {
            console.log(print(name).join(','));
        }
    }

    function createObj(name) {
        obj[name] = {};
    }

    function createObjWithParent(name, parentName) {
        createObj(name);
        obj[name].parent = parentName;
    }

    function print(name) {
        let current = obj[name];
        let result = [];

        for (const key of Object.keys(current).filter(o => o !== 'parent')) {
            result.push(`${key}:${current[key]}`);
        }

        if (current.hasOwnProperty('parent')) {
            print(current.parent).forEach(e => {
                result.push(e);
            });
        }

        return result;
    }
}

solve([
    'create c1',
    'create c2 inherit c1',
    'set c1 color red',
    'set c2 model new',
    'print c1',
    'print c2'
])