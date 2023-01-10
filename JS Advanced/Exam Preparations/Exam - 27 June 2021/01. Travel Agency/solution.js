window.addEventListener('load', solution);

function solution() {
    const input = {
        fullName: document.querySelector('#fname'),
        email: document.querySelector('#email'),
        number: document.querySelector('#phone'),
        address: document.querySelector('#address'),
        code: document.querySelector('#code')
    }

    const buttons = {
        submitBtn: document.querySelector('#submitBTN'),
        editBtn: document.querySelector('#editBTN'),
        continueBtn: document.querySelector('#continueBTN')
    }

    const infoPreview = document.querySelector('#infoPreview');

    buttons.submitBtn.addEventListener('click', submitReservation);

    function submitReservation() {
        if (input.fullName.value === '' || input.email.value === '') {
            return;
        }

        const fName = input.fullName.value;
        const email = input.email.value;
        const phone = input.number.value;
        const address = input.address.value;
        const code = input.code.value;

        infoPreview.appendChild(createElement(`li`, `Full Name: ${fName}`));
        infoPreview.appendChild(createElement(`li`, `Email: ${email}`));
        infoPreview.appendChild(createElement(`li`, `Phone Number: ${phone}`));
        infoPreview.appendChild(createElement(`li`, `Address: ${address}`));
        infoPreview.appendChild(createElement(`li`, `Postal Code: ${code}`));

        buttons.submitBtn.disabled = true;
        buttons.editBtn.disabled = false;
        buttons.continueBtn.disabled = false;

        buttons.editBtn.addEventListener('click', edit)
        buttons.continueBtn.addEventListener('click', completeReservation);

        Object.values(input).forEach(v => v.value = '');

        function edit() {
            input.fullName.value = fName;
            input.email.value = email;
            input.number.value = phone;
            input.address.value = address;
            input.code.value = code;

            buttons.submitBtn.disabled = false;
            buttons.editBtn.disabled = true;
            buttons.continueBtn.disabled = true;

            const children = Array.from(infoPreview.childNodes);

            for (const child of children) {
                infoPreview.removeChild(child);
            }
        }
        
        function completeReservation() {
            const blockEl = document.querySelector(`#block`);
            blockEl.innerHTML = '';

            const h3 = createElement('h3', `Thank you for your reservation!`)
            blockEl.appendChild(h3);
        }
    }

    function createElement(type, context, className) {
        const element = document.createElement(type);
        if (context) {
            element.textContent = context;
        }
        if (className) {
            element.className = className;
        }

        return element;
    }
}