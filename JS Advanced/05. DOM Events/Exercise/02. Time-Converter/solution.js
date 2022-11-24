function attachEventsListeners() {
    let buttons = document.querySelectorAll('div input:nth-child(3)');
    let days = document.getElementById('days');
    let hours = document.getElementById('hours');
    let minutes = document.getElementById('minutes');
    let seconds = document.getElementById('seconds');

    for (const button of buttons) {
        button.addEventListener('click', onConvert);
    }

    let ratios = {
        days: 1,
        hours: 24,
        minutes: 1440,
        seconds: 86400
    }

    function onConvert(event) {
        let input = event.target.parentElement.querySelector('input[type="text"]');
        let time = convertTime(Number(input.value), input.id)

        days.value = time.days;
        hours.value = time.hours;
        minutes.value = time.minutes;
        seconds.value = time.seconds;
    }

    function convertTime(value, unit) {
        let days = value / ratios[unit];
        return {
            days: days,
            hours: days * ratios.hours,
            minutes: days * ratios.minutes,
            seconds: days * ratios.seconds
        };
    }
}