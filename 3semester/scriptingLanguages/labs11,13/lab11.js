class Task{
    constructor(id, name, state){
        this.id = id;
        this.name = name;
        this.state = state;
    }
    changeName(name){
        this.name = name;
        console.log(`${this.name} пп`);
    }
    changeState(state){
        this.state = state;
        console.log(`${this.name} ппfe`);
    }
}

class Todolist{             // значения и свойства
    constructor(id, name){
        this.id = id;
        this.name = name;
        this.tasks = [];
    }

    updateName(newName){
        this.name = newName;
    }

    addTask(task){
        this.tasks.push(task);
    }

    getFilter(isComplete){
        return this.tasks.filter(task => task.state === isComplete);
    }

    printTasks(){
        this.tasks.forEach(task => console.log(task));
    }
}

let list1 = new Todolist(1, "firstTask");

list1.addTask(new Task(1, "one", false));
list1.addTask(new Task(2, "two", true));
list1.addTask(new Task(3,"three", false ));

let updateName = list1.tasks[0];
updateName.changeName("THREE");

list1.printTasks();
console.log(list1);

let filteredValue = list1.getFilter(true);

let list2 = new Todolist(2, "secondTask");

list2.addTask(new Task(1, "first", true));
list2.addTask(new Task(2, "second", true));
list2.addTask(new Task(3, "third", false));

let myTask = list2.getFilter(false);

list2.printTasks();
console.log(list2);
console.log(filteredValue);
console.log(myTask);