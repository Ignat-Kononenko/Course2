function makeCounter(){
    let currentCount = 1;

    return function(){                          // замыкание, будет уже вызываться при повторе counter() сразу
        return currentCount++;                  // сначала выводит, а потом плюсует
    };
 
}

let counter = makeCounter();
alert(counter()); // 1
alert(counter()); // 2
alert(counter()); // 3

let counter2 = makeCounter();
alert(counter2()); // 1

let currentC = 1;
function makeCount(){
    return function(){
        return currentC++;
    };
 
}

let counter3 = makeCount();
let counter4 = makeCount();

alert(counter3()); // 1
alert(counter3()); // 2

alert(counter4()); // 1
alert(counter4()); // 2

// secondTask

function findVolume(lenght){                        // каррированная функция(частич)                    
    return function(width){
        return function(height){
            return lenght*width*height;
        }
    }
}

const volumeWithFixLenght = findVolume(10);

console.log(volumeWithFixLenght(5)(3));             // постепенно вводим по одному аргументу
console.log(volumeWithFixLenght(10)(30));
  
// thirdTask

function* moveObject(){
    let x=0, y=0;
    while(true){
        const direction = prompt("Введите команду(left, right, up, down, exit)");
        if (direction === 'exit') {
            return;
        }
        for(let i = 0; i < 10; i++){
            switch(direction){
                case 'left':
                    x -=1;
                    break;
                case 'right':
                    x +=1;
                    break;
                case 'up':
                    y+=1;
                    break;
                default:
                    console.log("Неверная команда. Попробуйте еще раз");
                    break;
            }
            yield{x, y};
        }
    }
}

const generator = moveObject();

function move() {
    let result = generator.next();
    while (!result.done) {
        for (let i = 0; i < 10; i++) {
            console.log(`Координаты: x=${result.value.x}, y=${result.value.y}`);
            result = generator.next();
            if (result.done) break;
        }
        if (!result.done) {
            result = generator.next();
        }
    }
}
move();

// fourthTask

var globalVar = 10;
function globalFunction(){
    return "Hello, world!";
}

console.log(window.globalVar); // 10 (становится свойством глобального объекта)
console.log(window.globalFunction());

window.globalVar = 52;
window.globalFunction = function() {
    return "New function";
};
console.log(window.globalVar);
console.log(window.globalFunction());