function validate() {
    let input = document.getElementById('email');
    input.addEventListener('change', error)

    function error(event) {
        if (!(/\w+@\w+\.\w+/.test(input.value))) {
            event.target.classList.add('error');
        }
        else {
            event.target.classList.remove('error');
        }
    }
}