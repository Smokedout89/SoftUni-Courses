function extractText() {
    let itemNodes = document.querySelectorAll('ul#items li');
    let textArea = document.querySelector('#result');

    for (const node of itemNodes) {
        textArea.value += node.textContent + '\n';
    }
}