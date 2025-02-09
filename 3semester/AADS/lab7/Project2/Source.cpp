#include<iostream>
#include<algorithm>

using namespace std;

int main() {

	setlocale(LC_ALL, "rus");

	int N;

	cout << "Введите количество чисел: ";
	cin >> N;
	if (N <= 0) {
		cout << "Error" << endl;
		return 0;
	}

	int* arr{ new int[N] };
	int* value{ new int[N] };
	int* prev{ new int[N] };
	int* str{ new int[N] };
	
	for (int i = 0; i < N; i++) {
		cout << "Введите " << i + 1 << " элемент: ";
		cin >> value[i];
		arr[i] = 1;
	}
	
	int maxLen = 1;

	for (int i = 1; i < N; i++) {
		for (int j = 0; j < i; j++) {
			if (value[j] < value[i]) {
				/*prev[i] = j;*/
				arr[i] = max(arr[i], arr[j] + 1);		
			}
		}
		maxLen = max(maxLen, arr[i]);
	}

	int maxValue = arr[0];

	for (int i = 1; i < N; i++) {
			if (arr[i] >= maxValue)
				maxValue = arr[i];
	}

	int n = 0;
	for (int i = N - 1; i >= 0; i--) {
		
		if (arr[i] == maxValue) {
			prev[n] = arr[i];
			/*cout <<"value - " << prev[i] << endl;*/
			maxValue--;
			n++;
		}
	}

	cout << endl;
	for (int i = 0; i < N; i++) {
		cout << arr[i] << '\t';
	}

	//cout << endl;
	//for (int i = 0; i < n; i++) {
	//	cout << prev[i] << '\t';
	//}

	int m = 0;
	
	for (int i = N - 1; i >= 0; i--) {
		
		/*cout << prev[m] <<endl;*/
		
		if (arr[i] == prev[m]) {
			str[m] = value[i];
			
			m++;

		}
	}
	cout << endl<<"Values:" << endl;
	for (int i = m - 1; i >= 0; i--) {
		cout << str[i] << '\t';
	}

	cout << endl<<"Максимальная длина: "<< maxLen;

	delete[] str;
	delete[] prev;
	delete[] value;
	delete[] arr;

	return 0;
}