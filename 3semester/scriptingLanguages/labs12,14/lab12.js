class Sudoku {
    constructor() {
        this.initialBoard = Array.from({ length: 9 }, () => Array(9).fill(0)); 
        this.board = this.cloneBoard(this.initialBoard);
    }

    
    cloneBoard(board) {                                             //передаем матрицу
        return board.map(row => [...row]);                                                                      // Копируем каждый ряд массива, чтобы не модифицировать оригинал 
    }
    printBoard() {
        this.board.forEach(row => console.log(row.join("  "))); 
    }
    resetBoard() {
        this.board = this.cloneBoard(this.initialBoard);  // Сбрасываем поле до начального состояния
    }

    // проверка строки на наличие дубликатов
    checkRow(row) {
        const seen = new Set();  
        for (let col = 0; col < 9; col++) {
            const num = this.board[row][col];  // Читаем число в текущей клетке
            if (num !== 0) {  // Если клетка не пуста
                if (seen.has(num)) {
                    console.log(`Ошибка в строке ${row + 1}`);
                    return false;
                }
                seen.add(num);
            }
        }
        return true;
    }

    // проверка столбца на наличие дубликатов
    checkColumn(col) {
        const seen = new Set();
        for (let row = 0; row < 9; row++) {
            const num = this.board[row][col];
            if (num !== 0) {
                if (seen.has(num)) {
                    console.log(`Ошибка в столбце ${col + 1}`);
                    return false;
                }
                seen.add(num);
            }
        }
        return true;
    }

    // проверка квадрата 3x3 на наличие дубликатов
    checkSquare(row, col) {
        const seen = new Set();
        const startRow = row - (row % 3);
        const startCol = col - (col % 3);
        for (let i = 0; i < 3; i++) { 
            for (let j = 0; j < 3; j++) {
                const num = this.board[startRow + i][startCol + j];  // где начинается квадрат
                if (num !== 0) {
                    if (seen.has(num)) {
                        console.log(`Ошибка в квадрате (${startRow + 1}, ${startCol + 1})`);
                        return false;
                    }
                    seen.add(num);
                }
            }
        }
        return true;
    }

    checkBoard() {
        let valid = true;  // Переменная, которая отслеживает наличие ошибок
        for (let i = 0; i < 9; i++) {
            
            if (!this.checkRow(i)) valid = false;
            
            if (!this.checkColumn(i)) valid = false;
        }
        // Проверяем все квадраты 3x3
        for (let row = 0; row < 9; row += 3) {
            for (let col = 0; col < 9; col += 3) {
                if (!this.checkSquare(row, col)) valid = false;
            }
        }
        return valid;
    }

    //Метод для генерации правильного игрового поля
    generateSolution() {
        const fillBoard = (row, col) => {
            if (col === 9) {  // Если мы достигли конца строки
                col = 0;
                row++;  // Переходим к следующей строке
                if (row === 9) return true;  // Если все строки заполнены
            }

            const numbers = [1, 2, 3, 4, 5, 6, 7, 8, 9].sort(() => Math.random() - 0.5); 

            for (const num of numbers) {  // Пробуем числа в случайном порядке
                if (this.isValidPlacement(row, col, num)) {  // Если число можно поставить в клетку
                    this.board[row][col] = num;  // Записываем число в клетку
                    if (fillBoard(row, col + 1)) return true;  // Рекурсивно заполняем следующую клетку
                    this.board[row][col] = 0;  // Если не получилось, откатываем изменения
                }
            }
            return false;
        };
        this.resetBoard();  // Сбрасываем поле перед генерацией
        fillBoard(0, 0);  // Запускаем процесс заполнения поля с первой клетки
    }
    
    generateBoardWithErrors() {
         this.generateSolution(); // Генерируем корректное решение
         // Добавляем ошибки для проверки
        this.board[0][0] = this.board[0][1]; // Повтор в строке
         this.board[1][1] = this.board[2][1]; // Повтор в столбце
    }

    // Метод для проверки, может ли число быть поставлено на определенную позицию
    isValidPlacement(row, col, num) {
        for (let i = 0; i < 9; i++) {
            // Проверяем строку и столбец
            if (this.board[row][i] === num || this.board[i][col] === num) return false;
        }

        const startRow = row - (row % 3);
        const startCol = col - (col % 3);
        for (let i = 0; i < 3; i++) {  // Проверяем квадрат 3x3
            for (let j = 0; j < 3; j++) {
                if (this.board[startRow + i][startCol + j] === num) // Если число уже есть в квадрате
                    return false;
            }
        }

        return true;
    }
}

const sudoku = new Sudoku();
sudoku.generateSolution();  // Генерируем решение
sudoku.printBoard();
sudoku.checkBoard();
const isValid = sudoku.checkBoard();
console.log(isValid ? "Поле без ошибок." : "Есть ошибки в поле.");

console.log("-----------------------------------------");

sudoku.generateBoardWithErrors();  // Генерируем решение
sudoku.printBoard();  // Выводим поле в консоль
sudoku.checkBoard();  // Проверяем поле на ошибки

