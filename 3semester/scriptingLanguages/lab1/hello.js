let a = 5;
console.log(typeof(a));
let name = "Name";
console.log(typeof(name));
let i = 0;
console.log(typeof(i));
let double = 0.23;
console.log(typeof(double));
let result =1/0;
console.log(typeof(result));
let answer = true;
console.log(typeof(answer));
let no = null;
console.log(typeof(no));

let sideOfSquare = 5;
let firstSideOfRectangle = 45;
let secondSideOfRectangle = 21;
let amountOfSquare;
amountOfSquare = 45*21/(5*5);
console.log(Math.floor(amountOfSquare));

let firstNumber = 2;
let secondNumber = ++firstNumber; //префиксная форма
console.log(secondNumber);
let thirdNumber = firstNumber++; //постфиксная форма
console.log(thirdNumber);

console.log("Котик" == "котик"?"равны":"не равны");
console.log("Котик" == "китик"?"равны":"не равны");
console.log("Кот" == "Котик"?"равны":"не равны");
console.log("Привет" == "Пока"?"равны":"не равны");
console.log(73 == "53"?"равны":"не равны");
console.log(false == 0?"равны":"не равны"); //true
console.log(54 == true?"равны":"не равны");
console.log(123 == false?"равны":"не равны");
console.log(true == "3"?"равны":"не равны");
console.log(3 == "5mm"?"равны":"не равны");
console.log(8 == "-2"?"равны":"не равны");
console.log(34== "34"?"равны":"не равны");//true
console.log(null == undefined?"равны":"не равны");//true

let userName = prompt("Введите ваше имя, имя и отчество или полное ФИО");
let upperUserName = userName.toUpperCase();
let amountOfWords = userName.split(" ");
let names = "Иванов Иван Иванович".toUpperCase();
let words = names.split(" ");
let found = 0, amount = 0;

words.forEach(word => {
    console.log(word);
    if (upperUserName.split(" ").includes(word)) {
        found ++;
    }
});

amountOfWords.forEach(name=>{
    amount++;
})

if (found == amount) {
    alert("Здравствуйте, " + userName + "!");
} else {
    alert("Извините, но мы Вас не знаем");
}

// let student;
let russianLanguage = prompt("Введите информацию насчет русского языка: 1 - сдали, 2 - нет"),
    math = prompt("Введите информацию насчет математики: 1 - сдали, 2 - нет"), 
    englishLanguage = prompt("Введите информацию насчет английского языка: 1 - сдали, 2 - нет");

if(russianLanguage == 1 && math == 1 && englishLanguage == 1){
    console.log("Поздравляем, Вас перевели на следующий курс!");
}
else if(russianLanguage == 2 && math == 2 && englishLanguage == 2){
    console.log("Вы не сдали все предметы");
}
else if(russianLanguage == 2 || math == 2 || englishLanguage == 2){
    console.log("Пересдача, так как не сдали хотя бы 1 предмет");
}
else{
    console.log("Вы ввели неправильно");
}

let firstValue = true + true; // 2
console.log(firstValue);
let secondValue = 0 + "5mm"; // 05mm
console.log(secondValue);
let thirdValue = 5 + "mm"; // 5mm
console.log(thirdValue);
let forthValue = 8 / Infinity; // 0
console.log(forthValue);
let fifthValue = 9 * "\n9"; // 81
console.log(fifthValue);
let sixthValue = null - 1; // -1
console.log(sixthValue);
let seventhValue = "5" - 2; // 3
console.log(seventhValue);
let eightValue = "5px" - 3; // NaN
console.log(eightValue);
let ninthValue = true - 3; // -2
console.log(ninthValue);
let tenthValue = 7 || 0; // 7
console.log(tenthValue);

let massive = [1,2,3,4,5,6,7,8,9,10];
for(let i = 0; i < massive.length; i++){
    if(massive[i] % 2 == 0)
        console.log(massive[i] += 2);
    else
        console.log(massive[i] += "Xmm");
}

let week = ["Понедельник","Вторник","Среда","Четверг","Пятница","Суббота","Воскресенье"];
let choice = prompt("Выберите число от 1 до 7, где 1 - пн ... 7 вс");
for(let i = 0; i < week.length; i++){
    if( i == choice - 1)
        console.log("Это " + week[choice - 1]);
}

let daysOfWeek = {
    1:"Понедельник",
    2:"Вторник",
    3:"Среда",
    4:"Четверг",
    5:"Пятница",
    6:"Суббота",
    7:"Воскресенье"
};

let secondChoice = prompt("Выберите число от 1 до 7, где 1 - пн ... 7 вс");
if(daysOfWeek[secondChoice]){
    console.log(daysOfWeek[secondChoice]);
}
else{
    console.log("Вы ввели неправильно");
}

function createString(param1 = "По умолчанию", param2, param3){
    return `${param1}, ${param2}, ${param3}`;
}

let input = prompt("Введите параметр");
let resultOfString = createString(undefined, "Второй параметр", input);
console.log("Результат создания строки: " + resultOfString);

let firstSideOfFigure = prompt("Введите длину прямоугольника");
let secondSideOfFigure = prompt("Введите ширину прямоугольника");

let resultOfFigure = firstParams(firstSideOfFigure, secondSideOfFigure);
console.log("Значение фигуры равно " + resultOfFigure);

function firstParams(firstSideOfFigure, secondSideOfFigure){ // Function Declaration 
    if(firstSideOfFigure == secondSideOfFigure)
        return firstSideOfFigure * 4;
    else
        return firstSideOfFigure * secondSideOfFigure;
}

let secondParams = function(){ //Function Expression
    if(firstSideOfFigure == secondSideOfFigure)
        return firstSideOfFigure * 4;
    else
        return firstSideOfFigure * secondSideOfFigure;
};

console.log("Значение фигуры равно " + secondParams(firstSideOfFigure, secondSideOfFigure));

let thirdParams = (firstSideOfFigure, secondSideOfFigure) => { // Функции-стрелки
    if(firstSideOfFigure == secondSideOfFigure)
        return firstSideOfFigure * 4;
    else
        return firstSideOfFigure * secondSideOfFigure;
};

console.log("Значение фигуры равно " + thirdParams(firstSideOfFigure, secondSideOfFigure));