var __extends = (this && this.__extends) || (function () {
    var extendStatics = function (d, b) {
        extendStatics = Object.setPrototypeOf ||
            ({ __proto__: [] } instanceof Array && function (d, b) { d.__proto__ = b; }) ||
            function (d, b) { for (var p in b) if (Object.prototype.hasOwnProperty.call(b, p)) d[p] = b[p]; };
        return extendStatics(d, b);
    };
    return function (d, b) {
        if (typeof b !== "function" && b !== null)
            throw new TypeError("Class extends value " + String(b) + " is not a constructor or null");
        extendStatics(d, b);
        function __() { this.constructor = d; }
        d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
    };
})();
var __spreadArray = (this && this.__spreadArray) || function (to, from, pack) {
    if (pack || arguments.length === 2) for (var i = 0, l = from.length, ar; i < l; i++) {
        if (ar || !(i in from)) {
            if (!ar) ar = Array.prototype.slice.call(from, 0, i);
            ar[i] = from[i];
        }
    }
    return to.concat(ar || Array.prototype.slice.call(from));
};
console.log("-------------------------------the first task-------------------------------");
var BaseUser = /** @class */ (function () {
    function BaseUser(id, name) {
        this.id = id;
        this.name = name;
    }
    return BaseUser;
}());
var Guest = /** @class */ (function (_super) {
    __extends(Guest, _super);
    function Guest() {
        return _super !== null && _super.apply(this, arguments) || this;
    }
    Guest.prototype.getRole = function () {
        return ["Гость"];
    };
    Guest.prototype.getPermission = function () {
        return ["Просмотр контента"];
    };
    return Guest;
}(BaseUser));
var User = /** @class */ (function (_super) {
    __extends(User, _super);
    function User() {
        return _super !== null && _super.apply(this, arguments) || this;
    }
    User.prototype.getRole = function () {
        return ["Пользователь"];
    };
    User.prototype.getPermission = function () {
        return ["Просмотр контента", "Добавление комментариев"];
    };
    return User;
}(BaseUser));
var Admin = /** @class */ (function (_super) {
    __extends(Admin, _super);
    function Admin() {
        return _super !== null && _super.apply(this, arguments) || this;
    }
    Admin.prototype.getRole = function () {
        return ["Админ"];
    };
    Admin.prototype.getPermission = function () {
        return ["Просмотр контента", "Добавление комментариев", "Удаление комментариев", "Управление пользователями"];
    };
    return Admin;
}(BaseUser));
console.log("Первый пользователь:");
var guest = new Guest(1, "Аноним");
console.log(guest.getPermission());
console.log(guest.getRole());
console.log("Второй пользователь:");
var user = new User(1, "Григорий");
console.log(user.getPermission());
console.log(user.getRole());
console.log("Третий пользователь:");
var admin = new Admin(1, "Мария");
console.log(admin.getPermission());
console.log(admin.getRole());
console.log("-------------------------------the second task-------------------------------");
var MyReport = /** @class */ (function () {
    function MyReport(title, content) {
        this.title = title;
        this.content = content;
    }
    ;
    return MyReport;
}());
var HTMLReport = /** @class */ (function (_super) {
    __extends(HTMLReport, _super);
    function HTMLReport() {
        return _super !== null && _super.apply(this, arguments) || this;
    }
    HTMLReport.prototype.generate = function () {
        return "<h1>".concat(this.title, "</h1><p>").concat(this.content, "</p>");
    };
    return HTMLReport;
}(MyReport));
var JSONReport = /** @class */ (function (_super) {
    __extends(JSONReport, _super);
    function JSONReport() {
        return _super !== null && _super.apply(this, arguments) || this;
    }
    JSONReport.prototype.generate = function () {
        return { title: this.title, content: this.content };
    };
    return JSONReport;
}(MyReport));
var report1 = new HTMLReport("Отчет1", "Содержание отчета");
console.log(report1.generate());
var report2 = new JSONReport("Отчет2", "Содержание отчета");
console.log(report2.generate());
console.log("-------------------------------the third task-------------------------------");
var MYCache = /** @class */ (function () {
    function MYCache() {
        this.cache = new Map();
    }
    MYCache.prototype.add = function (key, value, ttl) {
        var newValue = Date.now() + ttl;
        this.cache.set(key, [value, newValue]);
    };
    MYCache.prototype.get = function (key) {
        var item = this.cache.get(key);
        if (item) {
            var value = item[0], newValue = item[1];
            if (Date.now() < newValue)
                return value;
            else
                this.cache.delete(key);
        }
        return null;
    };
    MYCache.prototype.clearExpired = function () {
        var _this = this;
        var nowNow = Date.now();
        this.cache.forEach(function (value, key) {
            var newValue = value[1];
            if (nowNow >= newValue)
                _this.cache.delete(key);
        });
    };
    return MYCache;
}());
var cache = new MYCache();
cache.add("price", 100, 500);
console.log(cache.get("price"));
setTimeout(function () { return console.log(cache.get("price")); }, 600);
console.log("-------------------------------the fourth task-------------------------------");
var ProductCategory;
(function (ProductCategory) {
    ProductCategory[ProductCategory["Electronics"] = 0] = "Electronics";
    ProductCategory[ProductCategory["Books"] = 1] = "Books";
    ProductCategory[ProductCategory["Clothing"] = 2] = "Clothing";
    ProductCategory[ProductCategory["Other"] = 3] = "Other";
})(ProductCategory || (ProductCategory = {}));
var Product = /** @class */ (function () {
    function Product(name, price, category) {
        this.name = name;
        this.price = price;
        this.category = category;
    }
    ;
    return Product;
}());
function createInstance(cls) {
    var args = [];
    for (var _i = 1; _i < arguments.length; _i++) {
        args[_i - 1] = arguments[_i];
    }
    return new (cls.bind.apply(cls, __spreadArray([void 0], args, false)))();
}
var p = createInstance(Product, "Телефон", 50000, ProductCategory.Electronics);
console.log(p);
console.log(ProductCategory[p.category]);
console.log("-------------------------------the fifth task-------------------------------");
var LogLevel;
(function (LogLevel) {
    LogLevel[LogLevel["INFO"] = 0] = "INFO";
    LogLevel[LogLevel["WARNING"] = 1] = "WARNING";
    LogLevel[LogLevel["ERROR"] = 2] = "ERROR";
})(LogLevel || (LogLevel = {}));
function logEvent(event) {
    var timestamp = event[0], level = event[1], message = event[2];
    var levelStr = LogLevel[level];
    console.log("[".concat(timestamp.toISOString(), "] [").concat(levelStr, "] [").concat(message, "]"));
}
logEvent([new Date(), LogLevel.INFO, "Система запущена"]);
console.log("-------------------------------the sixth task-------------------------------");
var HttpStatus;
(function (HttpStatus) {
    HttpStatus[HttpStatus["OK"] = 200] = "OK";
    HttpStatus[HttpStatus["Bad"] = 400] = "Bad";
    HttpStatus[HttpStatus["Unauthorized"] = 401] = "Unauthorized";
    HttpStatus[HttpStatus["NOT_FOUND"] = 404] = "NOT_FOUND";
    HttpStatus[HttpStatus["ServerError"] = 500] = "ServerError";
})(HttpStatus || (HttpStatus = {}));
function success(data) {
    return [HttpStatus.OK, data];
}
function error(message, status) {
    return [status, null, message];
}
var res1 = success({ user: "Андрей" });
console.log(res1);
var res2 = error("Не найдено", HttpStatus.NOT_FOUND);
console.log(res2);
