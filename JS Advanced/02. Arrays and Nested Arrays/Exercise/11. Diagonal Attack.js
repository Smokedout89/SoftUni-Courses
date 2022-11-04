function diagonalAttack(array) {
    const matrix = [];

    for (let i = 0; i < array.length; i++) {
        let element = array[i];
        matrix[i] = element.split(' ').map(Number);
    }

    let mainDiagonal = 0;
    let secondaryDiagonal = 0;
    let secondDiagonalIndex = matrix.length - 1;

    for (let i = 0; i < matrix.length; i++) {
        mainDiagonal += matrix[i][i];
        secondaryDiagonal += matrix[secondDiagonalIndex--][i];
    }

    if (mainDiagonal === secondaryDiagonal) {
        changeValues();
    }

    matrix.forEach(row => console.log(row.join(' ')));

    function changeValues() {
        for (let row = 0; row < matrix.length; row++) {
            for (let col = 0; col < matrix[row].length; col++) {
                if (row === col || (row + col) == (matrix[row].length - 1)) {
                    continue;
                }

                matrix[row][col] = mainDiagonal;
            }
        }
    }
}

diagonalAttack([
    '5 3 12 3 1',
    '11 4 23 2 5',
    '101 12 3 21 10',
    '1 4 5 2 2',
    '5 22 33 11 1']
)
diagonalAttack([
    '1 1 1',
    '1 1 1',
    '1 1 0']
)