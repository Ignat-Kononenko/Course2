let firstSquare = {
    sides: 10,
    color: 'yellow',
};

let secondSquare = {
    sides: 5,
};

secondSquare.__proto__= firstSquare;

console.log("firstSquare: ");
console.log(firstSquare);

console.log("secondSquare: ")
console.log("sides: " + secondSquare.sides);
console.log("color: " + secondSquare.color);

console.log("Отличия: ")
console.log(Object.getOwnPropertyNames(secondSquare));
console.log(Object.getOwnPropertyDescriptors(secondSquare));

let firstCircle = {
    radius: 6,
};

// let secondCircle = {
//     color: green,
// };

function SecondCircle(color){
    this.color = color;
    this.__proto__ = firstCircle;               // цепочка прототипов
}

let secondCircle = new SecondCircle("green");

// secondCircle.__proto__ = firstCircle;

console.log("firstCircle: ");
console.log(firstCircle);

console.log("secondCircle: ")
console.log("radius: " + secondCircle.radius);
console.log("color: " + secondCircle.color);

console.log("Отличия: ")
console.log(Object.getOwnPropertyNames(secondCircle));
console.log(Object.getOwnPropertyDescriptors(secondCircle));

let firstTriangle = {
    lines: 1,
    color: 'white',
};

let secondTriangle = Object.create(firstTriangle, {         // 
    lines:{                                                 // дескриптор
        value: 3,
    },
});

console.log("firstTriangle: ");
console.log(firstTriangle);

console.log("secondTriangle: ")
console.log("lines: " + secondTriangle.lines);
console.log("color: " + secondTriangle.color);

console.log("Отличия: ")
console.log(Object.getOwnPropertyNames(secondTriangle));
console.log(Object.getOwnPropertyDescriptors(secondTriangle));

class Human {
    constructor(birthYear, address){
        this.name = "Ivan";
        this.surname = "Ivanov";
        this.birthYear = birthYear;
        this.address = address;
        
    }
    get age(){
        let currentYear = new Date().getFullYear();
        return currentYear - this.birthYear;
    }

    // Сеттер для изменения года рождения на основании возраста
    set age(newAge){
        let currentYear = new Date().getFullYear();
        this.birthYear = currentYear - newAge;
    }

    // Геттер и сеттер для fullAge (возраст)
    get fullAge(){
        return this.age;
    }

    set fullAge(newAge){
        if(newAge < 0) return;
        let currentYear = new Date().getFullYear();
        this.birthYear = currentYear - newAge;
    }
}

let student = new Human(2005,"gg");
console.log(student);
console.log(student.fullAge);

student.fullAge = 34;
console.log(student);
console.log(student.fullAge);

class Student extends Human {
    constructor(birthYear, address, course, group){                          // метод
        super(birthYear, address);
        this.faculty = "FIT";
        this.course = course;
        this.group = group;
        this.numberTest = 73301300;
    }
    get changeCourse(){                                 // метод
        return this.course;
    }
    set changeCourse(value){
       this.course = value;
    }
    get changeGroup(){
        return this.group;
    }
    set changeGroup(value){
        this.group = value;
    }
    getFullName(){
        return `${this.name}, ${this.surname}`;
    }
}

let student2 = new Student(2007,"Minsk", 4, 5);
console.log(student2.getFullName());
student2.changeCourse = 2;
student2.changeGroup = 9;
console.log(student2);

class Faculty{
    constructor(faculty, numberOfGroup, numberOfStudents){
        this.faculty = faculty;
        this.numberOfGroup = numberOfGroup;
        this.numberOfStudents = numberOfStudents;
        
        this.students = [];
    }

    get changeNumberOfGroup(){
        return this.numberOfGroup;
    }
    set changeNumberOfGroup(value){
        this.numberOfGroup = value;
    }
    get changeNumberOfStudents(){
        return this.numberOfStudents;
    }
    set changeNumberOfStudents(value){
        this.numberOfStudents = value;
    }
    addStudents(student){
        this.students.push(student);
    }
    getDev(){
        return this.students.filter(student => student.numberTest.toString().charAt(2) ==='3');

    }
    getGroup(group){
        return this.students.filter(student => student.group === group);
    }
}

let student13 = new Student(2006, "gg",2,5);
let student24 = new Student(2005, "gg", 3, 1);

let faculties = new Faculty("FIT", 2, 50);
faculties.addStudents(student13);
faculties.addStudents(student24);

console.log(faculties.getDev());
console.log(faculties.getGroup(5)); 

console.log(student13.getFullName());
student13.changeCourse = 3; 
console.log(student13);