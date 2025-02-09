#include<iostream>

#define V 9

using namespace std;

void printSolution(int dist[]) {

    cout << "Вершина \t Дистанция от заданной вершины" << endl;
    char str[9] = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I' };
    for (int i = 0; i < V; i++)
        cout << "До вершины " << str[i] << "\t\t" << dist[i] << endl;
}

int minDistance(int dist[], bool sptSet[]) {
    int min = INT_MAX, minIndex;
    for (int v = 0; v < V; v++) {
        if (!sptSet[v] && dist[v] <= min)
            min = dist[v], minIndex = v;
    }
    return minIndex;
}

void dijkstra(int graph[V][V], int src) {
    int dist[V];                                        // массив для хранения кратчайших расстояний
    bool sptSet[V];                                     // массив для отслеживания вершин, включенных в множество кратчайших путей.

    for (int i = 0; i < V; i++) {
        dist[i] = INT_MAX;
        sptSet[i] = false;
    }
    dist[src] = 0;

    for (int count = 0; count < V - 1; count++) {
        int u = minDistance(dist, sptSet);
        sptSet[u] = true;
        for (int j = 0; j < V; j++) {
            if (!sptSet[j] && graph[u][j] && dist[u] != INT_MAX && dist[u] + graph[u][j] < dist[j])
                dist[j] = dist[u] + graph[u][j];
        }
    }
    printSolution(dist);
}



int main() {

	setlocale(LC_ALL, "rus");

    int dot;
    int graph[V][V] = {
        {0, 7, 10, 0, 0, 0, 0, 0, 0},
        {7, 0, 0, 0, 0, 9, 27, 0, 0},
        {10, 0, 0, 0, 31, 8, 0, 0, 0},
        {0, 0, 0, 0, 32, 0, 0, 17, 21},
        {0, 0, 31, 32, 0, 0, 0, 0, 0},
        {0, 9, 8, 0, 0, 0, 0, 11, 0},
        {0, 27, 0, 0, 0, 0, 0, 0, 15},
        {0, 0, 0, 17, 0, 11, 0, 0, 15},
        {0, 0, 0, 21, 0, 0, 15, 15, 0},
    };

	cout << "Введите точку, где A - 0, B - 1, C - 2, D - 3, E - 4, F - 5, G - 6, H - 7, I - 8 : ";
    cin >> dot;

    if (dot < 0 || dot > 8) {
        cout << "Error";
        return 1;
    }

    dijkstra(graph, dot);


	return 0;
}