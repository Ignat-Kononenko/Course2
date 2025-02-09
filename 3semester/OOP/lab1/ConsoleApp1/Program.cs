using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.Unicode;
            Console.OutputEncoding = Encoding.Unicode; //  для кириллицы 
            // Основные типы int | float | char | bool
            // Целочисленные типы
            byte b; //255
            sbyte sb ; // -128 | 127
            short s ; // -32768 | 32767
            ushort us; // MinValue | MaxValue
            int i, iFirstNum, iSecondNum;
            uint ui;
            long l;
            ulong ul=4;
            // Числа с плавающей точкой 
            float f, sum;
            double d;
            //  Символьный тип
            char c;
            // Строковый тип
            string str;
            // логический тип 
            bool bl;

            Console.Write("Введите byte: ");
            b = Convert.ToByte(Console.ReadLine());
            Console.WriteLine($"byte =  {b}");

            Console.Write("Введите sbyte: ");
            sb = Convert.ToSByte(Console.ReadLine());
            Console.WriteLine($"sbyte =  {sb}");

            Console.Write("Введите string: ");
            str = Console.ReadLine();
            Console.WriteLine($"str =  {str}");

            f = 15.44f;
            i = (int)f; // Явное преобразование 
            Console.WriteLine($"i =  {i}");

            l = i; // Неявное преобразование
            Console.WriteLine($"l =  {l}");

            sum = f + l;
            Console.WriteLine($"sum = {sum}");

            d = (double)sum - (double)ul;
            Console.WriteLine($"d = {d}");

            iFirstNum = 123;
            object o = iFirstNum; // запаковка значимых(не ссылочных)
            iSecondNum = (int)o; // распаковка
            Console.WriteLine($"iSecondNum = {iSecondNum}");

            var volumeOfCube = 10; //неявно типизированной переменной
            var userName = "Pasha";
            Console.WriteLine($"volumeOfCube = {volumeOfCube}");
            Console.WriteLine($"userName = {userName}");
            
            int? x = null; // Nullable
            int y = x ?? 3; //  ?? - null-объединение
            Console.WriteLine($"y value: {y}");
            int? nullableInt = null;
            nullableInt = 10; // Присвоение значения
            Console.WriteLine($"nullableInt has value: {nullableInt.HasValue}"); // Проверка наличия значения
            Console.WriteLine($"nullableInt value: {nullableInt.Value}");

            var count = 10;
            /*count = "ten"; не удается неявно преобразовать тип string в int */

            string regularString = "Line 1\nLine 2";
            string verbatimString = @"Line 1 
Line 2";
            /*            string rawString = """
                            Line 1
                            Line 2
                            """;*/
            Console.WriteLine($"regularString = {regularString}"); //Обычные строковые литералы
            Console.WriteLine($"verbatimString ={verbatimString} "); //Вербатим строковые литералы

            string nameOfFirstMap = "rust";
            string nameOfSecondMap = "sandstone";
            string nameOfThirdMap = "province";
            string concatenation = nameOfFirstMap +""+ nameOfSecondMap + "" + nameOfThirdMap; //сцепление
            string copiedString = string.Copy(nameOfSecondMap); //  копирование подстроки
            string subString = nameOfThirdMap.Substring(1,4); //выделение подстроки
            string[] splitString = nameOfThirdMap.Split(' '); // разделение строки на слова
            string insertString = nameOfFirstMap.Insert(2, "rer"); // вставка подстроки
            string removedSubString = nameOfThirdMap.Remove(2, 4); //удаление заданной подстроки
            string interpolatedString = $"{nameOfFirstMap}, {nameOfSecondMap} and {nameOfThirdMap} are maps of standoff2"; // интерполирование
            Console.WriteLine($"concatenation = {concatenation}");
            Console.WriteLine($"copiedString  = {copiedString}");
            Console.WriteLine($"subString  = {subString}");
            /*   Console.WriteLine($"splitString  = {splitString}");*/
            Console.Write("splitString = ");
            foreach (string words in splitString)
            {
                Console.WriteLine(words);
            }
            Console.WriteLine($"insertString  = {insertString}");
            Console.WriteLine($"removedSubString   = {removedSubString}");
            Console.WriteLine($"interpolatedString   = {interpolatedString}");

            string emptyString = "";
            string nullString = null;
            string concatenatedWithEmpty = "Hello" + emptyString;
            Console.WriteLine($"Is emptyString null or empty? {string.IsNullOrEmpty(emptyString)}");
            Console.WriteLine($"Is nullString null or empty? {string.IsNullOrEmpty(nullString)}");
            Console.WriteLine($"Length of emptyString: {emptyString.Length}"); // 0 занимает место в памяти и инициализирована
            Console.WriteLine($"concatenatedWithEmpty =  {concatenatedWithEmpty}"); 
