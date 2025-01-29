let array = [1, [1, 2, [3, 4]], [2, 4]];

function combineArray(arr){
    return arr.reduce((acc,val) => {                                        // обход каждого элемента массива, acc - аккумулятор и val - текущий элемент
        return acc.concat(Array.isArray(val) ? combineArray(val) : val);    // concat - объединение acc с val или результатом рекурсии
    }, []);                                                                 // начальное значение аккумулятора
}

console.log(combineArray(array));


// let result = array.reduce((sum, current) => sum + current, 0);           // для одномерного

// secondTask
function getSum(arr){
    return arr.reduce((sum, current) => {
        return sum + (Array.isArray(current) ? getSum(current) : current);
    }, 0);
}
console.log(getSum(array));

// thirdTask

let students = [
    {name: 'Ivan', age: 16, groupId: 1},
    {name: 'Petya', age: 20, groupId: 4},
    {name: 'Vasya', age: 17, groupId: 2},
    {name: 'Egor', age: 18, groupId: 3}
];

function sortStudent(students) {
    return students.reduce((acc, student) => {
        if (student.age > 17) {
            if (!acc[student.groupId]) {
                acc[student.groupId] = [];
            }
            acc[student.groupId].push(student);
        }
        return acc;
    }, {});
}

console.log(sortStudent(students));

// fourthTask

let input = 'ABC';

function processString(str){

    let total1 = str.split('').map(char => char.charCodeAt(0)).join('');        // split - рассоединяет ['A', 'B', 'C'], map - преобразуем в ascii, join - соединяем
    
    let total2 = total1.replace(/7/g, '1');

    let result = parseInt(total1) - parseInt(total2);
    return result;

}

console.log(processString(input));

// fifthTask

function createNewObject(...object){
    return Object.assign(...object);                                        // assign -клонирование и объединение объектов
}

console.log(createNewObject({a: 1, b: 2}, {c: 3}));

console.log(createNewObject({a: 1, b: 2}, {c: 3}, {d: 4} ));

// sixthTask

function createPyramid(floors){
    let tower = [];

    for(let i = 0; i < floors; i++){
        let spaces = ' '.repeat(floors - i);
        let stars = '*'.repeat(i*2+1);
        tower.push(spaces + stars + spaces);
    }
    return tower;
}

console.log(createPyramid(10));