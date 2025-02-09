#include<iostream>
#include<queue>
#include<string>
#include<stack>
#include<vector>
#include<array>

using namespace std;

int const N = 10;
bool* visited = new bool[N];

//������� ��������� �����
int graph[N][N] =
{
	{0, 1, 0, 0, 1, 0, 0, 0, 0, 0},
	{1, 0, 0, 0, 0, 0, 1, 1, 0, 0},
	{0, 0, 0, 0, 0, 0, 0, 1, 0, 0},
	{0, 0, 0, 0, 0, 1, 0, 0, 1, 0},
	{1, 0, 0, 0, 0, 1, 0, 0, 0, 0},
	{0, 0, 0, 1, 1, 0, 0, 0, 1, 0},
	{0, 1, 0, 0, 0, 0, 0, 1, 0, 0},
	{0, 1, 1, 0, 0, 0, 1, 0, 0, 0},
	{0, 0, 0, 1, 0, 1, 0, 0, 0, 1},
	{0, 0, 0, 0, 0, 0, 0, 0, 1, 0}
};


void BFS(int start) {
	queue <int> q;										// ������� ��� �������� ������� ������
	bool visited[N];
	bool addToQueye[N];

	for (int i = 0; i < N; i++) {
		visited[i] = false;
		addToQueye[i] = false;
	}

	visited[start] = addToQueye[start] = 1;				//����������� ������ �������
	q.push(start);

	while (!q.empty()) {

		int viewCell;									// ����� ���������� �������

		viewCell = q.front();							//��������� � ������� �������� �������
		cout << viewCell + 1 << " ";

		visited[viewCell] = true; 

		q.pop();

		for (int i = 0; i < N; i++) {
			if (!addToQueye[i] && graph[viewCell][i]) {	//���� ������� �� � ������� � ������ � �������
				q.push(i);
				addToQueye[i] = true;
			}
 		}
	}
	
}

void DFS(int start) {									// ���� ��� �������� ������� ������
	stack<int> s;
	bool visited[N];
	bool addToStack[N];
	int viewCell;										// ����� ���������� �������

	for (int i = 0; i < N; i++) {
		visited[i] = addToStack[i] = false;
	}

	visited[start] = addToStack[start] = true;			//����������� ������ �������

	s.push(start);										// ���������� ��������� ������� � �������
	while (!s.empty()) {

		viewCell = s.top();								//��������� � ������� �������� �������
		cout << viewCell + 1 << " ";
		visited[viewCell] = true;
		s.pop();
		for (int i = 0; i < N; i++) {
			if (!addToStack[i] && graph[viewCell][i]) {
				addToStack[i] = true;
				s.push(i);
			}
		}
		
	}
}

struct Edges {
	int start;
	int finish;
};

int main() {

	setlocale(LC_ALL, "rus");

	int start /*= 1*/;

	cout << "������� ����� �������: " << endl;
	cin >> start;
	if (start < 1 || start > 10) {
		cout << "�����������" << endl;
		return 1;
	}


	cout << "������ ���������:" << endl;
	vector<Edges> edges =
	{
		{1, 2}, {2, 1}, {1, 5}, {5, 1},
		{2, 7}, {7, 2}, {2, 8}, {8, 2},
		{7, 8}, {8, 7}, {8, 3}, {3, 8},
		{5, 6}, {6, 5}, {4, 6}, {6, 4},
		{4, 9}, {9, 4}, {6, 9}, {9, 6},
		{9, 10}, {10, 9}
	};

	vector<vector<int>> adjList;

	int n = 11;
	adjList.resize(n);

	for (auto& edge: edges) {
		adjList[edge.start].push_back(edge.finish);
	}

	for (int i = 1; i < n; i++) {
		cout << i << "--> { ";
			for (int v : adjList[i]) {
				cout << v << " ";
			}
			cout << " }" << endl;
	}


	/*cout << "������ ���������: " << endl;
	vector<Edge> edges =
	{
		{1, 2}, {2, 1}, {1, 5}, {5, 1},
		{2, 7}, {7, 2}, {2, 8}, {8, 2},
		{7, 8}, {8, 7}, {8, 3}, {3, 8},
		{5, 6}, {6, 5}, {4, 6}, {6, 4},
		{4, 9}, {9, 4}, {6, 9}, {9, 6},
		{9, 10}, {10, 9}
	};
	int n = 11;
	vector<vector<int>> adjList;
	adjList.resize(n);
	for (auto& edge : edges)
	{
		adjList[edge.start].push_back(edge.finish);
	}
	for (int i = 1; i < n; i++)
	{
		cout << i << "--> {";
		for (int v : adjList[i]) {
			cout << v << " ";
		}
		cout << "}" << endl;
	}
	cout << endl;*/
	cout << "������ �����: " << endl;

	for (int i = 1; i < n; i++) {
		for (int v : adjList[i]) {
			cout << "{ " << i << ", " << v << " }";
		}
		cout << endl;
	}

	cout << "������� ��������� �����: " << endl;
	for (int i = 0; i < N; i++) {
		visited[i] = false;
		for (int j = 0; j < N; j++) {
			cout << " " << graph[i][j];
		}
		cout << endl;
	}
	cout << "��������� �������: " << start << endl;

	cout << "����� � ������:" << endl;
	BFS(start - 1);
	cout << endl;
	cout << "����� � �����:" << endl;
	DFS(start - 1);

	//cout << "������ �-�������: " << endl;
	//int v, e; // v - �������, e - �����
	//cin >> v >> e;
	//cout << "O(|V| + |E|) = " << abs(v) + abs(e) << endl;

	return 0;
}