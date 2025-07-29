// the second task

let promise = new Promise(function(resolve, reject){
    setTimeout(() =>resolve(generateNumber(0, 100)), 3000);
})

promise.then(
    result => console.log(result)
)

function generateNumber (min, max) {
    return Math.floor(Math.random() * (max -min +1))+ min;
}

// the third task

function generateDelayForMyPromise(delay){
    let myPromise = new Promise(function(resolve, reject){
        setTimeout(() =>resolve(generateNumber(0, 100)), delay);
    });
    return myPromise;
}

Promise.all ([
    generateDelayForMyPromise(3000),
    generateDelayForMyPromise(2000),
    generateDelayForMyPromise(1000)
]).then(console.log);

// the fourth task

let pr = new Promise((res, rej) =>{
    rej('ku') // отклоняем промис сразу
})

pr
    .then(() => console.log(1))
    .catch(() => console.log(2))
    .catch(() => console.log(3))
    .then(() => console.log(4))
    .then(() => console.log(5))

// the fifth task

let newPromise = new Promise((res, rej) =>{
    res(21)
})

newPromise
    .then((res1) =>{
        console.log(res1);
        return new Promise((res,rej)=>{
            setTimeout(() => res(res1*2), 1000);
        });
    })
    .then((res2)=> {
        console.log(res2);
    })

// the sixth task

async function getPromise(){

    let prom = new Promise((res, rej) => {
        res(21);
    })

    let first_result = await prom;
    console.log(first_result);

    let second_result = await new Promise((res, rej) => {
        res( first_result*2);
    });
    console.log(second_result);
}

getPromise();

// the seventh task

let second_promise = new Promise((res, rej) => {
    res("Resolved promise - 1")
})

second_promise
    .then((res) => {
        console.log('Resolved promise - 2')
        return "OK"
    })
    .then((res) =>{
        console.log(res);
    })

// the eight task

let third_promise = new Promise((res, rej) => {
    res("Resolved promise - 1")
})

third_promise
    .then((res) => {
        console.log(res)
        return "OK"
    })
    .then((res1) =>{
        console.log(res1);
    })

// the ninth task

let fourth_promise = new Promise((res, rej) => {
    res("Resolved promise - 1")
})

fourth_promise
    .then((res) => {
        console.log(res)
        return res
    })
    .then((res1) =>{
        console.log('Resolved promise - 2');
    })

// the tenth task

let fifth_promise = new Promise((res, rej) => {
    res("Resolved promise - 1")
})

fifth_promise
    .then((res) => {
        console.log(res)
        return res
    })
    .then((res1) =>{
        console.log(res1);
    })

// the eleventh task

let sixth_promise = new Promise((res, rej) => {
    res("Resolved promise - 1")
})

sixth_promise
    .then((res) => {
        console.log(res)
    })
    .then((res1) =>{
        console.log(res1); // undefined
    })

// the twelfth task

let second_pr = new Promise((res, rej) => {
    rej('ku')
})

second_pr
    .then(() => console.log(1))
    .catch(() => console.log(2))
    .catch(() => console.log(3))
    .then(() => console.log(4))
    .then(() => console.log(5))