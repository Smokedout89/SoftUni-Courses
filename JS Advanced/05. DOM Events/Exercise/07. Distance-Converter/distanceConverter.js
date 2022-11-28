function attachEventsListeners() {
    const button = document.getElementById('convert');
    button.addEventListener('click', convert);

    let metricUnits = {
        km: 1000,
        m: 1,
        cm: 0.01,
        mm: 0.001,
        mi: 1609.34,
        yrd: 0.9144,
        ft: 0.3048,
        in: 0.0254
    }   

    function convert(event) {
        let fromValue = document.getElementById('inputUnits').value;
        let toValue = document.getElementById('outputUnits').value;

        let inputDistance = Number(document.getElementById('inputDistance').value);
        let outputDistance = document.getElementById('outputDistance');

        let valueInMetres = inputDistance * metricUnits[fromValue];
        let convertedValue = valueInMetres / metricUnits[toValue];

        outputDistance.value = convertedValue;
    }
}