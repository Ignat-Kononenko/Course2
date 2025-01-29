function basicOperation(operation, value1, value2){ // firstTask
    let result;

    switch(operation){
        case '+':
            result =   value1 + value2;
            break;
        case '-':
            result = value1 - value2;
            break;
        case '*':
            result = value1 * value2;
        case '/':
            result = value1 / value2;
            break;
        default:
            break;
    }

    return result;
}

let result = basicOperation('+', 5, 10);
console.log("result = " + result);

let n;

n = prompt("Введите n и получите сумму кубов до этого числа включительно:");

function getSumOfCubOfN(n){ // secondTask
    let getSum = 0;
    
    for(let i = 1; i <= n; i++){
        getSum += Math.pow(i, 3);
    }
    return getSum;
}

let getSumOfCub = getSumOfCubOfN(n);
console.log(getSumOfCub);

let massiveOfNumber = [1, 4, 6, 8, 2, 5]; // thirdTask


function getAverageSum(array){
    let getSumOfNumbers = 0;
    for(let i = 0; i < array.length; i++)
        getSumOfNumbers += array[i];

    return  getSumOfNumbers / array.length;
}

let resultOfAverageNumber = getAverageSum(massiveOfNumber);
console.log(resultOfAverageNumber);

//fourthTask

let firstArr = "JavaScript";
let secondArr = "JavaScr53&э ipt";

function swapLetters(array){
    let arr = "";
    for(let i = 0; i < array.length; i ++){
        if(array[i].toUpperCase() >='A' && array[i].toUpperCase() <= 'Z')
            arr += array[i];
    }
    
    let swapArr = "";
    for(let j = arr.length - 1; j >= 0; j--){
        swapArr += arr[j];
    }
    return swapArr;
}

//let cleanStr = array.replace(/[^a-zA-Z]/g,'')
//let reversedStr = cleanStr.split('').reversed().join(''); // arr.reverse меняет порядок элементов 

let resultOfFirstArr = swapLetters(firstArr);
let resultOfSecondArr = swapLetters(secondArr);
console.log(resultOfFirstArr);
console.log(resultOfSecondArr);

//fifthTask

function createNewString(num, str){
    let newArr = "";
    for(let i = 0; i < Math.abs(num); i++){
        newArr += str;
    }
    return newArr;
    //return str.repeat(num)
}

let num = 5;
let strs ="abcdef";
let resultOfStr = createNewString(num, strs);
console.log(resultOfStr);

//sixthTask

let firstMassiveOfString =["apple", "banana", "clone", "dance"];
let secondMassiveOfString =["banana", "dance", "english"];

function getNewMassiveOfString(firstArray, secondArray){
    return firstArray.filter(item => !secondArray.includes(item));
}

let resultOfNewMassive = getNewMassiveOfString(firstMassiveOfString, secondMassiveOfString);
console.log(resultOfNewMassive);