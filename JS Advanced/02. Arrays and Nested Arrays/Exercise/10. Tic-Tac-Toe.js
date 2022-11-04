function TicTacToe(moves) {
    const board = [
        [false, false, false],
        [false, false, false],
        [false, false, false],
    ];

    let player = 'X';

    for (let i = 0; i < moves.length; i++) {
        const move = moves[i].split(' ');
        const x = move[0];
        const y = move[1];

        if (board[x][y] !== false) {
            console.log('This place is already taken. Please choose another!');
            continue;
        }

        board[x][y] = player;

        const winner = checkForWinner();

        if (winner !== null) {
            console.log(`Player ${winner} wins!`);
            break;
        }

        const finished = checkForFreeSpace();

        if (!finished) {
            console.log('The game ended! Nobody wins :(');
            break;
        }

        player = player === 'X' ? 'O' : 'X';
    }

    board.forEach(row => { console.log(row.join('\t')); });

    function checkForWinner() {
        if (board[0][0] === board[0][1] && board[0][1] === board[0][2] && board[0][2] === player) { return player; }
        if (board[1][0] === board[1][1] && board[1][1] === board[1][2] && board[1][2] === player) { return player; }
        if (board[2][0] === board[2][1] && board[2][1] === board[2][2] && board[2][2] === player) { return player; }

        if (board[0][0] === board[1][0] && board[1][0] === board[2][0] && board[2][0] === player) { return player; }
        if (board[0][1] === board[1][1] && board[1][1] === board[2][1] && board[2][1] === player) { return player; }
        if (board[0][2] === board[1][2] && board[1][2] === board[2][2] && board[2][2] === player) { return player; }

        if (board[0][0] === board[1][1] && board[1][1] === board[2][2] && board[2][2] === player) { return player; }
        if (board[0][2] === board[1][1] && board[1][1] === board[2][0] && board[2][0] === player) { return player; }

        return null;
    }

    function checkForFreeSpace() {
        let finished = false;
        for (let row = 0; row < board.length; row++) {
            if (board[row].includes(false)) {
                finished = true;
            }
        }

        return finished;
    }
}

TicTacToe(["0 1", "0 0", "0 2", "2 0", "1 0", "1 1", "1 2", "2 2", "2 1", "0 0"]);
TicTacToe(["0 0", "0 0", "1 1", "0 1", "1 2", "0 2", "2 2", "1 2", "2 2", "2 1"]);
TicTacToe(["0 1", "0 0", "0 2", "2 0", "1 0", "1 2", "1 1", "2 1", "2 2", "0 0"]);