/*            Console.WriteLine($"concatenatedWithEmpty =  {nullString.Length}"); ошибка*/

            StringBuilder sbv = new StringBuilder("Hello, World!");
            sbv.Remove(5, 7); // начало, длина
            sbv.Insert(0, "start: ");
            sbv.Append(" :end");
            Console.WriteLine($"sbv = {sbv}");

            int[,] matrix = { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };
            Console.WriteLine($"matrix: ");
            for (int k = 0; k < matrix.GetLength(0); k++)
            {
                for(int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[k,j] + "\t");
                }
                Console.WriteLine();
            }

            string[] stringArray = { "apple", "banana", "cherry", "date", "elephone" };
            Console.WriteLine($"Содержимое stringArray:");
            foreach (string w in stringArray)
            {
                Console.WriteLine(w);
            }
            Console.WriteLine($"длмна массива = {stringArray.Length}");
            Console.WriteLine("введите позицию элемента для изменения (0-4)");
            int position = int.Parse( Console.ReadLine() ); // Console.ReadLine() считывает строку, введенную пользователем в консоль, и возвращает ее в виде строки /int.Parse() принимает строку (string) и пытается преобразовать ее в целое число 
            Console.WriteLine($"введите новое значение");
            string newValue = Console.ReadLine();
            if(position >= 0 && position < stringArray.Length)
            {
                stringArray[position] = newValue;
            }
            else
            {
                Console.WriteLine("неверная позиция");
            }
            Console.WriteLine("новое значение массива:");
            foreach(string item in stringArray)
            {
                Console.WriteLine(item);
            }

            int[][] jaggedArray = new int[3][];//ступенчатый массив
            jaggedArray[0] = new int[2];
            jaggedArray[1] = new int[3];
            jaggedArray[2] = new int[4];
            for(int k = 0; k<jaggedArray.Length; k++)
            {
                for(int j = 0; j < jaggedArray[k].Length; j++)
                {
                    Console.Write($"Введите значение для jaggedArray[{k}][{j}]: ");
                    jaggedArray[k][j] = int.Parse(Console.ReadLine());
                }
            }
            Console.WriteLine("\nСодержимое ступенчатого массива:");
            for (int k = 0; k < jaggedArray.Length; k++)
            {
                for (int j = 0; j < jaggedArray[k].Length; j++)
                {
                    Console.Write(jaggedArray[k][j] + "\t");
                }
                Console.WriteLine();
            }

            var stringArr = new[] {"apple", "banana", "chery" };//неявно типизированные переменные 
            var message = "Hello!";
            Console.WriteLine("содержимое массива");
            foreach(var it in stringArr) 
            {
                Console.WriteLine(it); 
            }
            Console.WriteLine($"\nСообщение: {message}");

            var myTuple = (42, "Hello", 'A', "World", 123456789UL);//кортеж из 5 элементов
            Console.WriteLine($"Item1: {myTuple.Item1}");
            Console.WriteLine($"Item2: {myTuple.Item2}");
            Console.WriteLine($"Item3: {myTuple.Item3}");
            Console.WriteLine($"Item4: {myTuple.Item4}");
            Console.WriteLine($"Item5: {myTuple.Item5}");
            (int number, string greeting, char letter, string word, ulong bigNumber) = myTuple;
            Console.WriteLine($"number: {number}, greeting: {greeting}, letter: {letter}, word: {word}, bigNumber: {bigNumber}");
            var (num, greet, let, wrd, bigNum) = myTuple;
            Console.WriteLine($"num: {num}, greet: {greet}, let: {let}, wrd: {wrd}, bigNum: {bigNum}");
            var (_, _, charLetter, _, ulongNumber) = myTuple;
            Console.WriteLine($"charLetter: {charLetter}, ulongNumber: {ulongNumber}");
            //Сравните два кортежа
            var tuple1 = (42, "Hello", 'A', "World", 123456789UL);
            var tuple2 = (42, "Hello", 'A', "World", 123456789UL);
            var tuple3 = (43, "Hi", 'B', "Universe", 987654321UL);
            bool areEqual1 = tuple1 == tuple2; // True
            bool areEqual2 = tuple1 == tuple3; // False
            Console.WriteLine($"tuple1 == tuple2: {areEqual1}");
            Console.WriteLine($"tuple1 == tuple3: {areEqual2}");

            int[] numbers = { 1, 2, 3, 4, 5 } ;
            string text = "Hello";
            var result = ProcessArrayAndString(numbers, text);
            Console.WriteLine($"Max: {result.max}, Min: {result.min}, Sum: {result.firstSum}, First Letter: {result.firstLetter}");

            (int max, int min, int firstSum, char firstLetter) ProcessArrayAndString(int[] arr, string firstStr)
            {
                int max = int.MinValue;
                int min = int.MaxValue;
                int firstSum = 0;

                foreach (var firstNum in arr)
                {
                    if (firstNum > max) max = firstNum;
                    if (firstNum < min) min = firstNum;
                    firstSum += firstNum;
                }

                char firstLetter = firstStr.Length > 0 ? firstStr[0] : '\0';

                return (max, min, firstSum, firstLetter);
            }

            // Определение и вызов функции с блоком checked(Если происходит переполнение, выбрасывается исключение OverflowException)
            void CheckedFunction()
            {
                try
                {
                    checked
                    {
                        int maxInt = int.MaxValue;
                        Console.WriteLine($"Checked: {maxInt + 1}");
                    }
                }
                catch (OverflowException e)
                {
                    Console.WriteLine($"Checked: OverflowException - {e.Message}");
                }
            }

            // Определение и вызов функции с блоком unchecked(В случае переполнения результат просто обрезается до допустимого диапазона типа данных)
            void UncheckedFunction()
            {
                unchecked
                {
                    int maxInt = int.MaxValue;
                    Console.WriteLine($"Unchecked: {maxInt + 1}");
                }
            }

            // Вызов функций
            CheckedFunction();
            UncheckedFunction();
        }
    
    }
}
