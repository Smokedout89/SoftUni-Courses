function validate() {
    document.getElementById('company').addEventListener('change', () => {
        let companyInfo = document.getElementById('companyInfo');

        if (document.getElementById('company').checked == false) {
            companyInfo.style.display = 'none';
        } else {
            companyInfo.style.display = 'block';
        }
    });

    document.getElementById('submit').addEventListener('click', onClick);

    function onClick(event) {
        event.preventDefault();

        let invalidFields = [];

        let checkBox = document.querySelector('#company');

        let username = document.getElementById('username');
        let email = document.getElementById('email');
        let password = document.getElementById('password');
        let confirmedPassword = document.getElementById('confirm-password');
        let companyId = document.getElementById('companyNumber');

        let usernamePattern = /^[A-Za-z0-9]{3,20}$/;
        let emailPattern = /^.*@.*\..*$/;
        let passwordPattern = /^[\w]{5,15}$/;
        let companyPattern = /^[1-9][0-9]{3}$/;

        if (!usernamePattern.test(username.value)) {
            invalidFields.push(username);
        }

        if (!emailPattern.test(email.value)) {
            invalidFields.push(email);
        }

        if (!passwordPattern.test(password.value) || confirmedPassword.value !== password.value) {
            invalidFields.push(password);
            invalidFields.push(confirmedPassword);
        }

        if (checkBox.checked) {
            if (!companyPattern.test(companyId.value)) {
                invalidFields.push(companyId);
            }
        }

        invalidFields.forEach(field => field.style.borderColor = 'red');

        let isValid = document.getElementById('valid');

        !invalidFields.length ? isValid.style.display = 'block' : isValid.style.display = 'none';
    }
}