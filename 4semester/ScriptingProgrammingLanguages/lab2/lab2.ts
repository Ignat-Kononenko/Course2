console.log("---------------the first task---------------");

const array = [
    {id: 1, name: 'Vasya', group: 10},
    {id: 2, name: 'Ivan', group: 11},
    {id: 3, name: 'Masha', group: 12},
    {id: 4, name: 'Petya', group: 10},
    {id: 5, name: 'Kira', group: 11},
]

interface IStudent{
    id: number;
    name: string;
    group: number;
}

function printStudents(student: IStudent):void{
    console.log("name:", student.name, ", group - ", student.group);
}

array.forEach(printStudents);

console.log("---------------the second task---------------");

interface CarsType{
    manufacturer?: string;
    model?:string;
}

let car:CarsType = {};
car.manufacturer = "manufacturer";
car.model = 'model';

function printCars(st:CarsType){
    console.log(st);
}
printCars(car);

console.log("---------------the third task---------------");

const car1: CarsType = {
    manufacturer: "none",
    model: "none"
};
car1.manufacturer="audi";
car1.model ='a8';

const car2: CarsType = {
    manufacturer: "none",
    model:"none"
};
car2.manufacturer = "tesla";
car2.model='y';

const arrayCars: Array<ArrayCarsType>=[
    {cars:[car1, car2]}
];

interface ArrayCarsType{
    cars:CarsType[];
}

console.log("car1:");
console.log(car1);
console.log("car2:");
console.log(car2);
console.log("Array of cars:");
console.dir(arrayCars, {depth:null});

console.log("ArrayOfCars:");
arrayCars.forEach((arrayCar, index)=>{
    console.table(arrayCar.cars);
});


console.log("---------------the fourth task---------------");

type MarkType = {
    subject: string,
    mark: MarkFilterType, // может принимать значения от 1 до 10
    done: DoneType,
}
type StudentType = {
    id: number,
    name: string,
    group: GroupFilterType, // может принимать значения от 1 до 12
    marks: Array<MarkType>,
}

type GroupType = {
    students: StudentType[]; // массив студентов типа StudentType
    studentsFilter: (group:GroupFilterType) => Array<StudentType>, // фильтр по группе
    marksFilter: (mark: MarkFilterType) => Array<StudentType>, // фильтр по  оценке
    deleteStudent: (id: number) => void, // удалить студента по id из  исходного массива
    // mark: MarkFilterType,
    // group: GroupFilterType,
}

type MarkFilterType = 1|2|3|4|5|6|7|8|9|10;

type GroupFilterType = 1|2|3|4|5|6|7|8|9|10|11|12;

type DoneType = boolean;

let firstStudent={
    id:1,
    name: "Alice",
    group:3,
    marks: [8,6,4]
}

// нужно создать переменную типа GroupType и там реализовать students, studentsFilter, marksFilter, deleteStudent/ x.students.push()

const group:GroupType = {
    students: [],
    studentsFilter: function(group:GroupFilterType){
        return this.students.filter(student => student.group === group);
    },
    marksFilter: function(marks:MarkFilterType){
        return this.students.filter(student => student.marks.some(m => m.mark === marks)); //find
        // return this.students.find(student => student.marks === marks);
    },
    deleteStudent(id:number){
        return this.students.filter(el => el.id !== id);
    }

};

group.students.push({
    id: 1,
    name:"Алиса",
    group:6,
    marks:[
        {subject:"Математика", mark: 8, done: true},
        {subject:"Английский", mark: 7, done: true},
    ]

});

group.students.push({
    id: 3,
    name:"Никита",
    group:6,
    marks:[
        {subject:"Русский язык", mark: 8, done: true},
        {subject:"Общество", mark: 10, done: true},
    ]

});

console.dir(group.studentsFilter(6), {depth:null});

console.log("Examples");

// group.studentsFilter(6).forEach((group, index)=>
//     console.table(group)
// )//посмотреть
console.dir(group.marksFilter(10), {depth:null}); //доделать

console.log("После удаления студента: ")
console.dir(group.deleteStudent(1), {depth:null});
