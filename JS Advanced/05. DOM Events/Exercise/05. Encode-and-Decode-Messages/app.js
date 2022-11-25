function encodeAndDecodeMessages() {
    let textAreas = document.querySelectorAll('textarea');
    let buttons = document.querySelectorAll('button');

    buttons[0].addEventListener('click', encode);
    buttons[1].addEventListener('click', decode);

    function encode(event) {
        let encodedMsg = '';
        let inputMsg = textAreas[0].value;

        for (let i = 0; i < inputMsg.length; i++) {
            encodedMsg += String.fromCharCode(inputMsg[i].charCodeAt(0) + 1);
        }

        textAreas[1].value = encodedMsg;
        textAreas[0].value = '';
    }

    function decode(event) {
        let decodedMsg = '';
        let inputMsg = textAreas[1].value;

        for (let i = 0; i < inputMsg.length; i++) {
            decodedMsg += String.fromCharCode(inputMsg[i].charCodeAt(0) - 1);
        }

        textAreas[1].value = decodedMsg;
    }
}