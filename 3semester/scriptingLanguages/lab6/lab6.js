let numbers =[1,2,3,4,5];
let [y] = numbers;
console.log(y);
let[,,x] = numbers;
console.log(x);

// secondTask

let user = {
    name: "Petya",
    age: 6
};

let admin = {
    admin: "fef",
    ...user
};

console.log(admin);

// thirdTask (rework)

let store = {
    state: {                        // firstLevel
        profilePage : {             // secondLevel
            posts: [                // thirdLevel
                {id: 1, messege: 'Hi', likesCount: 12},
                {id: 2, messege: 'Bye', likesCount: 1},
            ],
            newPostText: 'About me',
        },
        dialogsPage: {
            dialogs: [
                {id: 1, name:'Valera'},
                {id: 2, name:'Andrey'},
                {id: 3, name:'Sasha'},
                {id: 4, name:'Victor'},
            ],
            messages: [
                {id: 1, message:'hi'},
                {id: 2, message:'hi hi'},
                {id: 3, message:'hi hi hi'},
            ],
        },
        sidebar:[],
    },
}

let {
    state: {
        profilePage :{
            posts,
            newPostText
        },
        dialogsPage:{
            dialogs,
            messages
        },
        sidebar
    }
} = store;

for(let i = 0; i < posts.length; i++ ){
    console.log(posts[i].likesCount);
}

posts.forEach(post => console.log(post.likesCount));

let evenID = dialogs.filter(dialog => dialog.id % 2 === 0);

evenID.forEach(even => console.log(even));                  // values
console.log(evenID);                                        // array

let updateMessages = messages.map(upMessage => upMessage.message = "Hello, user!" );
console.log(updateMessages);

let updateMessage = messages.map(newMessage =>({...newMessage, message: "Hello, user!" }));
console.log(updateMessage);
//forthTask

let tasks = [
    {id: 1, title: "HTML&CSS", isDone: true},
    {id: 2, title: "JS", isDone: true},
    {id: 3, title: "ReactJS", isDone: false},
    {id: 4, title: "Rest API", isDone: false},
    {id: 5, title: "GraphQL", isDone: false},
];

let newTask ={id: 6, title:"feff", isDone: false};

tasks= [...tasks, newTask];

console.log(...tasks);

// fifthTask

let massive = [1,2,3];

function sumValues(x,y,z){
    return x+y+z;
}

console.log(sumValues(...massive));