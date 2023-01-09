window.addEventListener("load", solve);

function solve() {
    const makeField = document.querySelector('#make');
    const modelField = document.querySelector('#model');
    const yearField = document.querySelector('#year');
    const fuelField = document.querySelector('#fuel');
    const originalCostField = document.querySelector('#original-cost');
    const sellingPriceField = document.querySelector('#selling-price');

    const tBodyElement = document.querySelector('#table-body');
    const ulElement = document.querySelector('#cars-list');
    const publishBtn = document.querySelector('#publish');
    const profitElement = document.querySelector('#profit');
    let totalProfit = 0;
    publishBtn.addEventListener('click', publishCar)

    function publishCar(e) {
        e.preventDefault();

        const make = makeField.value;
        const model = modelField.value;
        const year = yearField.value;
        const fuel = fuelField.value;
        const originalCost = originalCostField.value;
        const sellingPrice = sellingPriceField.value;

        if (make === '' || model === '' || year === ''
            || fuel === '' || originalCost === '' || sellingPrice === '') {
            return;
        }

        if (originalCost > sellingPrice) {
            return;
        }

        const trElement = document.createElement('tr');
        trElement.className = 'row';

        trElement.innerHTML =
            `<td>${make}</td>
            <td>${model}</td>
            <td>${year}</td>
            <td>${fuel}</td>
            <td>${originalCost}</td>
            <td>${sellingPrice}</td>
            <td>
                <button class="action-btn edit">Edit</button>
                <button class="action-btn sell">Sell</button>
            </td>`;

        const editBtn = trElement.querySelector('.edit');
        const sellBtn = trElement.querySelector('.sell');

        editBtn.addEventListener('click', edit);
        sellBtn.addEventListener('click', sell);

        tBodyElement.appendChild(trElement);

        makeField.value = '';
        modelField.value = '';
        yearField.value = '';
        fuelField.value = '';
        originalCostField.value = '';
        sellingPriceField.value = '';

        function edit() {
            makeField.value = make;
            modelField.value = model;
            yearField.value = year;
            fuelField.value = fuel;
            originalCostField.value = originalCost;
            sellingPriceField.value = sellingPrice;

            trElement.remove();
        }

        function sell() {
            const liElement = document.createElement(`li`);
            liElement.className = 'each-list';

            const currDifference = sellingPrice - originalCost;

            liElement.innerHTML =
                `<span>${make} ${model}</span>
                <span>${year}</span>
                <span>${currDifference}</span>`;

            trElement.remove();
            ulElement.appendChild(liElement);

            totalProfit += currDifference;

            profitElement.textContent = totalProfit.toFixed(2);
        }
    }
}