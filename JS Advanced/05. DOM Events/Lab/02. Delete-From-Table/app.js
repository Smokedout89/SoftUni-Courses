function deleteByEmail() {
    let mails = document.querySelectorAll('#customers tr td:nth-child(2)');
    let result = document.getElementById('result');
    let email = document.getElementsByName('email')[0].value;

    for (const mail of mails) {
       if (mail.textContent === email) {
        let row = mail.parentNode;
        row.parentNode.removeChild(row);
        result.textContent = 'Deleted.';
        return;
       }
    }

    result.textContent = 'Not found.';
}