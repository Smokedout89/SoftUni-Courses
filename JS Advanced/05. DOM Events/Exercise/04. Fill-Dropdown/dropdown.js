function addItem() {
    const menu = document.getElementById('menu');
    let itemText = document.getElementById('newItemText');
    let itemValue = document.getElementById('newItemValue');

    let optionElement = document.createElement('option');
    optionElement.textContent = itemText.value;
    optionElement.value = itemValue.value;
    menu.appendChild(optionElement);

    itemText.value = '';
    itemValue.value = '';
}