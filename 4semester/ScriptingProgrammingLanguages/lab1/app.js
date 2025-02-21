console.log("welcome to ts");
//the first task
console.log("---------------the first task---------------");
var ten = 10;
var formOfPhone = /^\([0-9]{3}\)[-. ]([0-9]{3})[-]([0-9]{4})$/;
var numbersFromZeroToNine = /^[0-9]{10}$/;
var numbers = [1, 2, 3, 4, 5, 6, 7, 8, 9, 0];
function createPhoneNumber(numbers) {
    if (numbers.length != ten)
        return "false";
    if (!isOnlyNumberFromZeroToNine(numbers))
        return "false";
    return joinToString(numbers);
}
console.log(createPhoneNumber(numbers));
function isOnlyNumberFromZeroToNine(array) {
    return array.every(function (element) { return element >= 0 && element <= 9; });
}
function joinToString(array) {
    return '(' + array.join('').slice(0, 3) + ')' + ' ' + array.join('').slice(3, 6) + '-' + array.join('').slice(6, 10); // edit
}
// validation
console.log(isValidPhone("(123) 456-7890"));
console.log(isValidPhone(createPhoneNumber(numbers)));
function isValidPhone(phone) {
    return formOfPhone.test(phone);
}
// function isOnlyNumberFromZeroToNine(array){
//     return numbersFromZeroToNine.test(array);
// }
// console.log(isValidPhone(numbers));
//the second task
console.log("---------------the second task---------------");
var value = prompt("Введите число:");
var converToInteger = value !== null ? parseInt(value) : NaN;
//тенарный(условный) оператор
var Challenge = /** @class */ (function () {
    function Challenge() {
    }
    Challenge.solution = function (number) {
        if (number > 0) {
            var sum = 0;
            for (var i = 1; i < number; i++) {
                if (i % 3 == 0 && i % 5 == 0)
                    sum += i;
                else if (i % 3 == 0)
                    sum += i;
                else if (i % 5 == 0)
                    sum += i;
            }
            return sum;
        }
        else
            return -1;
    };
    return Challenge;
}());
console.log("Your input number = " + value);
console.log("Your answer:" + Challenge.solution(converToInteger)); //remake
console.log("---------------the third task---------------");
var nums = [1, 2, 3, 4, 5, 6, 7];
var a;
var k = 3;
function rotateArray(array, value) {
    if (array.length < value)
        value = value % array.length;
    if (value < 0)
        value = Math.abs(value);
    // a = copyArray(array);
    // array.reverse();
    // for(let i = k; i < numbers.length - k; i++){
    //     array[i] = a[i - k];
    // }
    // return array;
    return array.slice(-value).concat(array.slice(0, -value));
}
function copyArray(array) {
    return array.slice();
}
console.log(rotateArray(nums, k));
console.log("---------------the fourth task---------------");
var nums1 = [1, 3];
var nums2 = [2];
var nums3 = [1, 2];
var nums4 = [3, 4];
function findMedian(firstArray, secondArray) {
    var numsx = firstArray.concat(secondArray).sort(function (a, b) { return a - b; });
    var lenghtOfNumsx = numsx.length;
    if (numsx.length % 2 == 0) {
        return (numsx[Math.floor((lenghtOfNumsx - 1) / 2)] + numsx[Math.floor(lenghtOfNumsx / 2)]) / 2;
    }
    else {
        return numsx[Math.floor(lenghtOfNumsx / 2)];
    }
}
console.log(findMedian(nums1, nums2));
console.log(findMedian(nums3, nums4));
