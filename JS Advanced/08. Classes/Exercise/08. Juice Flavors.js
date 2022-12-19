function juiceFlavors(arr) {
    let juices = {};
    let bottles = {};

    for (const juice of arr) {
        let [flavor, qty] = juice.split(' => ');

        if (!juices[flavor]) {
            juices[flavor] = 0;
        }

        juices[flavor] += Number(qty);
        createBottle(flavor);
    }

    function createBottle(flavor) {
        if (juices[flavor] >= 1000) {
            if (!bottles[flavor]) {
                bottles[flavor] = 0;
            }

            let numOfBottles = Math.floor(juices[flavor] / 1000);
            bottles[flavor] += numOfBottles;
            juices[flavor] -= (numOfBottles * 1000)
        }
    }

    for (const flavor in bottles) {
        console.log(flavor + ' => ' + bottles[flavor]);
    }
}

juiceFlavors([
    'Orange => 2000',
    'Peach => 1432',
    'Banana => 450',
    'Peach => 600',
    'Strawberry => 549'])
juiceFlavors([
    'Kiwi => 234',
    'Pear => 2345',
    'Watermelon => 3456',
    'Kiwi => 4567',
    'Pear => 5678',
    'Watermelon => 6789'])