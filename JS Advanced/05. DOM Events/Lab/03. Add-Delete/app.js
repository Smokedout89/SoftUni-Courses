function addItem() {
    let element = document.getElementById('newItemText');
    let list = document.getElementById('items');

    let liElement = document.createElement('li');
    liElement.textContent = element.value;

    const deleteBtn = document.createElement('a');
    deleteBtn.textContent = '[Delete]';
    deleteBtn.href = '#';
    liElement.appendChild(deleteBtn);

    deleteBtn.addEventListener('click', onDelete);

    list.appendChild(liElement);
    element.value = '';

    function onDelete(event) {
        event.target.parentElement.remove();
    }
}