
#include<iostream>s
using namespace std;


void main() {
	setlocale(LC_ALL, "RUS");
	int N;
	cout << "������� ������ ������������������: "; cin >> N;
	int* arr = new int[N];
	int* buff = new int[N];
	int* path = new int[N];

	for (int i = 0; i < N; i++)
	{
		cout << "������� " << i + 1 << " ������� ������������������: "; cin >> arr[i];
		buff[i] = 1;
		path[i] = -1;
	}
	cout << endl;

	cout << "��������� ������������������: ";
	for (int i = 0; i < N; i++)
	{
		cout << arr[i] << " ";
	}
	cout << endl;

	for (int j = 1; j < N; j++) {
		for (int k = 0; k < j; k++) {
			if (arr[j] > arr[k] && (arr[j] - arr[k] == 1 || arr[j] - arr[k] == 2 || arr[j] - arr[k] == 3 || arr[j] - arr[k] == 4 || arr[j] - arr[k] == 5 || arr[j] - arr[k] == 6 || arr[j] - arr[k] == 7 || arr[j] - arr[k] == 8 || arr[j] - arr[k] == 9 || arr[j] - arr[k] == 10 || arr[j] - arr[k] == 11 || arr[j] - arr[k] == 12 || arr[j] - arr[k] == 13 || arr[j] - arr[k] == 14 || arr[j] - arr[k] == 15) || arr[j] > arr[k]) {
				if (buff[j] <= buff[k]) {
					buff[j] = buff[k] + 1;
					path[j] = k;
				}
			}
		}
	}

	// ����� ������������ �����
	int max = 0;
	int check = 0;
	for (int i = 0; i < N; i++)
	{
		if (buff[i] > max)
		{
			check = i;
			max = buff[i];
		}
	}
	cout << "����� ������������ ���������������������: " << max << endl;


	cout << "������ ���� ���������� ������������ ����������������������: ";
	for (int i = 0; i < N; i++)
	{
		cout << buff[i] << " ";
	}
	cout << endl; 

	cout << "���� �� ������� � �������: ";
	for (int i = 0; i < N; i++)
	{
		cout << path[i] << " ";
	}
	cout << endl;


	int out[100];
	for (int i = max; i >= 0; i--)
	{
		out[i] = arr[check];
		check = path[check];
	}

	cout << "������������ ������������ ���������������������: ";
	for (int i = 1; i < max + 1; i++)
	{
		cout << out[i] << " ";
	}
	delete[] arr;
	delete[] buff;
	delete[] path;
}