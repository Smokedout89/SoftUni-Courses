window.addEventListener("load", solve);

function solve() {
    const productType = document.getElementById('type-product');
    const clientDescription = document.getElementById('description');
    const clientName = document.getElementById('client-name');
    const clientPhone = document.getElementById('client-phone');

    const receivedOrders = document.getElementById(`received-orders`);
    const completedOrders = document.getElementById(`completed-orders`);

    const submitBtn = document.querySelector(`#right form button`);
    const clearBtn = document.querySelector(`#completed-orders button`);

    submitBtn.addEventListener('click', submitRepair);
    clearBtn.addEventListener('click', clear);

    function submitRepair(e) {
        e.preventDefault();

        const product = productType.value;
        const description = clientDescription.value;
        const name = clientName.value;
        const phone = clientPhone.value;

        if (description === '' || name === '' || phone === '') {
            return;
        }

        let divElement = document.createElement(`div`);
        divElement.className = `container`;

        divElement.innerHTML =
            `<h2>Product type for repair: ${product}</h2>
             <h3>Client information: ${name}, ${phone}</h3>
             <h4>Description of the problem: ${description}</h4>
             <button class="start-btn">Start Repair</button>
             <button class="finish-btn" disabled>Finish Repair</button>`

        const startBtn = divElement.querySelector('.start-btn');
        const finishBtn = divElement.querySelector('.finish-btn');

        startBtn.addEventListener('click', startRepair);
        finishBtn.addEventListener('click', moveToCompleted);

        receivedOrders.appendChild(divElement);

        clientDescription.value = '';
        clientName.value = '';
        clientPhone.value = '';
    }

    function startRepair(e) {
        e.currentTarget.disabled = true;

        e.currentTarget.parentNode.querySelector('.finish-btn').disabled = false;
    }

    function moveToCompleted(e) {
        let divElement = e.currentTarget.parentNode;

        e.currentTarget.remove();
        divElement.querySelector('.start-btn').remove();

        completedOrders.appendChild(divElement);
    }

    function clear() {
        let divElements = Array.from(document.querySelectorAll('#completed-orders div'));
        divElements.forEach(e => e.remove());
    }
}