const set = new Set([1,1,2,3,4]);       
console.log(set);

const name = "Lydia";
age = 21;                       // глобальная
console.log(delete name);       //let, const, var
console.log(name);
console.log(delete age);
console.log(window.age);

const numbers = [1,2,3,4,5];
const[y] = numbers;             // деструктуризация
console.log(y);
const[,,,x] = numbers;
console.log(x);

const user = {name: "Lydia", age: 21};
const admin = {admin: true, ...user};
console.log(admin);

const person = {name: "Lydia" };
Object.defineProperty(person, "age", {value: 21}); // , enumerable: true(перечисление) нужно
console.log(person);
console.log(Object.keys(person));

const a = {};
const b = {key: "b"};
const c = {key: "c"};
a[b] = 123;
a[c] = 456;
console.log(a[b]);

let num = 10;
const increaseNumber = () => num++;
const increasePassedNumber = number =>number++;
const num1 = increaseNumber();
const num2 = increasePassedNumber(num1);
console.log(num1);
console.log(num2);

const value ={number: 10};
const multiply = (x = {...value}) =>{
    console.log((x.number *=2));
};
console.log("FF");
multiply();
multiply();
multiply(value);
multiply(value);
console.log(value);

[1,2,3,4].reduce((x,y) => console.log(x,y));

[1,2,3,4].reduce((x,y) => {
    console.log(x,y);
    return x+y;
});