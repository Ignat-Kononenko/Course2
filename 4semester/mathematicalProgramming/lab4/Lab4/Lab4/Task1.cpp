#include<iostream>
#include<string>


using namespace std;



string generateString(int length) {

	string result;
	char arrayOfLetters[] = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";

	int sizeOfArrayOfLetters = sizeof(arrayOfLetters) - 1;

	result.resize(length);	// изменяет размер строки result до заданной длины length.

	for (int i = 0; i < length; i++) {
		result[i] = arrayOfLetters[rand() % sizeOfArrayOfLetters];
	}

	return result;
}

int main() {
	setlocale(LC_ALL, "rus");

	srand(time(0));

	string firstResult, secondResult;

	firstResult = generateString(300);
	secondResult = generateString(200);

	cout << "Первый ответ: " << firstResult << endl;
	cout << "Второй ответ: " << secondResult << endl;

	return 0;
}

