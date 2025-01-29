// firstTask
let products = new Set();                           // создания множества(вид коллекции)

function addProducts(products, product){            // добавляем
    return products.add(product);
}

addProducts(products, "Apple");
addProducts(products, "Banana");
addProducts(products, "Coconut");

function checkProduct(products, product){          // проверяем
    return products.has(product);
}

function removeProduct(products, product){         // удаляем
    return products.delete(product);
}

function getSizeOfProducts(products, product){      // получить размер
    return products.size;
}

console.log("Есть ли банан в списке?", checkProduct(products, "Banana")); // true

removeProduct(products, "Banana");

console.log("Есть ли банан в списке?", checkProduct(products, "Banana")); // false

console.log("Число продуктов:", getSizeOfProducts(products)); 

// secondTask

class Student {
    constructor(id, group, name) {          // специальный метод класса в JavaScript, который вызывается при создании нового экземпляра класса.
        this.id = id;
        this.group = group;
        this.name = name;
    }
}

function addStudent(students, student) {
    return students.add(student);
}

function removeStudentById(students, id) {
    for (let student of students) {
        if (student.id === id) {
            students.delete(student);
            break;
        }
    }
}

function filterStudentsByGroup(students, group) {
    return new Set([...students].filter(student => student.group === group));
}

function sortStudentsById(students) {
    return new Set([...students].sort((a, b) => a.id - b.id));
}

// Пример использования
let students = new Set();

addStudent(students, new Student(1, "A", "Иван Иванов"));
addStudent(students, new Student(4, "B", "Петр Петров"));
addStudent(students, new Student(3, "A", "Сергей Сергеевич"));

removeStudentById(students, 2);

let groupAStudents = filterStudentsByGroup(students, "A");
console.log("Студенты в группе А:", groupAStudents);

let sortedStudents = sortStudentsById(students);
console.log("Сортировка по ID:", sortedStudents);

// thirdTask

class Product{
    constructor(id, name, quantity, price){
        this.id = id;
        this.name = name;
        this.quantity = quantity;
        this.price = price;
    }
}

function addProduct(products, product) {
    products.set(product.id, product);
}

// Функция для удаления товара по id
function removeProductById(products, id) {
    products.delete(id);
}


function removeProductsByName(products, name){
    for(let product of products) {
        if(product.name === name){
            products.delete(id);
        }
    }
}

function updateProductQuantity(products, id, quantity) {
    if (products.has(id)) {
        let product = products.get(id);                     // возвращает товар с указанным
        product.quantity = quantity;
        products.set(id, product);
    }
}

function updateProductPrice(products, id, price) {
    if (products.has(id)) {
        let product = products.get(id);
        product.price = price;
        products.set(id, product);
    }
}

function getSize(products){
    return products.size;
}

function calculateTotalCost(products) {
    let totalCost = 0;
    for (let product of products.values()) {
        totalCost += product.quantity * product.price;
    }
    return totalCost;
}

let product = new Map();

addProduct(product, new Product(1, "Apple", 10, 2));
addProduct(product, new Product(2, "Banana", 5, 1.5));
addProduct(product, new Product(3, "Orange", 8, 3));


removeProductById(product, 2);                          // Удаляем товар по id


removeProductsByName(product, "Orange");                // Удаляем товары по названию


updateProductQuantity(product, 1, 15);                  // Изменяем количество товара


updateProductPrice(product, 1, 2.5);                    // Изменяем стоимость товара

console.log("Количество позиций:", getSize(products)); 

console.log("Сумма стоимости всех товаров:", calculateTotalCost(products));

// fourthTask


const cache = new WeakMap();                            // Создаем WeakMap для хранения кеша


function expensiveCalculation(obj) {                    // Функция для выполнения вычислений
   
    if (cache.has(obj)) {                               // Проверяем, есть ли результат в кеше
        console.log("Берем данные из кеша");
        return cache.get(obj);
    }


    const result = obj.value * 2;                       // Выполняем вычисления (например, просто умножаем значение на 2)


    cache.set(obj, result);                             // Сохраняем результат в кеш

    console.log("Выполняем вычисления");
    return result;
}

let obj1 = { value: 10 };
let obj2 = { value: 20 };

console.log(expensiveCalculation(obj1)); // Выполняем вычисления, 20
console.log(expensiveCalculation(obj1)); // Берем данные из кеша, 20
console.log(expensiveCalculation(obj2)); // Выполняем вычисления, 40
console.log(expensiveCalculation(obj2)); // Берем данные из кеша, 40