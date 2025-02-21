console.log("welcome to ts");
//the first task
console.log("---------------the first task---------------");
let ten:number = 10;
const formOfPhone = /^\([0-9]{3}\)[-. ]([0-9]{3})[-]([0-9]{4})$/;
const numbersFromZeroToNine = /^[0-9]{10}$/;

let numbers:number[] = [1,2,3,4,5,6,7,8,9,0];


function createPhoneNumber(numbers: number[]):string{
    if(numbers.length != ten)
        return "false";
    if(!isOnlyNumberFromZeroToNine(numbers))
        return "false";

    return joinToString(numbers);
    
}

console.log(createPhoneNumber(numbers));

function isOnlyNumberFromZeroToNine(array: number[]){
    return array.every(element => element >= 0 && element <= 9);
}

function joinToString(array:number[]){
    
    return '(' + array.join('').slice(0,3) + ')' + ' ' + array.join('').slice(3, 6) + '-' + array.join('').slice(6,10); // edit
}

// validation
console.log(isValidPhone("(123) 456-7890"));
console.log(isValidPhone(createPhoneNumber(numbers)));
function isValidPhone(phone){
    return formOfPhone.test(phone);
}


// function isOnlyNumberFromZeroToNine(array){
//     return numbersFromZeroToNine.test(array);
// }

// console.log(isValidPhone(numbers));

//the second task

console.log("---------------the second task---------------");

let value:string|null = prompt("Введите число:");
let converToInteger:number = value !== null ? parseInt(value) : NaN;
//тенарный(условный) оператор
class Challenge {
    static solution(number: number){
        if(number > 0){
            
            let sum:number = 0;
            for(let i:number = 1; i < number; i++){
                
                if(i % 3 == 0 && i % 5 == 0)
                    sum +=i;
                else if(i % 3 == 0)
                    sum +=i;
                else if(i % 5 == 0)
                    sum +=i;

            }
            return sum;
        }
        else
            return -1;
    }
}

console.log("Your input number = " + value);
console.log("Your answer:" + Challenge.solution(converToInteger)); //remake


console.log("---------------the third task---------------");

let nums:number[] = [1,2,3,4,5,6,7];
let a:number[];
let k:number = 3;

function rotateArray(array:number[] ,value:number): number[] {

    if(array.length < value)
        value = value%array.length;
    if(value < 0)
        value = Math.abs(value);

    // a = copyArray(array);
    // array.reverse();

    // for(let i = k; i < numbers.length - k; i++){
    //     array[i] = a[i - k];
    // }
    // return array;
    return array.slice(-value).concat(array.slice( 0, -value));
}

function copyArray(array:number[]){
    return array.slice();
}

console.log(rotateArray(nums, k));

console.log("---------------the fourth task---------------");

let nums1:number[] =[1,3];
let nums2:number[] =[2];

let nums3:number[] =[1,2];
let nums4:number[] =[3,4];

function findMedian(firstArray:number[], secondArray:number[]){

    let numsx:number[] = firstArray.concat(secondArray).sort((a,b) => a-b) ;
    let lenghtOfNumsx = numsx.length;
    if(numsx.length % 2 == 0){
        return (numsx[Math.floor((lenghtOfNumsx - 1) / 2) ] + numsx[Math.floor(lenghtOfNumsx /2)])/2;
    }
    else{
        return numsx[Math.floor(lenghtOfNumsx/ 2)];
    }
}

console.log(findMedian(nums1,nums2));
console.log(findMedian(nums3,nums4));