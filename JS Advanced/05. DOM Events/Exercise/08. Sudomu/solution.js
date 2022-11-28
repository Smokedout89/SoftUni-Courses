function solve() {
    const [quickCheckBtn, clearBtn] = Array.from(document.querySelectorAll('button'));
    let inputs = document.querySelectorAll('input');

    quickCheckBtn.style.cursor = 'pointer';
    clearBtn.style.cursor = 'pointer';

    const table = document.querySelector('table');
    const outputParagraph = document.querySelectorAll('#check p')[0];

    clearBtn.addEventListener('click', clear);
    quickCheckBtn.addEventListener('click', checkIfWon);

    function clear(event) {
        [...inputs].forEach(input => input.value = '');
        table.style.border = 'none';
        outputParagraph.textContent = '';
    }

    function checkIfWon(event) {
        let matrix = [
            [inputs[0].value, inputs[1].value, inputs[2].value],
            [inputs[3].value, inputs[4].value, inputs[5].value],
            [inputs[6].value, inputs[7].value, inputs[8].value]
        ];

        isSudomu = true;

        for (let i = 1; i < matrix.length; i++) {
            let row = matrix[i];
            let col = matrix.map(row => row[i]);

            if (col.length != [...new Set(col)].length || row.length != [...new Set(row)].length) {
                isSudomu = false;
                break;
            }
        }

        if (isSudomu) {
            table.style.border = '2px solid green';
            outputParagraph.style.color = 'green';
            outputParagraph.textContent = 'You solve it! Congratulations!';
        } else {
            table.style.border = '2px solid red';
            outputParagraph.style.color = 'red';
            outputParagraph.textContent = 'NOP! You are not done yet...';
        }
    }
}