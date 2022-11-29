function solve(area, vol, coordinates) {
    let objects = JSON.parse(coordinates); 
    return objects.map(calc);

    function calc(obj) {
        let areaObj = area.call(obj);
        let volumeObj = vol.call(obj);
        return { area: areaObj, volume: volumeObj};
    }
    
    function area() {
        return Math.abs(this.x * this.y);
    };
    
    function vol() {
        return Math.abs(this.x * this.y * this.z);
    };
}


solve(area, vol, `[
{"x":"1","y":"2","z":"10"},
{"x":"7","y":"7","z":"10"},
{"x":"5","y":"2","z":"10"}
]`)

solve(area, vol, `[
{"x":"10","y":"-22","z":"10"},
{"x":"47","y":"7","z":"-5"},
{"x":"55","y":"8","z":"0"},
{"x":"100","y":"100","z":"100"},
{"x":"55","y":"80","z":"250"}
]`)