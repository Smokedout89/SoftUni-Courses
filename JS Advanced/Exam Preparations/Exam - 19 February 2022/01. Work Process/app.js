function solve() {
    const input = {
        firstName: document.querySelector('#fname'),
        lastName: document.querySelector('#lname'),
        email: document.querySelector('#email'),
        dob: document.querySelector('#birth'),
        position: document.querySelector('#position'),
        salary: document.querySelector('#salary')
    }

    const addWorkerBtn = document.querySelector('#add-worker');
    addWorkerBtn.addEventListener('click', addWorker);

    const tBody = document.querySelector('#tbody');
    let totalSalary = 0;

    function addWorker(e) {
        e.preventDefault();

        if (input.firstName.value === '' || input.lastName.value === '' || input.email.value === ''
        || input.dob.value === '' || input.position.value === '' || input.salary.value === '') {
            return;
        }
        
        const trElement = document.createElement('tr');
        trElement.appendChild(createElement('td', `${input.firstName.value}`));
        trElement.appendChild(createElement('td', `${input.lastName.value}`));
        trElement.appendChild(createElement('td', `${input.email.value}`));
        trElement.appendChild(createElement('td', `${input.dob.value}`));
        trElement.appendChild(createElement('td', `${input.position.value}`));
        trElement.appendChild(createElement('td', `${input.salary.value}`));
        const tdWithButtons = document.createElement(`td`);
        tdWithButtons.appendChild(createElement('button', 'Fired', 'fired'));
        tdWithButtons.appendChild(createElement('button', 'Edit', 'edit'));

        const firedBtn = tdWithButtons.querySelector('.fired')
        const editBtn = tdWithButtons.querySelector('.edit')
        firedBtn.addEventListener('click', fire);
        editBtn.addEventListener('click', edit)

        trElement.appendChild(tdWithButtons);
        tBody.appendChild(trElement);

        let currSum = Number(input.salary.value);
        totalSalary += currSum;
        document.getElementById('sum').textContent = totalSalary.toFixed(2);

        Object.values(input).forEach(v => v.value = '');

        function edit(e) {
            const parent = e.currentTarget.parentElement.parentElement.children;

            input.firstName.value = parent[0].textContent;
            input.lastName.value = parent[1].textContent;
            input.email.value = parent[2].textContent;
            input.dob.value = parent[3].textContent;
            input.position.value = parent[4].textContent;
            input.salary.value = parent[5].textContent;

            let currSum = Number(input.salary.value);
            totalSalary -= currSum;
            document.getElementById('sum').textContent = totalSalary.toFixed(2);

            e.currentTarget.parentElement.parentElement.remove();
        }

        function fire(e) {
            const parent = e.currentTarget.parentElement.parentElement.children;
            input.salary.value = parent[5].textContent;

            let currSum = Number(input.salary.value);
            totalSalary -= currSum;
            document.getElementById('sum').textContent = totalSalary.toFixed(2);
            input.salary.value = '';
            e.currentTarget.parentElement.parentElement.remove();
        }
    }

    function createElement(type, content, className) {
        const element = document.createElement(type);
        element.textContent = content;
        if (className) {
            element.className = className;
        }

        return element;
    }
}
solve()