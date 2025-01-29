let user ={                 // объект
    name: 'Masha',          // под ключем name хранится строка(это можно назвать свойства объекта)
    age: 21
};

let clone1 = Object.assign({}, user);    // поверхностное копирование(по ссылке)
let clone2 = Object.create(user);
let clone3 = {...user};

let clone4 = JSON.parse(JSON.stringify(user));  // не можем инстансы даты, set, map, регулярные выражения, вложенные объекты

let clone5 = structuredClone(user); // глубокое копирование(не по ссылке), однако не можем функции, DOW- узлы, дескриптеры свойств, геттеры и сеттеры, прототипы объектов

console.log("assign: " + clone1.name);
console.log("create: " + clone2.age);
console.log("new object: " + clone3.name);
console.log("JSON: " + clone4.age);
console.log("structedClone: " + clone5.name);

let numbers = [1, 2, 3];

let clone6 = structuredClone(numbers);

console.log("numbers: " + clone6);

let user1 = {
    name: 'Masha',
    age: 23,
    location: {
        city: 'Minsk',
        country: 'Belarus'
    }
};

let clone7 = Object.assign({}, user1);
let clone8 = structuredClone(user1);

console.log("cloneUser1 - " + clone7.location.city);
console.log("cloneUser1 - " + clone8.location.country);

let user2 = {
    name: 'Masha',
    age: 28,
    skills: ["HTML", "CSS", "JavaScript", "React"]
};

let clone9 = structuredClone(user2);
let clone10 = Object.create(user2);

clone9.skills.push('C#');

console.log("basicUser2 - " + user2.skills);
console.log("cloneUser2 - " + clone9.skills);

clone10.skills.push('C++');
console.log("basicUser2 - " + user2.skills)
console.log("cloneUser2 - " + clone10.skills);

const array = [
    {id: 1, name: 'Vasya', group: 10}, 
    {id: 2, name: 'Ivan', group: 11},
    {id: 3, name: 'Masha', group: 12},
    {id: 4, name: 'Petya', group: 10},
    {id: 5, name: 'Kira', group: 11},
]

let clone11 = structuredClone(array);
let clone12 = Object.assign([], array);

console.log("cloneArray (structuredClone):");
clone11.forEach(item => console.log(item));

console.log("cloneArray (assign):");
clone12.forEach(item => console.log(item));

let user4 = {
    name: 'Masha',
    age: 19,
    studies: {
        university: 'BSTU',
        speciality: 'designer',
        year: 2020,
        exams: {
            maths: true,
            programming: false
        }
    }
};

let clone13 = structuredClone(user4);
let clone14 = Object.create(user4);

console.log("cloneUser4 (structuredClone): ")
console.log(clone13);

console.log("cloneUser4 (create): ")
console.log(clone14);

let user5 = {
    name: 'Masha',
    age: 22,
    studies: {
        university: 'BSTU',
        speciality: 'designer',
        year: 2020,
        department: {
            faculty: 'FIT',
            group: 10,
        },
        exams: [
            { maths: true, mark: 8},
            { programming: true, mark: 4},
        ]
    }
};

let clone15 = structuredClone(user5);
let clone16 = Object.assign({}, user5);

clone15.age = 12;
clone15.studies.department.group = 12;
clone15.studies.exams[1].mark = 10;

console.log("cloneUser5 (structuredClone): ")
console.log(clone15);
console.log(user5);

clone16.age = 16;
clone16.studies.department.group = 12;
clone16.studies.exams[1].mark = 10;

console.log("cloneUser5 (assign): ")
console.log(clone16);
console.log(user5);

let user6 = {
    name: 'Masha',
    age: 21,
    studies: {
        university: 'BSTU',
        speciality: 'designer',
        year: 2020,
        department: {
            faculty: 'FIT',
            group: 10,
        },
        exams: [
        { 
		maths: true,
		mark: 8,
		professor: {
		    name: 'Ivan Ivanov ',
		    degree: 'PhD'
		    }
	    },
        { 
		programming: true,
		mark: 10,
		professor: {
		    name: 'Petr Petrov',
		    degree: 'PhD'
		    }
	    },
        ]
    }
};

let clone17 = structuredClone(user6);
let clone18 = Object.assign({}, user6);

clone17.studies.exams[0].professor.name = 'Nikita';

console.log("cloneUser6 (structuredClone): ")
console.log(clone17);
console.log(user6);

clone18.studies.exams[0].professor.name = 'Igor';

console.log("cloneUser6 (structuredClone): ")
console.log(clone18);
console.log(user6);

let user7 = {
    name: 'Masha',
    age: 20,
    studies: {
        university: 'BSTU',
        speciality: 'designer',
        year: 2020,
        department: {
            faculty: 'FIT',
            group: 10,
        },
        exams: [
        { 
		maths: true,
		mark: 8,
		professor: {
		    name: 'Ivan Petrov',
		    degree: 'PhD',
		    articles: [
                        {title: "About HTML", pagesNumber: 3},
                        {title: "About CSS", pagesNumber: 5},
                        {title: "About JavaScript", pagesNumber: 1},
                    ]
		    }
	    },
        { 
		programming: true,
		mark: 10,
		professor: {
		    name: 'Petr Ivanov',
		    degree: 'PhD',
		    articles: [
                        {title: "About HTML", pagesNumber: 3},
                        {title: "About CSS", pagesNumber: 5},
                        {title: "About JavaScript", pagesNumber: 1},
                    ]
		    }
	    },
        ]
    }
};

let clone19 = structuredClone(user7);
let clone20 = Object.assign({}, user7);

clone19.studies.exams[0].professor.articles[1].pagesNumber = 3;

console.log("cloneUser7 (structuredClone): ")
console.log(clone19);
console.log(user7);

clone20.studies.exams[0].professor.articles[1].pagesNumber = 88;

console.log("cloneUser7 (assign): ")
console.log(clone20);
console.log(user7);

let store = {
    state: {
        profilePage: {
            posts:[
                {id: 1, message: 'Hi', likesCount: 12},
                {id: 2, message: 'Bye', likesCount: 1},
            ],
            newPostText: 'About me',
        },
        dialogsPage: {
            dialogs: [
                {id: 1, name:'Valera'},
                {id: 2, name:'Andrey'},
                {id: 3, name:'Sasha'},
                {id: 4, name:'Viktor'},
            ],
            messages: [
                {id: 1, message: 'hi'},
                {id: 2, message: 'hi hi'},
                {id: 3, message: 'hi hi hi hi'},
            ],   
        },
        sidebar:[],
    },
}

let = {                     // деструктуризация
    state:{
        profilePage: {
            post,
            newPostText,
        },
        dialogsPage:{
            dialogs,
            messages,
        },
        sidebar,
    },
} = store;

let clone21 = structuredClone(store);

clone21.state.dialogsPage.messages.forEach(item => item.message = "hello");

console.log("cloneUser5 (structuredClone): ");
console.log(clone21);

