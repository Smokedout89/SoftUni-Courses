function orbit(array) {
    const rows = array[0];
    const cols = array[1];
    const starRow = array[2];
    const starCol = array[3];

    const fillValue = null;

    const matrix = new Array(rows).fill(fillValue).map(() => new Array(cols).fill(fillValue))
    matrix[starRow][starCol] = 1;

    let startRow = starRow - 1 < 0 ? starRow : starRow - 1;
    let startCol = starCol - 1 < 0 ? starCol : starCol - 1;
    let endRow = starRow + 1;
    let endCol = starCol + 1;

    for (let i = 2; i <= matrix.length; i++) {

        for (let row = startRow; row <= endRow; row++) {
            for (let col = startCol; col <= endCol; col++) {

                if (row < 0 || row >= matrix.length || col < 0 || col >= matrix[row].length) {
                    continue;
                }

                if (matrix[row][col] === fillValue) {
                    matrix[row][col] = i;
                }
            }
        }

        startRow = startRow - 1 < 0 ? startRow : startRow - 1;
        startCol = startCol - 1 < 0 ? startCol : startCol - 1;

        endRow++;
        endCol++;
    }

    matrix.forEach(row => console.log(row.join(' ')));
}

orbit([4, 4, 0, 0])
orbit([5, 5, 2, 2])
orbit([3, 3, 2, 2])