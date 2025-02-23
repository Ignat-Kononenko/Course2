console.log("---------------the first task---------------");
var array = [
    { id: 1, name: 'Vasya', group: 10 },
    { id: 2, name: 'Ivan', group: 11 },
    { id: 3, name: 'Masha', group: 12 },
    { id: 4, name: 'Petya', group: 10 },
    { id: 5, name: 'Kira', group: 11 },
];
function printStudents(student) {
    console.log("name:", student.name, ", group - ", student.group);
}
array.forEach(printStudents);
console.log("---------------the second task---------------");
var car = {};
car.manufacturer = "manufacturer";
car.model = 'model';
function printCars(st) {
    console.log(st);
}
printCars(car);
console.log("---------------the third task---------------");
var car1 = {
    manufacturer: "none",
    model: "none"
};
car1.manufacturer = "audi";
car1.model = 'a8';
var car2 = {
    manufacturer: "none",
    model: "none"
};
car2.manufacturer = "tesla";
car2.model = 'y';
var arrayCars = [
    { cars: [car1, car2] }
];
console.log("car1:");
console.log(car1);
console.log("car2:");
console.log(car2);
console.log("Array of cars:");
console.dir(arrayCars, { depth: null });
console.log("ArrayOfCars:");
arrayCars.forEach(function (arrayCar, index) {
    console.table(arrayCar.cars);
});
console.log("---------------the fourth task---------------");
var firstStudent = {
    id: 1,
    name: "Alice",
    group: 3,
    marks: [8, 6, 4]
};
// нужно создать переменную типа GroupType и там реализовать students, studentsFilter, marksFilter, deleteStudent/ x.students.push()
var group = {
    students: [],
    studentsFilter: function (group) {
        return this.students.filter(function (student) { return student.group === group; });
    },
    marksFilter: function (marks) {
        return this.students.filter(function (student) { return student.marks.some(function (m) { return m.mark === marks; }); }); //find
        // return this.students.find(student => student.marks === marks);
    },
    deleteStudent: function (id) {
        return this.students.filter(function (el) { return el.id !== id; });
    }
};
group.students.push({
    id: 1,
    name: "Алиса",
    group: 6,
    marks: [
        { subject: "Математика", mark: 8, done: true },
        { subject: "Английский", mark: 7, done: true },
    ]
});
group.students.push({
    id: 3,
    name: "Никита",
    group: 6,
    marks: [
        { subject: "Русский язык", mark: 8, done: true },
        { subject: "Общество", mark: 10, done: true },
    ]
});
console.dir(group.studentsFilter(6), { depth: null });
console.log("Examples");
// group.studentsFilter(6).forEach((group, index)=>
//     console.table(group)
// )//посмотреть
console.dir(group.marksFilter(10), { depth: null }); //доделать
console.log("delete a student: ");
console.dir(group.deleteStudent(1), { depth: null });
