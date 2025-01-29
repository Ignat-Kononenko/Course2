let person ={
    name:'John',
    age: 23,
    greet(){
        console.log("Hello, user!");
    }, 
    ageAfterYears(years){
        return this.age + years;
    }
};

person.greet();
console.log(person.ageAfterYears(5));

// secondTask

let car ={
    model: "a4",
    year: 2024,
    getInfo(){
        console.log(`Model - ${this.model}, year - ${this.year}`);
    }
}

car.getInfo();

// thirdTask

function Book(title, author){                   //ф-ция - конструктор
    this.title = title;                         // указывыет на тек. экземпляр с которым мы работаем
    this.author = author;

    this.getTitle = function(){
        return this.title;
    }

    this.getAuthor = function(){
        return this.author;
    }
}

let myBook = new Book("Green", "Pavel");

console.log(myBook.title);
console.log(myBook.author);

// forthTask

let team = {
    players:["first", "second", "third", "forth"],
    getInfo(){
        this.players.forEach(player => console.log(`Player - ${player}`));
    }
}

team.getInfo();

// fifthTask

const counter =(function(){

    let count = 0;
    return{
        increment(){
            count++;
            return this.getCount();
        },
        decrement(){
            count--;
            return this.getCount()
        },
        getCount(){
            return count;
        }
    };

})(); 


console.log(counter.increment()); // 1
console.log(counter.increment()); // 2
console.log(counter.decrement()); // 1
console.log(counter.getCount()); // 1

// sixTask

let item= {
    price: 100
}

Object.defineProperty(item, "price", {
    configurable: true,
    writable: true
})

console.log(item.price);

item.price = 150;
console.log(item.price);

Object.defineProperty(item, "price", {
    value : 150,
    configurable: false,
    writable: false,
    enumerable:false
})

item.price = 200;
console.log(item.price);

// seventhTask

const Pi = 3.1415;
// math.PI

let circle = {
    radius: 10,


    get newRadius(){
        return this.radius;
    },
    set newRadius(value){
        if(value<0)
            console.log("Error");
        else
            this.radius = value;
    },
    get countS(){
        return Math.PI*this.radius*this.radius;
    }
}

console.log(circle.newRadius);
console.log(circle.countS);

circle.newRadius=3;
console.log(circle.newRadius);
console.log(circle.countS);

//eightTask

let cars = {
    make: "Belarus",
    model: "Geely",
    year: 2024
}


console.log(`About car: make - ${cars.make}, model - ${cars.model}, year - ${cars.year}`);

let descriptor = Object.getOwnPropertyDescriptor(cars, 'make');

console.log(JSON.stringify(descriptor, null, 2));

cars.make = "China";
cars.model ="BYD";
cars.year = 2025;

console.log(`About car: make - ${cars.make}, model - ${cars.model}, year - ${cars.year}`);

Object.defineProperty(cars, 'make', {
    writable:false,
    configurable: false
})

Object.defineProperty(cars, 'model', {
    writable:false,
    configurable:false
})

Object.defineProperty(cars, 'year',{
    writable:false,
    configurable:false
})
cars.make = "Germany";
cars.model ="Audi";
cars.year = 2023;

console.log(`About car: make - ${cars.make}, model - ${cars.model}, year - ${cars.year}`);

// ninthTask

let numbers = [1,2,3];

Object.defineProperty(numbers, 'sum', {
    get(){
        return this.reduce((acc, curr) =>acc + curr, 0);
    },  
    enumerable: true,
    configurable:false 
})
console.log(numbers.sum); 

numbers.sum = 10;
console.log(numbers.sum);

// tenthTask

let rectangle = {
    width: 22,
    height: 23,
    get getS(){
        return this.width * this.height;
    },
    get newWidth(){
        return this.width;
    },
    get newHeight(){
        return this.height;
    },
    set newWidth(value){
        this.width = value;
    },
    set newHeight(value){
        this.height = value;
    }
};

console.log(rectangle.getS);

rectangle.width = 35;
rectangle.height = 50;

console.log(rectangle.newWidth);
console.log(rectangle.height);
console.log(rectangle.getS);

// eleventhTask

let user = {
    firstName: "John",
    lastName: "Smith",
    get fullName(){
        return `${this.firstName} ${this.lastName}`;
    }, 
    set fullName(value){
        [this.firstName, this.lastName] = value.split(" ");
    }
};

console.log(user.fullName);

user.firstName = "Anna";
user.lastName = "JJH";

console.log(user.fullName);
