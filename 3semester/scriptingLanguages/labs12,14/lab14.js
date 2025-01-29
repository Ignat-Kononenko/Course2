class Sudoku {
    constructor() {
        this.initialBoard = Array.from({ length: 9 }, () => Array(9).fill(0));
        this.initBoard = Array.from({ length: 9 }, () => Array(9).fill(0));
        this.board = this.cloneBoard(this.initialBoard);
    }

    cloneBoard(board) {
        return board.map(row => [...row]);
    }

    printBoard() {
        const boardElement = document.getElementById('board');
        boardElement.innerHTML = '';
        this.board.forEach((row, rowIndex) => {
            row.forEach((num, colIndex) => {
                const cell = document.createElement('div');
                cell.classList.add('cell');
                cell.contentEditable = true;
                cell.textContent = num !== 0 ? num : '';
                cell.id = `cell-${rowIndex}-${colIndex}`;

                cell.addEventListener('input', (e) => {
                    const value = e.target.textContent;
                    if (this.isValidNumber(value)) {
                        this.board[rowIndex][colIndex] = Number(value);
                    } else {
                        e.target.textContent = '';
                        this.board[rowIndex][colIndex] = 0;
                    }
                });

                boardElement.append(cell);
            });
        });
    }

    isValidNumber(value) {
        return /^[1-9]$/.test(value);
    }

    resetBoard() {
        this.board = this.cloneBoard(this.initialBoard);
        this.printBoard();
    }

    checkRow(row) {
        const seen = new Set();
        for (let col = 0; col < 9; col++) {
            const num = this.board[row][col];
            if (num !== 0) {
                if (seen.has(num)) {
                    this.highlightErrorRow(row);
                    return false;
                }
                seen.add(num);
            }
        }
        return true;
    }

    checkColumn(col) {
        const seen = new Set();
        for (let row = 0; row < 9; row++) {
            const num = this.board[row][col];
            if (num !== 0) {
                if (seen.has(num)) {
                    this.highlightErrorColumn(col);
                    return false;
                }
                seen.add(num);
            }
        }
        return true;
    }

    checkSquare(row, col) {
        const seen = new Set();
        const startRow = row - (row % 3);
        const startCol = col - (col % 3);
        for (let i = 0; i < 3; i++) {
            for (let j = 0; j < 3; j++) {
                const num = this.board[startRow + i][startCol + j];
                if (num !== 0) {
                    if (seen.has(num)) {
                        this.highlightErrorSquare(startRow, startCol);
                        return false;
                    }
                    seen.add(num);
                }
            }
        }
        return true;
    }

    checkBoard() {
        let valid = true;
        for (let i = 0; i < 9; i++) {
            if (!this.checkRow(i))
                valid = false;
            if (!this.checkColumn(i))
                valid = false;
        }
        for (let row = 0; row < 9; row += 3) {
            for (let col = 0; col < 9; col += 3) {
                if (!this.checkSquare(row, col))
                    valid = false;
            }
        }
        if (valid) 
            this.highlightBoard();
        return valid;
    }

    highlightErrorRow(row) {
        for (let col = 0; col < 9; col++) {
            document.getElementById(`cell-${row}-${col}`).style.backgroundColor = 'red';
            
        }
    }

    highlightErrorColumn(col) {
        for (let row = 0; row < 9; row++) {
            document.getElementById(`cell-${row}-${col}`).style.backgroundColor = 'red';
        }
    }

    highlightErrorSquare(startRow, startCol) {
        for (let i = 0; i < 3; i++) {
            for (let j = 0; j < 3; j++) {
                document.getElementById(`cell-${startRow + i}-${startCol + j}`).style.backgroundColor = 'red';
            }
        }
    }

    highlightBoard() {
        const cells = document.querySelectorAll('.cell');
        cells.forEach(cell => cell.style.backgroundColor = 'yellow');
    }

    generateSolution() {
        this.initialBoard = this.cloneBoard(this.board);
        const fillBoard = (row, col) => {
            if (col === 9) {
                col = 0;
                row++;
                if (row === 9)
                    return true;
            }

            if (this.initialBoard[row][col] !== 0) {
                return fillBoard(row, col + 1);
            }

            const numbers = [1, 2, 3, 4, 5, 6, 7, 8, 9].sort(() => Math.random() - 0.5);
            for (const num of numbers) {
                if (this.isValidPlacement(row, col, num)) {
                    this.board[row][col] = num;
                    if (fillBoard(row, col + 1))
                        return true;
                    this.board[row][col] = 0;
                }
            }
            return false;
        };

        this.initialBoard = this.cloneBoard(this.board);
        fillBoard(0, 0);
        this.printBoard();
        this.initialBoard = Array.from({ length: 9 }, () => Array(9).fill(0));
    }

    generatePuzzle(difficulty = 40) {
        this.board = this.cloneBoard(this.initialBoard);
        this.generateSolution();
        let cellsToRemove = difficulty;
        while (cellsToRemove > 0) {
            const row = Math.floor(Math.random() * 9);
            const col = Math.floor(Math.random() * 9);
            if (this.board[row][col] !== 0 && this.initialBoard[row][col] === 0) {
                this.board[row][col] = 0;
                cellsToRemove--;
            }
        }

        this.printBoard();

    }

    isValidPlacement(row, col, num) {
        for (let i = 0; i < 9; i++) {
            if (this.board[row][i] === num || this.board[i][col] === num)
                return false;
        }
        const startRow = row - (row % 3);
        const startCol = col - (col % 3);
        for (let i = 0; i < 3; i++) {
            for (let j = 0; j < 3; j++) {
                if (this.board[startRow + i][startCol + j] === num)
                    return false;
            }
        }
        return true;
    }
}

const sudoku = new Sudoku();

function generateBoard() {
    sudoku.generatePuzzle();
}

function checkBoard() {
    sudoku.checkBoard();
}

function generateSolution() {
    
    sudoku.generateSolution();
    sudoku.printBoard();
}
