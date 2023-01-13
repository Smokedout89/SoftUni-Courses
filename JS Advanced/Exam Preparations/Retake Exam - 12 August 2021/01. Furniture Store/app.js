window.addEventListener('load', solve);

function solve() {
    const input = {
        model: document.querySelector('#model'),
        year: document.querySelector('#year'),
        description: document.querySelector('#description'),
        price: document.querySelector('#price')
    }

    const furnitureList = document.querySelector('#furniture-list');
    const priceElement = document.querySelector('.total-price');
    let totalPrice = 0;

    const addBtn = document.querySelector('#add');
    addBtn.addEventListener('click', moveToList);

    function moveToList(e) {
        e.preventDefault();

        const model = input.model.value;
        const year = input.year.value;
        const description = input.description.value;
        const price = input.price.value;

        if (model === '' || description === '' || year <= 0 || price <= 0) {
            return;
        }

        const firstTr = document.createElement('tr');
        const secondTr = document.createElement('tr');
        firstTr.className = 'info';
        secondTr.className = 'hide';

        const fixedPrice = Number(price).toFixed(2);

        firstTr.appendChild(createElement('td', `${model}`));
        firstTr.appendChild(createElement('td', `${fixedPrice}`));
        const tdOne = document.createElement('td');
        tdOne.appendChild(createElement('button', 'More Info', 'moreBtn'));
        tdOne.appendChild(createElement('button', 'Buy it', 'buyBtn'));
        firstTr.appendChild(tdOne);

        secondTr.appendChild(createElement('td', `Year: ${year}`));
        const tdTwo = document.createElement('td');
        tdTwo.colSpan = 3;
        tdTwo.textContent = `Description: ${description}`;
        secondTr.appendChild(tdTwo);

        const moreBtn = firstTr.querySelector('.moreBtn');
        const buyBtn = firstTr.querySelector('.buyBtn');

        moreBtn.addEventListener('click', showMore);
        buyBtn.addEventListener('click', buyFurniture);
        
        furnitureList.appendChild(firstTr);
        furnitureList.appendChild(secondTr);

        Object.values(input).forEach(i =>  i.value = '');
        
        function showMore(e) {
            if (e.currentTarget.textContent === 'Less Info') {
                e.currentTarget.textContent = 'More Info';
                secondTr.style.display = 'none';
            } else {
                e.currentTarget.textContent = 'Less Info';
                secondTr.style.display = 'contents';
            }
        }
        
        function buyFurniture(e) {
            totalPrice += Number(price);
            priceElement.textContent = totalPrice.toFixed(2);

            e.currentTarget.parentElement.parentElement.nextSibling.remove();
            e.currentTarget.parentElement.parentElement.remove();
        }
    }

    function createElement(type, context, className) {
        const element = document.createElement(type);
        element.textContent = context;
        if (className) {
            element.className = className;
        }

        return element;
    }
}