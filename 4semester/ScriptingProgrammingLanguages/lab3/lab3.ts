console.log("-------------------------------the first task-------------------------------");

abstract class BaseUser{
    public id:number;
    public name:string;
    constructor(id:number, name:string){
        this.id = id;
        this.name = name;
    }
    abstract getRole():string[];
    abstract getPermission():string[];
}

class Guest extends BaseUser{
    getRole():string[]{
        return ["Гость"];
    }
    getPermission(): string[] {
        return ["Просмотр контента"];
    }
}

class User extends BaseUser{
    getRole():string[]{
        return ["Пользователь"];
    }
    getPermission(): string[] {
        return ["Просмотр контента", "Добавление комментариев"];
    }
}

class Admin extends BaseUser{
    getRole():string[]{
        return ["Админ"];
    }
    getPermission(): string[] {
        return ["Просмотр контента", "Добавление комментариев", "Удаление комментариев", "Управление пользователями"];
    }
}

console.log("Первый пользователь:")
const guest = new Guest(1,"Аноним");
console.log(guest.getPermission());
console.log(guest.getRole());

console.log("Второй пользователь:")
const user = new User(1,"Григорий");
console.log(user.getPermission());
console.log(user.getRole());

console.log("Третий пользователь:")
const admin = new Admin(1,"Мария");
console.log(admin.getPermission());
console.log(admin.getRole());

console.log("-------------------------------the second task-------------------------------");

// interface IReport{
//     title:string;
//     content:string;
//     generate():string;
// }

// class MyReport implements IReport{
//     constructor(public title:string,public content:string){};
//     generate(): string {
//         return "";
//     }
// }

// class HTMLReport extends MyReport{
//     generate(): string {
//         return `<h1>${this.title}</h1><p>${this.content}</p>`;
//     }
// }

// class JSONReport extends MyReport{
//     generate(): string {
//         return "{title:\"" +this.title + "\", content:\"" + this.content + "\"}";
//     }
// }

interface IReport<T> {
    title:string;
    content:string;
    generate():T;
}

abstract class MyReport<T> implements IReport<T>{
    constructor(public title:string,public content:string){};
    abstract generate(): T;
}

class HTMLReport extends MyReport<string>{
    generate(): string {
        return `<h1>${this.title}</h1><p>${this.content}</p>`;
    }
}

class JSONReport extends MyReport<object>{
    generate(): object {
        return {title: this.title, content: this.content};
        
    }
}

const report1 = new HTMLReport("Отчет1", "Содержание отчета");
console.log(report1.generate());

const report2 = new JSONReport("Отчет2", "Содержание отчета");
console.log(report2.generate());

console.log("-------------------------------the third task-------------------------------");

interface ICache<T>{
    add(key:string, value: T, ttl:number):void;
    get(key:string):T|null;
    clearExpired():void;
}

class MYCache<T> implements ICache<T>{

    key:string;
    value: T;
    ttl:number;
    cache: Map<string,CacheEntry<T>> = new Map();

    add(key:string, value: T, ttl:number):void{

        const newValue = Date.now() + ttl;
        this.cache.set(key, [value, newValue]);
    }
    get(key:string): T|null{

        const item = this.cache.get(key);
        if(item){
            const [value, newValue] = item;
            if(Date.now() < newValue)
                return value;
            else
                this.cache.delete(key);
        }
        return null;
    }
    clearExpired():void {
        const nowNow = Date.now();
        
        this.cache.forEach((value, key) => {
            const [,newValue] = value;
            if(nowNow >= newValue)
                this.cache.delete(key);

            }
        )
    }

}

type CacheEntry<T> = [T, number];


const cache = new MYCache<number>();
cache.add("price", 100, 500);
console.log(cache.get("price"));
setTimeout(()=>console.log(cache.get("price")), 600);

console.log("-------------------------------the fourth task-------------------------------");

enum ProductCategory{
    Electronics,
    Books,
    Clothing,
    Other
}

class Product{
    constructor(public name:string, public price: number, public category: ProductCategory){};
}

function createInstance<T>(cls: new (...args: any[])=> T, ...args: any[]):T{
    return new cls(...args);
}

const p = createInstance(Product, "Телефон", 50000, ProductCategory.Electronics);
console.log(p);
console.log(ProductCategory[p.category]);

console.log("-------------------------------the fifth task-------------------------------");

type LogEntry = [Date, LogLevel, string];

enum LogLevel{
    INFO,
    WARNING,
    ERROR
}

function logEvent(event: LogEntry):void{
    const [timestamp, level, message] = event;
    const levelStr = LogLevel[level];
    console.log(`[${timestamp.toISOString()}] [${levelStr}] [${message}]`);
}

logEvent([new Date(), LogLevel.INFO, "Система запущена"]);

console.log("-------------------------------the sixth task-------------------------------");

enum HttpStatus{
    OK = 200,
    Bad = 400,
    Unauthorized = 401,
    NOT_FOUND = 404,
    ServerError = 500
}

type ApiResponse<T> = [status: HttpStatus, data: T | null, error?: string];

function success<T>(data:T){
    return [HttpStatus.OK, data]
}

function error(message:string, status: HttpStatus): ApiResponse<null>{
    return [status, null, message];
}

const res1 = success({user: "Андрей"});
console.log(res1);

const res2 = error("Не найдено", HttpStatus.NOT_FOUND);
console.log(res2);