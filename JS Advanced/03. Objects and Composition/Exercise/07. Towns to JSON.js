function townsToJson(arr) {
    let result = [];

    class Town {
        constructor(town, latitude, longitude) {
            this.Town = town;
            this.Latitude = Number(latitude);
            this.Longitude = Number(longitude);
        }
    }

    for (let i = 1; i < arr.length; i++) {
        const tokens = arr[i].split('|').map(t => t.trim()).filter(l => l.length != 0);
        const townName = tokens[0];
        const latitude = Number(tokens[1]).toFixed(2);
        const longitude = Number(tokens[2]).toFixed(2);
        
        const town = new Town(townName, latitude, longitude);
        result.push(town);
    }
    
    console.log(JSON.stringify(result));
}

townsToJson([
    '| Town | Latitude | Longitude |',
    '| Sofia | 42.696552 | 23.32601 |',
    '| Beijing | 39.913818 | 116.363625 |'])
townsToJson([
    '| Town | Latitude | Longitude |',
    '| Veliko Turnovo | 43.0757 | 25.6172 |',
    '| Monatevideo | 34.50 | 56.11 |'])