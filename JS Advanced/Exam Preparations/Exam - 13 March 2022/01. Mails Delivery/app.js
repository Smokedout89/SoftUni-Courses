function solve() {
    const recipient = document.getElementById('recipientName');
    const title = document.getElementById('title');
    const message = document.getElementById('message');
    const addToListBtn = document.getElementById('add');
    const resetBtn = document.getElementById('reset');

    const listMails = document.getElementById('list');
    const sentMails = document.querySelector('.sent-list');
    const deletedMails = document.querySelector('.delete-list');

    addToListBtn.addEventListener('click', addToList);
    resetBtn.addEventListener('click', reset);

    function addToList(e) {
        e.preventDefault();

        if (recipient.value === '' || title.value === '' || message.value === '') {
            return;
        }

        const recipientV = recipient.value;
        const titleV = title.value;
        const messageV = message.value;

        const liElement = document.createElement('li');

        liElement.innerHTML =
            `<h4>Title: ${titleV}</h4>
            <h4>Recipient Name: ${recipientV}</h4>
            <span>${messageV}</span>
            <div id="list-action">
            <button type="submit" id="send">Send</button>
            <button type="delete" id="delete">Delete</button>
            </div>`;

        const sendBtn = liElement.querySelector('#send');
        const deleteBtn = liElement.querySelector('#delete');
        sendBtn.addEventListener('click', sendMail);
        deleteBtn.addEventListener('click', deleteMail);

        listMails.appendChild(liElement);
        recipient.value = ''
        title.value = ''
        message.value = '';

        function sendMail() {
            liElement.remove();

            const sentLiElement = document.createElement('li');
            sentLiElement.innerHTML =
                `<span>To: ${recipientV}</span>
                <span>Title: ${titleV}</span>
                <div class="btn">
                <button type="submit" class="delete">Delete</button>
                </div>`

            const deleteBtn = sentLiElement.querySelector('.delete');

            deleteBtn.addEventListener('click', deleteMail);
            sentMails.appendChild(sentLiElement);
        }

        function deleteMail(e) {
            e.currentTarget.parentElement.parentElement.remove();

            const deletedEl = document.createElement('li');
            deletedEl.innerHTML =
                `<span>To: ${recipientV}</span>
                  <span>Title: ${titleV}</span>`

            deletedMails.appendChild(deletedEl);
        }
    }

    function reset(e) {
        e.preventDefault();

        recipient.value = '';
        title.value = '';
        message.value = '';
    }
}

solve()