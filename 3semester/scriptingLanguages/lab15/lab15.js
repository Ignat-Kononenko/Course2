const fam = document.getElementById("fam");
const nam = document.getElementById("name");
const email = document.getElementById("emai");
const phone = document.getElementById("phone");
const info = document.getElementById("dat");
const country = document.getElementById("from");
const university = document.getElementById("BSTU");
const course = document.getElementById("course");
const regex = /^[a-zA-Zа-яА-Я]+$/;
const formOfEmail =/^[^\s@]+@[a-zA-Z]{2,5}\.[a-zA-Z]{2,3}$/
const formOfPhone = /^\(0[1-9]{2}\)[1-9]{3}-[1-9]{2}-[1-9]{2}$/;

document.querySelector(".userform").addEventListener("submit", function(event){
    
    let valueName = 0, valueEmail = 0, valuePhone = 0 ;
    fam.classList.remove('invalid');
    nam.classList.remove('invalid');
    email.classList.remove('invalid');
    phone.classList.remove('invalid');
    info.classList.remove('invalid');
    errorFam.innerHTML="";
    errorName.innerHTML="";
    errorEmail.innerHTML="";
    errorPhone.innerHTML="";
    errorInfo.innerHTML="";
    if(fam.value === "" || fam.value.trim().length == 0){
        fam.classList.add('invalid');
        errorFam.innerHTML = 'Поле не должно быть пустым!';
        event.preventDefault();
    }
    if(nam.value ==="" || nam.value.trim().length == 0){
        nam.classList.add('invalid');
        errorName.innerHTML = 'Поле не должно быть пустым!';
        event.preventDefault();
        valueName++;
        
        
    }
    
    if(valueName == 0){
        if(!regex.test(nam.value)){
            nam.classList.add('invalid');
            errorName.innerHTML = 'Недопустимый формат';
            event.preventDefault();
        }
    }
    if(email.value ==="" || email.value.trim().length == 0){
        email.classList.add('invalid');
        errorEmail.innerHTML = 'Поле не должно быть пустым!';
        event.preventDefault();
        valueEmail++;
    }
    if(valueEmail == 0){
        if(!formOfEmail.test(email.value)){
            email.classList.add('invalid');
            errorEmail.innerHTML = 'Недопустимый формат';
            event.preventDefault();
        }
    }
    
    if(phone.value ==="" || phone.value.trim().length == 0){
        phone.classList.add('invalid');
        errorPhone.innerHTML = 'Поле не должно быть пустым!';
        event.preventDefault();
        valuePhone++;
    }
    if(valuePhone == 0){
        if(!formOfPhone.test(phone.value)){
            phone.classList.add('invalid');
            errorPhone.innerHTML = 'Недопустимый формат';
            event.preventDefault();
        }
    }
    
    if(info.value ==="" || info.value.trim().length == 0){
        info.classList.add('invalid');
        errorInfo.innerHTML = 'Поле не должно быть пустым!';
        event.preventDefault();
    }
    if(info.value.length > 250){
        info.classList.add('invalid');
        errorInfo.innerHTML = 'Более 250 символов';
        event.preventDefault();
    }
    if(country.value != "Минск" && course.value !== "3" && university.checked !== true){
        
        if(!confirm("Вы уверены?"))
            event.preventDefault();
    }
});

fam.onblur = function(){
    if(fam.value.length > 250){
        fam.classList.add('invalid');
        errorFam.innerHTML = 'Длина превышена (больше 20)';
    }
};

fam.onfocus = function(){
    if(this.classList.contains('invalid')){
        this.classList.remove('invalid');
        errorFam.innerHTML="";
    }
};