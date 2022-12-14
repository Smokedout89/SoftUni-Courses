function validate() {
    const emailEl = document.getElementById('email');
    let pattern = new RegExp('^[a-z]+@[a-z]+\\.[a-z]+');

    emailEl.addEventListener('change', () => {
        if (pattern.test(emailEl.value)) {
            emailEl.classList.remove('error');
        } else {
            emailEl.classList.add('error');
        }
    });
}